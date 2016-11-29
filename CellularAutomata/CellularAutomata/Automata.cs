using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace CellularAutomata {

    public class Automata {

        public LinkedList<Cell> CurrentGeneration { get; private set; }
        private readonly Rule rule;
        public List<LinkedList<Cell>> HistoryOfGenerations { get; private set; }

        public Automata(LinkedList<Cell> currentGeneration, Rule rule) {
            this.CurrentGeneration = currentGeneration;
            this.rule = rule;
            HistoryOfGenerations = new List<LinkedList<Cell>> { currentGeneration };
        }

        public void Evolve() {
            var nextGeneration = new LinkedList<Cell>();
            for (var cell = CurrentGeneration.First; cell != null; cell = cell.Next)
            {
                nextGeneration.AddLast(
                    rule.Apply(new Neighborhood(CheckBorder(cell.Previous), cell.Value, CheckBorder(cell.Next)))
                );
            }
            HistoryOfGenerations.Add(nextGeneration);
            CurrentGeneration = nextGeneration;
        }

        private static Cell CheckBorder(LinkedListNode<Cell> cell) {
            return cell? .Value ?? Cell.Death;
        }


    }

}