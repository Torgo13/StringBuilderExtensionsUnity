#region License
// The MIT License (MIT)

// Copyright (c) 2014 Andrii Chebukin as XperiAndri

// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:

// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
#endregion License

using System.Globalization;

namespace System.Text
{
    public static class StringBuilderExtensions
    {
        #region Any
        /// <summary>
        /// Replacement for <see cref="System.Linq.Enumerable.Any{TSource}(Collections.Generic.IEnumerable{TSource})"/>
        /// </summary>
        /// <param name="chars">Array of chars.</param>
        /// <param name="c">Char to search for.</param>
        /// <returns><see langword="true"/> if char c is present in chars.</returns>
        private static bool Any(this StringBuilder chars, char c)
        {
            for (int i = 0, charsLength = chars?.Length ?? 0; i < charsLength; i++)
            {
                if (chars[i] == c)
                    return true;
            }

            return false;
        }

        /// <inheritdoc cref="Any(StringBuilder, char)"/>
        private static bool Any(ReadOnlySpan<char> chars, char c)
        {
            foreach (char ch in chars)
            {
                if (ch == c)
                    return true;
            }

            return false;
        }
        #endregion // Any

        #region Remove
        /// <summary>
        /// Removes all occurrences of specified characters from <see cref="StringBuilder"/>.
        /// </summary>
        /// <param name="sb">A <see cref="StringBuilder"/> to remove from.</param>
        /// <param name="removeChar">A Unicode character to remove.</param>
        /// <returns>
        /// Returns <see cref="StringBuilder"/> without specified Unicode characters.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="sb"/> is null.</exception>
        public static StringBuilder Remove(this StringBuilder sb, char removeChar)
        {
            if (sb == null)
                throw new ArgumentNullException(nameof(sb));

            for (int i = 0; i < sb.Length;)
            {
                if (removeChar == sb[i])
                    _ = sb.Remove(i, 1);
                else
                    i++;
            }

            return sb;
        }

        /// <summary>
        /// Removes all occurrences of specified characters from <see cref="StringBuilder"/>.
        /// </summary>
        /// <param name="sb">A <see cref="StringBuilder"/> to remove from.</param>
        /// <param name="removeChars">Unicode characters to remove.</param>
        /// <returns>
        /// Returns <see cref="StringBuilder"/> without specified Unicode characters.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="removeChars"/> is null.</exception>
        public static StringBuilder Remove(this StringBuilder sb, params char[] removeChars)
        {
            return sb.Remove(removeChars.AsSpan());
        }

        /// <inheritdoc cref="Remove(StringBuilder, char[])"/>
        public static StringBuilder Remove(this StringBuilder sb, ReadOnlySpan<char> removeChars)
        {
            if (sb == null)
                throw new ArgumentNullException(nameof(sb));
            if (removeChars == null)
                throw new ArgumentNullException(nameof(removeChars));

            for (int i = 0; i < sb.Length;)
            {
                if (Any(removeChars, sb[i]))
                    _ = sb.Remove(i, 1);
                else
                    i++;
            }

            return sb;
        }

        /// <inheritdoc cref="Remove(StringBuilder, char[])"/>
        public static StringBuilder Remove(this StringBuilder sb, StringBuilder removeChars)
        {
            if (sb == null)
                throw new ArgumentNullException(nameof(sb));
            if (removeChars == null)
                throw new ArgumentNullException(nameof(removeChars));

            for (int i = 0; i < sb.Length;)
            {
                if (removeChars.Any(sb[i]))
                    _ = sb.Remove(i, 1);
                else
                    i++;
            }

            return sb;
        }

        /// <summary>
        /// Removes the range of characters from the specified index to the end of <see cref="StringBuilder"/>.
        /// </summary>
        /// <param name="sb">A <see cref="StringBuilder"/> to remove from.</param>
        /// <param name="startIndex">The zero-based position to begin deleting characters.</param>
        /// <returns>The <see cref="StringBuilder"/> after the excise operation has completed.</returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// If <paramref name="startIndex"/> is less than zero, or <paramref name="startIndex"/> is greater
        /// than the length - 1.
        /// </exception>
        public static StringBuilder Remove(this StringBuilder sb, int startIndex)
        {
            if (sb == null)
                throw new ArgumentNullException(nameof(sb));
            if (startIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(startIndex));
            if (startIndex >= sb.Length)
                throw new ArgumentOutOfRangeException(nameof(startIndex));

            return sb.Remove(startIndex, sb.Length - startIndex);
        }
        #endregion // Remove

        private static StringBuilder CreateTrimmedString(this StringBuilder sb, int start, int end)
        {
            int length = (end - start) + 1;
            if (length == sb.Length)
            {
                return sb;
            }

            if (length == 0)
            {
                sb.Length = 0;
                return sb;
            }

            return sb.InternalSubString(start, end);
        }

        private static StringBuilder InternalSubString(this StringBuilder sb, int startIndex, int end)
        {
            sb.Length = end + 1;
            return sb.Remove(0, startIndex);
        }

        #region TrimHelper
        private static StringBuilder TrimHelper(this StringBuilder sb, int trimType)
        {
            int end = sb.Length - 1;
            int start = 0;
            if (trimType != 1)
            {
                start = 0;
                while (start < sb.Length)
                {
                    if (!char.IsWhiteSpace(sb[start]))
                    {
                        break;
                    }

                    start++;
                }
            }

            if (trimType != 0)
            {
                end = sb.Length - 1;
                while (end >= start)
                {
                    if (!char.IsWhiteSpace(sb[end]))
                    {
                        break;
                    }

                    end--;
                }
            }

            return sb.CreateTrimmedString(start, end);
        }

        private static StringBuilder TrimHelper(this StringBuilder sb, ReadOnlySpan<char> trimChars, int trimType)
        {
            int end = sb.Length - 1;
            int start = 0;
            if (trimType != 1)
            {
                start = 0;
                while (start < sb.Length)
                {
                    int index = 0;
                    char ch = sb[start];
                    while (index < trimChars.Length)
                    {
                        if (trimChars[index] == ch)
                        {
                            break;
                        }

                        index++;
                    }

                    if (index == trimChars.Length)
                    {
                        break;
                    }

                    start++;
                }
            }

            if (trimType != 0)
            {
                end = sb.Length - 1;
                while (end >= start)
                {
                    int num4 = 0;
                    char ch2 = sb[end];
                    while (num4 < trimChars.Length)
                    {
                        if (trimChars[num4] == ch2)
                        {
                            break;
                        }

                        num4++;
                    }

                    if (num4 == trimChars.Length)
                    {
                        break;
                    }

                    end--;
                }
            }

            return sb.CreateTrimmedString(start, end);
        }

        private static StringBuilder TrimHelper(this StringBuilder sb, StringBuilder trimChars, int trimType)
        {
            int end = sb.Length - 1;
            int start = 0;
            if (trimType != 1)
            {
                start = 0;
                while (start < sb.Length)
                {
                    int index = 0;
                    char ch = sb[start];
                    while (index < trimChars.Length)
                    {
                        if (trimChars[index] == ch)
                        {
                            break;
                        }

                        index++;
                    }

                    if (index == trimChars.Length)
                    {
                        break;
                    }

                    start++;
                }
            }

            if (trimType != 0)
            {
                end = sb.Length - 1;
                while (end >= start)
                {
                    int num4 = 0;
                    char ch2 = sb[end];
                    while (num4 < trimChars.Length)
                    {
                        if (trimChars[num4] == ch2)
                        {
                            break;
                        }

                        num4++;
                    }

                    if (num4 == trimChars.Length)
                    {
                        break;
                    }

                    end--;
                }
            }

            return sb.CreateTrimmedString(start, end);
        }
        #endregion // TrimHelper

