using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace CellularAutomata {

    public class Automata {

        private readonly LinkedList<Cell> cells;
        private readonly Rule30 rule;
        public List<LinkedList<Cell>> HistoryOfGenerations { get; private set; }

        public Automata(LinkedList<Cell> cells, Rule30 rule) {
            this.cells = cells;
            this.rule = rule;
            HistoryOfGenerations = new List<LinkedList<Cell>> { cells };
        }

        public void Evolve() {
            var nextGeneration = new LinkedList<Cell>();
            for (var cell = cells.First; cell != null; cell = cell.Next)
            {
                nextGeneration.AddLast(
                    rule.Apply(new Neighborhood(CheckBorder(cell.Previous), cell.Value, CheckBorder(cell.Next)))
                );
            }
            HistoryOfGenerations.Add(nextGeneration);
        }

        private static Cell CheckBorder(LinkedListNode<Cell> node) {
            var cell = node? .Value ?? Cell.Death;
            return cell;
        }


    }

}