using NUnit.Framework;
using static System.Text.Tests.TestStrings;

namespace System.Text.Tests
{
    [TestFixture]
    public class IndexOfAnyTests
    {
        [Test]
        public void TestContainingCharacters()
        {
            StringBuilder sb;
            sb = new StringBuilder(ToIndexOfChars1);
            Assert.AreEqual(sb.IndexOfAny(SymbolsToTrim), ToIndexOfChars1.IndexOfAny(SymbolsToTrim));
            sb = new StringBuilder(ToIndexOfChars2);
            Assert.AreEqual(sb.IndexOfAny(SymbolsToTrim), ToIndexOfChars2.IndexOfAny(SymbolsToTrim));
            sb = new StringBuilder(ToIndexOfChars2);
            Assert.AreEqual(sb.IndexOfAny(SymbolsToTrim, 3), ToIndexOfChars2.IndexOfAny(SymbolsToTrim, 3));
            sb = new StringBuilder(ToIndexOfChars2);
            Assert.AreEqual(sb.IndexOfAny(SymbolsToTrim, 3, 7), ToIndexOfChars2.IndexOfAny(SymbolsToTrim, 3, 7));
        }

        [Test]
        public void TestNotContainingCharacters()
        {
            StringBuilder sb;
            sb = new StringBuilder(LeadingAndTrailingWhiteSpaces);
            Assert.AreEqual(sb.IndexOfAny(SymbolsToTrim), LeadingAndTrailingWhiteSpaces.IndexOfAny(SymbolsToTrim));
            sb = new StringBuilder(ToIndexOfChars1);
            Assert.AreEqual(sb.IndexOfAny(SymbolsToTrim, 23), ToIndexOfChars1.IndexOfAny(SymbolsToTrim, 23));
            sb = new StringBuilder(ToIndexOfChars2);
            Assert.AreEqual(sb.IndexOfAny(SymbolsToTrim, 3, 4), ToIndexOfChars2.IndexOfAny(SymbolsToTrim, 3, 4));
        }

        [Test]
        public void TestEmpty()
        {
            StringBuilder sb = new StringBuilder();
            Assert.AreEqual(sb.IndexOfAny(SymbolsToTrim), -1);
        }

        [Test]
        public void TestNullAnyOf()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                StringBuilder sb = new StringBuilder();
                sb.IndexOfAny(Null);
            }
            );
        }

        [Test]
        public void TestNullAnyOfIndex()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                StringBuilder sb = new StringBuilder();
                sb.IndexOfAny(Null, 3);
            }
            );
        }

        [Test]
        public void TestNullAnyOfIndexCount()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                StringBuilder sb = new StringBuilder();
                sb.IndexOfAny(Null, 3, 7);
            }
            );
        }

        [Test]
        public void TestIndexLastCharacter()
        {
            StringBuilder sb;
            sb = new StringBuilder(ToIndexOfChars1);
            Assert.AreEqual(sb.IndexOfAny(SymbolsToTrim, sb.Length - 1), ToIndexOfChars1.IndexOfAny(SymbolsToTrim, sb.Length - 1));
            sb = new StringBuilder(ToIndexOfChars2);
            Assert.AreEqual(sb.IndexOfAny(SymbolsToTrim, sb.Length - 1), ToIndexOfChars2.IndexOfAny(SymbolsToTrim, sb.Length - 1));
        }

        [Test]
        public void TestIndexAfterLastCharacter()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(ToIndexOfChars1);
                sb.IndexOfAny(SymbolsToTrim, sb.Length);
            }
            );
        }

        [Test]
        public void TestIndexAfterLastCharacterWithCount()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(ToIndexOfChars2);
                sb.IndexOfAny(SymbolsToTrim, sb.Length);
            }
            );
        }

        [Test]
        public void TestIndexLessThanZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(Composition1);
                sb.IndexOfAny(SymbolsToTrim, -1);
            }
            );
        }

        [Test]
        public void TestIndexLessThanZeroWithCount()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(Composition1);
                sb.IndexOfAny(SymbolsToTrim, -1, 5);
            }
            );
        }

        [Test]
        public void TestIndexGreaterThanMaximum()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(Composition1);
                sb.IndexOfAny(SymbolsToTrim, sb.Length + 1);
            }
            );
        }

        [Test]
        public void TestIndexGreaterThanMaximumWithCount()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(Composition1);
                sb.IndexOfAny(SymbolsToTrim, sb.Length + 1, 5);
            }
            );
        }

        [Test]
        public void TestCountLessThanZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(Composition1);
                sb.IndexOfAny(SymbolsToTrim, 0, -1);
            }
            );
        }

        [Test]
        public void TestCountEqualsZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(Composition1);
                sb.IndexOfAny(SymbolsToTrim, -1);
            }
            );
        }

        [Test]
        public void TestCountGreaterThanMaximum()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(Composition1);
                sb.IndexOfAny(SymbolsToTrim, 0, sb.Length + 1);
            }
            );
        }

        [Test]
        public void TestIndexPlusCountGreaterThanLength()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(Composition1);
                sb.IndexOfAny(SymbolsToTrim, 5, 20);
            }
            );
        }
    }
}
