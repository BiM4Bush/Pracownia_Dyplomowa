using FutStats.Application.Messaging.Commands;
using FutStats.Application.Messaging.Commands.Player;
using FutStats.Domain.Repositories;
using FutStats.Domain.Repositories.Entities;
using FutStats.Infrastructure.Database;
using FutStats.Infrastructure.Database.Repositories;
using FutStats.Infrastructure.Database.Repositories.FutStatsRepositories;
using FutStats.Infrastructure.Messaging.Queries;
using FutStats.Infrastructure.Messaging.Queries.Coach;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;
using FutStats.Application.Messaging.Commands.Statistic;
using FutStats.Application.Messaging.Commands.Team;
using FutStats.Infrastructure.Messaging.Queries.Player;
using FutStats.Infrastructure.Messaging.Queries.Team;

namespace FutStats
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
            services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);
            services.AddOptions();
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));

            services.AddTransient(typeof(IEntitiesRepository<>), typeof(EntitiesRepositoryBase<>));
            services.AddScoped(typeof(ICoachRepository), typeof(CoachRepository));
            services.AddTransient<IPlayerRepository, PlayerRepository>();
            services.AddTransient<IStatisticRepository, StatisticRepository>();
            services.AddTransient<ITeamRepository, TeamRepository>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddDbContext<FutStatDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddSwaggerGen(options =>
            {
                options.CustomSchemaIds(type => type.ToString());
            });

            //coach commands and queries
            services.AddMediatR(typeof(GetAllCoachesQuery).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(CreateCoachCommand).GetTypeInfo().Assembly);

            //player commands and queries
            services.AddMediatR(typeof(GetAllPlayersQuery).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(GetPlayerWithStatisticsQuery).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(CreatePlayerCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(UpdatePlayerOfStatisticCommand).GetTypeInfo().Assembly);

            //statistics commands and queries
            services.AddMediatR(typeof(CreateStatisticCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(UpdateStatisticCommand).GetTypeInfo().Assembly);

            //teams commands and queries
            services.AddMediatR(typeof(GetTeamQuery).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(CreateTeamCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(HireCoachCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(FireCoachCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(SignPlayerCommand).GetTypeInfo().Assembly);

            services.AddControllers();      
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();


            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "FutStatsApplication");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
