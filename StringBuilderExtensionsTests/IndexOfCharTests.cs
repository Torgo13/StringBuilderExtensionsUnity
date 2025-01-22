using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace System.Text.Tests
{
    public class IndexOfCharTests
    {
        [Test]
        public void TestContainingCharacters()
        {
            StringBuilder sb;
            sb = new StringBuilder(TestStrings.ToIndexOfChars1);
            foreach (char symbol in TestStrings.SymbolsToTrim)
            {
                Assert.AreEqual(sb.IndexOf(symbol), TestStrings.ToIndexOfChars1.IndexOf(symbol));
            }
            sb = new StringBuilder(TestStrings.ToIndexOfChars2);
            foreach (char symbol in TestStrings.SymbolsToTrim)
            {
                Assert.AreEqual(sb.IndexOf(symbol), TestStrings.ToIndexOfChars2.IndexOf(symbol));
            }
            sb = new StringBuilder(TestStrings.ToIndexOfChars2);
            foreach (char symbol in TestStrings.SymbolsToTrim)
            {
                Assert.AreEqual(sb.IndexOf(symbol, 3), TestStrings.ToIndexOfChars2.IndexOf(symbol, 3));
            }
            sb = new StringBuilder(TestStrings.ToIndexOfChars2);
            foreach (char symbol in TestStrings.SymbolsToTrim)
            {
                Assert.AreEqual(sb.IndexOf(symbol, 3, 7), TestStrings.ToIndexOfChars2.IndexOf(symbol, 3, 7));
            }
        }

        [Test]
        public void TestNotContainingCharacters()
        {
            StringBuilder sb;
            sb = new StringBuilder(TestStrings.LeadingAndTrailingWhiteSpaces);
            foreach (char symbol in TestStrings.SymbolsToTrim)
            {
                Assert.AreEqual(sb.IndexOf(symbol), TestStrings.LeadingAndTrailingWhiteSpaces.IndexOf(symbol));
            }
            sb = new StringBuilder(TestStrings.ToIndexOfChars1);
            foreach (char symbol in TestStrings.SymbolsToTrim)
            {
                Assert.AreEqual(sb.IndexOf(symbol, 23), TestStrings.ToIndexOfChars1.IndexOf(symbol, 23));
            }
            sb = new StringBuilder(TestStrings.ToIndexOfChars2);
            foreach (char symbol in TestStrings.SymbolsToTrim)
            {
                Assert.AreEqual(sb.IndexOf(symbol, 3, 4), TestStrings.ToIndexOfChars2.IndexOf(symbol, 3, 4));
            }
        }

        [Test]
        public void TestEmpty()
        {
            StringBuilder sb = new StringBuilder();
            foreach (char symbol in TestStrings.SymbolsToTrim)
            {
                Assert.AreEqual(sb.IndexOf(symbol), -1);
            }
            foreach (char symbol in TestStrings.SymbolsToTrim)
            {
                Assert.AreEqual(sb.IndexOf(symbol, 3), -1);
            }
            foreach (char symbol in TestStrings.SymbolsToTrim)
            {
                Assert.AreEqual(sb.IndexOf(symbol, 3, 7), -1);
            }
        }

        [Test]
        public void TestIndexLastCharacter()
        {
            StringBuilder sb;
            sb = new StringBuilder(TestStrings.ToIndexOfChars1);
            foreach (char symbol in TestStrings.SymbolsToTrim)
            {
                Assert.AreEqual(sb.IndexOf(symbol, sb.Length - 1), TestStrings.ToIndexOfChars1.IndexOf(symbol, sb.Length - 1));
            }
            sb = new StringBuilder(TestStrings.ToIndexOfChars2);
            foreach (char symbol in TestStrings.SymbolsToTrim)
            {
                Assert.AreEqual(sb.IndexOf(symbol, sb.Length - 1), TestStrings.ToIndexOfChars2.IndexOf(symbol, sb.Length - 1));
            }
        }

        [Test]
        public void TestIndexAfterLastCharacter()
        {
            try
            {
                StringBuilder sb = new StringBuilder(TestStrings.ToIndexOfChars1);
                sb.IndexOf(TestStrings.SymbolsToTrim[0], sb.Length);
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
                sb.IndexOf(TestStrings.SymbolsToTrim[0], sb.Length);
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
                sb.IndexOf(TestStrings.SymbolsToTrim[0], -1);
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
                sb.IndexOf(TestStrings.SymbolsToTrim[0], -1, 5);
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
                sb.IndexOf(TestStrings.SymbolsToTrim[0], sb.Length + 1);
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
                sb.IndexOf(TestStrings.SymbolsToTrim[0], sb.Length + 1, 5);
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
                sb.IndexOf(TestStrings.SymbolsToTrim[0], 0, -1);
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
                sb.IndexOf(TestStrings.SymbolsToTrim[0], -1);
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
                sb.IndexOf(TestStrings.SymbolsToTrim[0], 0, sb.Length + 1);
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
                sb.IndexOf(TestStrings.SymbolsToTrim[0], 5, 20);
            }
            catch (Exception ex)
            {
                Assert.IsAssignableFrom<ArgumentOutOfRangeException>(ex);
            }
        }
    }
}
