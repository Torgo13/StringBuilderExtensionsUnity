using NUnit.Framework;
using static System.Text.Tests.TestStrings;

namespace System.Text.Tests
{
    [TestFixture]
    public class IndexOfCharTests
    {
        [Test]
        public void TestContainingCharacters()
        {
            StringBuilder sb;
            sb = new StringBuilder(ToIndexOfChars1);
            foreach (char symbol in SymbolsToTrim)
            {
                Assert.AreEqual(sb.IndexOf(symbol), ToIndexOfChars1.IndexOf(symbol));
            }
            sb = new StringBuilder(ToIndexOfChars2);
            foreach (char symbol in SymbolsToTrim)
            {
                Assert.AreEqual(sb.IndexOf(symbol), ToIndexOfChars2.IndexOf(symbol));
            }
            sb = new StringBuilder(ToIndexOfChars2);
            foreach (char symbol in SymbolsToTrim)
            {
                Assert.AreEqual(sb.IndexOf(symbol, 3), ToIndexOfChars2.IndexOf(symbol, 3));
            }
            sb = new StringBuilder(ToIndexOfChars2);
            foreach (char symbol in SymbolsToTrim)
            {
                Assert.AreEqual(sb.IndexOf(symbol, 3, 7), ToIndexOfChars2.IndexOf(symbol, 3, 7));
            }
        }

        [Test]
        public void TestNotContainingCharacters()
        {
            StringBuilder sb;
            sb = new StringBuilder(LeadingAndTrailingWhiteSpaces);
            foreach (char symbol in SymbolsToTrim)
            {
                Assert.AreEqual(sb.IndexOf(symbol), LeadingAndTrailingWhiteSpaces.IndexOf(symbol));
            }
            sb = new StringBuilder(ToIndexOfChars1);
            foreach (char symbol in SymbolsToTrim)
            {
                Assert.AreEqual(sb.IndexOf(symbol, 23), ToIndexOfChars1.IndexOf(symbol, 23));
            }
            sb = new StringBuilder(ToIndexOfChars2);
            foreach (char symbol in SymbolsToTrim)
            {
                Assert.AreEqual(sb.IndexOf(symbol, 3, 4), ToIndexOfChars2.IndexOf(symbol, 3, 4));
            }
        }

        [Test]
        public void TestEmpty()
        {
            StringBuilder sb = new StringBuilder();
            foreach (char symbol in SymbolsToTrim)
            {
                Assert.AreEqual(sb.IndexOf(symbol), -1);
            }
            foreach (char symbol in SymbolsToTrim)
            {
                Assert.AreEqual(sb.IndexOf(symbol, 3), -1);
            }
            foreach (char symbol in SymbolsToTrim)
            {
                Assert.AreEqual(sb.IndexOf(symbol, 3, 7), -1);
            }
        }

        [Test]
        public void TestIndexLastCharacter()
        {
            StringBuilder sb;
            sb = new StringBuilder(ToIndexOfChars1);
            foreach (char symbol in SymbolsToTrim)
            {
                Assert.AreEqual(sb.IndexOf(symbol, sb.Length - 1), ToIndexOfChars1.IndexOf(symbol, sb.Length - 1));
            }
            sb = new StringBuilder(ToIndexOfChars2);
            foreach (char symbol in SymbolsToTrim)
            {
                Assert.AreEqual(sb.IndexOf(symbol, sb.Length - 1), ToIndexOfChars2.IndexOf(symbol, sb.Length - 1));
            }
        }

        [Test]
        public void TestIndexAfterLastCharacter()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(ToIndexOfChars1);
                sb.IndexOf(SymbolsToTrim[0], sb.Length);
            }
            );
        }

        [Test]
        public void TestIndexAfterLastCharacterWithCount()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(ToIndexOfChars2);
                sb.IndexOf(SymbolsToTrim[0], sb.Length);
            }
            );
        }

        [Test]
        public void TestIndexLessThanZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(Composition1);
                sb.IndexOf(SymbolsToTrim[0], -1);
            }
            );
        }

        [Test]
        public void TestIndexLessThanZeroWithCount()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(Composition1);
                sb.IndexOf(SymbolsToTrim[0], -1, 5);
            }
            );
        }

        [Test]
        public void TestIndexGreaterThanMaximum()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(Composition1);
                sb.IndexOf(SymbolsToTrim[0], sb.Length + 1);
            }
            );
        }

        [Test]
        public void TestIndexGreaterThanMaximumWithCount()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(Composition1);
                sb.IndexOf(SymbolsToTrim[0], sb.Length + 1, 5);
            }
            );
        }

        [Test]
        public void TestCountLessThanZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(Composition1);
                sb.IndexOf(SymbolsToTrim[0], 0, -1);
            }
            );
        }

        [Test]
        public void TestCountEqualsZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(Composition1);
                sb.IndexOf(SymbolsToTrim[0], -1);
            }
            );
        }

        [Test]
        public void TestCountGreaterThanMaximum()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(Composition1);
                sb.IndexOf(SymbolsToTrim[0], 0, sb.Length + 1);
            }
            );
        }

        [Test]
        public void TestIndexPlusCountGreaterThanLength()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(Composition1);
                sb.IndexOf(SymbolsToTrim[0], 5, 20);
            }
            );
        }
    }
}
