using NUnit.Framework;
using System.Globalization;
using static System.Text.Tests.TestStrings;

namespace System.Text.Tests
{
    [TestFixture]
    public class StartsWithTests
    {
        private static readonly string correctStringToSearch = string.Concat(Searched, Composition1, Searched, Composition2);
        private static readonly string correctStringToSearchUpperCase = string.Concat(Searched.ToUpper(), Composition1, Searched, Composition2);
        private static readonly string incorrectStringToSearch1 = string.Concat(SingleCharacter, Searched, Composition1, Composition2);
        private static readonly string incorrectStringToSearch2 = string.Concat(Composition1, Composition2);
        private static readonly string smallStringToSearch = Composition1;

        [Test]
        public void TestContainingCharacters()
        {
            StringBuilder sb;
            sb = new StringBuilder(correctStringToSearch);
            Assert.AreEqual(sb.StartsWith(Searched), correctStringToSearch.StartsWith(Searched));
            sb = new StringBuilder(Searched);
            Assert.AreEqual(sb.StartsWith(Searched), correctStringToSearch.StartsWith(Searched));
        }

        [Test]
        public void TestContainingCharactersIgnoreCase()
        {
            StringBuilder sb;
            sb = new StringBuilder(correctStringToSearchUpperCase);
            Assert.AreEqual(sb.StartsWith(Searched, true), correctStringToSearch.StartsWith(Searched, true, CultureInfo.CurrentCulture));
            sb = new StringBuilder(Searched.ToUpper());
            Assert.AreEqual(sb.StartsWith(Searched, true), correctStringToSearch.StartsWith(Searched, true, CultureInfo.CurrentCulture));
        }

        [Test]
        public void TestNotContainingCharacters()
        {
            StringBuilder sb;
            sb = new StringBuilder(incorrectStringToSearch1);
            Assert.AreEqual(sb.StartsWith(Searched), incorrectStringToSearch1.StartsWith(Searched));
            sb = new StringBuilder(incorrectStringToSearch2);
            Assert.AreEqual(sb.StartsWith(Searched), incorrectStringToSearch2.StartsWith(Searched));
        }

        [Test]
        public void TestNotContainingCharactersIgnoreCase()
        {
            StringBuilder sb;
            sb = new StringBuilder(incorrectStringToSearch1);
            Assert.AreEqual(sb.StartsWith(Searched, true), incorrectStringToSearch1.StartsWith(Searched, true, CultureInfo.CurrentCulture));
            sb = new StringBuilder(incorrectStringToSearch2);
            Assert.AreEqual(sb.StartsWith(Searched, true), incorrectStringToSearch2.StartsWith(Searched, true, CultureInfo.CurrentCulture));
        }

        [Test]
        public void TestNullValue()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                StringBuilder sb = new StringBuilder();
                sb.StartsWith(Null);
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
            Assert.AreEqual(sb.StartsWith(Searched), smallStringToSearch.StartsWith(Searched));
        }

        [Test]
        public void TestEmpty()
        {
            StringBuilder sb = new StringBuilder();
            Assert.IsFalse(sb.StartsWith(Searched));
        }
    }
}
