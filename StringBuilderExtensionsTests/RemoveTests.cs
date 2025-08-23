using NUnit.Framework;

namespace System.Text.Tests
{
    [TestFixture]
    public class RemoveTests
    {
        [Test]
        public void TestContainingCharacters()
        {
            StringBuilder sb;
            sb = new StringBuilder(TestStrings.LeadingAndTrailingWhiteSpaces).Remove(' ');
            Assert.AreEqual(sb.ToString(), TestStrings.WhiteSpacesRemoved);
            sb = new StringBuilder(TestStrings.LeadingAndTrailingSymbols).Remove(TestStrings.SymbolsToTrim);
            Assert.AreEqual(sb.ToString(), TestStrings.SymbolsRemoved);
        }

        [Test]
        public void TestNotContainingCharacters()
        {
            StringBuilder sb;
            sb = new StringBuilder(TestStrings.LeadingAndTrailingWhiteSpaces).Remove(TestStrings.SymbolsToTrim);
            Assert.AreEqual(sb.ToString(), TestStrings.LeadingAndTrailingWhiteSpaces);
            sb = new StringBuilder(TestStrings.LeadingAndTrailingSymbols).Remove(' ');
            Assert.AreEqual(sb.ToString(), TestStrings.LeadingAndTrailingSymbols);
        }

        [Test]
        public void TestByStartIndex()
        {
            StringBuilder sb = new StringBuilder(TestStrings.Composition1 + TestStrings.Composition2).Remove(TestStrings.Composition1.Length);
            Assert.AreEqual(sb.ToString(), TestStrings.Composition1);
        }

        [Test]
        public void TestEmpty()
        {
            StringBuilder sb = new StringBuilder().Remove(' ');
            Assert.AreEqual(sb.ToString(), string.Empty);
        }

        [Test]
        public void TestRemoveAllCharacters()
        {
            StringBuilder sb = new StringBuilder(TestStrings.Composition1).Remove(0);
            Assert.AreEqual(sb.ToString(), string.Empty);
        }

        [Test]
        public void TestRemoveLastCharacter()
        {
            StringBuilder sb = new StringBuilder(TestStrings.Composition1).Remove(TestStrings.Composition1.Length - 1);
            Assert.AreEqual(sb.ToString(), TestStrings.Composition1.Substring(0, TestStrings.Composition1.Length - 1));
        }

