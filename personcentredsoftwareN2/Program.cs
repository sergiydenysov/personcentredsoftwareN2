using System;
using System.Collections.Generic;
using System.Linq;

namespace personcentredsoftwareN2
{
    class Program
    {
        static void Main(string[] args)
        {

            //AS I am doing this excersise from memory I am asyming that in the string "4:2" 
            //4 represennts amount og Gas on this station
            //and 2 is represents amount of gas needed to get to this station from prevous station

            var sucsesfulRunStartIndeses = new List<int>();

            string[] stringArray = { "4:0", "2:1", "3:2", "5:12", "3:1" };
            var originalList = new List<Station>();
            for (int i = 0; i < stringArray.Length; i++)
            {
                originalList.Add(Station.convertToStation(stringArray[i], i));
            }

            foreach (var st in originalList)
            {
                bool sucsesfullRun = true;
                var list = new List<Station>();

                list.AddRange(originalList.GetRange(st.Index, originalList.Count - st.Index));
                if (st.Index != 0)
                {
                    list.AddRange(originalList.GetRange(0, st.Index));
                }

                var startIndex = list.First().Index;
                var amountGas = list.First().AmountOfGasOnStaion;
                list.Remove(list.First());
                foreach (var item in list)
                {
                    amountGas = amountGas + item.AmountOfGasOnStaion - item.AmoutToGetToStaion;
                    if (amountGas < 0)
                    {
                        sucsesfullRun = false;
                    }
                }

                if (sucsesfullRun)
                {
                    sucsesfulRunStartIndeses.Add(startIndex);
                }
            }

            Console.WriteLine("Indexes of the staion that you can start jorney to finish full circle " + String.Join(", ", sucsesfulRunStartIndeses.ToArray()));
        }
    }
}
