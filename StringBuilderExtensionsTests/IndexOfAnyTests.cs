using NUnit.Framework;

namespace System.Text.Tests
{
    [TestFixture]
    public class IndexOfAnyTests
    {
        [Test]
        public void TestContainingCharacters()
        {
            StringBuilder sb;
            sb = new StringBuilder(TestStrings.ToIndexOfChars1);
            Assert.AreEqual(sb.IndexOfAny(TestStrings.SymbolsToTrim), TestStrings.ToIndexOfChars1.IndexOfAny(TestStrings.SymbolsToTrim));
            sb = new StringBuilder(TestStrings.ToIndexOfChars2);
            Assert.AreEqual(sb.IndexOfAny(TestStrings.SymbolsToTrim), TestStrings.ToIndexOfChars2.IndexOfAny(TestStrings.SymbolsToTrim));
            sb = new StringBuilder(TestStrings.ToIndexOfChars2);
            Assert.AreEqual(sb.IndexOfAny(TestStrings.SymbolsToTrim, 3), TestStrings.ToIndexOfChars2.IndexOfAny(TestStrings.SymbolsToTrim, 3));
            sb = new StringBuilder(TestStrings.ToIndexOfChars2);
            Assert.AreEqual(sb.IndexOfAny(TestStrings.SymbolsToTrim, 3, 7), TestStrings.ToIndexOfChars2.IndexOfAny(TestStrings.SymbolsToTrim, 3, 7));
        }

        [Test]
        public void TestNotContainingCharacters()
        {
            StringBuilder sb;
            sb = new StringBuilder(TestStrings.LeadingAndTrailingWhiteSpaces);
            Assert.AreEqual(sb.IndexOfAny(TestStrings.SymbolsToTrim), TestStrings.LeadingAndTrailingWhiteSpaces.IndexOfAny(TestStrings.SymbolsToTrim));
            sb = new StringBuilder(TestStrings.ToIndexOfChars1);
            Assert.AreEqual(sb.IndexOfAny(TestStrings.SymbolsToTrim, 23), TestStrings.ToIndexOfChars1.IndexOfAny(TestStrings.SymbolsToTrim, 23));
            sb = new StringBuilder(TestStrings.ToIndexOfChars2);
            Assert.AreEqual(sb.IndexOfAny(TestStrings.SymbolsToTrim, 3, 4), TestStrings.ToIndexOfChars2.IndexOfAny(TestStrings.SymbolsToTrim, 3, 4));
        }

        [Test]
        public void TestEmpty()
        {
            StringBuilder sb = new StringBuilder();
            Assert.AreEqual(sb.IndexOfAny(TestStrings.SymbolsToTrim), -1);
        }

        [Test]
        public void TestNullAnyOf()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                StringBuilder sb = new StringBuilder();
                sb.IndexOfAny(null);
            }
            );
        }

        [Test]
        public void TestNullAnyOfIndex()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                StringBuilder sb = new StringBuilder();
                sb.IndexOfAny(null, 3);
            }
            );
        }

        [Test]
        public void TestNullAnyOfIndexCount()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                StringBuilder sb = new StringBuilder();
                sb.IndexOfAny(null, 3, 7);
            }
            );
        }

        [Test]
        public void TestIndexLastCharacter()
        {
            StringBuilder sb;
            sb = new StringBuilder(TestStrings.ToIndexOfChars1);
            Assert.AreEqual(sb.IndexOfAny(TestStrings.SymbolsToTrim, sb.Length - 1), TestStrings.ToIndexOfChars1.IndexOfAny(TestStrings.SymbolsToTrim, sb.Length - 1));
            sb = new StringBuilder(TestStrings.ToIndexOfChars2);
            Assert.AreEqual(sb.IndexOfAny(TestStrings.SymbolsToTrim, sb.Length - 1), TestStrings.ToIndexOfChars2.IndexOfAny(TestStrings.SymbolsToTrim, sb.Length - 1));
        }

        [Test]
        public void TestIndexAfterLastCharacter()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(TestStrings.ToIndexOfChars1);
                sb.IndexOfAny(TestStrings.SymbolsToTrim, sb.Length);
            }
            );
        }

        [Test]
        public void TestIndexAfterLastCharacterWithCount()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(TestStrings.ToIndexOfChars2);
                sb.IndexOfAny(TestStrings.SymbolsToTrim, sb.Length);
            }
            );
        }

        [Test]
        public void TestIndexLessThanZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(TestStrings.Composition1);
                sb.IndexOfAny(TestStrings.SymbolsToTrim, -1);
            }
            );
        }

        [Test]
        public void TestIndexLessThanZeroWithCount()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(TestStrings.Composition1);
                sb.IndexOfAny(TestStrings.SymbolsToTrim, -1, 5);
            }
            );
        }

        [Test]
        public void TestIndexGreaterThanMaximum()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(TestStrings.Composition1);
                sb.IndexOfAny(TestStrings.SymbolsToTrim, sb.Length + 1);
            }
            );
        }

        [Test]
        public void TestIndexGreaterThanMaximumWithCount()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(TestStrings.Composition1);
                sb.IndexOfAny(TestStrings.SymbolsToTrim, sb.Length + 1, 5);
            }
            );
        }

        [Test]
        public void TestCountLessThanZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(TestStrings.Composition1);
                sb.IndexOfAny(TestStrings.SymbolsToTrim, 0, -1);
            }
            );
        }

        [Test]
        public void TestCountEqualsZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(TestStrings.Composition1);
                sb.IndexOfAny(TestStrings.SymbolsToTrim, -1);
            }
            );
        }

        [Test]
        public void TestCountGreaterThanMaximum()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(TestStrings.Composition1);
                sb.IndexOfAny(TestStrings.SymbolsToTrim, 0, sb.Length + 1);
            }
            );
        }

        [Test]
        public void TestIndexPlusCountGreaterThanLength()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(TestStrings.Composition1);
                sb.IndexOfAny(TestStrings.SymbolsToTrim, 5, 20);
            }
            );
        }
    }
}
