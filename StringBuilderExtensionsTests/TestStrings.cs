namespace System.Text.Tests
{
    static class TestStrings
    {
        internal static readonly string WhiteSpacesTrimmed = "some string";
        internal static readonly string WhiteSpacesRemoved = "somestring";
        internal static readonly string LeadingWhiteSpaces = "  some string";
        internal static readonly string TrailingWhiteSpaces = "some string ";
        internal static readonly string LeadingAndTrailingWhiteSpaces = "    some string  ";
        internal static readonly string WhiteSpaces = "    ";

        internal static readonly char[] SymbolsToTrim = new char[] { '*', '^', '&' };
        internal static readonly string SymbolsTrimmed = "some*&^string";
        internal static readonly string SymbolsRemoved = "somestring";
        internal static readonly string LeadingSymbols = "*&^some*&^string";
        internal static readonly string TrailingSymbols = "some*&^string*&^";
        internal static readonly string LeadingAndTrailingSymbols = "&^*some*&^string&*^";
        
        internal static readonly string ToIndexOfChars1 = SymbolsTrimmed + LeadingSymbols;
        internal static readonly string ToIndexOfChars2 = LeadingSymbols + LeadingAndTrailingSymbols;
        
        internal static readonly string SingleCharacter = "!";
        internal static readonly string Searched = "mfsd42(*#D$#@cder23?"; // 20 symbols
        internal static readonly string Composition1 = "sfreewfr3c 4vtc"; // 15 symbols
        internal static readonly string Composition2 = "(dx D!@DWE 9&53 sr;'"; // 20 symbols
    }

    static class TestStringBuilders
    {
        internal static StringBuilder WhiteSpacesTrimmed = new StringBuilder("some string");
        internal static StringBuilder WhiteSpacesRemoved = new StringBuilder("somestring");
        internal static StringBuilder LeadingWhiteSpaces = new StringBuilder("  some string");
        internal static StringBuilder TrailingWhiteSpaces = new StringBuilder("some string ");
        internal static StringBuilder LeadingAndTrailingWhiteSpaces = new StringBuilder("    some string  ");
        internal static StringBuilder WhiteSpaces = new StringBuilder("    ");

        internal static StringBuilder SymbolsToTrim = new StringBuilder().Append('*').Append('^').Append('&');
        internal static StringBuilder SymbolsTrimmed = new StringBuilder("some*&^string");
        internal static StringBuilder SymbolsRemoved = new StringBuilder("somestring");
        internal static StringBuilder LeadingSymbols = new StringBuilder("*&^some*&^string");
        internal static StringBuilder TrailingSymbols = new StringBuilder("some*&^string*&^");
        internal static StringBuilder LeadingAndTrailingSymbols = new StringBuilder("&^*some*&^string&*^");

        internal static StringBuilder ToIndexOfChars1 = new StringBuilder().Append(SymbolsTrimmed).Append(LeadingSymbols);
        internal static StringBuilder ToIndexOfChars2 = new StringBuilder().Append(LeadingSymbols).Append(LeadingAndTrailingSymbols);

        internal static StringBuilder SingleCharacter = new StringBuilder("!");
        internal static StringBuilder Searched = new StringBuilder("mfsd42(*#D$#@cder23?"); // 20 symbols
        internal static StringBuilder Composition1 = new StringBuilder("sfreewfr3c 4vtc"); // 15 symbols
        internal static StringBuilder Composition2 = new StringBuilder("(dx D!@DWE 9&53 sr;'"); // 20 symbols
    }
}
