using NUnit.Framework;
using System.Globalization;

namespace System.Text.Tests
{
    [TestFixture]
    public class StartsWithTests
    {
        private static readonly string correctStringToSearch = string.Concat(TestStrings.Searched, TestStrings.Composition1, TestStrings.Searched, TestStrings.Composition2);
        private static readonly string correctStringToSearchUpperCase = string.Concat(TestStrings.Searched.ToUpper(), TestStrings.Composition1, TestStrings.Searched, TestStrings.Composition2);
        private static readonly string incorrectStringToSearch1 = string.Concat(TestStrings.SingleCharacter, TestStrings.Searched, TestStrings.Composition1, TestStrings.Composition2);
        private static readonly string incorrectStringToSearch2 = string.Concat(TestStrings.Composition1, TestStrings.Composition2);
        private static readonly string smallStringToSearch = TestStrings.Composition1;

        [Test]
        public void TestContainingCharacters()
        {
            StringBuilder sb;
            sb = new StringBuilder(correctStringToSearch);
            Assert.AreEqual(sb.StartsWith(TestStrings.Searched), correctStringToSearch.StartsWith(TestStrings.Searched));
            sb = new StringBuilder(TestStrings.Searched);
            Assert.AreEqual(sb.StartsWith(TestStrings.Searched), correctStringToSearch.StartsWith(TestStrings.Searched));
        }

        [Test]
        public void TestContainingCharactersIgnoreCase()
        {
            StringBuilder sb;
            sb = new StringBuilder(correctStringToSearchUpperCase);
            Assert.AreEqual(sb.StartsWith(TestStrings.Searched, true), correctStringToSearch.StartsWith(TestStrings.Searched, true, CultureInfo.CurrentCulture));
            sb = new StringBuilder(TestStrings.Searched.ToUpper());
            Assert.AreEqual(sb.StartsWith(TestStrings.Searched, true), correctStringToSearch.StartsWith(TestStrings.Searched, true, CultureInfo.CurrentCulture));
        }

        [Test]
        public void TestNotContainingCharacters()
        {
            StringBuilder sb;
            sb = new StringBuilder(incorrectStringToSearch1);
            Assert.AreEqual(sb.StartsWith(TestStrings.Searched), incorrectStringToSearch1.StartsWith(TestStrings.Searched));
            sb = new StringBuilder(incorrectStringToSearch2);
            Assert.AreEqual(sb.StartsWith(TestStrings.Searched), incorrectStringToSearch2.StartsWith(TestStrings.Searched));
        }

        [Test]
        public void TestNotContainingCharactersIgnoreCase()
        {
            StringBuilder sb;
            sb = new StringBuilder(incorrectStringToSearch1);
            Assert.AreEqual(sb.StartsWith(TestStrings.Searched, true), incorrectStringToSearch1.StartsWith(TestStrings.Searched, true, CultureInfo.CurrentCulture));
            sb = new StringBuilder(incorrectStringToSearch2);
            Assert.AreEqual(sb.StartsWith(TestStrings.Searched, true), incorrectStringToSearch2.StartsWith(TestStrings.Searched, true, CultureInfo.CurrentCulture));
        }

        [Test]
        public void TestNullValue()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                StringBuilder sb = new StringBuilder();
                sb.StartsWith(null);
            }
            );
        }

        [Test]
        public void TestEmptyValue()
        {
            StringBuilder sb = new StringBuilder();
            Assert.IsTrue(sb.StartsWith(string.Empty));
        }

        [Test]
        public void TestValueLengthGreaterThanStringBuilderLength()
        {
            StringBuilder sb = new StringBuilder(smallStringToSearch);
            Assert.AreEqual(sb.StartsWith(TestStrings.Searched), smallStringToSearch.StartsWith(TestStrings.Searched));
        }

        [Test]
        public void TestEmpty()
        {
            StringBuilder sb = new StringBuilder();
            Assert.IsFalse(sb.StartsWith(TestStrings.Searched));
        }
    }
}
