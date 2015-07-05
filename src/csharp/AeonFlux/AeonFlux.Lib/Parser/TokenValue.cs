#region license and copyright
/*
The MIT License, Copyright (c) 2011-2015 Marcel Schneider
for details see License.txt
 */
#endregion

namespace AeonFlux.Parser
{
    internal struct TokenValue
    {
        public Position SrcPosition { get; set; }
        public Token TokenId { get; set; }
        public string Literal { get; set; }
        public string Message { get; set; }
    }
}