        #region TrimStart
        /// <summary>
        /// Removes all leading occurrences of a set of characters specified in an array 
        /// from the current <see cref="StringBuilder"/> object.
        /// </summary>
        /// <param name="sb">A <see cref="StringBuilder"/> to remove from.</param>
        /// <param name="trimChars">An array of Unicode characters to remove, or null.</param>
        /// <returns>
        /// The <see cref="StringBuilder"/> object that contains a list of characters 
        /// that remains after all occurrences of the characters in the <paramref name="trimChars"/> parameter 
        /// are removed from the end of the current string. If <paramref name="trimChars"/> is null or an empty array, 
        /// Unicode white-space characters are removed instead.
        /// </returns>
        public static StringBuilder TrimStart(this StringBuilder sb, params char[] trimChars)
        {
            return sb.TrimStart(trimChars.AsSpan());
        }

        /// <inheritdoc cref="TrimStart(StringBuilder, char[])"/>
        public static StringBuilder TrimStart(this StringBuilder sb, ReadOnlySpan<char> trimChars)
        {
            if (sb == null)
                throw new ArgumentNullException(nameof(sb));

            return trimChars != null && trimChars.Length != 0
                ? sb.TrimHelper(trimChars, 0)
                : sb.TrimHelper(0);
        }

        /// <inheritdoc cref="TrimStart(StringBuilder, char[])"/>
        public static StringBuilder TrimStart(this StringBuilder sb, StringBuilder trimChars)
        {
            if (sb == null)
                throw new ArgumentNullException(nameof(sb));

            return trimChars != null && trimChars.Length != 0
                ? sb.TrimHelper(trimChars, 0)
                : sb.TrimHelper(0);
        }
        #endregion // TrimStart

        #region TrimEnd
        /// <summary>
        /// Removes all trailing occurrences of a set of characters specified in an array 
        /// from the current <see cref="StringBuilder"/> object.
        /// </summary>
        /// <param name="sb">A <see cref="StringBuilder"/> to remove from.</param>
        /// <param name="trimChars">An array of Unicode characters to remove, or null.</param>
        /// <returns>
        /// The <see cref="StringBuilder"/> object that contains a list of characters that remains 
        /// after all occurrences of the characters in the <paramref name="trimChars"/> parameter are removed 
        /// from the end of the current string. If <paramref name="trimChars"/> is null or an empty array, 
        /// Unicode white-space characters are removed instead.
        /// </returns>
        public static StringBuilder TrimEnd(this StringBuilder sb, params char[] trimChars)
        {
            return sb.TrimEnd(trimChars.AsSpan());
        }

        /// <inheritdoc cref="TrimEnd(StringBuilder, char[])"/>
        public static StringBuilder TrimEnd(this StringBuilder sb, ReadOnlySpan<char> trimChars)
        {
            if (sb == null)
                throw new ArgumentNullException(nameof(sb));

            return trimChars != null && trimChars.Length != 0
                ? sb.TrimHelper(trimChars, 1)
                : sb.TrimHelper(1);
        }

        /// <inheritdoc cref="TrimEnd(StringBuilder, char[])"/>
        public static StringBuilder TrimEnd(this StringBuilder sb, StringBuilder trimChars)
        {
            if (sb == null)
                throw new ArgumentNullException(nameof(sb));

            return trimChars != null && trimChars.Length != 0
                ? sb.TrimHelper(trimChars, 1)
                : sb.TrimHelper(1);
        }
        #endregion // TrimEnd

        #region Trim
        /// <summary>
        /// Removes all leading and trailing white-space characters from the current <see cref="StringBuilder"/> object.
        /// </summary>
        /// <param name="sb">A <see cref="StringBuilder"/> to remove from.</param>
        /// <returns>
        /// The <see cref="StringBuilder"/> object that contains a list of characters 
        /// that remains after all white-space characters are removed 
        /// from the start and end of the current StringBuilder.
        /// </returns>
        public static StringBuilder Trim(this StringBuilder sb)
        {
            if (sb == null)
                throw new ArgumentNullException(nameof(sb));

            return sb.TrimHelper(2);
        }

        /// <summary>
        /// Removes all leading and trailing occurrences of a set of characters specified in an array
        /// from the current <see cref="StringBuilder"/> object.
        /// </summary>
        /// <param name="sb">A <see cref="StringBuilder"/> to remove from.</param>
        /// <param name="trimChars">An array of Unicode characters to remove, or null.</param>
        /// <returns>
        /// The <see cref="StringBuilder"/> object that contains a list of characters that remains 
        /// after all occurrences of the characters in the <paramref name="trimChars"/> parameter are removed 
        /// from the end of the current StringBuilder. If <paramref name="trimChars"/> is null or an empty array, 
        /// Unicode white-space characters are removed instead.
        /// </returns>
        public static StringBuilder Trim(this StringBuilder sb, params char[] trimChars)
        {
            return sb.Trim(trimChars.AsSpan());
        }

        /// <inheritdoc cref="Trim(StringBuilder, char[])"/>
        public static StringBuilder Trim(this StringBuilder sb, ReadOnlySpan<char> trimChars)
        {
            if (sb == null)
                throw new ArgumentNullException(nameof(sb));

            return trimChars != null && trimChars.Length != 0
                ? sb.TrimHelper(trimChars, 2)
                : sb.TrimHelper(2);
        }

        /// <inheritdoc cref="Trim(StringBuilder, char[])"/>
        public static StringBuilder Trim(this StringBuilder sb, StringBuilder trimChars)
        {
            if (sb == null)
                throw new ArgumentNullException(nameof(sb));

            return trimChars != null && trimChars.Length != 0
                ? sb.TrimHelper(trimChars, 2)
                : sb.TrimHelper(2);
        }
        #endregion // Trim

        #region IndexOf
        /// <summary>
        /// Reports the zero-based index position of the first occurrence of the specified Unicode character.
        /// </summary>
        /// <param name="sb">A <see cref="StringBuilder"/> to search.</param>
        /// <param name="value">A Unicode character to seek.</param>
        /// <returns>
        /// The zero-based index position of <paramref name="value"/> if that character is found, or -1
        /// if it is not.
        /// </returns>
        public static int IndexOf(this StringBuilder sb, char value)
        {
            if (sb == null)
                throw new ArgumentNullException(nameof(sb));

            return IndexOf(sb, value, 0, sb.Length);
        }

