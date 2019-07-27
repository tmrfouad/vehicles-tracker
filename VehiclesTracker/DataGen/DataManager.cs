using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehiclesTracker.Business.Managers;
using VehiclesTracker.Data;
using VehiclesTracker.DataGen.DTO;

namespace VehiclesTracker.DataGen
{
    public static class DataManager
    {
        public static List<VehicleStatus> GetData()
        {
            var r = new Random();
            return new List<VehicleStatus>()
            {
               new VehicleStatus { VehicleId = "YS2R4X20005399401", On = Convert.ToBoolean(r.Next(0,2)) },
               new VehicleStatus { VehicleId = "VLUR4X20009093588", On = Convert.ToBoolean(r.Next(0,2)) },
               new VehicleStatus { VehicleId = "VLUR4X20009048066", On = Convert.ToBoolean(r.Next(0,2)) },
               new VehicleStatus { VehicleId = "YS2R4X20005388011", On = Convert.ToBoolean(r.Next(0,2)) },
               new VehicleStatus { VehicleId = "YS2R4X20005387949", On = Convert.ToBoolean(r.Next(0,2)) },
               new VehicleStatus { VehicleId = "YS2R4X20005387765", On = Convert.ToBoolean(r.Next(0,2)) },
               new VehicleStatus { VehicleId = "YS2R4X20005387055", On = Convert.ToBoolean(r.Next(0,2)) }
            };
        }
    }
}
