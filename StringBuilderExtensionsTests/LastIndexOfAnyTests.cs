using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace System.Text.Tests
{
    public class LastIndexOfAnyTests
    {
        [Test]
        public void TestContainingCharacters()
        {
            StringBuilder sb;
            sb = new StringBuilder(TestStrings.ToIndexOfChars1);
            Assert.AreEqual(sb.LastIndexOfAny(TestStrings.SymbolsToTrim), TestStrings.ToIndexOfChars1.LastIndexOfAny(TestStrings.SymbolsToTrim));
            sb = new StringBuilder(TestStrings.ToIndexOfChars2);
            Assert.AreEqual(sb.LastIndexOfAny(TestStrings.SymbolsToTrim), TestStrings.ToIndexOfChars2.LastIndexOfAny(TestStrings.SymbolsToTrim));
            sb = new StringBuilder(TestStrings.ToIndexOfChars2);
            Assert.AreEqual(sb.LastIndexOfAny(TestStrings.SymbolsToTrim, 22), TestStrings.ToIndexOfChars2.LastIndexOfAny(TestStrings.SymbolsToTrim, 22));
            sb = new StringBuilder(TestStrings.ToIndexOfChars2);
            Assert.AreEqual(sb.LastIndexOfAny(TestStrings.SymbolsToTrim, 22, 7), TestStrings.ToIndexOfChars2.LastIndexOfAny(TestStrings.SymbolsToTrim, 22, 7));
        }

        [Test]
        public void TestNotContainingCharacters()
        {
            StringBuilder sb;
            sb = new StringBuilder(TestStrings.LeadingAndTrailingWhiteSpaces);
            Assert.AreEqual(sb.LastIndexOfAny(TestStrings.SymbolsToTrim), TestStrings.LeadingAndTrailingWhiteSpaces.LastIndexOfAny(TestStrings.SymbolsToTrim));
            sb = new StringBuilder(TestStrings.ToIndexOfChars1);
            Assert.AreEqual(sb.LastIndexOfAny(TestStrings.SymbolsToTrim, 23), TestStrings.ToIndexOfChars1.LastIndexOfAny(TestStrings.SymbolsToTrim, 23));
            sb = new StringBuilder(TestStrings.ToIndexOfChars2);
            Assert.AreEqual(sb.LastIndexOfAny(TestStrings.SymbolsToTrim, 22, 4), TestStrings.ToIndexOfChars2.LastIndexOfAny(TestStrings.SymbolsToTrim, 22, 4));
        }

        [Test]
        public void TestEmpty()
        {
            StringBuilder sb = new StringBuilder();
            Assert.AreEqual(sb.LastIndexOfAny(TestStrings.SymbolsToTrim), -1);
        }

        [Test]
        public void TestNullAnyOf()
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.LastIndexOfAny(null);
            }
            catch (Exception ex)
            {
                Assert.IsAssignableFrom<ArgumentNullException>(ex);
            }
        }

        [Test]
        public void TestNullAnyOfIndex()
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.LastIndexOfAny(null, 22);
            }
            catch (Exception ex)
            {
                Assert.IsAssignableFrom<ArgumentNullException>(ex);
            }
        }

        [Test]
        public void TestNullAnyOfIndexCount()
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.LastIndexOfAny(null, 22, 7);
            }
            catch (Exception ex)
            {
                Assert.IsAssignableFrom<ArgumentNullException>(ex);
            }
        }

        [Test]
        public void TestIndexFirstCharacter()
        {
            StringBuilder sb;
            sb = new StringBuilder(TestStrings.ToIndexOfChars1);
            Assert.AreEqual(sb.LastIndexOfAny(TestStrings.SymbolsToTrim, 0), TestStrings.ToIndexOfChars1.LastIndexOfAny(TestStrings.SymbolsToTrim, 0));
            sb = new StringBuilder(TestStrings.ToIndexOfChars2);
            Assert.AreEqual(sb.LastIndexOfAny(TestStrings.SymbolsToTrim, 0), TestStrings.ToIndexOfChars2.LastIndexOfAny(TestStrings.SymbolsToTrim, 0));
        }

        [Test]
        public void TestIndexAfterLastCharacter()
        {
            try
            {
                StringBuilder sb = new StringBuilder(TestStrings.ToIndexOfChars1);
                sb.LastIndexOfAny(TestStrings.SymbolsToTrim, sb.Length);
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
                sb.LastIndexOfAny(TestStrings.SymbolsToTrim, sb.Length);
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
                sb.LastIndexOfAny(TestStrings.SymbolsToTrim, -1);
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
                sb.LastIndexOfAny(TestStrings.SymbolsToTrim, -1, 5);
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
                sb.LastIndexOfAny(TestStrings.SymbolsToTrim, sb.Length + 1);
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
                sb.LastIndexOfAny(TestStrings.SymbolsToTrim, sb.Length + 1, 5);
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
                sb.LastIndexOfAny(TestStrings.SymbolsToTrim, 0, -1);
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
                sb.LastIndexOfAny(TestStrings.SymbolsToTrim, -1);
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
                sb.LastIndexOfAny(TestStrings.SymbolsToTrim, 0, sb.Length + 1);
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
                sb.LastIndexOfAny(TestStrings.SymbolsToTrim, 15, 20);
            }
            catch (Exception ex)
            {
                Assert.IsAssignableFrom<ArgumentOutOfRangeException>(ex);
            }
        }
    }
}