        [Test]
        public void TestIndexLessThanZero()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(TestStrings.Composition1).Remove(-1);
            }
            );
        }

        [Test]
        public void TestIndexGreaterThanMaximum()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                StringBuilder sb = new StringBuilder(TestStrings.Composition1);
                sb.Remove(sb.Length);
            }
            );
        }

        [Test]
        public void TestNullRemoveChars()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                StringBuilder sb = new StringBuilder().Remove(null);
            }
            );
        }

        /// <summary>
        /// Verifies that the function gracefully handles an empty StringBuilder.
        /// </summary>
        [Test]
        public void RemoveChar_RemovesCharacterFromEmptyStringBuilder()
        {
            // Arrange
            StringBuilder sb = new StringBuilder();
            char removeChar = 'a';

            // Act
            sb.Remove(removeChar);

            // Assert
            Assert.AreEqual(string.Empty, sb.ToString());
        }

        /// <summary>
        /// Ensures correct functionality for removing one occurrence of a character.
        /// </summary>
        [Test]
        public void RemoveChar_RemovesSingleOccurrence()
        {
            // Arrange
            StringBuilder sb = new StringBuilder("abc");
            char removeChar = 'b';

            // Act
            sb.Remove(removeChar);

            // Assert
            Assert.AreEqual("ac", sb.ToString());
        }

        /// <summary>
        /// Checks removal of a character appearing multiple times.
        /// </summary>
        [Test]
        public void RemoveChar_RemovesMultipleOccurrences()
        {
            // Arrange
            StringBuilder sb = new StringBuilder("banana");
            char removeChar = 'a';

            // Act
            sb.Remove(removeChar);

            // Assert
            Assert.AreEqual("bnn", sb.ToString());
        }

        /// <summary>
        /// Ensures no changes when the target character is absent.
        /// </summary>
        [Test]
        public void RemoveChar_DoesNotRemoveWhenCharacterNotFound()
        {
            // Arrange
            StringBuilder sb = new StringBuilder("hello");
            char removeChar = 'z';

            // Act
            sb.Remove(removeChar);

            // Assert
            Assert.AreEqual("hello", sb.ToString());
        }

        /// <summary>
        /// Confirms all consecutive occurrences are removed.
        /// </summary>
        [Test]
        public void RemoveChar_RemovesAllOccurrencesIncludingConsecutive()
        {
            // Arrange
            StringBuilder sb = new StringBuilder("aaabbbaaa");
            char removeChar = 'a';

            // Act
            sb.Remove(removeChar);

            // Assert
            Assert.AreEqual("bbb", sb.ToString());
        }

        /// <summary>
        /// Validates the ArgumentNullException is thrown when sb is null.
        /// </summary>
        [Test]
        public void RemoveChar_HandlesNullStringBuilder()
        {
            // Arrange
            StringBuilder sb = null;
            char removeChar = 'x';

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => sb.Remove(removeChar));
        }

        /// <summary>
        /// Ensures proper handling of StringBuilder with pre-existing content.
        /// </summary>
        [Test]
        public void RemoveChar_HandlesPrepopulatedStringBuilder()
        {
            // Arrange
            StringBuilder sb = new StringBuilder("initial content");
            char removeChar = 'i';

            // Act
            sb.Remove(removeChar);

            // Assert
            Assert.AreEqual("ntal content", sb.ToString());
        }

        /// <summary>
        /// Tests removing the null character, ensuring no unexpected behavior.
        /// </summary>
        [Test]
        public void RemoveChar_HandlesEmptyCharacterInput()
        {
            // Arrange
            StringBuilder sb = new StringBuilder("empty test");
            char removeChar = '\0'; // Null character

            // Act
            sb.Remove(removeChar);

            // Assert
            Assert.AreEqual("empty test", sb.ToString());
        }

        /// <summary>
        /// Verifies the function's ability to handle and remove a Unicode character.
        /// </summary>
        [Test]
        public void RemoveChar_RemovesUnicodeCharacter()
        {
            // Arrange
            StringBuilder sb = new StringBuilder("cafè ☕");
            char removeChar = 'è';

            // Act
            sb.Remove(removeChar);

            // Assert
            Assert.AreEqual("caf ☕", sb.ToString());
        }

        [Test]
        public void ReplaceStringWithInt_ReplacesSingleOccurrenceCaseSensitive()
        {
            // Arrange
            StringBuilder sb = new StringBuilder("Hello, world!");
            string oldValue = "world";
            int newValue = 123;

            // Act
            sb.Replace(oldValue, newValue, ignoreCase: false);

            // Assert
            Assert.AreEqual("Hello, 123!", sb.ToString());
        }

        [Test]
        public void ReplaceStringWithInt_ReplacesMultipleOccurrencesCaseSensitive()
        {
            // Arrange
            StringBuilder sb = new StringBuilder("world world world!");
            string oldValue = "world";
            int newValue = 456;

            // Act
            sb.Replace(oldValue, newValue, ignoreCase: false);

            // Assert
            Assert.AreEqual("456 456 456!", sb.ToString());
        }

        [Test]
        public void ReplaceStringWithInt_DoesNotReplaceIfCaseDoesNotMatch()
        {
            // Arrange
            StringBuilder sb = new StringBuilder("Hello, World!");
            string oldValue = "world";
            int newValue = 789;

            // Act
            sb.Replace(oldValue, newValue, ignoreCase: false);

            // Assert
            Assert.AreEqual("Hello, World!", sb.ToString());
        }

        [Test]
        public void ReplaceStringWithInt_ReplacesSingleOccurrenceIgnoreCase()
        {
            // Arrange
            StringBuilder sb = new StringBuilder("Hello, World!");
            string oldValue = "world";
            int newValue = 987;

            // Act
            sb.Replace(oldValue, newValue, ignoreCase: true);

            // Assert
            Assert.AreEqual("Hello, 987!", sb.ToString());
        }

        [Test]
        public void ReplaceStringWithInt_ReplacesMultipleOccurrencesIgnoreCase()
        {
            // Arrange
            StringBuilder sb = new StringBuilder("World world WoRlD!");
            string oldValue = "world";
            int newValue = 654;

            // Act
            sb.Replace(oldValue, newValue, ignoreCase: true);

            // Assert
            Assert.AreEqual("654 654 654!", sb.ToString());
        }

        [Test]
        public void ReplaceStringWithInt_HandlesEmptyStringBuilder()
        {
            // Arrange
            StringBuilder sb = new StringBuilder();
            string oldValue = "test";
            int newValue = 42;

            // Act
            sb.Replace(oldValue, newValue, ignoreCase: false);

            // Assert
            Assert.AreEqual(string.Empty, sb.ToString());
        }

        [Test]
        public void ReplaceStringWithInt_HandlesEmptyOldValue()
        {
            // Arrange
            StringBuilder sb = new StringBuilder("Some content");
            string oldValue = string.Empty;
            int newValue = 99;

            // Act
            sb.Replace(oldValue, newValue, ignoreCase: false);

            // Assert
            Assert.AreEqual("Some content", sb.ToString());
        }

        [Test]
        public void ReplaceStringWithInt_HandlesNullOldValue()
        {
            // Arrange
            StringBuilder sb = new StringBuilder("Null test");
            string oldValue = null;
            int newValue = 123;

            // Act
            sb.Replace(oldValue, newValue, ignoreCase: false);

            // Assert
            Assert.AreEqual("Null test", sb.ToString());
        }

        [Test]
        public void ReplaceStringWithInt_DoesNotReplaceIfOldValueNotFound()
        {
            // Arrange
            StringBuilder sb = new StringBuilder("Not here!");
            string oldValue = "missing";
            int newValue = 456;

            // Act
            sb.Replace(oldValue, newValue, ignoreCase: true);

            // Assert
            Assert.AreEqual("Not here!", sb.ToString());
        }
    }
}
