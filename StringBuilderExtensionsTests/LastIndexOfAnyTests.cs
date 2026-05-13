using NUnit.Framework;
using static System.Text.Tests.TestStrings;

namespace System.Text.Tests
{
    [TestFixture]
    public class LastIndexOfAnyTests
    {
        [Test]
        public void TestContainingCharacters()
        {
            StringBuilder sb;
            sb = new StringBuilder(ToIndexOfChars1);
            Assert.AreEqual(sb.LastIndexOfAny(SymbolsToTrim), ToIndexOfChars1.LastIndexOfAny(SymbolsToTrim));
            sb = new StringBuilder(ToIndexOfChars2);
            Assert.AreEqual(sb.LastIndexOfAny(SymbolsToTrim), ToIndexOfChars2.LastIndexOfAny(SymbolsToTrim));
            sb = new StringBuilder(ToIndexOfChars2);
            Assert.AreEqual(sb.LastIndexOfAny(SymbolsToTrim, 22), ToIndexOfChars2.LastIndexOfAny(SymbolsToTrim, 22));
            sb = new StringBuilder(ToIndexOfChars2);
            Assert.AreEqual(sb.LastIndexOfAny(SymbolsToTrim, 22, 7), ToIndexOfChars2.LastIndexOfAny(SymbolsToTrim, 22, 7));
        }

        [Test]
        public void TestNotContainingCharacters()
        {
            StringBuilder sb;
            sb = new StringBuilder(LeadingAndTrailingWhiteSpaces);
            Assert.AreEqual(sb.LastIndexOfAny(SymbolsToTrim), LeadingAndTrailingWhiteSpaces.LastIndexOfAny(SymbolsToTrim));
            sb = new StringBuilder(ToIndexOfChars1);
            Assert.AreEqual(sb.LastIndexOfAny(SymbolsToTrim, 23), ToIndexOfChars1.LastIndexOfAny(SymbolsToTrim, 23));
            sb = new StringBuilder(ToIndexOfChars2);
            Assert.AreEqual(sb.LastIndexOfAny(SymbolsToTrim, 22, 4), ToIndexOfChars2.LastIndexOfAny(SymbolsToTrim, 22, 4));
        }

        [Test]
        public void TestEmpty()
        {
            StringBuilder sb = new StringBuilder();
            Assert.AreEqual(sb.LastIndexOfAny(SymbolsToTrim), -1);
        }

        [Test]
        public void TestNullAnyOf()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                StringBuilder sb = new StringBuilder();
                sb.LastIndexOfAny(Null);
            }
            );
        }

        [Test]
        public void TestNullAnyOfIndex()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                StringBuilder sb = new StringBuilder();
                sb.LastIndexOfAny(Null, 22);
            }
            );
        }

        [Test]
        public void TestNullAnyOfIndexCount()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                StringBuilder sb = new StringBuilder();
                sb.LastIndexOfAny(Null, 22, 7);
            }
            );
        }

        [Test]
        public void TestIndexFirstCharacter()
        {
            StringBuilder sb;
            sb = new StringBuilder(ToIndexOfChars1);
            Assert.AreEqual(sb.LastIndexOfAny(SymbolsToTrim, 0), ToIndexOfChars1.LastIndexOfAny(SymbolsToTrim, 0));
            sb = new StringBuilder(ToIndexOfChars2);
            Assert.AreEqual(sb.LastIndexOfAny(SymbolsToTrim, 0), ToIndexOfChars2.LastIndexOfAny(SymbolsToTrim, 0));
        }

        [Test]
        public void TestIndexAfterLastCharacter()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(ToIndexOfChars1);
                sb.LastIndexOfAny(SymbolsToTrim, sb.Length);
            }
            );
        }

        [Test]
        public void TestIndexAfterLastCharacterWithCount()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(ToIndexOfChars2);
                sb.LastIndexOfAny(SymbolsToTrim, sb.Length);
            }
            );
        }

        [Test]
        public void TestIndexLessThanZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(Composition1);
                sb.LastIndexOfAny(SymbolsToTrim, -1);
            }
            );
        }

        [Test]
        public void TestIndexLessThanZeroWithCount()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(Composition1);
                sb.LastIndexOfAny(SymbolsToTrim, -1, 5);
            }
            );
        }

        [Test]
        public void TestIndexGreaterThanMaximum()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(Composition1);
                sb.LastIndexOfAny(SymbolsToTrim, sb.Length + 1);
            }
            );
        }

        [Test]
        public void TestIndexGreaterThanMaximumWithCount()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(Composition1);
                sb.LastIndexOfAny(SymbolsToTrim, sb.Length + 1, 5);
            }
            );
        }

        [Test]
        public void TestCountLessThanZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(Composition1);
                sb.LastIndexOfAny(SymbolsToTrim, 0, -1);
            }
            );
        }

        [Test]
        public void TestCountEqualsZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(Composition1);
                sb.LastIndexOfAny(SymbolsToTrim, -1);
            }
            );
        }

        [Test]
        public void TestCountGreaterThanMaximum()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(Composition1);
                sb.LastIndexOfAny(SymbolsToTrim, 0, sb.Length + 1);
            }
            );
        }

        [Test]
        public void TestIndexPlusCountGreaterThanLength()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(Composition1);
                sb.LastIndexOfAny(SymbolsToTrim, 15, 20);
            }
            );
        }
    }
}
