using NUnit.Framework;
using static System.Text.Tests.TestStrings;

namespace System.Text.Tests
{
    [TestFixture]
    public class TrimEndTests
    {
        [Test]
        public void TestContainingWhiteSpaces()
        {
            StringBuilder sb;
            sb = new StringBuilder(LeadingWhiteSpaces).TrimEnd();
            Assert.AreEqual(sb.ToString(), LeadingWhiteSpaces.TrimEnd());
            sb = new StringBuilder(TrailingWhiteSpaces).TrimEnd();
            Assert.AreEqual(sb.ToString(), TrailingWhiteSpaces.TrimEnd());
            sb = new StringBuilder(LeadingAndTrailingWhiteSpaces).TrimEnd();
            Assert.AreEqual(sb.ToString(), LeadingAndTrailingWhiteSpaces.TrimEnd());
        }

        [Test]
        public void TestContainingWhiteSpacesNullTrimChars()
        {
            char[] nullTrimChars = null;
            StringBuilder sb;
            sb = new StringBuilder(LeadingWhiteSpaces).TrimEnd(nullTrimChars);
            Assert.AreEqual(sb.ToString(), LeadingWhiteSpaces.TrimEnd(nullTrimChars));
            sb = new StringBuilder(TrailingWhiteSpaces).TrimEnd(nullTrimChars);
            Assert.AreEqual(sb.ToString(), TrailingWhiteSpaces.TrimEnd(nullTrimChars));
            sb = new StringBuilder(LeadingAndTrailingWhiteSpaces).TrimEnd(nullTrimChars);
            Assert.AreEqual(sb.ToString(), LeadingAndTrailingWhiteSpaces.TrimEnd(nullTrimChars));
        }

        [Test]
        public void TestContainingWhiteSpacesEmptyTrimChars()
        {
            StringBuilder sb;
            sb = new StringBuilder(LeadingWhiteSpaces).TrimEnd(new char[] { });
            Assert.AreEqual(sb.ToString(), LeadingWhiteSpaces.TrimEnd(new char[] { }));
            sb = new StringBuilder(TrailingWhiteSpaces).TrimEnd(new char[] { });
            Assert.AreEqual(sb.ToString(), TrailingWhiteSpaces.TrimEnd(new char[] { }));
            sb = new StringBuilder(LeadingAndTrailingWhiteSpaces).TrimEnd(new char[] { });
            Assert.AreEqual(sb.ToString(), LeadingAndTrailingWhiteSpaces.TrimEnd(new char[] { }));
        }

        [Test]
        public void TestNotContainingWhiteSpaces()
        {
            StringBuilder sb;
            sb = new StringBuilder(WhiteSpacesTrimmed).TrimEnd();
            Assert.AreEqual(sb.ToString(), WhiteSpacesTrimmed);
        }

        [Test]
        public void TestContainingCharacters()
        {
            StringBuilder sb;
            sb = new StringBuilder(LeadingSymbols).TrimEnd(SymbolsToTrim);
            Assert.AreEqual(sb.ToString(), LeadingSymbols.TrimEnd(SymbolsToTrim));
            sb = new StringBuilder(TrailingSymbols).TrimEnd(SymbolsToTrim);
            Assert.AreEqual(sb.ToString(), TrailingSymbols.TrimEnd(SymbolsToTrim));
            sb = new StringBuilder(LeadingAndTrailingSymbols).TrimEnd(SymbolsToTrim);
            Assert.AreEqual(sb.ToString(), LeadingAndTrailingSymbols.TrimEnd(SymbolsToTrim));
        }

        [Test]
        public void TestNotContainingCharacters()
        {
            StringBuilder sb;
            sb = new StringBuilder(SymbolsTrimmed).TrimEnd(SymbolsToTrim);
            Assert.AreEqual(sb.ToString(), SymbolsTrimmed);
        }

        [Test]
        public void TestEmpty()
        {
            StringBuilder sb;
            sb = new StringBuilder(string.Empty).TrimEnd();
            Assert.AreEqual(sb.ToString(), string.Empty);
        }

        [Test]
        public void TrimWhiteSpaces()
        {
            StringBuilder sb = new StringBuilder(WhiteSpaces).TrimEnd();
            Assert.AreEqual(sb.ToString(), string.Empty);
        }
    }
}
