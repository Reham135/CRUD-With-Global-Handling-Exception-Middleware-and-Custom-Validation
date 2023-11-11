
using GoodsMart.Bl;
using GoodsMart.DAL;
using GoodsMart.DAL.Data.Context;
using GoodsMart.DAL.HandlingExceptionMiddleware;
using Microsoft.EntityFrameworkCore;

namespace GoodsMart.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

           #region Default Services

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            #endregion

            #region CORS Policy
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAllDomains", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });
            #endregion

            #region Database
            var connectionString = builder.Configuration.GetConnectionString("GoodsMart_Connection_string");//get connection string from appSetting.json

            builder.Services.AddDbContext<GoodsMartContext>(options => options.UseSqlServer(connectionString));
            #endregion

            #region Services Registeration
            builder.Services.AddScoped<IProductRepo, ProductRepo>();
            builder.Services.AddScoped<IProductManager, ProductManager>();
            #endregion

            var app = builder.Build();

            #region Middlewares

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.Use(async (context, next) =>
            {
                try
                {
                    await next(context);
                }
                catch (CustomWrongInputException ex)
                {

                    context.Response.StatusCode = StatusCodes.Status400BadRequest;
                }
                catch (CustomNotFoundException ex)
                {

                    context.Response.StatusCode = StatusCodes.Status404NotFound;
                }
                catch (Exception ex)
                {
                    //log exception in file
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                }

            });


            app.UseCors("AllowAllDomains");

            app.UseAuthorization();

            app.MapControllers();
            #endregion

            app.Run();
        }
    }
}