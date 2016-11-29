using System.Collections.Generic;

namespace CellularAutomata {

    public class Rule90 : Rule {

        private readonly List<Neighborhood> killerNeighborhoods = new List<Neighborhood> {
            new Neighborhood(Cell.Alive, Cell.Alive, Cell.Alive),
            new Neighborhood(Cell.Alive, Cell.Death, Cell.Alive),
            new Neighborhood(Cell.Death, Cell.Alive, Cell.Death),
            new Neighborhood(Cell.Death, Cell.Death, Cell.Death),
        };

        public virtual Cell Apply(Neighborhood neighborhood)
        {
            return killerNeighborhoods.Contains(neighborhood) ? Cell.Death : Cell.Alive;
        }

    }

}