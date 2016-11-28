using System.Collections.Generic;

namespace CellularAutomata {

    public class Automata {

        private readonly List<Cell> cells;
        private Rule30 rule;

        public Automata(List<Cell> cells, Rule30 rule) {
            this.cells = cells;
            this.rule = rule;
        }

        public void Evolve() {
            cells.ForEach(x => rule.Apply(new Neighborhood(Cell.Alive, Cell.Alive, Cell.Alive)));
        }

    }

}