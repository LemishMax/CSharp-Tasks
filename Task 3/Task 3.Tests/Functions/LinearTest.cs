using NUnit.Framework;
using Task_3.Functions;

namespace Task_3.Tests.Functions
{

    public class LinearTest
    {
        [Test]
        public void Derivative_Linear_CorrectResultReturned()
        {
            var l1 = new Linear(7, 3);
            var expectedResult = new Linear(0, 7);
            Assert.AreEqual(expectedResult, l1.Derivative());
        }

        [Test]
        public void ValueAtThePoint_Value5_CorrectResultReturned()
        {
            var l1 = new Linear(4, -5);
            const int expectedResult = 7;
            Assert.AreEqual(expectedResult, l1.ValueAtPoint(3));
        }

        [Test]
        public void ToString_KEquals1_CorrectResultReturned()
        {
            var l1 = new Linear(1, 4);
            const string expectedResult = "x+4";
            Assert.AreEqual(expectedResult, l1.ToString());
        }

        [Test]
        public void ToString_KEquals0_CorrectResultReturned()
        {
            var l1 = new Linear(0, 4);
            const string expectedResult = "4";
            Assert.AreEqual(expectedResult, l1.ToString());
        }

        [Test]
        public void ToString_BEquals0_CorrectResultReturned()
        {
            var l1 = new Linear(7, 0);
            const string expectedResult = "7x";
            Assert.AreEqual(expectedResult, l1.ToString());
        }
        [Test]
        public void ToString_BEqualsMinus6_CorrectResultReturned()
        {
            var l1 = new Linear(7, -6);
            const string expectedResult = "7x-6";
            Assert.AreEqual(expectedResult, l1.ToString());
        }

        [Test]
        public void Equals_ComparesOneLinear_TrueReturned()
        {
            var l1 = new Linear(2, 3);
            Assert.IsTrue(l1.Equals(l1));
        }

        [Test]
        public void Equals_DifferentValues_FalseReturned()
        {
            var l1 = new Linear(2, 3);
            var l2 = new Linear(2, 4);
            Assert.IsFalse(l1.Equals(l2));
        }

        [Test]
        public void Equals_EqualsValues_TrueReturned()
        {
            var l1 = new Linear(2, 3);
            var l2 = new Linear(2, 3);
            Assert.IsTrue(l1.Equals(l2));
        }
    }
}
