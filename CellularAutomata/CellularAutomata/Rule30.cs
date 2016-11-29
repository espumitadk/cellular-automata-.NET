using System.Collections.Generic;

namespace CellularAutomata {

    public class Rule30 : Rule {
        
        private readonly List<Neighborhood> killersNeighborhoods = new List<Neighborhood> {
            new Neighborhood(Cell.Alive, Cell.Alive, Cell.Alive),
            new Neighborhood(Cell.Alive, Cell.Alive, Cell.Death),
            new Neighborhood(Cell.Alive, Cell.Death, Cell.Alive),
            new Neighborhood(Cell.Death, Cell.Death, Cell.Death),
        };

        public virtual Cell Apply(Neighborhood neighborhood)
        {
            return killersNeighborhoods.Contains(neighborhood) ? Cell.Death : Cell.Alive;
        }

    }

}