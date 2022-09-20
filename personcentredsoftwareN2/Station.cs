using System;
using System.Collections.Generic;
using System.Text;

namespace personcentredsoftwareN2
{
    public class Station
    {
        public int Index { get; set; }
        public int AmountOfGasOnStaion { get; set; }
        public int AmoutToGetToStaion { get; set; }

        public Station(int index, int amountOfGasOnStaion, int amoutToGetToStaion)
        {
            Index = index;
            AmountOfGasOnStaion = amountOfGasOnStaion;
            AmoutToGetToStaion = amoutToGetToStaion;
        }

        public static Station convertToStation(string gassStaion, int index)
        {
            int amountOfGasOnStaion = 0;
            int amoutToGetToStaion = 0;

            if (gassStaion.Contains(":"))
            {
                string[] gassStaionNumbers = gassStaion.Split(':');
                amountOfGasOnStaion = convertToInt(gassStaionNumbers[0]);
                amoutToGetToStaion = convertToInt(gassStaionNumbers[1]);
            }
            else
            {
                amountOfGasOnStaion = convertToInt(gassStaion);
            }

            return new Station(index, amountOfGasOnStaion, amoutToGetToStaion);
        }

        public static int convertToInt(string st)
        {
            int amount = 0;
            try
            {
                amount = Int32.Parse(st);
                return amount;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Please check your input data -> " + st);
            }
            return amount;
        }
    }
}
