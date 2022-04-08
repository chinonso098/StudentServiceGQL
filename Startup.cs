using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StudentServiceGQL.DataService;
using StudentServiceGQL.DomainObjects;
using Microsoft.EntityFrameworkCore;
using StudentServiceGQL.GraphQL;
using StudentServiceGQL.GraphQL.Types;
using StudentServiceGQL.Repository;
using GraphQL.Server.Ui.Voyager;

namespace StudentServiceGQL
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        //readonly string CorsApi = "CorsApi";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddPooledDbContextFactory<StudentServiceContext>(opt => opt.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));

            services.AddScoped<IRepository<Student>, StudentRepository>();
            services.AddScoped<IRepository<Address>, AddressRepository>();
            services.AddScoped<IRepository<CollegeProgram>, CollegeProgramRepository>();

            
            services.AddGraphQLServer().AddQueryType<Query>()
                                       // .AddType<AddressType>()
                                         .AddType<StudentType>();
            //                             .AddProjections();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
            });

            app.UseGraphQLVoyager(new VoyagerOptions(){
                GraphQLEndPoint = "/graphql"
            },"/graphql-Ui");
        }
    }
}