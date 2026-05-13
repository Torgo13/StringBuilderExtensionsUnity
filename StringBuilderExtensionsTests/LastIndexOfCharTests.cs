using NUnit.Framework;
using static System.Text.Tests.TestStrings;

namespace System.Text.Tests
{
    [TestFixture]
    public class LastIndexOfCharTests
    {
        [Test]
        public void TestContainingCharacters()
        {
            StringBuilder sb;
            sb = new StringBuilder(ToIndexOfChars1);
            foreach (char symbol in SymbolsToTrim)
            {
                Assert.AreEqual(sb.LastIndexOf(symbol), ToIndexOfChars1.LastIndexOf(symbol));
            }
            sb = new StringBuilder(ToIndexOfChars2);
            foreach (char symbol in SymbolsToTrim)
            {
                Assert.AreEqual(sb.LastIndexOf(symbol), ToIndexOfChars2.LastIndexOf(symbol));
            }
            sb = new StringBuilder(ToIndexOfChars2);
            foreach (char symbol in SymbolsToTrim)
            {
                Assert.AreEqual(sb.LastIndexOf(symbol, 22), ToIndexOfChars2.LastIndexOf(symbol, 22));
            }
            sb = new StringBuilder(ToIndexOfChars2);
            foreach (char symbol in SymbolsToTrim)
            {
                Assert.AreEqual(sb.LastIndexOf(symbol, 22, 7), ToIndexOfChars2.LastIndexOf(symbol, 22, 7));
            }
        }

        [Test]
        public void TestNotContainingCharacters()
        {
            StringBuilder sb;
            sb = new StringBuilder(LeadingAndTrailingWhiteSpaces);
            foreach (char symbol in SymbolsToTrim)
            {
                Assert.AreEqual(sb.LastIndexOf(symbol), LeadingAndTrailingWhiteSpaces.LastIndexOf(symbol));
            }
            sb = new StringBuilder(ToIndexOfChars1);
            foreach (char symbol in SymbolsToTrim)
            {
                Assert.AreEqual(sb.LastIndexOf(symbol, 23), ToIndexOfChars1.LastIndexOf(symbol, 23));
            }
            sb = new StringBuilder(ToIndexOfChars2);
            foreach (char symbol in SymbolsToTrim)
            {
                Assert.AreEqual(sb.LastIndexOf(symbol, 22, 4), ToIndexOfChars2.LastIndexOf(symbol, 22, 4));
            }
        }

        [Test]
        public void TestEmpty()
        {
            StringBuilder sb = new StringBuilder();
            foreach (char symbol in SymbolsToTrim)
            {
                Assert.AreEqual(sb.LastIndexOf(symbol), -1);
            }
            foreach (char symbol in SymbolsToTrim)
            {
                Assert.AreEqual(sb.LastIndexOf(symbol, 22), -1);
            }
            foreach (char symbol in SymbolsToTrim)
            {
                Assert.AreEqual(sb.LastIndexOf(symbol, 22, 7), -1);
            }
        }

        [Test]
        public void TestIndexFirstCharacter()
        {
            StringBuilder sb;
            sb = new StringBuilder(ToIndexOfChars1);
            foreach (char symbol in SymbolsToTrim)
            {
                Assert.AreEqual(sb.LastIndexOf(symbol, 0), ToIndexOfChars1.LastIndexOf(symbol, 0));
            }
            sb = new StringBuilder(ToIndexOfChars2);
            foreach (char symbol in SymbolsToTrim)
            {
                Assert.AreEqual(sb.LastIndexOf(symbol, 0), ToIndexOfChars2.LastIndexOf(symbol, 0));
            }
        }

        [Test]
        public void TestIndexAfterLastCharacter()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(ToIndexOfChars1);
                sb.LastIndexOf(SymbolsToTrim[0], sb.Length);
            }
            );
        }

        [Test]
        public void TestIndexAfterLastCharacterWithCount()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(ToIndexOfChars2);
                sb.LastIndexOf(SymbolsToTrim[0], sb.Length);
            }
            );
        }

        [Test]
        public void TestIndexLessThanZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(Composition1);
                sb.LastIndexOf(SymbolsToTrim[0], -1);
            }
            );
        }

        [Test]
        public void TestIndexLessThanZeroWithCount()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(Composition1);
                sb.LastIndexOf(SymbolsToTrim[0], -1, 5);
            }
            );
        }

        [Test]
        public void TestIndexGreaterThanMaximum()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(Composition1);
                sb.LastIndexOf(SymbolsToTrim[0], sb.Length + 1);
            }
            );
        }

        [Test]
        public void TestIndexGreaterThanMaximumWithCount()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(Composition1);
                sb.LastIndexOf(SymbolsToTrim[0], sb.Length + 1, 5);
            }
            );
        }

        [Test]
        public void TestCountLessThanZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(Composition1);
                sb.LastIndexOf(SymbolsToTrim[0], 0, -1);
            }
            );
        }

        [Test]
        public void TestCountEqualsZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(Composition1);
                sb.LastIndexOf(SymbolsToTrim[0], -1);
            }
            );
        }

        [Test]
        public void TestCountGreaterThanMaximum()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(Composition1);
                sb.LastIndexOf(SymbolsToTrim[0], 0, sb.Length + 1);
            }
            );
        }

        [Test]
        public void TestIndexPlusCountGreaterThanLength()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(Composition1);
                sb.LastIndexOf(SymbolsToTrim[0], 15, 20);
            }
            );
        }
    }
}
