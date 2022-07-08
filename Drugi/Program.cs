using Microsoft.Extensions.DependencyInjection;

namespace Drugi
{
    public interface IStartCar
    {
        public void Start();
    }

    public class StartCar : IStartCar
    {
        public void Start()
        {
            Console.WriteLine("paljenje auta");
        }
    }

    public class RunCar
    {
        private IStartCar _car;
        public RunCar(IStartCar car)
        {
            _car = car;
        }

        public void Run()
        {
            Console.WriteLine("auto je upaljeno mozete krenuti");
        }
    }

    class Program
    {
        public static async Task Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddScoped<IStartCar, StartCar>();

            //services.AddSingleton<IStartCar, RunCar>();
            
            var startovanje = new StartCar();
            var pokretanje = new RunCar(startovanje);
            startovanje.Start();
            await Task.Delay(2500);
            pokretanje.Run();


        }
    }
}
