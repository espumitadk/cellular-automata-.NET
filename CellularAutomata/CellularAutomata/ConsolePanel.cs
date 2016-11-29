using System;
using System.Collections.Generic;

namespace CellularAutomata {

    public class ConsolePanel {

        public static void Print(List<LinkedList<Cell>> generations) {
            generations.ForEach(PrintLine);
        }

        private static void PrintLine(LinkedList<Cell> generation) {
            foreach (var cell in generation)
            {
                Console.Write(cell == Cell.Alive ? "x" : " ");
            }
            Console.Write("\n");
        }


    }

}