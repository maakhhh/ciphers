using Microsoft.Extensions.DependencyInjection;

namespace Ciphers.Client;

static class Program
{
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        var services = new ServiceCollection()
            .AddForms()
            .AddLogic()
            .AddWordProcessors();
        
        var provider = services.BuildServiceProvider();
        
        ApplicationConfiguration.Initialize();
        var mainForm = provider.GetRequiredService<MainForm>();
        Application.Run(mainForm);
    }
}