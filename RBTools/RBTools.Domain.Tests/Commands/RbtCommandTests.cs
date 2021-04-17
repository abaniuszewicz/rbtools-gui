using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using RBTools.Domain.Commands;
using RBTools.Domain.Options;

namespace RBTools.Domain.Tests.Commands
{
    [TestFixture]
    public class RbtCommandTests
    {
        private Mock<RbtCommand> _command;

        [SetUp]
        public void SetUp()
        {
            _command = new Mock<RbtCommand>();
            _command.Setup(c => c.Command).Returns("commandName");
        }

        [Test]
        public void Print_WhenNoOptionsSpecified_ReturnsOnlyRbtAndNameOfCommand()
        {
            _command.Setup(c => c.Options).Returns(Enumerable.Empty<IRbtOption>());

            var text = _command.Object.Print();

            Assert.AreEqual("rbt commandName", text);
        }

        [Test]
        public void Print_WhenOneOptionSpecified_ReturnsRbtPostAndThatOption()
        {
            var option = new Mock<IRbtOption>();
            option.Setup(o => o.Print()).Returns("option");
            _command.Setup(c => c.Options).Returns(new[] { option.Object });

            var text = _command.Object.Print();

            Assert.AreEqual("rbt commandName option", text);
        }

        [Test]
        public void Print_WhenMultipleOptionsSpecified_ReturnsRbtPostAndOptionsSeparatedBySingleSpace()
        {
            var option1 = new Mock<IRbtOption>();
            var option2 = new Mock<IRbtOption>();
            var option3 = new Mock<IRbtOption>();
            option1.Setup(o => o.Print()).Returns("1");
            option2.Setup(o => o.Print()).Returns("2");
            option3.Setup(o => o.Print()).Returns("3");
            _command.Setup(c => c.Options).Returns(new[] { option1.Object, option2.Object, option3.Object });

            var text = _command.Object.Print();

            Assert.AreEqual("rbt commandName 1 2 3", text);
        }
    }
}