namespace CellularAutomata {

    public interface Rule {

        Cell Apply(Neighborhood neighborhood);

    }

}