using NUnit.Framework;

namespace System.Text.Tests
{
    [TestFixture]
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
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(TestStrings.ToIndexOfChars1);
                sb.IndexOf(TestStrings.SymbolsToTrim[0], sb.Length);
            }
            );
        }

        [Test]
        public void TestIndexAfterLastCharacterWithCount()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(TestStrings.ToIndexOfChars2);
                sb.IndexOf(TestStrings.SymbolsToTrim[0], sb.Length);
            }
            );
        }

        [Test]
        public void TestIndexLessThanZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(TestStrings.Composition1);
                sb.IndexOf(TestStrings.SymbolsToTrim[0], -1);
            }
            );
        }

        [Test]
        public void TestIndexLessThanZeroWithCount()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(TestStrings.Composition1);
                sb.IndexOf(TestStrings.SymbolsToTrim[0], -1, 5);
            }
            );
        }

        [Test]
        public void TestIndexGreaterThanMaximum()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(TestStrings.Composition1);
                sb.IndexOf(TestStrings.SymbolsToTrim[0], sb.Length + 1);
            }
            );
        }

        [Test]
        public void TestIndexGreaterThanMaximumWithCount()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(TestStrings.Composition1);
                sb.IndexOf(TestStrings.SymbolsToTrim[0], sb.Length + 1, 5);
            }
            );
        }

        [Test]
        public void TestCountLessThanZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(TestStrings.Composition1);
                sb.IndexOf(TestStrings.SymbolsToTrim[0], 0, -1);
            }
            );
        }

        [Test]
        public void TestCountEqualsZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(TestStrings.Composition1);
                sb.IndexOf(TestStrings.SymbolsToTrim[0], -1);
            }
            );
        }

        [Test]
        public void TestCountGreaterThanMaximum()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(TestStrings.Composition1);
                sb.IndexOf(TestStrings.SymbolsToTrim[0], 0, sb.Length + 1);
            }
            );
        }

        [Test]
        public void TestIndexPlusCountGreaterThanLength()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(TestStrings.Composition1);
                sb.IndexOf(TestStrings.SymbolsToTrim[0], 5, 20);
            }
            );
        }
    }
}
