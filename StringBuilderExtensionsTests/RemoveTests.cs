using NUnit.Framework;

namespace System.Text.Tests
{
    [TestFixture]
    public class RemoveTests
    {
        [Test]
        public void TestContainingCharacters()
        {
            StringBuilder sb;
            sb = new StringBuilder(TestStrings.LeadingAndTrailingWhiteSpaces).Remove(' ');
            Assert.AreEqual(sb.ToString(), TestStrings.WhiteSpacesRemoved);
            sb = new StringBuilder(TestStrings.LeadingAndTrailingSymbols).Remove(TestStrings.SymbolsToTrim);
            Assert.AreEqual(sb.ToString(), TestStrings.SymbolsRemoved);
        }

        [Test]
        public void TestNotContainingCharacters()
        {
            StringBuilder sb;
            sb = new StringBuilder(TestStrings.LeadingAndTrailingWhiteSpaces).Remove(TestStrings.SymbolsToTrim);
            Assert.AreEqual(sb.ToString(), TestStrings.LeadingAndTrailingWhiteSpaces);
            sb = new StringBuilder(TestStrings.LeadingAndTrailingSymbols).Remove(' ');
            Assert.AreEqual(sb.ToString(), TestStrings.LeadingAndTrailingSymbols);
        }

        [Test]
        public void TestByStartIndex()
        {
            StringBuilder sb = new StringBuilder(TestStrings.Composition1 + TestStrings.Composition2).Remove(TestStrings.Composition1.Length);
            Assert.AreEqual(sb.ToString(), TestStrings.Composition1);
        }

        [Test]
        public void TestEmpty()
        {
            StringBuilder sb = new StringBuilder().Remove(' ');
            Assert.AreEqual(sb.ToString(), string.Empty);
        }

        [Test]
        public void TestRemoveAllCharacters()
        {
            StringBuilder sb = new StringBuilder(TestStrings.Composition1).Remove(0);
            Assert.AreEqual(sb.ToString(), string.Empty);
        }

        [Test]
        public void TestRemoveLastCharacter()
        {
            StringBuilder sb = new StringBuilder(TestStrings.Composition1).Remove(TestStrings.Composition1.Length - 1);
            Assert.AreEqual(sb.ToString(), TestStrings.Composition1.Substring(0, TestStrings.Composition1.Length - 1));
        }

        [Test]
        public void TestIndexLessThanZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(TestStrings.Composition1).Remove(-1);
            }
            );
        }

        [Test]
        public void TestIndexGreaterThanMaximum()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(TestStrings.Composition1);
                sb.Remove(sb.Length);
            }
            );
        }

        [Test]
        public void TestNullRemoveChars()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                StringBuilder sb = new StringBuilder().Remove(null);
            }
            );
        }
    }
}
