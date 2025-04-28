using NUnit.Framework;

namespace System.Text.Tests
{
    [TestFixture]
    public class ContainsStringTests
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
            Assert.AreEqual(sb.Contains(TestStrings.Searched), correctStringToSearch1.Contains(TestStrings.Searched));
            int count = correctStringToSearch2.Length - 3;
            sb = new StringBuilder(correctStringToSearch2);
            Assert.AreEqual(sb.Contains(TestStrings.Searched), correctStringToSearch2.Contains(TestStrings.Searched));
        }

        [Test]
        public void TestContainingCharactersIgnoreCase()
        {
            StringBuilder sb;
            sb = new StringBuilder(correctStringToSearchUpperCase1);
            Assert.AreEqual(sb.Contains(TestStrings.Searched, true), correctStringToSearchUpperCase1.Contains(TestStrings.Searched, StringComparison.CurrentCultureIgnoreCase));
            int count = correctStringToSearchUpperCase2.Length - 3;
            sb = new StringBuilder(correctStringToSearchUpperCase2);
            Assert.AreEqual(sb.Contains(TestStrings.Searched, true), correctStringToSearchUpperCase2.Contains(TestStrings.Searched, StringComparison.CurrentCultureIgnoreCase));
        }

        [Test]
        public void TestNotContainingCharacters()
        {
            StringBuilder sb;
            sb = new StringBuilder(incorrectStringToSearch);
            Assert.AreEqual(sb.Contains(TestStrings.Searched), incorrectStringToSearch.Contains(TestStrings.Searched));
        }

        [Test]
        public void TestNotContainingCharactersIgnoreCase()
        {
            string testStringsSearchedToUpper = TestStrings.Searched.ToUpper();

            StringBuilder sb;
            sb = new StringBuilder(incorrectStringToSearch);
            Assert.AreEqual(sb.Contains(testStringsSearchedToUpper, true), incorrectStringToSearch.Contains(testStringsSearchedToUpper, StringComparison.CurrentCultureIgnoreCase));
        }

        [Test]
        public void TestNullValue()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                StringBuilder sb = new StringBuilder();
                sb.Contains(null);
            }
            );
        }

        [Test]
        public void TestEmptyValue()
        {
            StringBuilder sb;
            sb = new StringBuilder();
            Assert.AreEqual(sb.Contains(string.Empty), string.Empty.Contains(string.Empty));
            sb = new StringBuilder(correctStringToSearch1);
            Assert.AreEqual(sb.Contains(string.Empty), correctStringToSearch1.Contains(string.Empty));
        }

        [Test]
        public void TestValueLengthGreaterThanStringBuilderLengthContaining()
        {
            StringBuilder sb = new StringBuilder(correctSmallStringToSearch);
            Assert.AreEqual(sb.Contains(TestStrings.Searched), correctSmallStringToSearch.Contains(TestStrings.Searched));
        }

        [Test]
        public void TestValueLengthGreaterThanStringBuilderLengthNotContaining()
        {
            StringBuilder sb = new StringBuilder(incorrectSmallStringToSearch);
            Assert.AreEqual(sb.Contains(TestStrings.Searched), incorrectSmallStringToSearch.Contains(TestStrings.Searched));
        }

        [Test]
        public void TestEmptyStringBuilder()
        {
            StringBuilder sb = new StringBuilder();
            Assert.AreEqual(sb.Contains(TestStrings.Searched), string.Empty.Contains(TestStrings.Searched));
        }
    }
}
