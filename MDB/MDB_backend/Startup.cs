using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Configuration;
using Microsoft.Extensions.Options;

namespace MDB_backend
{
    public class Startup
    {
        public static string dbName;

        public Startup(IConfiguration configuration)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.ConnectionStrings.ConnectionStrings.Remove("MysqlConnection");

            string host = "localhost";
            string port = "3306";
            string db_name = "edb";
            string user_id = "root";
            string pw = "";

            string cleardb_url = Environment.GetEnvironmentVariable("CLEARDB_DATABASE_URL");
            if (!string.IsNullOrEmpty(cleardb_url))
            {
                user_id = cleardb_url.Substring(8, 14);
                pw = cleardb_url.Substring(23, 8);
                host = cleardb_url.Substring(cleardb_url.IndexOf('@') + 1, cleardb_url.LastIndexOf('/') - cleardb_url.IndexOf('@') - 1);
                db_name = cleardb_url.Substring(cleardb_url.LastIndexOf('/') + 1, cleardb_url.LastIndexOf('?') - cleardb_url.LastIndexOf('/') - 1);
            }
            dbName = db_name;

            config.ConnectionStrings.ConnectionStrings.Add(new ConnectionStringSettings("MysqlConnection", $"Data Source={host};port={port};Initial Catalog={db_name}; User Id={user_id};password={pw};SslMode=none;convert zero datetime=True"));

            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");


            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                });
            });
            services.AddControllers().AddNewtonsoftJson();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
