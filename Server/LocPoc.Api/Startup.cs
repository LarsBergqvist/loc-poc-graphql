using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using LocPoc.Contracts;
using Microsoft.EntityFrameworkCore;
using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using LocPoc.Api.GraphQL;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using LocPoc.Api.GraphQL.Messaging;

namespace LocPoc.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        private readonly string CorsPolicy = "appCorsPolicy";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Sqlite database
            services.AddDbContext<LocPoc.Repository.Sqlite.SqliteContext>(options =>
                options.UseSqlite("Data Source=locpoc.db"));
            services.AddScoped<ILocationsRepositoryAsync, LocPoc.Repository.Sqlite.LocationsRepositoryAsync>();

            services.AddCors(options =>
            {
                options.AddPolicy(CorsPolicy,
                builder =>
                {
                    builder.WithOrigins(Configuration["AllowedOrigins"].Split(";")).AllowAnyHeader().AllowAnyMethod();
                });
            });

            // Required for GraphQL?
            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            services.AddScoped<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
            services.AddScoped<LocPocSchema>();
            services.AddSingleton<LocationMessageService>();

            services.AddGraphQL(o => { o.ExposeExceptions = true; })
                .AddGraphTypes(ServiceLifetime.Scoped)
                .AddDataLoader()
                .AddWebSockets();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/api/Locations");
            }

            app.UseHttpsRedirection();


            app.UseCors(CorsPolicy);
            app.UseWebSockets();
            app.UseGraphQLWebSockets<LocPocSchema>("/graphql");
            app.UseGraphQL<LocPocSchema>();
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());
        }
    }
}
