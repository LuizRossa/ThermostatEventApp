namespace ThermostatEventApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Press any key to start device...");
            Console.ReadKey();

            IDevice device = new Device();
            device.RunDevice();

            Console.ReadKey();
        }
    }
}