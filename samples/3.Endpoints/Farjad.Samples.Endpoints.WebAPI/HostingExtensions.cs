using Microsoft.EntityFrameworkCore;
using Farjad.Endpoints.WebApi.Extentions.DependencyInjection;
using Farjad.Extensions.Caching.InMemory.Extensions.DependencyInjection;
using Farjad.Extensions.DependencyInjection;
using Farjad.Extensions.ObjectMappers.AutoMapper.Extensions.DependencyInjection;
using Farjad.Samples.Infrastructures.Data.Sql.Commands.Common;
using Farjad.Samples.Infrastructures.Data.Sql.Queries.Common;

namespace Farjad.Samples.Endpoints.WebAPI
{
    public static class HostingExtensions
    {
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            string cnn = "Server=.; Initial Catalog=FarjadSample; Integrated Security=True;TrustServerCertificate=True;";
            builder.Services.AddFarjadParrotTranslator(c =>
            {
                c.ConnectionString = cnn;
                c.AutoCreateSqlTable = true;
                c.SchemaName = "dbo";
                c.TableName = "ParrotTranslations";
                c.ReloadDataIntervalInMinuts = 1;
            });

            builder.Services.AddFarjadWebUserInfoService(true);

            builder.Services.AddFarjadAutoMapperProfiles(option =>
            {
                option.AssmblyNamesForLoadProfiles = "Farjad.Samples";
            });

            builder.Services.AddFarjadMicrosoftSerializer();

            builder.Services.AddFarjadInMemoryCaching();

            builder.Services.AddDbContext<SampleCommandDbContext>(c => c.UseSqlServer(cnn));
            builder.Services.AddDbContext<SampleQueryDbContext>(c => c.UseSqlServer(cnn));
            builder.Services.AddFarjadApiCore("Farjad");
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            return builder.Build();
        }

        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            app.UseFarjadApiExceptionHandler();
            //app.UseSerilogRequestLogging();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => { c.SwaggerEndpoint("./v1/swagger.json", "FarjadAPI"); });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            return app;
        }
    }
}