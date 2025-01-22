using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace System.Text.Tests
{
    public class IndexOfStringTests
    {
        private static readonly string correctStringToSearch1 = string.Concat(TestStrings.Searched, TestStrings.Composition2, TestStrings.Searched, TestStrings.Composition1);
        private static readonly string correctStringToSearch2 = string.Concat(TestStrings.Composition2, TestStrings.Composition1, TestStrings.Searched);
        private static readonly string correctStringToSearchUpperCase1 = string.Concat(TestStrings.Searched.ToUpper(), TestStrings.Composition1, TestStrings.Searched, TestStrings.Composition2);
        private static readonly string correctStringToSearchUpperCase2 = string.Concat(TestStrings.Composition2, TestStrings.Composition1, TestStrings.Searched.ToUpper());
        private static readonly string incorrectStringToSearch = string.Concat(TestStrings.Composition1, TestStrings.Composition2);
        private static readonly string correctSmallStringToSearch = string.Concat(TestStrings.Searched.Substring(10), TestStrings.Composition1.Substring(10));
        private static readonly string incorrectSmallStringToSearch = TestStrings.Composition1;


        [Test]
        public void TestContainingCharacters()
        {
            StringBuilder sb;
            sb = new StringBuilder(correctStringToSearch1);
            Assert.AreEqual(sb.IndexOf(TestStrings.Searched), correctStringToSearch1.IndexOf(TestStrings.Searched));
            Assert.AreEqual(sb.IndexOf(TestStrings.Searched, 3), correctStringToSearch1.IndexOf(TestStrings.Searched, 3));
            Assert.AreEqual(sb.IndexOf(TestStrings.Searched, 3, 55), correctStringToSearch1.IndexOf(TestStrings.Searched, 3, 55));
            Assert.AreEqual(sb.IndexOf(TestStrings.Searched, 3, 57), correctStringToSearch1.IndexOf(TestStrings.Searched, 3, 57));
            int count = correctStringToSearch2.Length - 3;
            sb = new StringBuilder(correctStringToSearch2);
            Assert.AreEqual(sb.IndexOf(TestStrings.Searched), correctStringToSearch2.IndexOf(TestStrings.Searched));
            Assert.AreEqual(sb.IndexOf(TestStrings.Searched, 3), correctStringToSearch2.IndexOf(TestStrings.Searched, 3));
            Assert.AreEqual(sb.IndexOf(TestStrings.Searched, 3, count), correctStringToSearch2.IndexOf(TestStrings.Searched, 3, count));
        }

        [Test]
        public void TestContainingCharactersIgnoreCase()
        {
            StringBuilder sb;
            sb = new StringBuilder(correctStringToSearchUpperCase1);
            Assert.AreEqual(sb.IndexOf(TestStrings.Searched, true), correctStringToSearchUpperCase1.IndexOf(TestStrings.Searched, StringComparison.CurrentCultureIgnoreCase));
            Assert.AreEqual(sb.IndexOf(TestStrings.Searched, 3, true), correctStringToSearchUpperCase1.IndexOf(TestStrings.Searched, 3, StringComparison.CurrentCultureIgnoreCase));
            Assert.AreEqual(sb.IndexOf(TestStrings.Searched, 3, 55, true), correctStringToSearchUpperCase1.IndexOf(TestStrings.Searched, 3, 55, StringComparison.CurrentCultureIgnoreCase));
            Assert.AreEqual(sb.IndexOf(TestStrings.Searched, 3, 57, true), correctStringToSearchUpperCase1.IndexOf(TestStrings.Searched, 3, 57, StringComparison.CurrentCultureIgnoreCase));
            int count = correctStringToSearchUpperCase2.Length - 3;
            sb = new StringBuilder(correctStringToSearchUpperCase2);
            Assert.AreEqual(sb.IndexOf(TestStrings.Searched, true), correctStringToSearchUpperCase2.IndexOf(TestStrings.Searched, StringComparison.CurrentCultureIgnoreCase));
            Assert.AreEqual(sb.IndexOf(TestStrings.Searched, 3, true), correctStringToSearchUpperCase2.IndexOf(TestStrings.Searched, 3, StringComparison.CurrentCultureIgnoreCase));
            Assert.AreEqual(sb.IndexOf(TestStrings.Searched, 3, count, true), correctStringToSearchUpperCase2.IndexOf(TestStrings.Searched, 3, count, StringComparison.CurrentCultureIgnoreCase));
        }

        [Test]
        public void TestNotContainingCharacters()
        {
            StringBuilder sb;
            sb = new StringBuilder(incorrectStringToSearch);
            Assert.AreEqual(sb.IndexOf(TestStrings.Searched), incorrectStringToSearch.IndexOf(TestStrings.Searched));
            sb = new StringBuilder(incorrectStringToSearch);
            Assert.AreEqual(sb.IndexOf(TestStrings.Searched, 3), incorrectStringToSearch.IndexOf(TestStrings.Searched, 3));
            sb = new StringBuilder(incorrectStringToSearch);
            Assert.AreEqual(sb.IndexOf(TestStrings.Searched, 3, 32), incorrectStringToSearch.IndexOf(TestStrings.Searched, 3, 32));
        }

        [Test]
        public void TestNotContainingCharactersIgnoreCase()
        {
            string testStringsSearchedToUpper = TestStrings.Searched.ToUpper();

            StringBuilder sb;
            sb = new StringBuilder(incorrectStringToSearch);
            Assert.AreEqual(sb.IndexOf(testStringsSearchedToUpper, true), incorrectStringToSearch.IndexOf(testStringsSearchedToUpper, StringComparison.CurrentCultureIgnoreCase));
            sb = new StringBuilder(incorrectStringToSearch);
            Assert.AreEqual(sb.IndexOf(testStringsSearchedToUpper, 3, true), incorrectStringToSearch.IndexOf(testStringsSearchedToUpper, 3, StringComparison.CurrentCultureIgnoreCase));
            sb = new StringBuilder(incorrectStringToSearch);
            Assert.AreEqual(sb.IndexOf(testStringsSearchedToUpper, 3, 32, true), incorrectStringToSearch.IndexOf(testStringsSearchedToUpper, 3, 32, StringComparison.CurrentCultureIgnoreCase));
        }

        [Test]
        public void TestNullValue()
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.IndexOf(null);
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
                sb.IndexOf(null, 3);
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
                sb.IndexOf(null, 3, 55);
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
            Assert.AreEqual(sb.IndexOf(string.Empty), string.Empty.IndexOf(string.Empty));
            sb = new StringBuilder(correctStringToSearch1);
            Assert.AreEqual(sb.IndexOf(string.Empty), correctStringToSearch1.IndexOf(string.Empty));
            Assert.AreEqual(sb.IndexOf(string.Empty, 3), correctStringToSearch1.IndexOf(string.Empty, 3));
            Assert.AreEqual(sb.IndexOf(string.Empty, 3, 55), correctStringToSearch1.IndexOf(string.Empty, 3, 55));
        }

        [Test]
        public void TestEmptyValueEmptyStringBuilderIndex()
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.IndexOf(string.Empty, 3);
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
                sb.IndexOf(string.Empty, 3, 55);
            }
            catch (Exception ex)
            {
                Assert.IsAssignableFrom<ArgumentOutOfRangeException>(ex);
            }
        }

        [Test]
        public void TestValueLengthGreaterThanStringBuilderLengthContaining()
        {
            StringBuilder sb = new StringBuilder(correctSmallStringToSearch);
            Assert.AreEqual(sb.IndexOf(TestStrings.Searched), correctSmallStringToSearch.IndexOf(TestStrings.Searched));
            Assert.AreEqual(sb.IndexOf(TestStrings.Searched, 3), correctSmallStringToSearch.IndexOf(TestStrings.Searched, 3));
            Assert.AreEqual(sb.IndexOf(TestStrings.Searched, 3, 12), correctSmallStringToSearch.IndexOf(TestStrings.Searched, 3, 12));
        }

        [Test]
        public void TestValueLengthGreaterThanStringBuilderLengthNotContaining()
        {
            StringBuilder sb = new StringBuilder(incorrectSmallStringToSearch);
            Assert.AreEqual(sb.IndexOf(TestStrings.Searched), incorrectSmallStringToSearch.IndexOf(TestStrings.Searched));
            Assert.AreEqual(sb.IndexOf(TestStrings.Searched, 3), incorrectSmallStringToSearch.IndexOf(TestStrings.Searched, 3));
            Assert.AreEqual(sb.IndexOf(TestStrings.Searched, 3, 12), incorrectSmallStringToSearch.IndexOf(TestStrings.Searched, 3, 12));
        }

        [Test]
        public void TestEmptyStringBuilder()
        {
            StringBuilder sb = new StringBuilder();
            Assert.AreEqual(sb.IndexOf(TestStrings.Searched), string.Empty.IndexOf(TestStrings.Searched));
            Assert.AreEqual(sb.IndexOf(TestStrings.Searched, 0), string.Empty.IndexOf(TestStrings.Searched, 0));
            Assert.AreEqual(sb.IndexOf(TestStrings.Searched, 0, 0), string.Empty.IndexOf(TestStrings.Searched, 0, 0));
        }

        [Test]
        public void TestEmptyStringBuilderIndex()
        {
            try
            {
                StringBuilder sb = new StringBuilder();
                sb.IndexOf(TestStrings.Searched, 3);
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
                sb.IndexOf(TestStrings.Searched, 3, 55);
            }
            catch (Exception ex)
            {
                Assert.IsAssignableFrom<ArgumentOutOfRangeException>(ex);
            }
        }

        [Test]
        public void TestIndexLastCharacter()
        {
            StringBuilder sb;
            sb = new StringBuilder(TestStrings.ToIndexOfChars1);
            Assert.AreEqual(sb.IndexOf(TestStrings.Searched, sb.Length - 1), TestStrings.ToIndexOfChars1.IndexOf(TestStrings.Searched, sb.Length - 1));
            sb = new StringBuilder(correctStringToSearch1);
            Assert.AreEqual(sb.IndexOf(TestStrings.Searched, sb.Length - 1), correctStringToSearch1.IndexOf(TestStrings.Searched, sb.Length - 1));
        }

        [Test]
        public void TestIndexAfterLastCharacter()
        {
            try
            {
                StringBuilder sb = new StringBuilder(TestStrings.ToIndexOfChars1);
                sb.IndexOf(TestStrings.Searched, sb.Length);
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
                sb.IndexOf(TestStrings.Searched, sb.Length);
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
                sb.IndexOf(TestStrings.Searched, -1);
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
                sb.IndexOf(TestStrings.Searched, -1, 5);
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
                sb.IndexOf(TestStrings.Searched, sb.Length + 1);
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
                sb.IndexOf(TestStrings.Searched, sb.Length + 1, 5);
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
                sb.IndexOf(TestStrings.Searched, 0, -1);
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
                sb.IndexOf(TestStrings.Searched, -1);
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
                sb.IndexOf(TestStrings.Searched, 0, sb.Length + 1);
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
                sb.IndexOf(TestStrings.Searched, 5, 20);
            }
            catch (Exception ex)
            {
                Assert.IsAssignableFrom<ArgumentOutOfRangeException>(ex);
            }
        }
    }
}
