using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace System.Text.Tests
{
    public class LastIndexOfStringTests
    {
        private static readonly string correctStringToSearch1 = string.Concat(TestStrings.Composition1, TestStrings.Searched, TestStrings.Composition2, TestStrings.Searched);
        private static readonly string correctStringToSearch2 = string.Concat(TestStrings.Searched, TestStrings.Composition1, TestStrings.Composition2);
        private static readonly string correctStringToSearchUpperCase1 = string.Concat(TestStrings.Composition1, TestStrings.Searched, TestStrings.Composition2, TestStrings.Searched.ToUpper());
        private static readonly string correctStringToSearchUpperCase2 = string.Concat(TestStrings.Searched.ToUpper(), TestStrings.Composition1, TestStrings.Composition2);
        private static readonly string incorrectStringToSearch = string.Concat(TestStrings.Composition1, TestStrings.Composition2);
        private static readonly string correctSmallStringToSearch = string.Concat(TestStrings.Searched.Substring(10), TestStrings.Composition1.Substring(10));
        private static readonly string incorrectSmallStringToSearch = TestStrings.Composition1;
        private static readonly int startIndexCorrectString1 = correctStringToSearch1.Length - 4;
        private static readonly int startIndexCorrectString2 = correctStringToSearch2.Length - 4;
        private static readonly int startIndexIncorrectString = incorrectStringToSearch.Length - 4;

        [Test]
        public void TestContainingCharacters()
        {
            StringBuilder sb;
            sb = new StringBuilder(correctStringToSearch1);
            Assert.AreEqual(sb.LastIndexOf(TestStrings.Searched), correctStringToSearch1.LastIndexOf(TestStrings.Searched));
            Assert.AreEqual(sb.LastIndexOf(TestStrings.Searched, startIndexCorrectString1), correctStringToSearch1.LastIndexOf(TestStrings.Searched, startIndexCorrectString1));
            Assert.AreEqual(sb.LastIndexOf(TestStrings.Searched, startIndexCorrectString1, 55), correctStringToSearch1.LastIndexOf(TestStrings.Searched, startIndexCorrectString1, 55), "Result = -1, contains a part of sting in the specified range");
            Assert.AreEqual(sb.LastIndexOf(TestStrings.Searched, startIndexCorrectString1, 57), correctStringToSearch1.LastIndexOf(TestStrings.Searched, startIndexCorrectString1, 57), "Result = 15, contains full string in the specified range");
            int count = startIndexCorrectString2 + 1;
            sb = new StringBuilder(correctStringToSearch2);
            Assert.AreEqual(sb.LastIndexOf(TestStrings.Searched), correctStringToSearch2.LastIndexOf(TestStrings.Searched));
            Assert.AreEqual(sb.LastIndexOf(TestStrings.Searched, startIndexCorrectString2), correctStringToSearch2.LastIndexOf(TestStrings.Searched, startIndexCorrectString2));
            Assert.AreEqual(sb.LastIndexOf(TestStrings.Searched, startIndexCorrectString2, count), correctStringToSearch2.LastIndexOf(TestStrings.Searched, startIndexCorrectString2, count));
        }

        [Test]
        public void TestContainingCharactersIgnoreCase()
        {
            StringBuilder sb;
            sb = new StringBuilder(correctStringToSearchUpperCase1);
            Assert.AreEqual(sb.LastIndexOf(TestStrings.Searched, true), correctStringToSearchUpperCase1.LastIndexOf(TestStrings.Searched, StringComparison.CurrentCultureIgnoreCase));
            Assert.AreEqual(sb.LastIndexOf(TestStrings.Searched, startIndexCorrectString1, true), correctStringToSearchUpperCase1.LastIndexOf(TestStrings.Searched, startIndexCorrectString1, StringComparison.CurrentCultureIgnoreCase));
            Assert.AreEqual(sb.LastIndexOf(TestStrings.Searched, startIndexCorrectString1, 55, true), correctStringToSearchUpperCase1.LastIndexOf(TestStrings.Searched, startIndexCorrectString1, 55, StringComparison.CurrentCultureIgnoreCase));
            Assert.AreEqual(sb.LastIndexOf(TestStrings.Searched, startIndexCorrectString1, 57, true), correctStringToSearchUpperCase1.LastIndexOf(TestStrings.Searched, startIndexCorrectString1, 57, StringComparison.CurrentCultureIgnoreCase));
            int count = startIndexCorrectString2 + 1;
            sb = new StringBuilder(correctStringToSearchUpperCase2);
            Assert.AreEqual(sb.LastIndexOf(TestStrings.Searched, true), correctStringToSearchUpperCase2.LastIndexOf(TestStrings.Searched, StringComparison.CurrentCultureIgnoreCase));
            Assert.AreEqual(sb.LastIndexOf(TestStrings.Searched, startIndexCorrectString2, true), correctStringToSearchUpperCase2.LastIndexOf(TestStrings.Searched, startIndexCorrectString2, StringComparison.CurrentCultureIgnoreCase));
            Assert.AreEqual(sb.LastIndexOf(TestStrings.Searched, startIndexCorrectString2, count, true), correctStringToSearchUpperCase2.LastIndexOf(TestStrings.Searched, startIndexCorrectString2, count, StringComparison.CurrentCultureIgnoreCase));
        }

        [Test]
        public void TestNotContainingCharacters()
        {
            StringBuilder sb;
            sb = new StringBuilder(incorrectStringToSearch);
            Assert.AreEqual(sb.LastIndexOf(TestStrings.Searched), incorrectStringToSearch.LastIndexOf(TestStrings.Searched));
            sb = new StringBuilder(incorrectStringToSearch);
            Assert.AreEqual(sb.LastIndexOf(TestStrings.Searched, startIndexIncorrectString), incorrectStringToSearch.LastIndexOf(TestStrings.Searched, startIndexIncorrectString));
            sb = new StringBuilder(incorrectStringToSearch);
            Assert.AreEqual(sb.LastIndexOf(TestStrings.Searched, startIndexIncorrectString, 32), incorrectStringToSearch.LastIndexOf(TestStrings.Searched, startIndexIncorrectString, 32));
        }

        [Test]
        public void TestNotContainingCharactersIgnoreCase()
        {
            string testStringsSearchedToUpper = TestStrings.Searched.ToUpper();

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
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.LastIndexOf(null);
            }
            catch (Exception ex)
            {
                Assert.IsAssignableFrom<ArgumentNullException>(ex);
            }
        }

        [Test]
        public void TestNullValueWithIndex()
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.LastIndexOf(null, startIndexCorrectString1);
            }
            catch (Exception ex)
            {
                Assert.IsAssignableFrom<ArgumentNullException>(ex);
            }
        }

        [Test]
        public void TestNullValueWithIndexAndCount()
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.LastIndexOf(null, startIndexCorrectString1, 55);
            }
            catch (Exception ex)
            {
                Assert.IsAssignableFrom<ArgumentNullException>(ex);
            }
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
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.LastIndexOf(string.Empty, startIndexCorrectString1);
            }
            catch (Exception ex)
            {
                Assert.IsAssignableFrom<ArgumentOutOfRangeException>(ex);
            }
        }

        [Test]
        public void TestEmptyValueEmptyStringBuilderIndexAndCount()
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.LastIndexOf(string.Empty, startIndexCorrectString1, 55);
            }
            catch (Exception ex)
            {
                Assert.IsAssignableFrom<ArgumentOutOfRangeException>(ex);
            }
        }

        [Test]
        public void TestValueLengthGreaterThanStringBuilderLengthContaining()
        {
            int startIndex = correctSmallStringToSearch.Length - 4;
            StringBuilder sb = new StringBuilder(correctSmallStringToSearch);
            Assert.AreEqual(sb.LastIndexOf(TestStrings.Searched), correctSmallStringToSearch.LastIndexOf(TestStrings.Searched));
            Assert.AreEqual(sb.LastIndexOf(TestStrings.Searched, startIndex), correctSmallStringToSearch.LastIndexOf(TestStrings.Searched, startIndex));
            Assert.AreEqual(sb.LastIndexOf(TestStrings.Searched, startIndex, 12), correctSmallStringToSearch.LastIndexOf(TestStrings.Searched, startIndex, 12));
        }

        [Test]
        public void TestValueLengthGreaterThanStringBuilderLengthNotContaining()
        {
            int startIndex = incorrectSmallStringToSearch.Length - 4;
            StringBuilder sb = new StringBuilder(incorrectSmallStringToSearch);
            Assert.AreEqual(sb.LastIndexOf(TestStrings.Searched), incorrectSmallStringToSearch.LastIndexOf(TestStrings.Searched));
            Assert.AreEqual(sb.LastIndexOf(TestStrings.Searched, startIndex), incorrectSmallStringToSearch.LastIndexOf(TestStrings.Searched, startIndex));
            Assert.AreEqual(sb.LastIndexOf(TestStrings.Searched, startIndex, 12), incorrectSmallStringToSearch.LastIndexOf(TestStrings.Searched, startIndex, 12));
        }

        [Test]
        public void TestEmptyStringBuilder()
        {
            StringBuilder sb = new StringBuilder();
            Assert.AreEqual(sb.LastIndexOf(TestStrings.Searched), string.Empty.LastIndexOf(TestStrings.Searched));
            Assert.AreEqual(sb.LastIndexOf(TestStrings.Searched, 0), string.Empty.LastIndexOf(TestStrings.Searched, 0));
            Assert.AreEqual(sb.LastIndexOf(TestStrings.Searched, 0, 55), string.Empty.LastIndexOf(TestStrings.Searched, 0, 55));
        }

        [Test]
        public void TestEmptyStringBuilderIndex()
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.LastIndexOf(TestStrings.Searched, startIndexCorrectString1);
            }
            catch (Exception ex)
            {
                Assert.IsAssignableFrom<ArgumentOutOfRangeException>(ex);
            }
        }

        [Test]
        public void TestEmptyStringBuilderIndexWithCount()
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.LastIndexOf(TestStrings.Searched, startIndexCorrectString1, 55);
            }
            catch (Exception ex)
            {
                Assert.IsAssignableFrom<ArgumentOutOfRangeException>(ex);
            }
        }

        [Test]
        public void TestIndexFirstCharacter()
        {
            StringBuilder sb;
            sb = new StringBuilder(TestStrings.ToIndexOfChars1);
            Assert.AreEqual(sb.LastIndexOf(TestStrings.Searched, 0), TestStrings.ToIndexOfChars1.LastIndexOf(TestStrings.Searched, 0));
            sb = new StringBuilder(correctStringToSearch1);
            Assert.AreEqual(sb.LastIndexOf(TestStrings.Searched, 0), correctStringToSearch1.LastIndexOf(TestStrings.Searched, 0));
        }

        [Test]
        public void TestIndexAfterLastCharacter()
        {
            try
            {
                StringBuilder sb = new StringBuilder(TestStrings.ToIndexOfChars1);
                sb.LastIndexOf(TestStrings.Searched, sb.Length);
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
                StringBuilder sb = new StringBuilder(correctStringToSearch1);
                sb.LastIndexOf(TestStrings.Searched, sb.Length);
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
                sb.LastIndexOf(TestStrings.Searched, -1);
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
                sb.LastIndexOf(TestStrings.Searched, -1, 5);
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
                sb.LastIndexOf(TestStrings.Searched, sb.Length + 1);
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
                sb.LastIndexOf(TestStrings.Searched, sb.Length + 1, 5);
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
                sb.LastIndexOf(TestStrings.Searched, 0, -1);
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
                sb.LastIndexOf(TestStrings.Searched, -1);
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
                sb.LastIndexOf(TestStrings.Searched, 0, sb.Length + 1);
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
                sb.LastIndexOf(TestStrings.Searched, 5, 20);
            }
            catch (Exception ex)
            {
                Assert.IsAssignableFrom<ArgumentOutOfRangeException>(ex);
            }
        }
    }
}
