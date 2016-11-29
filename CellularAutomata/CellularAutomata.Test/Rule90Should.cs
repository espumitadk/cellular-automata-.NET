using FluentAssertions;
using NUnit.Framework;

namespace CellularAutomata.Test {

    [TestFixture]
    public class Rule90Should
    {

        [TestCase(Cell.Alive, Cell.Alive, Cell.Alive)]
        [TestCase(Cell.Alive, Cell.Death, Cell.Alive)]
        [TestCase(Cell.Death, Cell.Alive, Cell.Death)]
        [TestCase(Cell.Death, Cell.Death, Cell.Death)]
        public void give_a_death_cell_when_neighborhood_is_(Cell leftCell, Cell centerCell, Cell rightCell)
        {
            var rule = new Rule90();
            var neighborhood = new Neighborhood(leftCell, centerCell, rightCell);

            var evolvedCell = rule.Apply(neighborhood);

            evolvedCell.Should().Be(Cell.Death);
        }

        [TestCase(Cell.Alive, Cell.Alive, Cell.Death)]
        [TestCase(Cell.Alive, Cell.Death, Cell.Death)]
        [TestCase(Cell.Death, Cell.Alive, Cell.Alive)]
        [TestCase(Cell.Death, Cell.Death, Cell.Alive)]
        public void give_a_alive_cell_when_neighborhood_is_(Cell leftCell, Cell centerCell, Cell rightCell)
        {
            var rule = new Rule90();
            var neighborhood = new Neighborhood(leftCell, centerCell, rightCell);

            var evolvedCell = rule.Apply(neighborhood);

            evolvedCell.Should().Be(Cell.Alive);
        }

    }

}