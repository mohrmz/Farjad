using Microsoft.EntityFrameworkCore;
using Scorpion.Endpoints.WebApi.Extentions.DependencyInjection;
using Scorpion.Extensions.Caching.InMemory.Extensions.DependencyInjection;
using Scorpion.Extensions.DependencyInjection;
using Scorpion.Extensions.ObjectMappers.AutoMapper.Extensions.DependencyInjection;
using Scorpion.Samples.Infrastructures.Data.Sql.Commands.Common;
using Scorpion.Samples.Infrastructures.Data.Sql.Queries.Common;

namespace Scorpion.Samples.Endpoints.WebAPI
{
    public static class HostingExtensions
    {
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            string cnn = "Server=.; Initial Catalog=ScorpionSample; Integrated Security=True;TrustServerCertificate=True;";
            builder.Services.AddScorpionParrotTranslator(c =>
            {
                c.ConnectionString = cnn;
                c.AutoCreateSqlTable = true;
                c.SchemaName = "dbo";
                c.TableName = "ParrotTranslations";
                c.ReloadDataIntervalInMinuts = 1;
            });

            builder.Services.AddScorpionWebUserInfoService(true);

            builder.Services.AddScorpionAutoMapperProfiles(option =>
            {
                option.AssmblyNamesForLoadProfiles = "Scorpion.Samples";
            });

            builder.Services.AddScorpionMicrosoftSerializer();

            builder.Services.AddScorpionInMemoryCaching();

            builder.Services.AddDbContext<SampleCommandDbContext>(c => c.UseSqlServer(cnn));
            builder.Services.AddDbContext<SampleQueryDbContext>(c => c.UseSqlServer(cnn));
            builder.Services.AddScorpionApiCore("Scorpion");
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            return builder.Build();
        }

        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            app.UseScorpionApiExceptionHandler();
            //app.UseSerilogRequestLogging();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => { c.SwaggerEndpoint("./v1/swagger.json", "ScorpionAPI"); });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            return app;
        }
    }
}