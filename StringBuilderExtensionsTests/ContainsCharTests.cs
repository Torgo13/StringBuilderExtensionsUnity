using NUnit.Framework;

namespace System.Text.Tests
{
    [TestFixture]
    public class ContainsCharTests
    {
        [Test]
        public void TestContainingCharacters()
        {
            StringBuilder sb;
            sb = new StringBuilder(TestStrings.ToIndexOfChars1);
            foreach (char symbol in TestStrings.SymbolsToTrim)
            {
                Assert.AreEqual(sb.Contains(symbol), TestStrings.ToIndexOfChars1.Contains(symbol));
            }
            sb = new StringBuilder(TestStrings.ToIndexOfChars2);
            foreach (char symbol in TestStrings.SymbolsToTrim)
            {
                Assert.AreEqual(sb.Contains(symbol), TestStrings.ToIndexOfChars2.Contains(symbol));
            }
        }

        [Test]
        public void TestNotContainingCharacters()
        {
            StringBuilder sb;
            sb = new StringBuilder(TestStrings.LeadingAndTrailingWhiteSpaces);
            foreach (char symbol in TestStrings.SymbolsToTrim)
            {
                Assert.AreEqual(sb.Contains(symbol), TestStrings.LeadingAndTrailingWhiteSpaces.Contains(symbol));
            }
        }

        [Test]
        public void TestEmpty()
        {
            StringBuilder sb = new StringBuilder();
            foreach (char symbol in TestStrings.SymbolsToTrim)
            {
                Assert.AreEqual(sb.Contains(symbol), false);
            }
        }
    }
}
