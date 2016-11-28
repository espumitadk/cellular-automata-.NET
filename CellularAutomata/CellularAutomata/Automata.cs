using System.Collections.Generic;
using System.Linq;

namespace CellularAutomata {

    public class Automata {

        private readonly LinkedList<Cell> cells;
        private Rule30 rule;

        public Automata(LinkedList<Cell> cells, Rule30 rule) {
            this.cells = cells;
            this.rule = rule;
        }

        public void Evolve() {
            for (LinkedListNode<Cell> cell = cells.First; cell != null; cell = cell.Next)
            {
                rule.Apply(new Neighborhood(CheckBorder(cell.Previous),cell.Value, CheckBorder(cell.Next)));
            }
        }

        private static Cell CheckBorder(LinkedListNode<Cell> node) {
            return node != null ? node.Value : Cell.Death;
        }

    }

}