using NUnit.Framework;
using static System.Text.Tests.TestStrings;

namespace System.Text.Tests
{
    [TestFixture]
    public class RemoveStringBuilderTests
    {
        [Test]
        public void TestNotContainingCharacters()
        {
            StringBuilder sb;
            StringBuilder test = new StringBuilder(" ");
            sb = new StringBuilder(LeadingAndTrailingWhiteSpaces).Remove(TestStringBuilders.SymbolsToTrim);
            Assert.AreEqual(sb.ToString(), LeadingAndTrailingWhiteSpaces);
            sb = new StringBuilder(LeadingAndTrailingSymbols).Remove(test);
            Assert.AreEqual(sb.ToString(), LeadingAndTrailingSymbols);
        }

        [Test]
        public void TestEmpty()
        {
            StringBuilder test = new StringBuilder(" ");
            StringBuilder sb = new StringBuilder().Remove(test);
            Assert.AreEqual(sb.ToString(), string.Empty);
        }

        [Test]
        public void TestNullRemoveStringBuilder()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                StringBuilder test = default;
                StringBuilder sb = new StringBuilder().Remove(test);
            }
            );
        }

        /// <summary>
        /// Verifies that the function gracefully handles an empty StringBuilder.
        /// </summary>
        [Test]
        public void RemoveStringBuilder_RemovesCharacterFromEmptyStringBuilder()
        {
            // Arrange
            StringBuilder sb = new StringBuilder();
            StringBuilder removeChar = new StringBuilder("a");

            // Act
            sb.Remove(removeChar);

            // Assert
            Assert.AreEqual(string.Empty, sb.ToString());
        }

        /// <summary>
        /// Ensures correct functionality for removing one occurrence of a character.
        /// </summary>
        [Test]
        public void RemoveStringBuilder_RemovesSingleOccurrence()
        {
            // Arrange
            StringBuilder sb = new StringBuilder("abc");
            StringBuilder removeChar = new StringBuilder("b");

            // Act
            sb.Remove(removeChar);

            // Assert
            Assert.AreEqual("ac", sb.ToString());
        }

        /// <summary>
        /// Checks removal of a character appearing multiple times.
        /// </summary>
        [Test]
        public void RemoveStringBuilder_RemovesMultipleOccurrences()
        {
            // Arrange
            StringBuilder sb = new StringBuilder("banana");
            StringBuilder removeChar = new StringBuilder("a");

            // Act
            sb.Remove(removeChar);

            // Assert
            Assert.AreEqual("bnn", sb.ToString());
        }

        /// <summary>
        /// Ensures no changes when the target character is absent.
        /// </summary>
        [Test]
        public void RemoveStringBuilder_DoesNotRemoveWhenCharacterNotFound()
        {
            // Arrange
            StringBuilder sb = new StringBuilder("hello");
            StringBuilder removeChar = new StringBuilder("z");

            // Act
            sb.Remove(removeChar);

            // Assert
            Assert.AreEqual("hello", sb.ToString());
        }

        /// <summary>
        /// Confirms all consecutive occurrences are removed.
        /// </summary>
        [Test]
        public void RemoveStringBuilder_RemovesAllOccurrencesIncludingConsecutive()
        {
            // Arrange
            StringBuilder sb = new StringBuilder("aaabbbaaa");
            StringBuilder removeChar = new StringBuilder("a");

            // Act
            sb.Remove(removeChar);

            // Assert
            Assert.AreEqual("bbb", sb.ToString());
        }

        /// <summary>
        /// Validates the ArgumentNullException is thrown when sb is null.
        /// </summary>
        [Test]
        public void RemoveStringBuilder_HandlesNullStringBuilder()
        {
            // Arrange
            StringBuilder sb = null;
            StringBuilder removeChar = new StringBuilder("x");

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => sb.Remove(removeChar));
        }

        /// <summary>
        /// Tests removing the null character, ensuring no unexpected behavior.
        /// </summary>
        [Test]
        public void RemoveStringBuilder_HandlesEmptyCharacterInput()
        {
            // Arrange
            StringBuilder sb = new StringBuilder("empty test");
            StringBuilder removeChar = new StringBuilder("\0"); // Null character

            // Act
            sb.Remove(removeChar);

            // Assert
            Assert.AreEqual("empty test", sb.ToString());
        }

        /// <summary>
        /// Verifies the function's ability to handle and remove a Unicode character.
        /// </summary>
        [Test]
        public void RemoveStringBuilder_RemovesUnicodeCharacter()
        {
            // Arrange
            StringBuilder sb = new StringBuilder("cafè ☕");
            StringBuilder removeChar = new StringBuilder("è");

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
            StringBuilder oldValue = new StringBuilder("world");
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
            StringBuilder oldValue = new StringBuilder("world");
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
            StringBuilder oldValue = new StringBuilder("world");
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
            StringBuilder oldValue = new StringBuilder("world");
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
            StringBuilder oldValue = new StringBuilder("world");
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
            StringBuilder oldValue = new StringBuilder("test");
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
            StringBuilder oldValue = new StringBuilder();
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
            StringBuilder oldValue = default;
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
            StringBuilder oldValue = new StringBuilder("missing");
            int newValue = 456;

            // Act
            sb.Replace(oldValue, newValue, ignoreCase: true);

            // Assert
            Assert.AreEqual("Not here!", sb.ToString());
        }

        [Test]
        public void ReplaceStringBuilderWithStringBuilder_ReplacesSingleOccurrenceCaseSensitive()
        {
            // Arrange
            StringBuilder sb = new StringBuilder("Hello, world!");
            StringBuilder oldValue = new StringBuilder("world");
            StringBuilder newValue = new StringBuilder("123");

            // Act
            sb.Replace(oldValue, newValue, ignoreCase: false);

            // Assert
            Assert.AreEqual("Hello, 123!", sb.ToString());
        }

        [Test]
        public void ReplaceStringBuilderWithStringBuilder_ReplacesMultipleOccurrencesCaseSensitive()
        {
            // Arrange
            StringBuilder sb = new StringBuilder("world world world!");
            StringBuilder oldValue = new StringBuilder("world");
            StringBuilder newValue = new StringBuilder("456");

            // Act
            sb.Replace(oldValue, newValue, ignoreCase: false);

            // Assert
            Assert.AreEqual("456 456 456!", sb.ToString());
        }

        [Test]
        public void ReplaceStringBuilderWithStringBuilder_DoesNotReplaceIfCaseDoesNotMatch()
        {
            // Arrange
            StringBuilder sb = new StringBuilder("Hello, World!");
            StringBuilder oldValue = new StringBuilder("world");
            StringBuilder newValue = new StringBuilder("789");

            // Act
            sb.Replace(oldValue, newValue, ignoreCase: false);

            // Assert
            Assert.AreEqual("Hello, World!", sb.ToString());
        }

        [Test]
        public void ReplaceStringBuilderWithStringBuilder_ReplacesSingleOccurrenceIgnoreCase()
        {
            // Arrange
            StringBuilder sb = new StringBuilder("Hello, World!");
            StringBuilder oldValue = new StringBuilder("world");
            StringBuilder newValue = new StringBuilder("987");

            // Act
            sb.Replace(oldValue, newValue, ignoreCase: true);

            // Assert
            Assert.AreEqual("Hello, 987!", sb.ToString());
        }

        [Test]
        public void ReplaceStringBuilderWithStringBuilder_ReplacesMultipleOccurrencesIgnoreCase()
        {
            // Arrange
            StringBuilder sb = new StringBuilder("World world WoRlD!");
            StringBuilder oldValue = new StringBuilder("world");
            StringBuilder newValue = new StringBuilder("654");

            // Act
            sb.Replace(oldValue, newValue, ignoreCase: true);

            // Assert
            Assert.AreEqual("654 654 654!", sb.ToString());
        }

        [Test]
        public void ReplaceStringBuilderWithStringBuilder_HandlesEmptyStringBuilder()
        {
            // Arrange
            StringBuilder sb = new StringBuilder();
            StringBuilder oldValue = new StringBuilder("test");
            StringBuilder newValue = new StringBuilder("42");

            // Act
            sb.Replace(oldValue, newValue, ignoreCase: false);

            // Assert
            Assert.AreEqual(string.Empty, sb.ToString());
        }

        [Test]
        public void ReplaceStringBuilderWithStringBuilder_HandlesEmptyOldValue()
        {
            // Arrange
            StringBuilder sb = new StringBuilder("Some content");
            StringBuilder oldValue = new StringBuilder();
            StringBuilder newValue = new StringBuilder("99");

            // Act
            sb.Replace(oldValue, newValue, ignoreCase: false);

            // Assert
            Assert.AreEqual("Some content", sb.ToString());
        }

        [Test]
        public void ReplaceStringBuilderWithStringBuilder_HandlesNullOldValue()
        {
            // Arrange
            StringBuilder sb = new StringBuilder("Null test");
            StringBuilder oldValue = default;
            StringBuilder newValue = new StringBuilder("123");

            // Act
            sb.Replace(oldValue, newValue, ignoreCase: false);

            // Assert
            Assert.AreEqual("Null test", sb.ToString());
        }

        [Test]
        public void ReplaceStringBuilderWithStringBuilder_DoesNotReplaceIfOldValueNotFound()
        {
            // Arrange
            StringBuilder sb = new StringBuilder("Not here!");
            StringBuilder oldValue = new StringBuilder("missing");
            StringBuilder newValue = new StringBuilder("456");

            // Act
            sb.Replace(oldValue, newValue, ignoreCase: true);

            // Assert
            Assert.AreEqual("Not here!", sb.ToString());
        }
    }
}
