using System;
using System.Collections.Generic;
using System.Linq;

namespace CellularAutomata {

    class Program {

        static void Main(string[] args) {
            var cells = Cells();
            var rule30 = new Rule30();
            var automata = new Automata(cells, rule30);
            Enumerable.Range(0, 20).ForEach(x => automata.Evolve());
            ConsolePanel.Print(automata.HistoryOfGenerations);

            Console.ReadLine();
        }

        private static LinkedList<Cell> Cells() {
            var cells = new LinkedList<Cell>();
            Enumerable.Range(0, 49).ForEach(x => cells.AddLast(Cell.Death));
            cells.AddLast(Cell.Alive);
            Enumerable.Range(0, 48).ForEach(x => cells.AddLast(Cell.Death));
            return cells;
        }

    }

    public static class FrameworkExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> @enum, Action<T> mapFunction)
        {
            foreach (var item in @enum) mapFunction(item);
        }
    }
}
