using System.Collections.Generic;

namespace CellularAutomata {

    public class Rule30 {
        
        private readonly Dictionary<Neighborhood, Cell> equivalences = new Dictionary<Neighborhood, Cell> {
            { new Neighborhood(Cell.Alive, Cell.Alive, Cell.Alive), Cell.Death },
            { new Neighborhood(Cell.Alive, Cell.Alive, Cell.Death), Cell.Death },
            { new Neighborhood(Cell.Alive, Cell.Death, Cell.Alive), Cell.Death },
            { new Neighborhood(Cell.Death, Cell.Death, Cell.Death), Cell.Death }
        };

        public virtual Cell Apply(Neighborhood neighborhood) {
            return equivalences[neighborhood];
        }

    }

}