using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;

namespace CellularAutomata.Test {

    [TestFixture]
    public class AutomataShould {

        private Rule rule;

        [SetUp]
        public void SetUp() {
            rule = Substitute.For<Rule>();
        }

        [Test]
        public void apply_given_rule_to_each_neighborhood_during_evolution() {
            var automata = new Automata(GivenCells(), rule);

            automata.Evolve();

            rule.Received(3).Apply(Arg.Any<Neighborhood>());
        }

        [Test]
        public void consider_borders_as_dead_cells() {
            var automata = new Automata(GivenCells(), rule);

            automata.Evolve();

            rule.Received().Apply(new Neighborhood(Cell.Death, Cell.Alive, Cell.Alive));
            rule.Received().Apply(new Neighborhood(Cell.Alive, Cell.Alive, Cell.Alive));
            rule.Received().Apply(new Neighborhood(Cell.Alive, Cell.Alive, Cell.Death));
        }

        [Test]
        public void have_next_generation_after_evolve() {
            var automata = new Automata(GivenCells(), rule);

            automata.Evolve();

            automata.HistoryOfGenerations.Count.Should().Be(2);
        }

        [Test]
        public void update_current_generation_after_evolve() {
            var automata = new Automata(GivenCells(), rule);
            rule.Apply(Arg.Any<Neighborhood>()).Returns(Cell.Death);

            automata.Evolve();

            automata.CurrentGeneration.Should().NotBeEquivalentTo(GivenCells());
        }

        private static LinkedList<Cell> GivenCells() {
            var result = new LinkedList<Cell>();
            result.AddLast(Cell.Alive);
            result.AddLast(Cell.Alive);
            result.AddLast(Cell.Alive);
            return result;
        }

    }

}
