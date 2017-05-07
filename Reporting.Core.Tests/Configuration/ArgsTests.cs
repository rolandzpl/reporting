using NUnit.Framework;
using System.Linq;

namespace Reporting.Configuration
{
    [TestFixture]
    class ArgsTests
    {
        [Test]
        public void One_ArgExists_ReturnsValue()
        {
            var args = new Args("--sampleParameter=1");

            var result = args.One<int>("sampleParameter");

            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void Switch_ArgExists_ReturnsValue()
        {
            var args = new Args("--sample-switch");

            var result = args.Switch("sample-switch");

            Assert.That(result, Is.True);
        }

        [Test]
        public void One_ArgNotExists_ThrowsArgumentNotFountException()
        {
            var args = new Args();

            Assert.Throws<ArgumentNotFountException>(
                () => args.One<int>("sampleParameter"));
        }

        [Test]
        public void Has_ArgExists_ReturnsTrue()
        {
            var args = new Args("--sampleParameter=1");

            var result = args.Has<int>("sampleParameter");

            Assert.That(result, Is.True);
        }

        [Test]
        public void Has_ThreeArgsExists_ReturnsTrue()
        {
            var args = new Args("--x=1", "--x=1", "--x=1");

            var result = args.Has<int>("x");

            Assert.That(result, Is.True);
        }

        [Test]
        public void Has_ArgNotExists_ReturnsFalse()
        {
            var args = new Args();

            var result = args.Has<int>("sampleParameter");

            Assert.That(result, Is.False);
        }

        [Test]
        public void Many_ThreeArgsExist_ReturnsThreeItems()
        {
            var args = new Args("--x=1", "--x=2", "--x=3");

            var result = args.Many<int>("x");

            Assert.That(result.Count(), Is.EqualTo(3));
        }

        [Test]
        public void Many_NoArgsExist_ThrowsArgumentNotFountException()
        {
            var args = new Args();

            Assert.Throws<ArgumentNotFountException>(
                () => args.Many<int>("x"));
        }
    }
}
