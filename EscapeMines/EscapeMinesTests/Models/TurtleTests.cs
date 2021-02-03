using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;

namespace EscapeMines.Models.Tests
{
    [TestClass()]
    public class TurtleTests
    {
        [TestMethod()]
        public void MoveShouldChangeX()
        {
            var expectedTurtle = new Turtle(1, 0, Direction.S);

            var actualTurtle = new Turtle(0, 0, Direction.S);
            actualTurtle.Move("M");


            expectedTurtle.Should().BeEquivalentTo(actualTurtle);
        }

        [TestMethod()]
        public void MoveAndRotateShouldChangeCordinatesAndDirection()
        {
            var expectedTurtle = new Turtle(1, 1, Direction.E);

            var actualTurtle = new Turtle(0, 0, Direction.S);
            actualTurtle.Move("M");
            actualTurtle.Move("L");
            actualTurtle.Move("M");

            expectedTurtle.Should().BeEquivalentTo(actualTurtle);
        }
    }
}