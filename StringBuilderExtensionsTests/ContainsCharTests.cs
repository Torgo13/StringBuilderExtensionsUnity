using NUnit.Framework;
using static System.Text.Tests.TestStrings;

namespace System.Text.Tests
{
    [TestFixture]
    public class ContainsCharTests
    {
        [Test]
        public void TestContainingCharacters()
        {
            StringBuilder sb;
            sb = new StringBuilder(ToIndexOfChars1);
            foreach (char symbol in SymbolsToTrim)
            {
                Assert.AreEqual(sb.Contains(symbol), ToIndexOfChars1.Contains(symbol));
            }
            sb = new StringBuilder(ToIndexOfChars2);
            foreach (char symbol in SymbolsToTrim)
            {
                Assert.AreEqual(sb.Contains(symbol), ToIndexOfChars2.Contains(symbol));
            }
        }

        [Test]
        public void TestNotContainingCharacters()
        {
            StringBuilder sb;
            sb = new StringBuilder(LeadingAndTrailingWhiteSpaces);
            foreach (char symbol in SymbolsToTrim)
            {
                Assert.AreEqual(sb.Contains(symbol), LeadingAndTrailingWhiteSpaces.Contains(symbol));
            }
        }

        [Test]
        public void TestEmpty()
        {
            StringBuilder sb = new StringBuilder();
            foreach (char symbol in SymbolsToTrim)
            {
                Assert.AreEqual(sb.Contains(symbol), false);
            }
        }
    }
}
