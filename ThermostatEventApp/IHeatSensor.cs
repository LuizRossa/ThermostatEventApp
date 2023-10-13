using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThermostatEventApp
{
    public interface IHeatSensor
    {
        event EventHandler<TemperatureEventArgscs> TemperatureReachesEmergencyLevelEventHandler;
        event EventHandler<TemperatureEventArgscs> TemperatureReachesWarningLevelEventHandler;
        event EventHandler<TemperatureEventArgscs> TemperatureFallsBelowWarningLevelEventHandler;

        void RunHeatSensor();
    } 
}
