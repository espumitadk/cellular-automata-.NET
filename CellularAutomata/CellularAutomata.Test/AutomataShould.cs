using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
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

            rule30.Received(3).Apply(Arg.Any<Neighborhood>());
        }

        [Test]
        public void consider_borders_as_dead_cells() {
            var rule30 = Substitute.For<Rule30>();
            var automata = new Automata(GivenCells(), rule30);

            automata.Evolve();

            rule30.Received().Apply(new Neighborhood(Cell.Death, Cell.Alive, Cell.Alive));
            rule30.Received().Apply(new Neighborhood(Cell.Alive, Cell.Alive, Cell.Alive));
            rule30.Received().Apply(new Neighborhood(Cell.Alive, Cell.Alive, Cell.Death));
        }

        [Test]
        public void have_next_generation_after_evolve() {
            var rule30 = new Rule30();
            var automata = new Automata(GivenCells(), rule30);

            automata.Evolve();

            var evolvedGeneration = new LinkedList<Cell>();
            evolvedGeneration.AddLast(Cell.Alive);
            evolvedGeneration.AddLast(Cell.Death);
            evolvedGeneration.AddLast(Cell.Death);
            automata.HistoryOfGenerations[1].Should().BeEquivalentTo(evolvedGeneration);
        }

        [Test]
        public void update_current_generation_after_evolve() {
            var rule30 = new Rule30();
            var automata = new Automata(GivenCells(), rule30);

            automata.Evolve();

            var evolvedGeneration = new LinkedList<Cell>();
            evolvedGeneration.AddLast(Cell.Alive);
            evolvedGeneration.AddLast(Cell.Death);
            evolvedGeneration.AddLast(Cell.Death);
            automata.CurrentGeneration.Should().BeEquivalentTo(evolvedGeneration);
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
