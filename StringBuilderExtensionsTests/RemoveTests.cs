using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace System.Text.Tests
{    
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
            try
            {
                StringBuilder sb = new StringBuilder(TestStrings.Composition1).Remove(-1);
            }
            catch (Exception ex)
            {
                Assert.IsAssignableFrom<ArgumentOutOfRangeException>(ex);
            }
        }

        [Test]
        public void TestIndexGreaterThanMaximum()
        {
            try
            {
                StringBuilder sb = new StringBuilder(TestStrings.Composition1);
                sb.Remove(sb.Length);
            }
            catch (Exception ex)
            {
                Assert.IsAssignableFrom<ArgumentOutOfRangeException>(ex);
            }
        }

        [Test]
        public void TestNullRemoveChars()
        {
            try
            {
                StringBuilder sb = new StringBuilder().Remove(null);
            }
            catch (Exception ex)
            {
                Assert.IsAssignableFrom<ArgumentNullException>(ex);
            }
        }
    }
}
