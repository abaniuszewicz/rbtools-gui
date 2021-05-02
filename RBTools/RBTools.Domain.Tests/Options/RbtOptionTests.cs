using Moq;
using NUnit.Framework;

namespace RBTools.Domain.Tests.Options
{
    [TestFixture]
    public class RbtOptionTests
    {
        [Test]
        public void Print_ForOptionWithLongFormAndShortFormAndValue_TakesShortFormAndValue()
        {
            var option = new Mock<OptionWithLongFormAndShortFormAndValue>();
            option.Setup(o => o.LongForm).Returns("long");
            option.Setup(o => o.ShortForm).Returns("short");
            option.Setup(o => o.Value).Returns("value");

            string text = option.Object.Print();

            Assert.AreEqual("-short value", text);
        }

        [Test]
        public void Print_ForOptionWithLongAndShortForm_TakesShortForm()
        {
            var option = new Mock<OptionWithLongFormAndShortForm>();
            option.Setup(o => o.LongForm).Returns("long");
            option.Setup(o => o.ShortForm).Returns("short");

            string text = option.Object.Print();

            Assert.AreEqual("-short", text);
        }

        [Test]
        public void Print_ForOptionWithLongFormAndValue_TakesLongFormAndValue()
        {
            var option = new Mock<OptionWithLongFormAndValue>();
            option.Setup(o => o.LongForm).Returns("long");
            option.Setup(o => o.Value).Returns("value");

            string text = option.Object.Print();

            Assert.AreEqual("--long value", text);
        }

        [Test]
        public void Print_ForOptionWithShortFormAndValue_TakesShortFormAndValue()
        {
            var option = new Mock<OptionWithShortFormAndValue>();
            option.Setup(o => o.ShortForm).Returns("short");
            option.Setup(o => o.Value).Returns("value");

            string text = option.Object.Print();

            Assert.AreEqual("-short value", text);
        }

        [Test]
        public void Print_ForOptionWithLongForm_TakesLongForm()
        {
            var option = new Mock<OptionWithLongForm>();
            option.Setup(o => o.LongForm).Returns("long");

            string text = option.Object.Print();

            Assert.AreEqual("--long", text);
        }

        [Test]
        public void Print_ForOptionWIthShortForm_TakesShortForm()
        {
            var option = new Mock<OptionWithShortForm>();
            option.Setup(o => o.ShortForm).Returns("short");

            string text = option.Object.Print();

            Assert.AreEqual("-short", text);
        }

        [Test]
        public void Print_ForOptionWithValue_TakesValue()
        {
            var option = new Mock<OptionWithValue>();
            option.Setup(o => o.Value).Returns("value");

            string text = option.Object.Print();

            Assert.AreEqual("value", text);
        }

        [Test]
        [TestCase("val ue", "\"val ue\"")]
        [TestCase("val\"ue", "val\\\"ue")]
        [TestCase(" ", "\" \"")]
        [TestCase("val\nue", "\"val\nue\"")]
        public void Print_ForValueWithInvalidCharacters_EscapeAllInvalidCharacters(string value, string expectedEscapedValue)
        {
            var option = new Mock<OptionWithValue>();
            option.Setup(o => o.Value).Returns(value);

            string text = option.Object.Print();

            Assert.AreEqual(expectedEscapedValue, text);
        }
    }
}
