using NUnit.Framework;
using static System.Text.Tests.TestStrings;

namespace System.Text.Tests
{
    [TestFixture]
    public class TrimStartTests
    {
        [Test]
        public void TestContainingWhiteSpaces()
        {
            StringBuilder sb;
            sb = new StringBuilder(LeadingWhiteSpaces).TrimStart();
            Assert.AreEqual(sb.ToString(), LeadingWhiteSpaces.TrimStart());
            sb = new StringBuilder(TrailingWhiteSpaces).TrimStart();
            Assert.AreEqual(sb.ToString(), TrailingWhiteSpaces.TrimStart());
            sb = new StringBuilder(LeadingAndTrailingWhiteSpaces).TrimStart();
            Assert.AreEqual(sb.ToString(), LeadingAndTrailingWhiteSpaces.TrimStart());
        }

        [Test]
        public void TestContainingWhiteSpacesNullTrimChars()
        {
            char[] nullTrimChars = null;
            StringBuilder sb;
            sb = new StringBuilder(LeadingWhiteSpaces).TrimStart(nullTrimChars);
            Assert.AreEqual(sb.ToString(), LeadingWhiteSpaces.TrimStart(nullTrimChars));
            sb = new StringBuilder(TrailingWhiteSpaces).TrimStart(nullTrimChars);
            Assert.AreEqual(sb.ToString(), TrailingWhiteSpaces.TrimStart(nullTrimChars));
            sb = new StringBuilder(LeadingAndTrailingWhiteSpaces).TrimStart(nullTrimChars);
            Assert.AreEqual(sb.ToString(), LeadingAndTrailingWhiteSpaces.TrimStart(nullTrimChars));
        }

        [Test]
        public void TestContainingWhiteSpacesEmptyTrimChars()
        {
            StringBuilder sb;
            sb = new StringBuilder(LeadingWhiteSpaces).TrimStart(new char[] { });
            Assert.AreEqual(sb.ToString(), LeadingWhiteSpaces.TrimStart(new char[] { }));
            sb = new StringBuilder(TrailingWhiteSpaces).TrimStart(new char[] { });
            Assert.AreEqual(sb.ToString(), TrailingWhiteSpaces.TrimStart(new char[] { }));
            sb = new StringBuilder(LeadingAndTrailingWhiteSpaces).TrimStart(new char[] { });
            Assert.AreEqual(sb.ToString(), LeadingAndTrailingWhiteSpaces.TrimStart(new char[] { }));
        }

        [Test]
        public void TestNotContainingWhiteSpaces()
        {
            StringBuilder sb;
            sb = new StringBuilder(WhiteSpacesTrimmed).TrimStart();
            Assert.AreEqual(sb.ToString(), WhiteSpacesTrimmed);
        }

        [Test]
        public void TestContainingCharacters()
        {
            StringBuilder sb;
            sb = new StringBuilder(LeadingSymbols).TrimStart(SymbolsToTrim);
            Assert.AreEqual(sb.ToString(), LeadingSymbols.TrimStart(SymbolsToTrim));
            sb = new StringBuilder(TrailingSymbols).TrimStart(SymbolsToTrim);
            Assert.AreEqual(sb.ToString(), TrailingSymbols.TrimStart(SymbolsToTrim));
            sb = new StringBuilder(LeadingAndTrailingSymbols).TrimStart(SymbolsToTrim);
            Assert.AreEqual(sb.ToString(), LeadingAndTrailingSymbols.TrimStart(SymbolsToTrim));
        }

        [Test]
        public void TestNotContainingCharacters()
        {
            StringBuilder sb;
            sb = new StringBuilder(SymbolsTrimmed).TrimStart(SymbolsToTrim);
            Assert.AreEqual(sb.ToString(), SymbolsTrimmed);
        }

        [Test]
        public void TestEmpty()
        {
            StringBuilder sb;
            sb = new StringBuilder(string.Empty).TrimStart();
            Assert.AreEqual(sb.ToString(), string.Empty);
        }

        [Test]
        public void TrimWhiteSpaces()
        {
            StringBuilder sb = new StringBuilder(WhiteSpaces).TrimStart();
            Assert.AreEqual(sb.ToString(), string.Empty);
        }
    }
}
