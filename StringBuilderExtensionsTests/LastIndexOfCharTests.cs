using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace System.Text.Tests
{
    public class LastIndexOfCharTests
    {
        [Test]
        public void TestContainingCharacters()
        {
            StringBuilder sb;
            sb = new StringBuilder(TestStrings.ToIndexOfChars1);
            foreach (char symbol in TestStrings.SymbolsToTrim)
            {
                Assert.AreEqual(sb.LastIndexOf(symbol), TestStrings.ToIndexOfChars1.LastIndexOf(symbol));
            }
            sb = new StringBuilder(TestStrings.ToIndexOfChars2);
            foreach (char symbol in TestStrings.SymbolsToTrim)
            {
                Assert.AreEqual(sb.LastIndexOf(symbol), TestStrings.ToIndexOfChars2.LastIndexOf(symbol));
            }
            sb = new StringBuilder(TestStrings.ToIndexOfChars2);
            foreach (char symbol in TestStrings.SymbolsToTrim)
            {
                Assert.AreEqual(sb.LastIndexOf(symbol, 22), TestStrings.ToIndexOfChars2.LastIndexOf(symbol, 22));
            }
            sb = new StringBuilder(TestStrings.ToIndexOfChars2);
            foreach (char symbol in TestStrings.SymbolsToTrim)
            {
                Assert.AreEqual(sb.LastIndexOf(symbol, 22, 7), TestStrings.ToIndexOfChars2.LastIndexOf(symbol, 22, 7));
            }
        }

        [Test]
        public void TestNotContainingCharacters()
        {
            StringBuilder sb;
            sb = new StringBuilder(TestStrings.LeadingAndTrailingWhiteSpaces);
            foreach (char symbol in TestStrings.SymbolsToTrim)
            {
                Assert.AreEqual(sb.LastIndexOf(symbol), TestStrings.LeadingAndTrailingWhiteSpaces.LastIndexOf(symbol));
            }
            sb = new StringBuilder(TestStrings.ToIndexOfChars1);
            foreach (char symbol in TestStrings.SymbolsToTrim)
            {
                Assert.AreEqual(sb.LastIndexOf(symbol, 23), TestStrings.ToIndexOfChars1.LastIndexOf(symbol, 23));
            }
            sb = new StringBuilder(TestStrings.ToIndexOfChars2);
            foreach (char symbol in TestStrings.SymbolsToTrim)
            {
                Assert.AreEqual(sb.LastIndexOf(symbol, 22, 4), TestStrings.ToIndexOfChars2.LastIndexOf(symbol, 22, 4));
            }
        }

        [Test]
        public void TestEmpty()
        {
            StringBuilder sb = new StringBuilder();
            foreach (char symbol in TestStrings.SymbolsToTrim)
            {
                Assert.AreEqual(sb.LastIndexOf(symbol), -1);
            }
            foreach (char symbol in TestStrings.SymbolsToTrim)
            {
                Assert.AreEqual(sb.LastIndexOf(symbol, 22), -1);
            }
            foreach (char symbol in TestStrings.SymbolsToTrim)
            {
                Assert.AreEqual(sb.LastIndexOf(symbol, 22, 7), -1);
            }
        }

        [Test]
        public void TestIndexFirstCharacter()
        {
            StringBuilder sb;
            sb = new StringBuilder(TestStrings.ToIndexOfChars1);
            foreach (char symbol in TestStrings.SymbolsToTrim)
            {
                Assert.AreEqual(sb.LastIndexOf(symbol, 0), TestStrings.ToIndexOfChars1.LastIndexOf(symbol, 0));
            }
            sb = new StringBuilder(TestStrings.ToIndexOfChars2);
            foreach (char symbol in TestStrings.SymbolsToTrim)
            {
                Assert.AreEqual(sb.LastIndexOf(symbol, 0), TestStrings.ToIndexOfChars2.LastIndexOf(symbol, 0));
            }
        }

        [Test]
        public void TestIndexAfterLastCharacter()
        {
            try
            {
                StringBuilder sb = new StringBuilder(TestStrings.ToIndexOfChars1);
                sb.LastIndexOf(TestStrings.SymbolsToTrim[0], sb.Length);
            }
            catch (Exception ex)
            {
                Assert.IsAssignableFrom<ArgumentOutOfRangeException>(ex);
            }
        }

        [Test]
        public void TestIndexAfterLastCharacterWithCount()
        {
            try
            {
                StringBuilder sb = new StringBuilder(TestStrings.ToIndexOfChars2);
                sb.LastIndexOf(TestStrings.SymbolsToTrim[0], sb.Length);
            }
            catch (Exception ex)
            {
                Assert.IsAssignableFrom<ArgumentOutOfRangeException>(ex);
            }
        }

        [Test]
        public void TestIndexLessThanZero()
        {
            try
            {
                StringBuilder sb = new StringBuilder(TestStrings.Composition1);
                sb.LastIndexOf(TestStrings.SymbolsToTrim[0], -1);
            }
            catch (Exception ex)
            {
                Assert.IsAssignableFrom<ArgumentOutOfRangeException>(ex);
            }
        }

        [Test]
        public void TestIndexLessThanZeroWithCount()
        {
            try
            {
                StringBuilder sb = new StringBuilder(TestStrings.Composition1);
                sb.LastIndexOf(TestStrings.SymbolsToTrim[0], -1, 5);
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
                sb.LastIndexOf(TestStrings.SymbolsToTrim[0], sb.Length + 1);
            }
            catch (Exception ex)
            {
                Assert.IsAssignableFrom<ArgumentOutOfRangeException>(ex);
            }
        }

        [Test]
        public void TestIndexGreaterThanMaximumWithCount()
        {
            try
            {
                StringBuilder sb = new StringBuilder(TestStrings.Composition1);
                sb.LastIndexOf(TestStrings.SymbolsToTrim[0], sb.Length + 1, 5);
            }
            catch (Exception ex)
            {
                Assert.IsAssignableFrom<ArgumentOutOfRangeException>(ex);
            }
        }

        [Test]
        public void TestCountLessThanZero()
        {
            try
            {
                StringBuilder sb = new StringBuilder(TestStrings.Composition1);
                sb.LastIndexOf(TestStrings.SymbolsToTrim[0], 0, -1);
            }
            catch (Exception ex)
            {
                Assert.IsAssignableFrom<ArgumentOutOfRangeException>(ex);
            }
        }

        [Test]
        public void TestCountEqualsZero()
        {
            try
            {
                StringBuilder sb = new StringBuilder(TestStrings.Composition1);
                sb.LastIndexOf(TestStrings.SymbolsToTrim[0], -1);
            }
            catch (Exception ex)
            {
                Assert.IsAssignableFrom<ArgumentOutOfRangeException>(ex);
            }
        }

        [Test]
        public void TestCountGreaterThanMaximum()
        {
            try
            {
                StringBuilder sb = new StringBuilder(TestStrings.Composition1);
                sb.LastIndexOf(TestStrings.SymbolsToTrim[0], 0, sb.Length + 1);
            }
            catch (Exception ex)
            {
                Assert.IsAssignableFrom<ArgumentOutOfRangeException>(ex);
            }
        }

        [Test]
        public void TestIndexPlusCountGreaterThanLength()
        {
            try
            {
                StringBuilder sb = new StringBuilder(TestStrings.Composition1);
                sb.LastIndexOf(TestStrings.SymbolsToTrim[0], 15, 20);
            }
            catch (Exception ex)
            {
                Assert.IsAssignableFrom<ArgumentOutOfRangeException>(ex);
            }
        }
    }
}
