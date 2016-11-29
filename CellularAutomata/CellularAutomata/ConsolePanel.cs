using System;
using System.Collections.Generic;

namespace CellularAutomata {

    public class ConsolePanel {

        public static void Print(List<LinkedList<Cell>> generations) {
            generations.ForEach(PrintLine);
        }

        private static void PrintLine(LinkedList<Cell> generation) {
            generation.ForEach(cell => Console.Write(cell == Cell.Alive ? "x" : " "));
            Console.Write("\n");
        }


    }

}