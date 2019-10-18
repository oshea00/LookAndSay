using NUnit.Framework;
using sayit;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void CanFindConsecutiveDigitsInEmptyString()
        {
            var str = "";
            Assert.AreEqual(("",""),LookAndSay.NextSequence(str));
        }

        [Test]
        public void CanFindConsecutiveDigitsInNonEmptyString()
        {
            var str = "11";
            Assert.AreEqual(("21", ""), LookAndSay.NextSequence(str));
            str = "2211";
            Assert.AreEqual(("22", "11"), LookAndSay.NextSequence(str));
        }

        [Test]
        public void CanSayNextStringFromStartingString()
        {
            var str = "11";
            Assert.AreEqual("21", LookAndSay.ExpandSequence(str));
            str = "112";
            Assert.AreEqual("2112", LookAndSay.ExpandSequence(str));
        }

        [Test]
        public void CanLookAndSay()
        {
            Assert.AreEqual("1113213211", LookAndSay.Say(1, 8));
        }
    }
}