        /// <summary>
        /// Reports the zero-based index position of the first occurrence of the specified Unicode
        /// characters. The search starts at a specified character position.
        /// </summary>
        /// <param name="sb">A <see cref="StringBuilder"/> to search.</param>
        /// <param name="value">A Unicode character to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <returns>
        /// The zero-based index position of <paramref name="value"/> if that character is found, or -1
        /// if it is not.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// The current instance <see cref="StringBuilder.Length"/> does not equal 0, and <paramref name="startIndex"/> 
        /// is less than 0 (zero) or greater than the length of the <see cref="StringBuilder"/>.
        /// </exception>
        public static int IndexOf(this StringBuilder sb, char value, int startIndex)
        {
            if (sb == null)
                throw new ArgumentNullException(nameof(sb));
            if (sb.Length != 0 && startIndex < 0)
                throw new ArgumentOutOfRangeException();
            if (sb.Length != 0 && startIndex >= sb.Length)
                throw new ArgumentOutOfRangeException();

            return sb.IndexOf(value, startIndex, sb.Length - startIndex);
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence of the specified Unicode
        /// character in the <see cref="StringBuilder"/>. The search starts 
        /// at a specified character position and examines a specified number of character positions.
        /// </summary>
        /// <param name="sb">A <see cref="StringBuilder"/> to search.</param>
        /// <param name="value">A Unicode character to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="count">The number of character positions to examine.</param>
        /// <returns>
        /// The zero-based index position of <paramref name="value"/> if that character is found, or -1 
        /// if it is not.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// The current instance <see cref="StringBuilder.Length"/> does not equal 0, and <paramref name="count"/> 
        /// or <paramref name="startIndex"/> is negative.-or- <paramref name="startIndex"/> is greater than 
        /// the length of the <see cref="StringBuilder"/>.
        /// -or-The current instance <see cref="StringBuilder.Length"/> does not equal 0, and <paramref name="count"/> 
        /// is greater than the length minus <paramref name="startIndex"/>. 
        /// </exception>
        public static int IndexOf(this StringBuilder sb, char value, int startIndex, int count)
        {
            if (sb == null)
                throw new ArgumentNullException(nameof(sb));
            if (sb.Length != 0 && startIndex < 0)
                throw new ArgumentOutOfRangeException();
            if (sb.Length != 0 && count < 0)
                throw new ArgumentOutOfRangeException();
            if (sb.Length != 0 && startIndex + count > sb.Length)
                throw new ArgumentOutOfRangeException();

            if (sb.Length == 0 || count == 0)
                return -1;

            for (int i = startIndex; i < startIndex + count; i++)
            {
                if (sb[i] == value)
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence of the specified string in the current <see cref="StringBuilder"/> object.
        /// </summary>
        /// <param name="sb">A <see cref="StringBuilder"/> to search.</param>
        /// <param name="value">The string to seek.</param>
        /// <param name="ignoreCase"><see langword="true"/> to ignore case during the comparison; otherwise, <see langword="false"/>.</param>
        /// <returns>
        /// The zero-based index position of the <paramref name="value"/> parameter if that string is found, 
        /// or -1 if it is not. If <paramref name="value"/> is <see cref="String.Empty"/>, the return value 
        /// is 0.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
        public static int IndexOf(this StringBuilder sb, ReadOnlySpan<char> value, bool ignoreCase = false)
        {
            if (sb == null)
                throw new ArgumentNullException(nameof(sb));
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            if (value.Length == 0)
                return 0;

            return IndexOfInternal(sb, value, 0, sb.Length, ignoreCase);
        }

        /// <inheritdoc cref="IndexOf(StringBuilder, ReadOnlySpan{char}, bool)"/>
        public static int IndexOf(this StringBuilder sb, StringBuilder value, bool ignoreCase = false)
        {
            if (sb == null)
                throw new ArgumentNullException(nameof(sb));
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            if (value.Length == 0)
                return 0;

            return IndexOfInternal(sb, value, 0, sb.Length, ignoreCase);
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence of the specified string in the current <see cref="StringBuilder"/> object. 
        /// Parameter specifies the starting search position in the current <see cref="StringBuilder"/>.
        /// </summary>
        /// <param name="sb">A <see cref="StringBuilder"/> to search.</param>
        /// <param name="value">The string to seek. </param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="ignoreCase"><see langword="true"/> to ignore case during the comparison; otherwise, <see langword="false"/>.</param>
        /// <returns>
        /// The zero-based index position of the <paramref name="value"/> parameter if that string is found, 
        /// or -1 if it is not. If <paramref name="value"/> is <see cref="String.Empty"/>, the return value 
        /// is <paramref name="startIndex"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="startIndex"/> is less than 0 (zero) or greater than the length of the <see cref="StringBuilder"/>.
        /// </exception>
        public static int IndexOf(this StringBuilder sb, ReadOnlySpan<char> value, int startIndex, bool ignoreCase = false)
        {
            if (sb == null)
                throw new ArgumentNullException(nameof(sb));
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            if (startIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(startIndex));
            if ((sb.Length != 0 || startIndex != 0) && startIndex >= sb.Length)
                throw new ArgumentOutOfRangeException();

            return IndexOfInternal(sb, value, startIndex, sb.Length - startIndex, ignoreCase);
        }

        /// <inheritdoc cref="IndexOf(StringBuilder, ReadOnlySpan{char}, int, bool)"/>
        public static int IndexOf(this StringBuilder sb, StringBuilder value, int startIndex, bool ignoreCase = false)
        {
            if (sb == null)
                throw new ArgumentNullException(nameof(sb));
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            if (startIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(startIndex));
            if ((sb.Length != 0 || startIndex != 0) && startIndex >= sb.Length)
                throw new ArgumentOutOfRangeException();

            return IndexOfInternal(sb, value, startIndex, sb.Length - startIndex, ignoreCase);
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence of the specified string in the current <see cref="StringBuilder"/> object. 
        /// The search starts at a specified character position and examines a specified number of character positions.
        /// </summary>
        /// <param name="sb">A <see cref="StringBuilder"/> to search.</param>
        /// <param name="value">The string to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="count">The number of character positions to examine.</param>
        /// <param name="ignoreCase"><see langword="true"/> to ignore case during the comparison; otherwise, <see langword="false"/>.</param>
        /// <returns>
        /// The zero-based index position of the <paramref name="value"/> parameter if that string is found, 
        /// or -1 if it is not. If <paramref name="value"/> is <see cref="String.Empty"/>, 
        /// the return value is <paramref name="startIndex"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">value is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="count"/> or <paramref name="startIndex"/> is negative.-or- <paramref name="startIndex"/> is 
        /// greater than the length.-or-<paramref name="count"/> is greater than the length of 
        /// the <see cref="StringBuilder"/> minus <paramref name="startIndex"/>.
        /// </exception>
        public static int IndexOf(this StringBuilder sb, ReadOnlySpan<char> value, int startIndex, int count, bool ignoreCase = false)
        {
            if (sb == null)
                throw new ArgumentNullException(nameof(sb));
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            if (startIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(startIndex));
            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count));
            if (startIndex + count > sb.Length)
                throw new ArgumentOutOfRangeException();

            return IndexOfInternal(sb, value, startIndex, count, ignoreCase);
        }

        /// <inheritdoc cref="IndexOf(StringBuilder, ReadOnlySpan{char}, int, int, bool)"/>
        public static int IndexOf(this StringBuilder sb, StringBuilder value, int startIndex, int count, bool ignoreCase = false)
        {
            if (sb == null)
                throw new ArgumentNullException(nameof(sb));
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            if (startIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(startIndex));
            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count));
            if (startIndex + count > sb.Length)
                throw new ArgumentOutOfRangeException();

            return IndexOfInternal(sb, value, startIndex, count, ignoreCase);
        }

        private static int IndexOfInternal(StringBuilder sb, ReadOnlySpan<char> value, int startIndex, int count, bool ignoreCase)
        {
            if (value == null || value.Length == 0)
                return startIndex;
            if (sb.Length == 0 || count == 0 || startIndex + 1 + value.Length > sb.Length)
                return -1;

            int num3;
            int length = value.Length;
            int num2 = startIndex + count - value.Length;
            if (!ignoreCase)
            {
                for (int i = startIndex; i <= num2; i++)
                {
                    if (sb[i] == value[0])
                    {
                        num3 = 1;
                        while ((num3 < length) && (sb[i + num3] == value[num3]))
                        {
                            num3++;
                        }

                        if (num3 == length)
                        {
                            return i;
                        }
                    }
                }
            }
            else
            {
                for (int j = startIndex; j <= num2; j++)
                {
                    if (char.ToLower(sb[j]) == char.ToLower(value[0]))
                    {
                        num3 = 1;
                        while ((num3 < length) && (char.ToLower(sb[j + num3]) == char.ToLower(value[num3])))
                        {
                            num3++;
                        }

                        if (num3 == length)
                        {
                            return j;
                        }
                    }
                }
            }

            return -1;
        }

        private static int IndexOfInternal(StringBuilder sb, StringBuilder value, int startIndex, int count, bool ignoreCase)
        {
            if (value.Length == 0)
                return startIndex;
            if (sb.Length == 0 || count == 0 || startIndex + 1 + value.Length > sb.Length)
                return -1;

            int num3;
            int length = value.Length;
            int num2 = startIndex + count - value.Length;
            if (!ignoreCase)
            {
                for (int i = startIndex; i <= num2; i++)
                {
                    if (sb[i] == value[0])
                    {
                        num3 = 1;
                        while ((num3 < length) && (sb[i + num3] == value[num3]))
                        {
                            num3++;
                        }

                        if (num3 == length)
                        {
                            return i;
                        }
                    }
                }
            }
            else
            {
                for (int j = startIndex; j <= num2; j++)
                {
                    if (char.ToLower(sb[j]) == char.ToLower(value[0]))
                    {
                        num3 = 1;
                        while ((num3 < length) && (char.ToLower(sb[j + num3]) == char.ToLower(value[num3])))
                        {
                            num3++;
                        }

                        if (num3 == length)
                        {
                            return j;
                        }
                    }
                }
            }

            return -1;
        }
        #endregion // IndexOf

        #region IndexOfAny
        /// <summary>
        /// Reports the zero-based index of the first occurrence
        /// of any character in a specified array of Unicode characters.
        /// </summary>
        /// <param name="sb">A <see cref="StringBuilder"/> to search.</param>
        /// <param name="anyOf">A Unicode character array containing one or more characters to seek.</param>
        /// <returns>
        /// The zero-based index position of the first occurrence
        /// where any character in <paramref name="anyOf"/> was found; -1 if no character in <paramref name="anyOf"/> was found.
        /// </returns>
        /// <exception cref="ArgumentNullException">anyOf is null.</exception>
        public static int IndexOfAny(this StringBuilder sb, ReadOnlySpan<char> anyOf)
        {
            if (sb == null)
                throw new ArgumentNullException(nameof(sb));

            return sb.IndexOfAny(anyOf, 0, sb.Length);
        }

        /// <inheritdoc cref="IndexOfAny(StringBuilder, ReadOnlySpan{char})"/>
        public static int IndexOfAny(this StringBuilder sb, StringBuilder anyOf)
        {
            if (sb == null)
                throw new ArgumentNullException(nameof(sb));

            return sb.IndexOfAny(anyOf, 0, sb.Length);
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence of any character 
        /// in a specified array of Unicode characters. The search starts at a specified character position.
        /// </summary>
        /// <param name="sb">A <see cref="StringBuilder"/> to search.</param>
        /// <param name="anyOf">A Unicode character array containing one or more characters to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <returns>
        /// The zero-based index position of the first occurrence
        /// where any character in <paramref name="anyOf"/> was found; -1 if no character in <paramref name="anyOf"/> was found.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="anyOf"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="startIndex"/> is negative.-or-<paramref name="startIndex"/> is greater 
        /// than the number of characters.
        /// </exception>
        public static int IndexOfAny(this StringBuilder sb, ReadOnlySpan<char> anyOf, int startIndex)
        {
            if (sb == null)
                throw new ArgumentNullException(nameof(sb));
            if (sb.Length != 0 && startIndex < 0)
                throw new ArgumentOutOfRangeException();
            if (sb.Length != 0 && startIndex >= sb.Length)
                throw new ArgumentOutOfRangeException();

            return sb.IndexOfAny(anyOf, startIndex, sb.Length - startIndex);
        }

        /// <inheritdoc cref="IndexOfAny(StringBuilder, ReadOnlySpan{char}, int)"/>
        public static int IndexOfAny(this StringBuilder sb, StringBuilder anyOf, int startIndex)
        {
            if (sb == null)
                throw new ArgumentNullException(nameof(sb));
            if (sb.Length != 0 && startIndex < 0)
                throw new ArgumentOutOfRangeException();
            if (sb.Length != 0 && startIndex >= sb.Length)
                throw new ArgumentOutOfRangeException();

            return sb.IndexOfAny(anyOf, startIndex, sb.Length - startIndex);
        }

        /// <summary>
        /// Reports the zero-based index of the first occurrence of any character 
        /// in a specified array of Unicode characters. The search starts at a specified character position and examines a specified number of character positions.
        /// </summary>
        /// <param name="sb">A <see cref="StringBuilder"/> to search.</param>
        /// <param name="anyOf">A Unicode character array containing one or more characters to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="count">The number of character positions to examine.</param>
        /// <returns>
        /// The zero-based index position of the first occurrence
        /// where any character in <paramref name="anyOf"/> was found; -1 if no character in <paramref name="anyOf"/> was found.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="anyOf"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="count"/> or <paramref name="startIndex"/> is negative.
        /// -or-<paramref name="count"/> + <paramref name="startIndex"/> is greater than the number of characters.
        /// </exception>
        public static int IndexOfAny(this StringBuilder sb, ReadOnlySpan<char> anyOf, int startIndex, int count)
        {
            if (sb == null)
                throw new ArgumentNullException(nameof(sb));
            if (anyOf == null)
                throw new ArgumentNullException(nameof(anyOf));
            if (sb.Length != 0 && startIndex < 0)
                throw new ArgumentOutOfRangeException();
            if (sb.Length != 0 && startIndex >= sb.Length)
                throw new ArgumentOutOfRangeException();
            if (sb.Length != 0 && count < 0)
                throw new ArgumentOutOfRangeException();
            if (sb.Length != 0 && startIndex + count > sb.Length)
                throw new ArgumentOutOfRangeException();

            if (sb.Length == 0 || count == 0)
                return -1;

            for (int i = startIndex; i < startIndex + count; i++)
            {
                if (Any(anyOf, sb[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        /// <inheritdoc cref="IndexOfAny(StringBuilder, ReadOnlySpan{char}, int, int)"/>
        public static int IndexOfAny(this StringBuilder sb, StringBuilder anyOf, int startIndex, int count)
        {
            if (sb == null)
                throw new ArgumentNullException(nameof(sb));
            if (anyOf == null)
                throw new ArgumentNullException(nameof(anyOf));
            if (sb.Length != 0 && startIndex < 0)
                throw new ArgumentOutOfRangeException();
            if (sb.Length != 0 && startIndex >= sb.Length)
                throw new ArgumentOutOfRangeException();
            if (sb.Length != 0 && count < 0)
                throw new ArgumentOutOfRangeException();
            if (sb.Length != 0 && startIndex + count > sb.Length)
                throw new ArgumentOutOfRangeException();

            if (sb.Length == 0 || count == 0)
                return -1;

            for (int i = startIndex; i < startIndex + count; i++)
            {
                if (anyOf.Any(sb[i]))
                {
                    return i;
                }
            }

            return -1;
        }
        #endregion // IndexOfAny

        #region LastIndexOf
        /// <summary>
        /// Reports the zero-based index of the last occurrence of the specified Unicode character.
        /// </summary>
        /// <param name="sb">A <see cref="StringBuilder"/> to search.</param>
        /// <param name="value">A Unicode character to seek.</param>
        /// <returns>
        /// The zero-based index position of <paramref name="value"/> if that character is found, or -1
        /// if it is not.
        /// </returns>
        public static int LastIndexOf(this StringBuilder sb, char value)
        {
            if (sb == null)
                throw new ArgumentNullException(nameof(sb));

            return LastIndexOf(sb, value, sb.Length - 1, sb.Length);
        }

        /// <summary>
        /// Reports the zero-based index position of the last occurrence of the specified Unicode character 
        /// in a substring. The search starts at a specified character position and 
        /// proceeds backward toward the beginning of the <see cref="StringBuilder"/> 
        /// for a specified number of character positions.
        /// </summary>
        /// <param name="sb">A <see cref="StringBuilder"/> to search.</param>
        /// <param name="value">A Unicode character to seek.</param>
        /// <param name="startIndex">
        /// The starting position of the search. The search proceeds from <paramref name="startIndex"/> toward the beginning.
        /// </param>
        /// <returns>
        /// The zero-based index position of <paramref name="value"/> if that character is found, or -1
        /// if it is not.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// The current instance <see cref="StringBuilder.Length"/> does not equal 0, 
        /// and <paramref name="startIndex"/> is less than zero or greater than or equal to the length.
        /// </exception>
        public static int LastIndexOf(this StringBuilder sb, char value, int startIndex)
        {
            if (sb == null)
                throw new ArgumentNullException(nameof(sb));
            if (sb.Length != 0 && startIndex < 0)
                throw new ArgumentOutOfRangeException();
            if (sb.Length != 0 && startIndex >= sb.Length)
                throw new ArgumentOutOfRangeException();

            return sb.LastIndexOf(value, startIndex, startIndex + 1);
        }

        /// <summary>
        /// Reports the zero-based index of the last occurrence of the specified Unicode
        /// character in the <see cref="StringBuilder"/>. The search starts 
        /// at a specified character position and examines a specified number of character positions.
        /// </summary>
        /// <param name="sb">A <see cref="StringBuilder"/> to search.</param>
        /// <param name="value">A Unicode character to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="count">The number of character positions to examine.</param>
        /// <returns>
        /// The zero-based index position of <paramref name="value"/> if that character is found, or -1 
        /// if it is not.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// The current instance <see cref="StringBuilder.Length"/> does not equal 0, 
        /// and <paramref name="startIndex"/> is less than zero or greater than or equal to the length.
        /// -or-The current instance <see cref="StringBuilder.Length"/> 
        /// does not equal 0, and <paramref name="startIndex"/> - <paramref name="count"/> + 1 is less than zero.
        /// </exception>
        public static int LastIndexOf(this StringBuilder sb, char value, int startIndex, int count)
        {
            if (sb == null)
                throw new ArgumentNullException(nameof(sb));
            if (sb.Length != 0 && startIndex < 0)
                throw new ArgumentOutOfRangeException();
            if (sb.Length != 0 && startIndex >= sb.Length)
                throw new ArgumentOutOfRangeException();
            if (sb.Length != 0 && count < 0)
                throw new ArgumentOutOfRangeException();
            if (sb.Length != 0 && startIndex - count + 1 < 0)
                throw new ArgumentOutOfRangeException();

            if (sb.Length == 0 || count == 0)
                return -1;

            for (int i = startIndex; i > startIndex - count; i--)
            {
                if (sb[i] == value)
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// Reports the zero-based index of the last occurrence of the specified string 
        /// in the current <see cref="StringBuilder"/> object.
        /// </summary>
        /// <param name="sb">A <see cref="StringBuilder"/> to search.</param>
        /// <param name="value">The string to seek.</param>
        /// <param name="ignoreCase"><see langword="true"/> to ignore case during the comparison; otherwise, <see langword="false"/>.</param>
        /// <returns>
        /// The zero-based index position of the value parameter if that string is found, 
        /// or -1 if it is not. If value is <see cref="String.Empty"/>, the return value is startIndex.
        /// </returns>
        /// <exception cref="ArgumentNullException">value is null.</exception>
        public static int LastIndexOf(this StringBuilder sb, ReadOnlySpan<char> value, bool ignoreCase = false)
        {
            if (sb == null)
                throw new ArgumentNullException(nameof(sb));
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            if (value.Length == 0)
            {
                if (sb.Length == 0)
                    return 0;

                return sb.Length - 1;
            }

            if (sb.Length == 0)
                return -1;

            return LastIndexOfInternal(sb, value, sb.Length - 1, sb.Length, ignoreCase);
        }

        /// <inheritdoc cref="LastIndexOf(StringBuilder, ReadOnlySpan{char}, bool)"/>
        public static int LastIndexOf(this StringBuilder sb, StringBuilder value, bool ignoreCase = false)
        {
            if (sb == null)
                throw new ArgumentNullException(nameof(sb));
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            if (value.Length == 0)
            {
                if (sb.Length == 0)
                    return 0;

                return sb.Length - 1;
            }

            if (sb.Length == 0)
                return -1;

            return LastIndexOfInternal(sb, value, sb.Length - 1, sb.Length, ignoreCase);
        }

        /// <summary>
        /// Reports the zero-based index of the last occurrence of the specified string in the current <see cref="StringBuilder"/> object. 
        /// Parameter specifies the starting search position in the current <see cref="StringBuilder"/>.
        /// </summary>
        /// <param name="sb">A <see cref="StringBuilder"/> to search.</param>
        /// <param name="value">The string to seek. </param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="ignoreCase"><see langword="true"/> to ignore case during the comparison; otherwise, <see langword="false"/>.</param>
        /// <returns>
        /// The zero-based index position of the value parameter if that string is found, 
        /// or -1 if it is not. If value is <see cref="String.Empty"/>, the return value is startIndex.
        /// </returns>
        public static int LastIndexOf(this StringBuilder sb, ReadOnlySpan<char> value, int startIndex, bool ignoreCase = false)
        {
            if (sb == null)
                throw new ArgumentNullException(nameof(sb));
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            if (startIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(startIndex));
            if ((sb.Length != 0 || startIndex != 0) && startIndex >= sb.Length)
                throw new ArgumentOutOfRangeException();

            return LastIndexOfInternal(sb, value, startIndex, startIndex + 1, ignoreCase);
        }

        /// <inheritdoc cref="LastIndexOf(StringBuilder, ReadOnlySpan{char}, int, bool)"/>
        public static int LastIndexOf(this StringBuilder sb, StringBuilder value, int startIndex, bool ignoreCase = false)
        {
            if (sb == null)
                throw new ArgumentNullException(nameof(sb));
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            if (startIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(startIndex));
            if ((sb.Length != 0 || startIndex != 0) && startIndex >= sb.Length)
                throw new ArgumentOutOfRangeException();

            return LastIndexOfInternal(sb, value, startIndex, startIndex + 1, ignoreCase);
        }

        /// <summary>
        /// Reports the zero-based index of the last occurrence of the specified string in the current <see cref="StringBuilder"/> object. 
        /// The search starts at a specified character position and examines a specified number of character positions.
        /// </summary>
        /// <param name="sb">A <see cref="StringBuilder"/> to search.</param>
        /// <param name="value">The string to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="count">The number of character positions to examine.</param>
        /// <param name="ignoreCase"><see langword="true"/> to ignore case during the comparison; otherwise, <see langword="false"/>.</param>
        /// <returns>
        /// The zero-based index position of the value parameter if that string is found, 
        /// or -1 if it is not. If value is <see cref="String.Empty"/>, the return value is startIndex.
        /// </returns>
        /// <exception cref="ArgumentNullException">value is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// startIndex is less than 0 (zero) or greater than the length.
        /// </exception>
        public static int LastIndexOf(this StringBuilder sb, ReadOnlySpan<char> value, int startIndex, int count, bool ignoreCase = false)
        {
            if (sb == null)
                throw new ArgumentNullException(nameof(sb));
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            if (startIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(startIndex));
            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count));
            if (!((sb.Length == 0 && startIndex == 0) || startIndex < sb.Length))
                throw new ArgumentOutOfRangeException();
            if (!((sb.Length == 0 && startIndex == 0) || startIndex - count + 1 >= 0))
                throw new ArgumentOutOfRangeException();

            return LastIndexOfInternal(sb, value, startIndex, count, ignoreCase);
        }

        /// <inheritdoc cref="LastIndexOf(StringBuilder, ReadOnlySpan{char}, int, int, bool)"/>
        public static int LastIndexOf(this StringBuilder sb, StringBuilder value, int startIndex, int count, bool ignoreCase = false)
        {
            if (sb == null)
                throw new ArgumentNullException(nameof(sb));
            if (value == null)
                throw new ArgumentNullException(nameof(value));
            if (startIndex < 0)
                throw new ArgumentOutOfRangeException(nameof(startIndex));
            if (count < 0)
                throw new ArgumentOutOfRangeException(nameof(count));
            if (!((sb.Length == 0 && startIndex == 0) || startIndex < sb.Length))
                throw new ArgumentOutOfRangeException();
            if (!((sb.Length == 0 && startIndex == 0) || startIndex - count + 1 >= 0))
                throw new ArgumentOutOfRangeException();

            return LastIndexOfInternal(sb, value, startIndex, count, ignoreCase);
        }

        private static int LastIndexOfInternal(StringBuilder sb, ReadOnlySpan<char> value, int startIndex, int count, bool ignoreCase)
        {
            if (value == null || value.Length == 0)
                return startIndex;
            if (sb.Length == 0 || count == 0 || startIndex + 1 - count + value.Length > sb.Length)
                return -1;

            int num3;
            int length = value.Length;
            int maxValueIndex = length - 1;
            int num2 = startIndex - count + value.Length;
            if (!ignoreCase)
            {
                for (int i = startIndex; i >= num2; i--)
                {
                    if (sb[i] == value[maxValueIndex])
                    {
                        num3 = 1;
                        while ((num3 < length) && (sb[i - num3] == value[maxValueIndex - num3]))
                        {
                            num3++;
                        }

                        if (num3 == length)
                        {
                            return i - num3 + 1;
                        }
                    }
                }
            }
            else
            {
                for (int j = startIndex; j >= num2; j--)
                {
                    if (char.ToLower(sb[j]) == char.ToLower(value[maxValueIndex]))
                    {
                        num3 = 1;
                        while ((num3 < length) && (char.ToLower(sb[j - num3]) == char.ToLower(value[maxValueIndex - num3])))
                        {
                            num3++;
                        }

                        if (num3 == length)
                        {
                            return j - num3 + 1;
                        }
                    }
                }
            }

            return -1;
        }

        private static int LastIndexOfInternal(StringBuilder sb, StringBuilder value, int startIndex, int count, bool ignoreCase)
        {
            if (value.Length == 0)
                return startIndex;
            if (sb.Length == 0 || count == 0 || startIndex + 1 - count + value.Length > sb.Length)
                return -1;

            int num3;
            int length = value.Length;
            int maxValueIndex = length - 1;
            int num2 = startIndex - count + value.Length;
            if (!ignoreCase)
            {
                for (int i = startIndex; i >= num2; i--)
                {
                    if (sb[i] == value[maxValueIndex])
                    {
                        num3 = 1;
                        while ((num3 < length) && (sb[i - num3] == value[maxValueIndex - num3]))
                        {
                            num3++;
                        }

                        if (num3 == length)
                        {
                            return i - num3 + 1;
                        }
                    }
                }
            }
            else
            {
                for (int j = startIndex; j >= num2; j--)
                {
                    if (char.ToLower(sb[j]) == char.ToLower(value[maxValueIndex]))
                    {
                        num3 = 1;
                        while ((num3 < length) && (char.ToLower(sb[j - num3]) == char.ToLower(value[maxValueIndex - num3])))
                        {
                            num3++;
                        }

                        if (num3 == length)
                        {
                            return j - num3 + 1;
                        }
                    }
                }
            }

            return -1;
        }
        #endregion // LastIndexOf

        #region LastIndexOfAny
        /// <summary>
        /// Reports the zero-based index of the last occurrence
        /// of any character in a specified array of Unicode characters.
        /// </summary>
        /// <param name="sb">A <see cref="StringBuilder"/> to search.</param>
        /// <param name="anyOf">A Unicode character array containing one or more characters to seek.</param>
        /// <returns>
        /// The zero-based index position of the last occurrence
        /// where any character in <paramref name="anyOf"/> was found; -1 if no character in <paramref name="anyOf"/> was found.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="anyOf"/> is null.</exception>
        public static int LastIndexOfAny(this StringBuilder sb, ReadOnlySpan<char> anyOf)
        {
            if (sb == null)
                throw new ArgumentNullException(nameof(sb));

            return sb.LastIndexOfAny(anyOf, sb.Length - 1, sb.Length);
        }

        /// <inheritdoc cref="LastIndexOfAny(StringBuilder, ReadOnlySpan{char})"/>
        public static int LastIndexOfAny(this StringBuilder sb, StringBuilder anyOf)
        {
            if (sb == null)
                throw new ArgumentNullException(nameof(sb));

            return sb.LastIndexOfAny(anyOf, sb.Length - 1, sb.Length);
        }

        /// <summary>
        /// Reports the zero-based index of the last occurrence of any character 
        /// in a specified array of Unicode characters. The search starts at a specified character position.
        /// </summary>
        /// <param name="sb">A <see cref="StringBuilder"/> to search.</param>
        /// <param name="anyOf">A Unicode character array containing one or more characters to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <returns>
        /// The zero-based index position of the last occurrence
        /// where any character in <paramref name="anyOf"/> was found; -1 if no character in <paramref name="anyOf"/> was found.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="anyOf"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="startIndex"/> is negative.-or- <paramref name="startIndex"/> is greater 
        /// than the number of characters.
        /// </exception>
        public static int LastIndexOfAny(this StringBuilder sb, ReadOnlySpan<char> anyOf, int startIndex)
        {
            if (sb == null)
                throw new ArgumentNullException(nameof(sb));
            if (sb.Length != 0 && startIndex < 0)
                throw new ArgumentOutOfRangeException();
            if (sb.Length != 0 && startIndex >= sb.Length)
                throw new ArgumentOutOfRangeException();

            return sb.LastIndexOfAny(anyOf, startIndex, startIndex + 1);
        }

        /// <inheritdoc cref="LastIndexOfAny(StringBuilder, ReadOnlySpan{char}, int)"/>
        public static int LastIndexOfAny(this StringBuilder sb, StringBuilder anyOf, int startIndex)
        {
            if (sb == null)
                throw new ArgumentNullException(nameof(sb));
            if (sb.Length != 0 && startIndex < 0)
                throw new ArgumentOutOfRangeException();
            if (sb.Length != 0 && startIndex >= sb.Length)
                throw new ArgumentOutOfRangeException();

            return sb.LastIndexOfAny(anyOf, startIndex, startIndex + 1);
        }

        /// <summary>
        /// Reports the zero-based index of the last occurrence of any character 
        /// in a specified array of Unicode characters. The search starts at a specified character position and examines a specified number of character positions.
        /// </summary>
        /// <param name="sb">A <see cref="StringBuilder"/> to search.</param>
        /// <param name="anyOf">A Unicode character array containing one or more characters to seek.</param>
        /// <param name="startIndex">The search starting position.</param>
        /// <param name="count">The number of character positions to examine.</param>
        /// <returns>
        /// The zero-based index position of the last occurrence
        /// where any character in <paramref name="anyOf"/> was found; -1 if no character in <paramref name="anyOf"/> was found.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="anyOf"/> is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">
        /// <paramref name="count"/> or <paramref name="startIndex"/> is negative.
        /// -or-<paramref name="count"/> + <paramref name="startIndex"/> is greater than the number of characters.
        /// </exception>
        public static int LastIndexOfAny(this StringBuilder sb, ReadOnlySpan<char> anyOf, int startIndex, int count)
        {
            if (sb == null)
                throw new ArgumentNullException(nameof(sb));
            if (anyOf == null)
                throw new ArgumentNullException(nameof(anyOf));
            if (!(sb.Length == 0 || startIndex >= 0))
                throw new ArgumentOutOfRangeException();
            if (!(sb.Length == 0 || startIndex < sb.Length))
                throw new ArgumentOutOfRangeException();
            if (!(sb.Length == 0 || count >= 0))
                throw new ArgumentOutOfRangeException();
            if (!(sb.Length == 0 || startIndex - count + 1 >= 0))
                throw new ArgumentOutOfRangeException();

            if (sb.Length == 0 || count == 0)
                return -1;

            for (int i = startIndex; i > startIndex - count; i--)
            {
                if (Any(anyOf, sb[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        /// <inheritdoc cref="LastIndexOfAny(StringBuilder, ReadOnlySpan{char}, int, int)"/>
        public static int LastIndexOfAny(this StringBuilder sb, StringBuilder anyOf, int startIndex, int count)
        {
            if (sb == null)
                throw new ArgumentNullException(nameof(sb));
            if (anyOf == null)
                throw new ArgumentNullException(nameof(anyOf));
            if (!(sb.Length == 0 || startIndex >= 0))
                throw new ArgumentOutOfRangeException();
            if (!(sb.Length == 0 || startIndex < sb.Length))
                throw new ArgumentOutOfRangeException();
            if (!(sb.Length == 0 || count >= 0))
                throw new ArgumentOutOfRangeException();
            if (!(sb.Length == 0 || startIndex - count + 1 >= 0))
                throw new ArgumentOutOfRangeException();

            if (sb.Length == 0 || count == 0)
                return -1;

            for (int i = startIndex; i > startIndex - count; i--)
            {
                if (anyOf.Any(sb[i]))
                {
                    return i;
                }
            }

            return -1;
        }
        #endregion // LastIndexOfAny

        #region StartsWith
        /// <summary>
        /// Determines whether the <see cref="StringBuilder"/> starts with the specified string.
        /// </summary>
        /// <param name="sb">A <see cref="StringBuilder"/> to compare.</param>
        /// <param name="value">The string to compare.</param>
        /// <param name="ignoreCase"><see langword="true"/> to ignore case during the comparison; otherwise, <see langword="false"/>.</param>
        /// <returns>
        /// <see langword="true"/> if the <paramref name="value"/> parameter matches the beginning; otherwise, <see langword="false"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
        public static bool StartsWith(this StringBuilder sb, ReadOnlySpan<char> value, bool ignoreCase = false)
        {
            if (sb == null)
                throw new ArgumentNullException(nameof(sb));
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            int length = value.Length;
            if (length > sb.Length)
                return false;

            if (!ignoreCase)
            {
                for (int i = 0; i < length; i++)
                {
                    if (sb[i] != value[i])
                    {
                        return false;
                    }
                }
            }
            else
            {
                for (int j = 0; j < length; j++)
                {
                    if (char.ToLower(sb[j]) != char.ToLower(value[j]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <inheritdoc cref="StartsWith(StringBuilder, ReadOnlySpan{char}, bool)"/>
        public static bool StartsWith(this StringBuilder sb, StringBuilder value, bool ignoreCase = false)
        {
            if (sb == null)
                throw new ArgumentNullException(nameof(sb));
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            int length = value.Length;
            if (length > sb.Length)
                return false;

            if (!ignoreCase)
            {
                for (int i = 0; i < length; i++)
                {
                    if (sb[i] != value[i])
                    {
                        return false;
                    }
                }
            }
            else
            {
                for (int j = 0; j < length; j++)
                {
                    if (char.ToLower(sb[j]) != char.ToLower(value[j]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        #endregion // StartsWith

        #region EndsWith
        /// <summary>
        /// Determines whether the <see cref="StringBuilder"/> ends with the specified string.
        /// </summary>
        /// <param name="sb">A <see cref="StringBuilder"/> to compare.</param>
        /// <param name="value">The string to compare to the substring at the end.</param>
        /// <param name="ignoreCase"><see langword="true"/> to ignore case during the comparison; otherwise, <see langword="false"/>.</param>
        /// <returns>
        /// <see langword="true"/> if the <paramref name="value"/> parameter matches the beginning; otherwise, <see langword="false"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is null.</exception>
        public static bool EndsWith(this StringBuilder sb, ReadOnlySpan<char> value, bool ignoreCase = false)
        {
            if (sb == null)
                throw new ArgumentNullException(nameof(sb));
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            int length = value.Length;
            int maxSBIndex = sb.Length - 1;
            int maxValueIndex = length - 1;
            if (length > sb.Length)
                return false;

            if (!ignoreCase)
            {
                for (int i = 0; i < length; i++)
                {
                    if (sb[maxSBIndex - i] != value[maxValueIndex - i])
                    {
                        return false;
                    }
                }
            }
            else
            {
                for (int j = length - 1; j >= 0; j--)
                {
                    if (char.ToLower(sb[maxSBIndex - j]) != char.ToLower(value[maxValueIndex - j]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <inheritdoc cref="EndsWith(StringBuilder, ReadOnlySpan{char}, bool)"/>
        public static bool EndsWith(this StringBuilder sb, StringBuilder value, bool ignoreCase = false)
        {
            if (sb == null)
                throw new ArgumentNullException(nameof(sb));
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            int length = value.Length;
            int maxSBIndex = sb.Length - 1;
            int maxValueIndex = length - 1;
            if (length > sb.Length)
                return false;

            if (!ignoreCase)
            {
                for (int i = 0; i < length; i++)
                {
                    if (sb[maxSBIndex - i] != value[maxValueIndex - i])
                    {
                        return false;
                    }
                }
            }
            else
            {
                for (int j = length - 1; j >= 0; j--)
                {
                    if (char.ToLower(sb[maxSBIndex - j]) != char.ToLower(value[maxValueIndex - j]))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        #endregion // EndsWith

        #region ToLower
        /// <summary>
        /// Returns a <see cref="StringBuilder"/> converted to lowercase.
        /// </summary>
        /// <param name="sb">A <see cref="StringBuilder"/> to convert to lowercase.</param>
        /// <returns>The <see cref="StringBuilder"/> converted to lowercase.</returns>
        public static StringBuilder ToLower(this StringBuilder sb)
        {
            if (sb == null)
                throw new ArgumentNullException(nameof(sb));

            for (int i = 0; i < sb.Length; i++)
            {
                sb[i] = char.ToLower(sb[i]);
            }

            return sb;
        }

        /// <summary>
        /// Returns a <see cref="StringBuilder"/> converted to lowercase, using the casing rules of the specified culture.
        /// </summary>
        /// <param name="sb">A <see cref="StringBuilder"/> to convert to lowercase.</param>
        /// <param name="culture">An object that supplies culture-specific casing rules.</param>
        /// <returns>The <see cref="StringBuilder"/> converted to lowercase using specified culture.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="culture"/>is null.</exception>
        public static StringBuilder ToLower(this StringBuilder sb, CultureInfo culture)
        {
            if (sb == null)
                throw new ArgumentNullException(nameof(sb));
            if (culture == null)
                throw new ArgumentNullException(nameof(culture));

            for (int i = 0; i < sb.Length; i++)
            {
                sb[i] = char.ToLower(sb[i], culture);
            }

            return sb;
        }

        /// <summary>
        /// Returns a <see cref="StringBuilder"/> converted to lowercase, using the casing rules of the invariant culture.
        /// </summary>
        /// <param name="sb">A <see cref="StringBuilder"/> to convert to lowercase.</param>
        /// <returns>The <see cref="StringBuilder"/> converted to lowercase using invariant culture.</returns>
        public static StringBuilder ToLowerInvariant(this StringBuilder sb)
        {
            return sb.ToLower(CultureInfo.InvariantCulture);
        }
        #endregion // ToLower

        #region ToUpper
        /// <summary>
        /// Returns a <see cref="StringBuilder"/> converted to uppercase.
        /// </summary>
        /// <param name="sb">A <see cref="StringBuilder"/> to convert to uppercase.</param>
        /// <returns>The <see cref="StringBuilder"/> converted to uppercase.</returns>
        public static StringBuilder ToUpper(this StringBuilder sb)
        {
            if (sb == null)
                throw new ArgumentNullException(nameof(sb));

            for (int i = 0; i < sb.Length; i++)
            {
                sb[i] = char.ToUpper(sb[i]);
            }

            return sb;
        }

        /// <summary>
        /// Returns a <see cref="StringBuilder"/> converted to uppercase, using the casing rules of the specified culture.
        /// </summary>
        /// <param name="sb">A <see cref="StringBuilder"/> to convert to uppercase.</param>
        /// <param name="culture">An object that supplies culture-specific casing rules.</param>
        /// <returns>The <see cref="StringBuilder"/> converted to uppercase using specified culture.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="culture"/>is null.</exception>
        public static StringBuilder ToUpper(this StringBuilder sb, CultureInfo culture)
        {
            if (sb == null)
                throw new ArgumentNullException(nameof(sb));
            if (culture == null)
                throw new ArgumentNullException(nameof(culture));

            for (int i = 0; i < sb.Length; i++)
            {
                sb[i] = char.ToUpper(sb[i], culture);
            }

            return sb;
        }

        /// <summary>
        /// Returns a <see cref="StringBuilder"/> converted to uppercase, using the casing rules of the invariant culture.
        /// </summary>
        /// <param name="sb">A <see cref="StringBuilder"/> to convert to uppercase.</param>
        /// <returns>The <see cref="StringBuilder"/> converted to uppercase using invariant culture.</returns>
        public static StringBuilder ToUpperInvariant(this StringBuilder sb)
        {
            return sb.ToUpper(CultureInfo.InvariantCulture);
        }
        #endregion // ToUpper

        /// <summary>
        /// Removes all whitespace from <see cref="StringBuilder"/>.
        /// </summary>
        /// <param name="sb">A <see cref="StringBuilder"/> to remove from.</param>
        /// <returns>
        /// Returns <see cref="StringBuilder"/> without whitespace.
        /// </returns>
        /// <exception cref="ArgumentNullException"><paramref name="sb"/> is null.</exception>
        public static StringBuilder RemoveWhiteSpace(this StringBuilder sb)
        {
            if (sb == null)
                throw new ArgumentNullException(nameof(sb));

            for (int i = 0; i < sb.Length;)
            {
                if (char.IsWhiteSpace(sb[i]))
                    _ = sb.Remove(i, 1);
                else
                    i++;
            }

            return sb;
        }

        #region Replace
        public static StringBuilder Replace(this StringBuilder sb, ReadOnlySpan<char> oldValue, ReadOnlySpan<char> newValue,
            StringComparison comparisonType)
        {
            return sb.Replace(oldValue, newValue, IgnoreCase(comparisonType));
        }

        public static StringBuilder Replace(this StringBuilder sb, ReadOnlySpan<char> oldValue, ReadOnlySpan<char> newValue,
            bool ignoreCase = false)
        {
            if (sb == null)
                throw new ArgumentNullException(nameof(sb));

            int oldValueLength = oldValue == null ? 0 : oldValue.Length;
            if (oldValueLength == 0)
                return sb;

            if (newValue == null)
                newValue = string.Empty;

            int index = sb.IndexOf(oldValue, ignoreCase);
            while (index != -1)
            {
                _ = sb.Remove(index, oldValueLength);
                _ = sb.Insert(index, newValue);

                index = sb.IndexOf(oldValue, ignoreCase);
            }

            return sb;
        }

        public static StringBuilder Replace(this StringBuilder sb, ReadOnlySpan<char> oldValue, long newValue,
            bool ignoreCase = false)
        {
            if (sb == null)
                throw new ArgumentNullException(nameof(sb));

            int oldValueLength = oldValue == null ? 0 : oldValue.Length;
            if (oldValueLength == 0)
                return sb;

            int index = sb.IndexOf(oldValue, ignoreCase);
            while (index != -1)
            {
                _ = sb.Remove(index, oldValueLength);
                _ = sb.Insert(index, newValue);

                index = sb.IndexOf(oldValue, ignoreCase);
            }

            return sb;
        }

        public static StringBuilder Replace(this StringBuilder sb, StringBuilder oldValue, long newValue,
            bool ignoreCase = false)
        {
            if (sb == null)
                throw new ArgumentNullException(nameof(sb));

            int oldValueLength = oldValue?.Length ?? 0;
            if (oldValueLength == 0)
                return sb;

            int index = sb.IndexOf(oldValue, ignoreCase);
            while (index != -1)
            {
                _ = sb.Remove(index, oldValueLength);
                _ = sb.Insert(index, newValue);

                index = sb.IndexOf(oldValue, ignoreCase);
            }

            return sb;
        }

        public static StringBuilder Replace(this StringBuilder sb, StringBuilder oldValue, StringBuilder newValue,
            bool ignoreCase = false)
        {
            if (sb == null)
                throw new ArgumentNullException(nameof(sb));

            int oldValueLength = oldValue?.Length ?? 0;
            if (oldValueLength == 0)
                return sb;

            int index = sb.IndexOf(oldValue, ignoreCase);
            while (index != -1)
            {
                _ = sb.Replace(index, oldValueLength, newValue);

                index = sb.IndexOf(oldValue, ignoreCase);
            }

            return sb;
        }

        public static StringBuilder Replace(this StringBuilder sb, ReadOnlySpan<char> oldValue, StringBuilder newValue,
            bool ignoreCase = false)
        {
            if (sb == null)
                throw new ArgumentNullException(nameof(sb));

            int oldValueLength = oldValue == null ? 0 : oldValue.Length;
            if (oldValueLength == 0)
                return sb;

            int index = sb.IndexOf(oldValue, ignoreCase);
            while (index != -1)
            {
                _ = sb.Replace(index, oldValueLength, newValue);

                index = sb.IndexOf(oldValue, ignoreCase);
            }

            return sb;
        }

        public static StringBuilder Replace(this StringBuilder sb, StringBuilder oldValue, ReadOnlySpan<char> newValue,
            bool ignoreCase = false)
        {
            if (sb == null)
                throw new ArgumentNullException(nameof(sb));

            int oldValueLength = oldValue?.Length ?? 0;
            if (oldValueLength == 0)
                return sb;

            int index = sb.IndexOf(oldValue, ignoreCase);
            while (index != -1)
            {
                _ = sb.Replace(index, oldValueLength, newValue);

                index = sb.IndexOf(oldValue, ignoreCase);
            }

            return sb;
        }
        #endregion // Replace

        public static StringBuilder Shift(this StringBuilder sb, int index, int offset)
        {
            if (sb == null)
                throw new ArgumentNullException(nameof(sb));

            sb.Length += offset;
            
            for (int i = 1; i <= index; i++)
            {
                sb[^i] = sb[^(i + offset)];
            }

            return sb;
        }

        public static StringBuilder Insert(this StringBuilder sb, int index, StringBuilder value)
        {
            if (sb == null)
                throw new ArgumentNullException(nameof(sb));
            if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index));

            int valueLength = value?.Length ?? 0;
            if (valueLength == 0)
                return sb;

            _ = sb.Shift(index, valueLength);

            for (int i = valueLength - 1; i >= 0; --i)
            {
                sb[i + index] = value[i];
            }

            return sb;
        }

        public static StringBuilder Replace(this StringBuilder sb, int index, int length, StringBuilder value)
        {
            if (sb == null)
                throw new ArgumentNullException(nameof(sb));
            if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index));

            int valueLength = value == null ? 0 : value.Length;
            for (int i = 0, replaceLength = Math.Min(length, valueLength); i < replaceLength; i++)
            {
                sb[i + index] = value[i];
            }

            if (length > valueLength)
            {
                _ = sb.Remove(index + valueLength, length - valueLength);
            }
            else if (length < valueLength)
            {
                _ = sb.Insert(index, value);
            }

            return sb;
        }

        public static StringBuilder Replace(this StringBuilder sb, int index, int length, ReadOnlySpan<char> value)
        {
            if (sb == null)
                throw new ArgumentNullException(nameof(sb));
            if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index));

            int valueLength = value == null ? 0 : value.Length;
            for (int i = 0, replaceLength = Math.Min(length, valueLength); i < replaceLength; i++)
            {
                sb[i + index] = value[i];
            }

            if (length > valueLength)
            {
                _ = sb.Remove(index + valueLength, length - valueLength);
            }
            else if (length < valueLength)
            {
                _ = sb.Insert(index, value);
            }

            return sb;
        }

        public static StringBuilder EnsureRoom(this StringBuilder sb, int room)
        {
            if (sb == null)
                throw new ArgumentNullException(nameof(sb));

            _ = sb.EnsureCapacity(sb.Length + room);
            return sb;
        }

        /// <summary>
        /// Converts a <see cref="StringComparison"/> to a <see langword="bool"/>
        /// that is <see langword="true"/> if case is ignored.
        /// </summary>
        /// <param name="comparisonType">A <see cref="StringComparison"/> enum.</param>
        /// <returns><see langword="true"/> if <paramref name="comparisonType"/> ignores case.</returns>
        private static bool IgnoreCase(StringComparison comparisonType)
        {
            return (int)comparisonType % 2 != 0;
        }

        #region Contains
        #region StringComparison
        public static bool Contains(this StringBuilder sb, ReadOnlySpan<char> value,
            StringComparison comparisonType)
        {
            return sb.IndexOf(value, IgnoreCase(comparisonType)) >= 0;
        }

        public static bool Contains(this StringBuilder sb, StringBuilder value,
            StringComparison comparisonType)
        {
            return sb.IndexOf(value, IgnoreCase(comparisonType)) >= 0;
        }
        #endregion // StringComparison

        #region ignoreCase
        public static bool Contains(this StringBuilder sb, ReadOnlySpan<char> value,
            bool ignoreCase = false)
        {
            return sb.IndexOf(value, ignoreCase) >= 0;
        }

        public static bool Contains(this StringBuilder sb, StringBuilder value,
            bool ignoreCase = false)
        {
            return sb.IndexOf(value, ignoreCase) >= 0;
        }
        #endregion // ignoreCase

        public static bool Contains(this StringBuilder sb, char value)
        {
            return sb.IndexOf(value) >= 0;
        }
        #endregion // Contains
    }
}
