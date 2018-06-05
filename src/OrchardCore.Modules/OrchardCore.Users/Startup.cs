using System;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using OrchardCore.Data.Migration;
using OrchardCore.DisplayManagement;
using OrchardCore.DisplayManagement.Handlers;
using OrchardCore.Environment.Commands;
using OrchardCore.Environment.Navigation;
using OrchardCore.Environment.Shell;
using OrchardCore.Liquid;
using OrchardCore.Modules;
using OrchardCore.Security;
using OrchardCore.Security.Permissions;
using OrchardCore.Settings;
using OrchardCore.Setup.Events;
using OrchardCore.Users.Commands;
using OrchardCore.Users.Drivers;
using OrchardCore.Users.Indexes;
using OrchardCore.Users.Models;
using OrchardCore.Users.Services;
using YesSql.Indexes;

namespace OrchardCore.Users
{
    public class Startup : StartupBase
    {
        private const string LoginPath = "Login";
        private const string ChangePasswordPath = "ChangePassword";
        private const string ForgotPasswordPath = "ForgotPassword";

        private readonly string _tenantName;
        private readonly string _tenantPrefix;

        public Startup(ShellSettings shellSettings)
        {
            _tenantName = shellSettings.Name;
            _tenantPrefix = "/" + shellSettings.RequestUrlPrefix;
        }

        public override void Configure(IApplicationBuilder builder, IRouteBuilder routes, IServiceProvider serviceProvider)
        {
            routes.MapAreaRoute(
                name: "Login",
                areaName: "OrchardCore.Users",
                template: LoginPath,
                defaults: new { controller = "Account", action = "Login" }
            );
            routes.MapAreaRoute(
                name: "ChangePassword",
                areaName: "OrchardCore.Users",
                template: ChangePasswordPath,
                defaults: new { controller = "Account", action = "ChangePassword" }
            );
            routes.MapAreaRoute(
                name: "ForgotPassword",
                areaName: "OrchardCore.Users",
                template: ForgotPasswordPath,
                defaults: new { controller = "Account", action = "ForgotPassword" }
            );
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddSecurity();

            // Adds the default token providers used to generate tokens for reset passwords, change email
            // and change telephone number operations, and for two factor authentication token generation.
            new IdentityBuilder(typeof(IUser), typeof(IRole), services).AddDefaultTokenProviders();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = IdentityConstants.ApplicationScheme;
                options.DefaultChallengeScheme = IdentityConstants.ApplicationScheme;
                options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
            })
            .AddCookie(IdentityConstants.ApplicationScheme, options =>
            {
                options.LoginPath = new PathString("/Account/Login");
                options.Events = new CookieAuthenticationEvents
                {
                    OnValidatePrincipal = async context =>
                    {
                        await SecurityStampValidator.ValidatePrincipalAsync(context);
                    }
                };
            })
            .AddCookie(IdentityConstants.ExternalScheme, options =>
            {
                options.Cookie.Name = IdentityConstants.ExternalScheme;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
            })
            .AddCookie(IdentityConstants.TwoFactorRememberMeScheme, options =>
            {
                options.Cookie.Name = IdentityConstants.TwoFactorRememberMeScheme;
            })
            .AddCookie(IdentityConstants.TwoFactorUserIdScheme, IdentityConstants.TwoFactorUserIdScheme, options =>
            {
                options.Cookie.Name = IdentityConstants.TwoFactorUserIdScheme;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
            });

            // Identity services
            services.TryAddScoped<IUserValidator<IUser>, UserValidator<IUser>>();
            services.TryAddScoped<IPasswordValidator<IUser>, PasswordValidator<IUser>>();
            services.TryAddScoped<IPasswordHasher<IUser>, PasswordHasher<IUser>>();
            services.TryAddSingleton<ILookupNormalizer, UpperInvariantLookupNormalizer>();

            // No interface for the error describer so we can add errors without rev'ing the interface
            services.TryAddScoped<IdentityErrorDescriber>();
            services.TryAddScoped<ISecurityStampValidator, SecurityStampValidator<IUser>>();
            services.TryAddScoped<IUserClaimsPrincipalFactory<IUser>, UserClaimsPrincipalFactory<IUser, IRole>>();
            services.TryAddScoped<UserManager<IUser>>();
            services.TryAddScoped<SignInManager<IUser>>();

            services.TryAddScoped<UserStore>();
            services.TryAddScoped<IUserStore<IUser>>(sp => sp.GetRequiredService<UserStore>());
            services.TryAddScoped<IUserRoleStore<IUser>>(sp => sp.GetRequiredService<UserStore>());
            services.TryAddScoped<IUserPasswordStore<IUser>>(sp => sp.GetRequiredService<UserStore>());
            services.TryAddScoped<IUserEmailStore<IUser>>(sp => sp.GetRequiredService<UserStore>());
            services.TryAddScoped<IUserSecurityStampStore<IUser>>(sp => sp.GetRequiredService<UserStore>());
            services.TryAddScoped<IUserLoginStore<IUser>>(sp => sp.GetRequiredService<UserStore>());

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "orchauth_" + _tenantName;
                options.Cookie.Path = _tenantPrefix;
                options.LoginPath = "/" + LoginPath;
                options.AccessDeniedPath = options.LoginPath;
            });

            services.AddSingleton<IIndexProvider, UserIndexProvider>();
            services.AddSingleton<IIndexProvider, UserByRoleNameIndexProvider>();
            services.AddSingleton<IIndexProvider, UserByLoginInfoIndexProvider>();
            services.AddScoped<IDataMigration, Migrations>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IMembershipService, MembershipService>();
            services.AddScoped<ISetupEventHandler, SetupEventHandler>();
            services.AddScoped<ICommandHandler, UserCommands>();
            services.AddScoped<IRoleRemovedEventHandler, UserRoleRemovedEventHandler>();

            services.AddScoped<IPermissionProvider, Permissions>();
            services.AddScoped<INavigationProvider, AdminMenu>();

            services.AddScoped<ILiquidTemplateEventHandler, UserLiquidTemplateEventHandler>();

            services.AddScoped<IDisplayManager<User>, DisplayManager<User>>();
            services.AddScoped<IDisplayDriver<User>, UserDisplayDriver>();
            services.AddScoped<IDisplayDriver<User>, UserButtonsDisplayDriver>();
            
            services.AddScoped<IDisplayDriver<ISite>, RegistrationSettingsDisplayDriver>();
        }
    }
}