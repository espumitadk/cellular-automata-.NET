using System;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;

namespace CellularAutomata.Test {

    [TestFixture]
    public class AutomataShould {

        [Test]
        public void apply_given_rule_to_each_cell() {
            var rule30 =  Substitute.For<Rule30>();
            List<Cell> givenCells = new List<Cell>{
                Cell.Alive, Cell.Alive, Cell.Death, Cell.Alive, Cell.Death, Cell.Alive, Cell.Death
            };
            var automata = new Automata(givenCells, rule30);

            automata.Iterate();

            rule30.Received(7).Apply(Arg.Any<Neighborhood>());
        }
    }

}
