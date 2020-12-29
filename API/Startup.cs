using System.Text;
using API.Middleware;
using Application.Workdays;
using Application.Interfaces;
using Domain;
using FluentValidation.AspNetCore;
using Infrastructure.Security;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Persistence;
using AutoMapper;
using Application.Users.Mappers;
using Application.Workdays.Mappers;
using Application.Clients.Mappers;
using Application.Workplaces.Mappers;
using Application.Workdays.Commands;
using Application.WorkdayMaterials.Mappers;
using Application.Notifications.Mappers;

namespace API
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddDbContext<DataContext>(opt =>
      {
        opt.UseLazyLoadingProxies();
        opt.UseSqlite(Configuration.GetConnectionString("DefaultConnection"));
      });

      services.AddCors(opt =>
      {
        opt.AddPolicy("CorsPolicy", policy =>
              {
                policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000");
              });
      });
      services.AddMediatR(typeof(List.Handler).Assembly);
      services.AddSingleton(provider => new MapperConfiguration(cfg =>
      {
        cfg.AddProfile(new LoginRegisterProfile(provider.GetService<IJwtGenerator>()));
        cfg.AddProfile(new UserProfile());
        cfg.AddProfile(new WorkdayProfile());
        cfg.AddProfile(new ClientProfile());
        cfg.AddProfile(new WorkplaceProfile());
        cfg.AddProfile(new WorkdayMaterialProfile());
        cfg.AddProfile(new NotificationProfile());
      }).CreateMapper());

      services.AddControllers(opt =>
      {
        var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
        opt.Filters.Add(new AuthorizeFilter(policy));
      })
        .AddFluentValidation(cfg =>
        {
          cfg.RegisterValidatorsFromAssemblyContaining<Create>();
        });

      var builder = services.AddIdentityCore<AppUser>();
      var identityBuilder = new IdentityBuilder(builder.UserType, builder.Services);
      identityBuilder.AddEntityFrameworkStores<DataContext>();
      identityBuilder.AddSignInManager<SignInManager<AppUser>>();

      var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["TokenKey"]));
      services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(opt =>
        {
          opt.TokenValidationParameters = new TokenValidationParameters
          {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = key,
            ValidateAudience = false,
            ValidateIssuer = false
          };
        });

      services.AddSingleton<IJwtGenerator, JwtGenerator>();
      services.AddScoped<IUserAccessor, UserAccessor>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      app.UseMiddleware<ErrorHandlingMiddleware>();
      if (env.IsDevelopment())
      {
        //app.UseDeveloperExceptionPage();
      }

      //app.UseHttpsRedirection();

      app.UseRouting();

      app.UseAuthentication();
      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
