using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace System.Text.Tests
{    
    public class TrimEndTests
    {
        [Test]
        public void TestContainingWhiteSpaces()
        {
            StringBuilder sb;
            sb = new StringBuilder(TestStrings.LeadingWhiteSpaces).TrimEnd();
            Assert.AreEqual(sb.ToString(), TestStrings.LeadingWhiteSpaces.TrimEnd());
            sb = new StringBuilder(TestStrings.TrailingWhiteSpaces).TrimEnd();
            Assert.AreEqual(sb.ToString(), TestStrings.TrailingWhiteSpaces.TrimEnd());
            sb = new StringBuilder(TestStrings.LeadingAndTrailingWhiteSpaces).TrimEnd();
            Assert.AreEqual(sb.ToString(), TestStrings.LeadingAndTrailingWhiteSpaces.TrimEnd());
        }

        [Test]
        public void TestContainingWhiteSpacesNullTrimChars()
        {
            StringBuilder sb;
            sb = new StringBuilder(TestStrings.LeadingWhiteSpaces).TrimEnd(null);
            Assert.AreEqual(sb.ToString(), TestStrings.LeadingWhiteSpaces.TrimEnd(null));
            sb = new StringBuilder(TestStrings.TrailingWhiteSpaces).TrimEnd(null);
            Assert.AreEqual(sb.ToString(), TestStrings.TrailingWhiteSpaces.TrimEnd(null));
            sb = new StringBuilder(TestStrings.LeadingAndTrailingWhiteSpaces).TrimEnd(null);
            Assert.AreEqual(sb.ToString(), TestStrings.LeadingAndTrailingWhiteSpaces.TrimEnd(null));
        }

        [Test]
        public void TestContainingWhiteSpacesEmptyTrimChars()
        {
            StringBuilder sb;
            sb = new StringBuilder(TestStrings.LeadingWhiteSpaces).TrimEnd(new char[] { });
            Assert.AreEqual(sb.ToString(), TestStrings.LeadingWhiteSpaces.TrimEnd(new char[] { }));
            sb = new StringBuilder(TestStrings.TrailingWhiteSpaces).TrimEnd(new char[] { });
            Assert.AreEqual(sb.ToString(), TestStrings.TrailingWhiteSpaces.TrimEnd(new char[] { }));
            sb = new StringBuilder(TestStrings.LeadingAndTrailingWhiteSpaces).TrimEnd(new char[] { });
            Assert.AreEqual(sb.ToString(), TestStrings.LeadingAndTrailingWhiteSpaces.TrimEnd(new char[] { }));
        }

        [Test]
        public void TestNotContainingWhiteSpaces()
        {
            StringBuilder sb;
            sb = new StringBuilder(TestStrings.WhiteSpacesTrimmed).TrimEnd();
            Assert.AreEqual(sb.ToString(), TestStrings.WhiteSpacesTrimmed);
        }

        [Test]
        public void TestContainingCharacters()
        {
            StringBuilder sb;
            sb = new StringBuilder(TestStrings.LeadingSymbols).TrimEnd(TestStrings.SymbolsToTrim);
            Assert.AreEqual(sb.ToString(), TestStrings.LeadingSymbols.TrimEnd(TestStrings.SymbolsToTrim));
            sb = new StringBuilder(TestStrings.TrailingSymbols).TrimEnd(TestStrings.SymbolsToTrim);
            Assert.AreEqual(sb.ToString(), TestStrings.TrailingSymbols.TrimEnd(TestStrings.SymbolsToTrim));
            sb = new StringBuilder(TestStrings.LeadingAndTrailingSymbols).TrimEnd(TestStrings.SymbolsToTrim);
            Assert.AreEqual(sb.ToString(), TestStrings.LeadingAndTrailingSymbols.TrimEnd(TestStrings.SymbolsToTrim));
        }

        [Test]
        public void TestNotContainingCharacters()
        {
            StringBuilder sb;
            sb = new StringBuilder(TestStrings.SymbolsTrimmed).TrimEnd(TestStrings.SymbolsToTrim);
            Assert.AreEqual(sb.ToString(), TestStrings.SymbolsTrimmed);
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
            StringBuilder sb = new StringBuilder(TestStrings.WhiteSpaces).TrimEnd();
            Assert.AreEqual(sb.ToString(), string.Empty);
        }
    }
}
