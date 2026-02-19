using CrewredTestTask;
using CrewredTestTask.Classes;
using Microsoft.Extensions.DependencyInjection;

namespace CrewRedTestTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Startup.ServiceProvider.GetRequiredService<App>().Run();
        }
    }
}
