using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThermostatEventApp
{
    public class Thermostat : IThermostat
    {
        private ICoolingMechanism _coolingMechanism = null;
        private IHeatSensor _heatSensor = null;
        private IDevice _device = null;

        private const double WarningLevel = 27;
        private const double EmergencyLevel = 75;

        private void WireUpEventsToEventHandlers()
        {
            _heatSensor.TemperatureReachesWarningLevelEventHandler += HeatSensor_TemperatureReachesWarningLevelEventHandler;
            _heatSensor.TemperatureFallsBelowWarningLevelEventHandler += HeatSensor_TemperatureFallsBelowWarningLevelEventHandler;
            _heatSensor.TemperatureReachesEmergencyLevelEventHandler += HeatSensor_TemperatureReachesEmergencyLevelEventHandler;
        }

        private void HeatSensor_TemperatureReachesEmergencyLevelEventHandler(object? sender, TemperatureEventArgscs e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine();
            Console.WriteLine($"Emergency Alert!! (emergency level is between {_device.EmergencyTemperatureLevel} and above).");
            _device.HandleEmergency();
            Console.ResetColor();
        }

        private void HeatSensor_TemperatureFallsBelowWarningLevelEventHandler(object? sender, TemperatureEventArgscs e)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine();
            Console.WriteLine($"Information Alert!! Temperature falls below warning level (warning level is between {_device.WarningTemperatureLevel} and {_device.EmergencyTemperatureLevel})");
            _coolingMechanism.Off();
            Console.ResetColor();
        }

        private void HeatSensor_TemperatureReachesWarningLevelEventHandler(object? sender, TemperatureEventArgscs e)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine();
            Console.WriteLine($"Warning Alert!! (warning level is between {_device.WarningTemperatureLevel} and {_device.EmergencyTemperatureLevel})");
            _coolingMechanism.On();
            Console.ResetColor();
        }

        public Thermostat(IDevice device, IHeatSensor heatSensor, ICoolingMechanism coolingMechanism) 
        {
            _device = device;
            _heatSensor = heatSensor;
            _coolingMechanism = coolingMechanism;
        }
        public void RunThermostat()
        {
            Console.WriteLine("Thermostat is running...");
            WireUpEventsToEventHandlers();
            _heatSensor.RunHeatSensor();
        }
    }
}
