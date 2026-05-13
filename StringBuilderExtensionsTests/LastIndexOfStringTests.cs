using NUnit.Framework;
using static System.Text.Tests.TestStrings;

namespace System.Text.Tests
{
    [TestFixture]
    public class LastIndexOfStringTests
    {
        private static readonly string correctStringToSearch1 = string.Concat(Composition1, Searched, Composition2, Searched);
        private static readonly string correctStringToSearch2 = string.Concat(Searched, Composition1, Composition2);
        private static readonly string correctStringToSearchUpperCase1 = string.Concat(Composition1, Searched, Composition2, Searched.ToUpper());
        private static readonly string correctStringToSearchUpperCase2 = string.Concat(Searched.ToUpper(), Composition1, Composition2);
        private static readonly string incorrectStringToSearch = string.Concat(Composition1, Composition2);
        private static readonly string correctSmallStringToSearch = string.Concat(Searched.Substring(10), Composition1.Substring(10));
        private static readonly string incorrectSmallStringToSearch = Composition1;
        private static readonly int startIndexCorrectString1 = correctStringToSearch1.Length - 4;
        private static readonly int startIndexCorrectString2 = correctStringToSearch2.Length - 4;
        private static readonly int startIndexIncorrectString = incorrectStringToSearch.Length - 4;

        [Test]
        public void TestContainingCharacters()
        {
            StringBuilder sb;
            sb = new StringBuilder(correctStringToSearch1);
            Assert.AreEqual(sb.LastIndexOf(Searched), correctStringToSearch1.LastIndexOf(Searched));
            Assert.AreEqual(sb.LastIndexOf(Searched, startIndexCorrectString1), correctStringToSearch1.LastIndexOf(Searched, startIndexCorrectString1));
            Assert.AreEqual(sb.LastIndexOf(Searched, startIndexCorrectString1, 55), correctStringToSearch1.LastIndexOf(Searched, startIndexCorrectString1, 55), "Result = -1, contains a part of sting in the specified range");
            Assert.AreEqual(sb.LastIndexOf(Searched, startIndexCorrectString1, 57), correctStringToSearch1.LastIndexOf(Searched, startIndexCorrectString1, 57), "Result = 15, contains full string in the specified range");
            int count = startIndexCorrectString2 + 1;
            sb = new StringBuilder(correctStringToSearch2);
            Assert.AreEqual(sb.LastIndexOf(Searched), correctStringToSearch2.LastIndexOf(Searched));
            Assert.AreEqual(sb.LastIndexOf(Searched, startIndexCorrectString2), correctStringToSearch2.LastIndexOf(Searched, startIndexCorrectString2));
            Assert.AreEqual(sb.LastIndexOf(Searched, startIndexCorrectString2, count), correctStringToSearch2.LastIndexOf(Searched, startIndexCorrectString2, count));
        }

        [Test]
        public void TestContainingCharactersIgnoreCase()
        {
            StringBuilder sb;
            sb = new StringBuilder(correctStringToSearchUpperCase1);
            Assert.AreEqual(sb.LastIndexOf(Searched, true), correctStringToSearchUpperCase1.LastIndexOf(Searched, StringComparison.CurrentCultureIgnoreCase));
            Assert.AreEqual(sb.LastIndexOf(Searched, startIndexCorrectString1, true), correctStringToSearchUpperCase1.LastIndexOf(Searched, startIndexCorrectString1, StringComparison.CurrentCultureIgnoreCase));
            Assert.AreEqual(sb.LastIndexOf(Searched, startIndexCorrectString1, 55, true), correctStringToSearchUpperCase1.LastIndexOf(Searched, startIndexCorrectString1, 55, StringComparison.CurrentCultureIgnoreCase));
            Assert.AreEqual(sb.LastIndexOf(Searched, startIndexCorrectString1, 57, true), correctStringToSearchUpperCase1.LastIndexOf(Searched, startIndexCorrectString1, 57, StringComparison.CurrentCultureIgnoreCase));
            int count = startIndexCorrectString2 + 1;
            sb = new StringBuilder(correctStringToSearchUpperCase2);
            Assert.AreEqual(sb.LastIndexOf(Searched, true), correctStringToSearchUpperCase2.LastIndexOf(Searched, StringComparison.CurrentCultureIgnoreCase));
            Assert.AreEqual(sb.LastIndexOf(Searched, startIndexCorrectString2, true), correctStringToSearchUpperCase2.LastIndexOf(Searched, startIndexCorrectString2, StringComparison.CurrentCultureIgnoreCase));
            Assert.AreEqual(sb.LastIndexOf(Searched, startIndexCorrectString2, count, true), correctStringToSearchUpperCase2.LastIndexOf(Searched, startIndexCorrectString2, count, StringComparison.CurrentCultureIgnoreCase));
        }

