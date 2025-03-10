using NUnit.Framework;
using System.Globalization;

namespace System.Text.Tests
{
    [TestFixture]
    public class EndsWithTests
    {
        private static readonly string correctStringToSearch = string.Concat(TestStrings.Composition1, TestStrings.Searched, TestStrings.Composition2, TestStrings.Searched);
        private static readonly string correctStringToSearchUpperCase = string.Concat(TestStrings.Composition1, TestStrings.Searched, TestStrings.Composition2, TestStrings.Searched.ToUpper());
        private static readonly string incorrectStringToSearch1 = string.Concat(TestStrings.Composition1, TestStrings.Composition2, TestStrings.Searched, TestStrings.SingleCharacter);
        private static readonly string incorrectStringToSearch2 = string.Concat(TestStrings.Composition1, TestStrings.Composition2);
        private static readonly string smallStringToSearch = TestStrings.Composition1;

        [Test]
        public void TestContainingCharacters()
        {
            StringBuilder sb;
            sb = new StringBuilder(correctStringToSearch);
            Assert.AreEqual(sb.EndsWith(TestStrings.Searched), correctStringToSearch.EndsWith(TestStrings.Searched));
            sb = new StringBuilder(TestStrings.Searched);
            Assert.AreEqual(sb.EndsWith(TestStrings.Searched), correctStringToSearch.EndsWith(TestStrings.Searched));
        }

        [Test]
        public void TestContainingCharactersIgnoreCase()
        {
            StringBuilder sb;
            sb = new StringBuilder(correctStringToSearchUpperCase);
            Assert.AreEqual(sb.EndsWith(TestStrings.Searched, true), correctStringToSearch.EndsWith(TestStrings.Searched, true, CultureInfo.CurrentCulture));
            sb = new StringBuilder(TestStrings.Searched.ToUpper());
            Assert.AreEqual(sb.EndsWith(TestStrings.Searched, true), correctStringToSearch.EndsWith(TestStrings.Searched, true, CultureInfo.CurrentCulture));
        }

        [Test]
        public void TestNotContainingCharacters()
        {
            StringBuilder sb;
            sb = new StringBuilder(incorrectStringToSearch1);
            Assert.AreEqual(sb.EndsWith(TestStrings.Searched), incorrectStringToSearch1.EndsWith(TestStrings.Searched));
            sb = new StringBuilder(incorrectStringToSearch2);
            Assert.AreEqual(sb.EndsWith(TestStrings.Searched), incorrectStringToSearch2.EndsWith(TestStrings.Searched));
        }

        [Test]
        public void TestNotContainingCharactersIgnoreCase()
        {
            StringBuilder sb;
            sb = new StringBuilder(incorrectStringToSearch1);
            Assert.AreEqual(sb.EndsWith(TestStrings.Searched, true), incorrectStringToSearch1.EndsWith(TestStrings.Searched, true, CultureInfo.CurrentCulture));
            sb = new StringBuilder(incorrectStringToSearch2);
            Assert.AreEqual(sb.EndsWith(TestStrings.Searched, true), incorrectStringToSearch2.EndsWith(TestStrings.Searched, true, CultureInfo.CurrentCulture));
        }

        [Test]
        public void TestNullValue()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                StringBuilder sb = new StringBuilder();
                sb.EndsWith(null);
            }
            );
        }

        [Test]
        public void TestEmptyValue()
        {
            StringBuilder sb = new StringBuilder();
            Assert.IsTrue(sb.EndsWith(string.Empty));
        }

        [Test]
        public void TestValueLengthGreaterThanStringBuilderLength()
        {
            StringBuilder sb = new StringBuilder(smallStringToSearch);
            Assert.AreEqual(sb.EndsWith(TestStrings.Searched), smallStringToSearch.EndsWith(TestStrings.Searched));
        }

        [Test]
        public void TestEmpty()
        {
            StringBuilder sb = new StringBuilder();
            Assert.IsFalse(sb.EndsWith(TestStrings.Searched));
        }
    }
}
