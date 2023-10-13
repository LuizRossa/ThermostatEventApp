using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThermostatEventApp
{
    public class Device : IDevice
    {
        private const double WarningLevel = 27;
        private const double EmergencyLevel = 75;

        public double WarningTemperatureLevel => WarningLevel;

        public double EmergencyTemperatureLevel => EmergencyLevel;

        private void ShutDownDevice()
        {
            Console.WriteLine("Shutting down device...");
        }
        public void HandleEmergency()
        {
            Console.WriteLine();
            Console.WriteLine("Sending out notifications to emergency services personal...");
            ShutDownDevice();
            Console.WriteLine();
        }

        public void RunDevice()
        {
            Console.WriteLine("Device is running...");

            ICoolingMechanism coolingMechanism = new CoolingMechanism();
            IHeatSensor heatSensor = new HeatSensor(WarningLevel, EmergencyLevel);
            IThermostat thermostat = new Thermostat(this, heatSensor, coolingMechanism);

            thermostat.RunThermostat();
        }
    }
}
