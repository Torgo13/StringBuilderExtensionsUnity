using NUnit.Framework;
using System.Globalization;
using static System.Text.Tests.TestStrings;

namespace System.Text.Tests
{
    [TestFixture]
    public class EndsWithTests
    {
        private static readonly string correctStringToSearch = string.Concat(Composition1, Searched, Composition2, Searched);
        private static readonly string correctStringToSearchUpperCase = string.Concat(Composition1, Searched, Composition2, Searched.ToUpper());
        private static readonly string incorrectStringToSearch1 = string.Concat(Composition1, Composition2, Searched, SingleCharacter);
        private static readonly string incorrectStringToSearch2 = string.Concat(Composition1, Composition2);
        private static readonly string smallStringToSearch = Composition1;

        [Test]
        public void TestContainingCharacters()
        {
            StringBuilder sb;
            sb = new StringBuilder(correctStringToSearch);
            Assert.AreEqual(sb.EndsWith(Searched), correctStringToSearch.EndsWith(Searched));
            sb = new StringBuilder(Searched);
            Assert.AreEqual(sb.EndsWith(Searched), correctStringToSearch.EndsWith(Searched));
        }

        [Test]
        public void TestContainingCharactersIgnoreCase()
        {
            StringBuilder sb;
            sb = new StringBuilder(correctStringToSearchUpperCase);
            Assert.AreEqual(sb.EndsWith(Searched, true), correctStringToSearch.EndsWith(Searched, true, CultureInfo.CurrentCulture));
            sb = new StringBuilder(Searched.ToUpper());
            Assert.AreEqual(sb.EndsWith(Searched, true), correctStringToSearch.EndsWith(Searched, true, CultureInfo.CurrentCulture));
        }

        [Test]
        public void TestNotContainingCharacters()
        {
            StringBuilder sb;
            sb = new StringBuilder(incorrectStringToSearch1);
            Assert.AreEqual(sb.EndsWith(Searched), incorrectStringToSearch1.EndsWith(Searched));
            sb = new StringBuilder(incorrectStringToSearch2);
            Assert.AreEqual(sb.EndsWith(Searched), incorrectStringToSearch2.EndsWith(Searched));
        }

        [Test]
        public void TestNotContainingCharactersIgnoreCase()
        {
            StringBuilder sb;
            sb = new StringBuilder(incorrectStringToSearch1);
            Assert.AreEqual(sb.EndsWith(Searched, true), incorrectStringToSearch1.EndsWith(Searched, true, CultureInfo.CurrentCulture));
            sb = new StringBuilder(incorrectStringToSearch2);
            Assert.AreEqual(sb.EndsWith(Searched, true), incorrectStringToSearch2.EndsWith(Searched, true, CultureInfo.CurrentCulture));
        }

        [Test]
        public void TestNullValue()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                StringBuilder sb = new StringBuilder();
                sb.EndsWith(Null);
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
            Assert.AreEqual(sb.EndsWith(Searched), smallStringToSearch.EndsWith(Searched));
        }

        [Test]
        public void TestEmpty()
        {
            StringBuilder sb = new StringBuilder();
            Assert.IsFalse(sb.EndsWith(Searched));
        }
    }
}
