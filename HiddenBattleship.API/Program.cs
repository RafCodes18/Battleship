using DocumentFormat.OpenXml.Office2016.Drawing.ChartDrawing;
using HiddenBattleship.PL;
using Microsoft.EntityFrameworkCore;
using Serilog.Ui.MsSqlServerProvider;
using Serilog.Ui.Web;
using System.Reflection;

public class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        //builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        //    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

        //builder.Services.AddCors(options => options.AddPolicy("CorsPolicy",
        //    builder =>
        //    {
        //        builder.AllowAnyHeader()
        //        .AllowAnyMethod()
        //        .SetIsOriginAllowed((host) => true)
        //        .AllowCredentials();
        //    }));

        builder.Services.AddSignalR()
            .AddJsonProtocol(options =>
            {
                options.PayloadSerializerOptions.PropertyNamingPolicy = null;
            });

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
            {
                Title = "Hidden Battleship API",
                Version = "v1",
                Contact = new Microsoft.OpenApi.Models.OpenApiContact
                {
                    Email = "500135802@fvtc.edu",
                    Name = "Pete, Rafael, & Kathy",
                    Url = new Uri("https://www.fvtc.edu")
                }
            });

            // TODO: Implement xml documentation
            // C# needed for the xml documentation to be used.
            //var xmlfile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            //var xmlpath = Path.Combine(AppContext.BaseDirectory, xmlfile);
            //c.IncludeXmlComments(xmlpath);


        });

        builder.Services.AddDbContextPool<HiddenBattleshipEntities>(options =>
        {
            options.UseSqlServer(builder.Configuration.GetConnectionString("HiddenBattleshipConnection"));
            //options.UseLazyLoadingProxies();
        });


        string connection = builder.Configuration.GetConnectionString("HiddenBattleshipConnection");

        builder.Services.AddSerilogUi(options =>
        {
            options.UseSqlServer(connection, "Logs");
        });


        var app = builder.Build();

        app.UseSerilogUi(options =>
        {
            options.RoutePrefix = "logs";
        });


        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }



        app.UseHttpsRedirection();
        app.UseRouting();

        app.UseAuthentication();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}