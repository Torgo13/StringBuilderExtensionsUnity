using NUnit.Framework;
using static System.Text.Tests.TestStrings;

namespace System.Text.Tests
{
    [TestFixture]
    public class ContainsStringTests
    {
        private static readonly string correctStringToSearch1 = string.Concat(Searched, Composition2, Searched, Composition1);
        private static readonly string correctStringToSearch2 = string.Concat(Composition2, Composition1, Searched);
        private static readonly string correctStringToSearchUpperCase1 = string.Concat(Searched.ToUpper(), Composition1, Searched, Composition2);
        private static readonly string correctStringToSearchUpperCase2 = string.Concat(Composition2, Composition1, Searched.ToUpper());
        private static readonly string incorrectStringToSearch = string.Concat(Composition1, Composition2);
        private static readonly string correctSmallStringToSearch = string.Concat(Searched.Substring(10), Composition1.Substring(10));
        private static readonly string incorrectSmallStringToSearch = Composition1;


        [Test]
        public void TestContainingCharacters()
        {
            StringBuilder sb;
            sb = new StringBuilder(correctStringToSearch1);
            Assert.AreEqual(sb.Contains(Searched), correctStringToSearch1.Contains(Searched));
            int count = correctStringToSearch2.Length - 3;
            sb = new StringBuilder(correctStringToSearch2);
            Assert.AreEqual(sb.Contains(Searched), correctStringToSearch2.Contains(Searched));
        }

        [Test]
        public void TestContainingCharactersIgnoreCase()
        {
            StringBuilder sb;
            sb = new StringBuilder(correctStringToSearchUpperCase1);
            Assert.AreEqual(sb.Contains(Searched, true), correctStringToSearchUpperCase1.Contains(Searched, StringComparison.CurrentCultureIgnoreCase));
            int count = correctStringToSearchUpperCase2.Length - 3;
            sb = new StringBuilder(correctStringToSearchUpperCase2);
            Assert.AreEqual(sb.Contains(Searched, true), correctStringToSearchUpperCase2.Contains(Searched, StringComparison.CurrentCultureIgnoreCase));
        }

        [Test]
        public void TestNotContainingCharacters()
        {
            StringBuilder sb;
            sb = new StringBuilder(incorrectStringToSearch);
            Assert.AreEqual(sb.Contains(Searched), incorrectStringToSearch.Contains(Searched));
        }

        [Test]
        public void TestNotContainingCharactersIgnoreCase()
        {
            string testStringsSearchedToUpper = Searched.ToUpper();

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
                sb.Contains(Null);
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
            Assert.AreEqual(sb.Contains(Searched), correctSmallStringToSearch.Contains(Searched));
        }

        [Test]
        public void TestValueLengthGreaterThanStringBuilderLengthNotContaining()
        {
            StringBuilder sb = new StringBuilder(incorrectSmallStringToSearch);
            Assert.AreEqual(sb.Contains(Searched), incorrectSmallStringToSearch.Contains(Searched));
        }

        [Test]
        public void TestEmptyStringBuilder()
        {
            StringBuilder sb = new StringBuilder();
            Assert.AreEqual(sb.Contains(Searched), string.Empty.Contains(Searched));
        }
    }
}
