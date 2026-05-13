using NUnit.Framework;
using static System.Text.Tests.TestStrings;

namespace System.Text.Tests
{
    [TestFixture]
    public class TrimTests
    {
        [Test]
        public void TestContainingWhiteSpaces()
        {
            StringBuilder sb;
            sb = new StringBuilder(LeadingWhiteSpaces).Trim();
            Assert.AreEqual(sb.ToString(), LeadingWhiteSpaces.Trim());
            sb = new StringBuilder(TrailingWhiteSpaces).Trim();
            Assert.AreEqual(sb.ToString(), TrailingWhiteSpaces.Trim());
            sb = new StringBuilder(LeadingAndTrailingWhiteSpaces).Trim();
            Assert.AreEqual(sb.ToString(), LeadingAndTrailingWhiteSpaces.Trim());
        }

        [Test]
        public void TestContainingWhiteSpacesNullTrimChars()
        {
            char[] nullTrimChars = null;
            StringBuilder sb;
            sb = new StringBuilder(LeadingWhiteSpaces).Trim(nullTrimChars);
            Assert.AreEqual(sb.ToString(), LeadingWhiteSpaces.Trim(nullTrimChars));
            sb = new StringBuilder(TrailingWhiteSpaces).Trim(nullTrimChars);
            Assert.AreEqual(sb.ToString(), TrailingWhiteSpaces.Trim(nullTrimChars));
            sb = new StringBuilder(LeadingAndTrailingWhiteSpaces).Trim(nullTrimChars);
            Assert.AreEqual(sb.ToString(), LeadingAndTrailingWhiteSpaces.Trim(nullTrimChars));
        }

        [Test]
        public void TestContainingWhiteSpacesEmptyTrimChars()
        {
            StringBuilder sb;
            sb = new StringBuilder(LeadingWhiteSpaces).Trim(new char[] {});
            Assert.AreEqual(sb.ToString(), LeadingWhiteSpaces.Trim(new char[] { }));
            sb = new StringBuilder(TrailingWhiteSpaces).Trim(new char[] { });
            Assert.AreEqual(sb.ToString(), TrailingWhiteSpaces.Trim(new char[] { }));
            sb = new StringBuilder(LeadingAndTrailingWhiteSpaces).Trim(new char[] { });
            Assert.AreEqual(sb.ToString(), LeadingAndTrailingWhiteSpaces.Trim(new char[] { }));
        }

        [Test]
        public void TestNotContainingWhiteSpaces()
        {
            StringBuilder sb = new StringBuilder(WhiteSpacesTrimmed).Trim();
            Assert.AreEqual(sb.ToString(), WhiteSpacesTrimmed);
        }
        
        [Test]
        public void TestContainingCharacters()
        {
            StringBuilder sb;
            sb = new StringBuilder(LeadingSymbols).Trim(SymbolsToTrim);
            Assert.AreEqual(sb.ToString(), LeadingSymbols.Trim(SymbolsToTrim));
            sb = new StringBuilder(TrailingSymbols).Trim(SymbolsToTrim);
            Assert.AreEqual(sb.ToString(), TrailingSymbols.Trim(SymbolsToTrim));
            sb = new StringBuilder(LeadingAndTrailingSymbols).Trim(SymbolsToTrim);
            Assert.AreEqual(sb.ToString(), LeadingAndTrailingSymbols.Trim(SymbolsToTrim));
        }

        [Test]
        public void TestNotContainingCharacters()
        {
            StringBuilder sb = new StringBuilder(SymbolsTrimmed).Trim(SymbolsToTrim);
            Assert.AreEqual(sb.ToString(), SymbolsTrimmed);
        }

        [Test]
        public void TestEmpty()
        {
            StringBuilder sb = new StringBuilder(string.Empty).Trim();
            Assert.AreEqual(sb.ToString(), string.Empty);
        }

        [Test]
        public void TrimWhiteSpaces()
        {
            StringBuilder sb = new StringBuilder(WhiteSpaces).Trim();
            Assert.AreEqual(sb.ToString(), string.Empty);
        }
    }
}
