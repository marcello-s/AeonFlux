#region license and copyright
/*
 * The MIT License, Copyright (c) 2011-2019 Marcel Schneider
 * for details see License.txt
 */
#endregion
        
using System.IO;
using System.Text;
using Xunit;

namespace AeonFlux.Parser
{
    public class LexerTests
    {
        [Fact]
        public void ScanWhiteSpace_WhenSpace_ThenReturnWhitespace()
        {
            const string input = " ";
            var renderedTokens = Scan(input);

            Assert.Equal("tok:'WhiteSpace' lit:' '", renderedTokens);
        }

        [Fact]
        public void ScanWhiteSpace_WhenTab_ThenReturnWhiteSpace()
        {
            const string input = "\t";
            var renderedTokens = Scan(input);

            Assert.Equal("tok:'WhiteSpace' lit:'\t'", renderedTokens);
        }

        [Fact]
        public void ScanWhiteSpace_WhenBackspace_ThenReturnWhiteSpace()
        {
            const char bs = '\u0008';
            var renderedTokens = Scan(bs.ToString());

            Assert.Equal("tok:'WhiteSpace' lit:'" + bs + "'", renderedTokens);
        }

        [Fact]
        public void ScanWhiteSpace_WhenHorizontalTab_ThenReturnWhiteSpace()
        {
            const char htab = '\u0009';
            var renderedTokens = Scan(htab.ToString());

            Assert.Equal("tok:'WhiteSpace' lit:'" + htab + "'", renderedTokens);
        }

        [Fact]
        public void ScanWhiteSpace_WhenVerticalTab_ThenReturnWhiteSpace()
        {
            const char vtab = '\u000B';
            var renderedTokens = Scan(vtab.ToString());

            Assert.Equal("tok:'WhiteSpace' lit:'" + vtab + "'", renderedTokens);
        }

        [Fact]
        public void ScanNewline_WhenNewline_ThenReturnNewLine()
        {
            const string input = "\n";
            var renderedTokens = Scan(input);

            Assert.Equal("tok:'NewLine' lit:'\n'", renderedTokens);
        }

        [Fact]
        public void ScanNewline_WhenCarriageReturn_ThenReturnNewLine()
        {
            const string input = "\r";
            var renderedTokens = Scan(input);

            Assert.Equal("tok:'NewLine' lit:'\r'", renderedTokens);
        }

        [Fact]
        public void ScanString_WhenIdentifier_ThenReturnIdentifier()
        {
            const string input = "The";
            var renderedTokens = Scan(input);

            Assert.Equal("tok:'Identifier' lit:'The'", renderedTokens);
        }

        [Fact]
        public void ScanString_WhenEscaped_ThenReturnStringLiteral()
        {
            const string input = "\"quick brown fox\"";
            var renderedTokens = Scan(input);

            Assert.Equal("tok:'StringLiteral' lit:'quick brown fox'", renderedTokens);
        }

        [Fact]
        public void ScanString_WhenEscapedQuoted_ThenReturnStringLiteral()
        {
            const string input = "\"\\\"jumps\\\"\"";
            var renderedTokens = Scan(input);

            Assert.Equal("tok:'StringLiteral' lit:'\"jumps\"'", renderedTokens);
        }

        [Fact]
        public void ScanString_WhenSingleQuotedString_ThenReturnStringLiteral()
        {
            const string input = "'single \"quoted\" string'";
            var renderedTokens = Scan(input);

            Assert.Equal("tok:'StringLiteral' lit:'single \"quoted\" string'", renderedTokens);
        }

        [Fact]
        public void ScanString_WhenTabbedString_ThenReturnStringLiteral()
        {
            const string input = "'str\ttabbed'";
            var renderedTokens = Scan(input);

            Assert.Equal("tok:'StringLiteral' lit:'str tabbed'", renderedTokens);
        }


        [Fact]
        public void ScanNumber_WhenInteger_ThenReturnNumberLiteral()
        {
            const string input = "123";
            var renderedTokens = Scan(input);

            Assert.Equal("tok:'NumberLiteral' lit:'123'", renderedTokens);
        }

        [Fact]
        public void ScanNumber_WhenFloat_ThenReturnNumberLiteral()
        {
            const string input = "78.90";
            var renderedTokens = Scan(input);

            Assert.Equal("tok:'NumberLiteral' lit:'78.90'", renderedTokens);
        }

        [Fact]
        public void ScanNumber_WhenScientificLower_ThenReturnNumberLiteral()
        {
            const string input = "45e-6";
            var renderedTokens = Scan(input);

            Assert.Equal("tok:'NumberLiteral' lit:'45e-6'", renderedTokens);
        }

        [Fact]
        public void ScanNumber_WhenScientificUpper_ThenReturnNumberLiteral()
        {
            const string input = "12E+3";
            var renderedTokens = Scan(input);

            Assert.Equal("tok:'NumberLiteral' lit:'12E+3'", renderedTokens);
        }

        [Fact]
        public void ScanNumber_WhenHex_ThenReturnNumberLiteral()
        {
            const string input = "0xabcdff";
            var renderedTokens = Scan(input);

            Assert.Equal("tok:'NumberLiteral' lit:'0xabcdff'", renderedTokens);
        }



        private static string Scan(string input)
        {
            var sb = new StringBuilder();
            var bytes = Encoding.Default.GetBytes(input);

            using (var ms = new MemoryStream(bytes))
            {
                var sr = new StreamReader(ms);
                var lexer = new Lexer(sr);

                var token = lexer.ReadToken();
                while (token.TokenId != Token.EOF)
                {
                    //Console.WriteLine(FormatTokenValue(token));
                    sb.AppendLine(FormatTokenValue(token));
                    token = lexer.ReadToken();
                }
            }

            return sb.ToString().Trim();
        }

        private static string FormatTokenValue(TokenValue tokenValue)
        {
            var sb = new StringBuilder();

            sb.AppendFormat("tok:'{0}' ", tokenValue.TokenId);
            //sb.AppendFormat("src:'{0}' ", tokenValue.SrcPosition.Text);

            if (!string.IsNullOrEmpty(tokenValue.Literal))
            {
                sb.AppendFormat("lit:'{0}' ", tokenValue.Literal);
            }

            if (!string.IsNullOrEmpty(tokenValue.Message))
            {
                sb.AppendFormat("msg:'{0}'", tokenValue.Message);
            }

            return sb.ToString();
        }
    }
}
