using Microsoft.Extensions.DependencyInjection;

namespace Drugi
{
    public interface IStartCar
    {
        public void Start(int i)
        {

        }
        

        
    }

    public class StartCar : IStartCar
    {
        void Start(int i)
        {
            Console.WriteLine($"odbroravanje {i}");
        }
    }

    public interface IRunCar
    {
        public void Run()
        {

        }
       
    }
    public class RunCar: IRunCar
    {
        
        private readonly IStartCar _car;
        public RunCar(IStartCar car)
        {
            _car = car;
        }

         public void Run()
        {
            for (int i = 0; i < 5; i++)
            {
                _car.Start(i);
            }
        }
    }
    
    class Program
    {
        public static async Task Main(string[] args)
        {

            var services = new ServiceCollection();
            services.AddScoped<IStartCar, StartCar>();
            services.AddScoped<IRunCar, RunCar>();
            IServiceProvider serviceProvider = services.BuildServiceProvider();
            var runCarService = serviceProvider.GetService<IRunCar>();

            runCarService.Run();
            
            await Task.Delay(2500);

            Console.WriteLine("kraj");
            

            


        }
    }
}
