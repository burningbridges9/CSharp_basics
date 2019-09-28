using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenBuilding
{
    public class FactoryBuilding
    {
        static Hashtable hashtable = new Hashtable();
        public static Building CreateBuilding()
        {
            Building building = new Building();
            hashtable.Add(building.Number, building);
            return building;
        }
        public static Building CreateBuilding(double Height, int Floors, int FlatsNumber, int PorchNumber)
        {
            Building building = new Building(Height, Floors, FlatsNumber, PorchNumber);
            hashtable.Add(building.Number, building);
            return building;
        }
        public static Building CreateBuilding(int Floors, int FlatsNumber, int PorchNumber)
        {
            Building building = new Building(Floors, FlatsNumber, PorchNumber);
            hashtable.Add(building.Number, building);
            return building;
        }
        public static Building CreateBuilding(int FlatsNumber, int PorchNumber)
        {
            Building building = new Building(FlatsNumber, PorchNumber);
            hashtable.Add(building.Number, building);
            return building;
        }
        public void DeleteBuilding(int number)
        {
            hashtable.Remove(number);
        }
        private FactoryBuilding() { }
    }
}
