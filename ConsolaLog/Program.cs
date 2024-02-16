using Serilog;
using Serilog.Sinks.MSSqlServer;
using Serilog.Sinks.MSSqlServer.Sinks.MSSqlServer.Options;

var configuracion = new LoggerConfiguration().WriteTo.Console(
    Serilog.Events.LogEventLevel.Information).
    WriteTo.File("Logs.txt",Serilog.Events.LogEventLevel.Error,
    rollingInterval:RollingInterval.Day,retainedFileCountLimit:10).
    WriteTo.MSSqlServer("Data Source=LAPTOP-MO5BCA5I;Initial Catalog=SalesGalaxy1;Integrated Security=True;Encrypt=False;Trust Server Certificate=True"
    ,new MSSqlServerSinkOptions
    {
        TableName="events",
        SchemaName="logs",
        AutoCreateSqlTable=true,

    });

var logger = configuracion.CreateLogger();

logger.Information("Test");

try
{
    throw new Exception("dd");

}
catch (Exception ex)
{
    logger.Error(ex.ToString(),"No se puede procesar");
	
}
logger.Error("Revisar TXT");
string cadena = "Hola";

Console.WriteLine("Hello, World!");

Console.ReadKey();

