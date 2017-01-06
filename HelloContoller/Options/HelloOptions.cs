/// <summary>
/// The options pattern uses custom options classes to represent a group of related settings.
/// Values are read from the appsettings.json file. Uses DI to inject the values into your app.
/// Add the following code to ConfigureServices in Startup.cs
///   services.Configure<HelloOptions>(Configuration);
/// </summary>
public class HelloOptions
{
    public HelloOptions()
    {
        HelloValue = "Hello Options!"; // default value
    }
    public string HelloValue { get; set; }
}
