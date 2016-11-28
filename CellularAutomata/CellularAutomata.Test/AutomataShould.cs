using System;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;

namespace CellularAutomata.Test {

    [TestFixture]
    public class AutomataShould {

        [Test]
        public void apply_given_rule_to_each_neighborhood_during_evolution() {
            var rule30 =  Substitute.For<Rule30>();
            var automata = new Automata(GivenCells(), rule30);

            automata.Evolve();

            rule30.Received(7).Apply(Arg.Any<Neighborhood>());
        }

        private static List<Cell> GivenCells() {
            return new List<Cell>{
                Cell.Alive, Cell.Alive, Cell.Death, Cell.Alive, Cell.Death, Cell.Alive, Cell.Death
            };
        }

    }

}
