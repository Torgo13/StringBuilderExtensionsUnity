using NUnit.Framework;

namespace System.Text.Tests
{
    [TestFixture]
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
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(TestStrings.ToIndexOfChars1);
                sb.LastIndexOf(TestStrings.SymbolsToTrim[0], sb.Length);
            }
            );
        }

        [Test]
        public void TestIndexAfterLastCharacterWithCount()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(TestStrings.ToIndexOfChars2);
                sb.LastIndexOf(TestStrings.SymbolsToTrim[0], sb.Length);
            }
            );
        }

        [Test]
        public void TestIndexLessThanZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(TestStrings.Composition1);
                sb.LastIndexOf(TestStrings.SymbolsToTrim[0], -1);
            }
            );
        }

        [Test]
        public void TestIndexLessThanZeroWithCount()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(TestStrings.Composition1);
                sb.LastIndexOf(TestStrings.SymbolsToTrim[0], -1, 5);
            }
            );
        }

        [Test]
        public void TestIndexGreaterThanMaximum()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(TestStrings.Composition1);
                sb.LastIndexOf(TestStrings.SymbolsToTrim[0], sb.Length + 1);
            }
            );
        }

        [Test]
        public void TestIndexGreaterThanMaximumWithCount()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(TestStrings.Composition1);
                sb.LastIndexOf(TestStrings.SymbolsToTrim[0], sb.Length + 1, 5);
            }
            );
        }

        [Test]
        public void TestCountLessThanZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(TestStrings.Composition1);
                sb.LastIndexOf(TestStrings.SymbolsToTrim[0], 0, -1);
            }
            );
        }

        [Test]
        public void TestCountEqualsZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(TestStrings.Composition1);
                sb.LastIndexOf(TestStrings.SymbolsToTrim[0], -1);
            }
            );
        }

        [Test]
        public void TestCountGreaterThanMaximum()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(TestStrings.Composition1);
                sb.LastIndexOf(TestStrings.SymbolsToTrim[0], 0, sb.Length + 1);
            }
            );
        }

        [Test]
        public void TestIndexPlusCountGreaterThanLength()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(TestStrings.Composition1);
                sb.LastIndexOf(TestStrings.SymbolsToTrim[0], 15, 20);
            }
            );
        }
    }
}
