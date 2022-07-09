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

    public class RunCar: IStartCar
    {
        // morao sam ovo da maknem da bi mi scoped radio
        /*private IStartCar _car;
        public RunCar(IStartCar car)
        {
            _car = car;
        }*/

        public void Start()
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

            //
            services.AddScoped<IStartCar, RunCar>();
            //

            //services.BuildServiceProvider();

           

            IServiceProvider serviceProvider = services.BuildServiceProvider();
            serviceProvider.GetService<StartCar>();
            serviceProvider.GetService<RunCar>();

            
            await Task.Delay(2500);
            

            //var startovanje = new StartCar();
            //var pokretanje = new RunCar(startovanje);
            //startovanje.Start();
            //pokretanje.Run();


        }
    }
}