        [Test]
        public void TestNotContainingCharacters()
        {
            StringBuilder sb;
            sb = new StringBuilder(incorrectStringToSearch);
            Assert.AreEqual(sb.LastIndexOf(Searched), incorrectStringToSearch.LastIndexOf(Searched));
            sb = new StringBuilder(incorrectStringToSearch);
            Assert.AreEqual(sb.LastIndexOf(Searched, startIndexIncorrectString), incorrectStringToSearch.LastIndexOf(Searched, startIndexIncorrectString));
            sb = new StringBuilder(incorrectStringToSearch);
            Assert.AreEqual(sb.LastIndexOf(Searched, startIndexIncorrectString, 32), incorrectStringToSearch.LastIndexOf(Searched, startIndexIncorrectString, 32));
        }

        [Test]
        public void TestNotContainingCharactersIgnoreCase()
        {
            string testStringsSearchedToUpper = Searched.ToUpper();

            StringBuilder sb;
            sb = new StringBuilder(incorrectStringToSearch);
            Assert.AreEqual(sb.LastIndexOf(testStringsSearchedToUpper, true), incorrectStringToSearch.LastIndexOf(testStringsSearchedToUpper, StringComparison.CurrentCultureIgnoreCase));
            sb = new StringBuilder(incorrectStringToSearch);
            Assert.AreEqual(sb.LastIndexOf(testStringsSearchedToUpper, startIndexIncorrectString, true), incorrectStringToSearch.LastIndexOf(testStringsSearchedToUpper, startIndexIncorrectString, StringComparison.CurrentCultureIgnoreCase));
            sb = new StringBuilder(incorrectStringToSearch);
            Assert.AreEqual(sb.LastIndexOf(testStringsSearchedToUpper, startIndexIncorrectString, 32, true), incorrectStringToSearch.LastIndexOf(testStringsSearchedToUpper, startIndexIncorrectString, 32, StringComparison.CurrentCultureIgnoreCase));
        }

