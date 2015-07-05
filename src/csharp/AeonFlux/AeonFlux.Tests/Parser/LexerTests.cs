#region license and copyright
/*
The MIT License, Copyright (c) 2011-2015 Marcel Schneider
for details see License.txt
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
