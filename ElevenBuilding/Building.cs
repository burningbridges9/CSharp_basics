using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenBuilding
{
    public class Building
    {
        static int count = 0;
        private int number;
        public int Number
        {
            get
            {
                return number;
            }
            set
            {
                number = ++count;
            }
        }
        public double Height { get; set; }
        public int Floors { get; set; }
        public int FlatsNumber { get; set; }
        public int PorchNumber { get; set; }
        internal Building(double Height, int Floors, int FlatsNumber, int PorchNumber)
        {
            Number = ++count;
            this.Height = Height;
            this.Floors = Floors;
            this.FlatsNumber = FlatsNumber;
            this.PorchNumber = PorchNumber;
        }
        internal Building()
        {
            Number = ++count;
        }
        internal Building(int Floors, int FlatsNumber, int PorchNumber)
        {
            Number = ++count;
            this.Floors = Floors;
            this.FlatsNumber = FlatsNumber;
            this.PorchNumber = PorchNumber;
        }
        internal Building(int FlatsNumber, int PorchNumber)
        {
            Number = ++count;
            this.Floors = Floors;
            this.FlatsNumber = FlatsNumber;
        }
        public double GetFloorHeight()
        {
            return Height / Floors;
        }
        public int GetFlatsNumberInOnePorch()
        {
            return FlatsNumber / PorchNumber;
        }
        public int GetFlatsNumberInOneFloor()
        {
            return GetFlatsNumberInOnePorch() / Floors;
        }
        public override string ToString()
        {
            return "Building info:\n"
                + Number.ToString() + '\n'
                + Height.ToString() + '\n'
                + Floors.ToString() + '\n'
                + FlatsNumber.ToString() + '\n'
                + PorchNumber.ToString() + '\n';
        }
    }
}