        [Test]
        public void TestNullValue()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                StringBuilder sb = new StringBuilder();
                sb.LastIndexOf(Null);
            }
            );
        }

        [Test]
        public void TestNullValueWithIndex()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                StringBuilder sb = new StringBuilder();
                sb.LastIndexOf(Null, startIndexCorrectString1);
            }
            );
        }

        [Test]
        public void TestNullValueWithIndexAndCount()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                StringBuilder sb = new StringBuilder();
                sb.LastIndexOf(Null, startIndexCorrectString1, 55);
            }
            );
        }

        [Test]
        public void TestEmptyValue()
        {
            StringBuilder sb;
            sb = new StringBuilder();
            Assert.AreEqual(sb.LastIndexOf(string.Empty), string.Empty.LastIndexOf(string.Empty));
            //correctStringToSearch.LastIndexOf(string.Empty, startIndexCorrectString, 55);
            sb = new StringBuilder(correctStringToSearch1);
            Assert.AreEqual(sb.LastIndexOf(string.Empty), correctStringToSearch1.LastIndexOf(string.Empty));
            Assert.AreEqual(sb.LastIndexOf(string.Empty, startIndexCorrectString1), correctStringToSearch1.LastIndexOf(string.Empty, startIndexCorrectString1));
            Assert.AreEqual(sb.LastIndexOf(string.Empty, startIndexCorrectString1, 55), correctStringToSearch1.LastIndexOf(string.Empty, startIndexCorrectString1, 55));
        }

        [Test]
        public void TestEmptyValueEmptyStringBuilderIndex()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder();
                sb.LastIndexOf(string.Empty, startIndexCorrectString1);
            }
            );
        }

        [Test]
        public void TestEmptyValueEmptyStringBuilderIndexAndCount()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder();
                sb.LastIndexOf(string.Empty, startIndexCorrectString1, 55);
            }
            );
        }

        [Test]
        public void TestValueLengthGreaterThanStringBuilderLengthContaining()
        {
            int startIndex = correctSmallStringToSearch.Length - 4;
            StringBuilder sb = new StringBuilder(correctSmallStringToSearch);
            Assert.AreEqual(sb.LastIndexOf(Searched), correctSmallStringToSearch.LastIndexOf(Searched));
            Assert.AreEqual(sb.LastIndexOf(Searched, startIndex), correctSmallStringToSearch.LastIndexOf(Searched, startIndex));
            Assert.AreEqual(sb.LastIndexOf(Searched, startIndex, 12), correctSmallStringToSearch.LastIndexOf(Searched, startIndex, 12));
        }

        [Test]
        public void TestValueLengthGreaterThanStringBuilderLengthNotContaining()
        {
            int startIndex = incorrectSmallStringToSearch.Length - 4;
            StringBuilder sb = new StringBuilder(incorrectSmallStringToSearch);
            Assert.AreEqual(sb.LastIndexOf(Searched), incorrectSmallStringToSearch.LastIndexOf(Searched));
            Assert.AreEqual(sb.LastIndexOf(Searched, startIndex), incorrectSmallStringToSearch.LastIndexOf(Searched, startIndex));
            Assert.AreEqual(sb.LastIndexOf(Searched, startIndex, 12), incorrectSmallStringToSearch.LastIndexOf(Searched, startIndex, 12));
        }

        [Test]
        public void TestEmptyStringBuilder()
        {
            StringBuilder sb = new StringBuilder();
            Assert.AreEqual(sb.LastIndexOf(Searched), string.Empty.LastIndexOf(Searched));
            Assert.AreEqual(sb.LastIndexOf(Searched, 0), string.Empty.LastIndexOf(Searched, 0));
            Assert.AreEqual(sb.LastIndexOf(Searched, 0, 55), string.Empty.LastIndexOf(Searched, 0, 55));
        }

        [Test]
        public void TestEmptyStringBuilderIndex()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder();
                sb.LastIndexOf(Searched, startIndexCorrectString1);
            }
            );
        }

        [Test]
        public void TestEmptyStringBuilderIndexWithCount()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder();
                sb.LastIndexOf(Searched, startIndexCorrectString1, 55);
            }
            );
        }

        [Test]
        public void TestIndexFirstCharacter()
        {
            StringBuilder sb;
            sb = new StringBuilder(ToIndexOfChars1);
            Assert.AreEqual(sb.LastIndexOf(Searched, 0), ToIndexOfChars1.LastIndexOf(Searched, 0));
            sb = new StringBuilder(correctStringToSearch1);
            Assert.AreEqual(sb.LastIndexOf(Searched, 0), correctStringToSearch1.LastIndexOf(Searched, 0));
        }

        [Test]
        public void TestIndexAfterLastCharacter()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(ToIndexOfChars1);
                sb.LastIndexOf(Searched, sb.Length);
            }
            );
        }

        [Test]
        public void TestIndexAfterLastCharacterWithCount()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(correctStringToSearch1);
                sb.LastIndexOf(Searched, sb.Length);
            }
            );
        }

        [Test]
        public void TestIndexLessThanZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(Composition1);
                sb.LastIndexOf(Searched, -1);
            }
            );
        }

        [Test]
        public void TestIndexLessThanZeroWithCount()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(Composition1);
                sb.LastIndexOf(Searched, -1, 5);
            }
            );
        }

        [Test]
        public void TestIndexGreaterThanMaximum()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(Composition1);
                sb.LastIndexOf(Searched, sb.Length + 1);
            }
            );
        }

        [Test]
        public void TestIndexGreaterThanMaximumWithCount()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(Composition1);
                sb.LastIndexOf(Searched, sb.Length + 1, 5);
            }
            );
        }

        [Test]
        public void TestCountLessThanZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(Composition1);
                sb.LastIndexOf(Searched, 0, -1);
            }
            );
        }

        [Test]
        public void TestCountEqualsZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(Composition1);
                sb.LastIndexOf(Searched, -1);
            }
            );
        }

        [Test]
        public void TestCountGreaterThanMaximum()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(Composition1);
                sb.LastIndexOf(Searched, 0, sb.Length + 1);
            }
            );
        }

        [Test]
        public void TestIndexPlusCountGreaterThanLength()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(Composition1);
                sb.LastIndexOf(Searched, 5, 20);
            }
            );
        }
    }
}
