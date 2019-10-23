using NUnit.Framework;
using sayit;

namespace Tests
{
    public class TestsSpan : LookAndSaySpan
    {
        [Test]
        public void CanFindConsecutiveDigitsInEmptyString()
        {
            var str = "";
            Assert.AreEqual((0,'\0'), NextSequence(str));
        }

        [Test]
        public void CanFindConsecutiveDigitsInNonEmptyString()
        {
            var str = "11";
            Assert.AreEqual((2, '1'), NextSequence(str));
            str = "2211";
            Assert.AreEqual((2, '2'), NextSequence(str));
        }

        [Test]
        public void CanSayNextStringFromStartingString()
        {
            var str = "11";
            Assert.AreEqual("21", ExpandSequence(str));
            str = "112";
            Assert.AreEqual("2112", ExpandSequence(str));
        }

        [Test]
        public void CanLookAndSay()
        {
            Assert.AreEqual("11131221133112132113212221", Say(1, 11));
        }

        [Test]
        public void CanLookAndSayStartingWith9()
        {
            Assert.AreEqual("132113213221133112132123222119", Say(9, 11));
        }

        [Test]
        public void CanExploreLargeN()
        {
            var bigN = Say(1, 60); // 60 takes 4 seconds compared to 350ms...
            Assert.AreEqual(894810, bigN.Length);
        }
    }
}