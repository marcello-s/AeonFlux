-- Copyright (c) 2015-2019 Marcel Schneider
-- for details see License.txt

with Lexer_Base; use Lexer_Base;
with TokenValue; use TokenValue;
with TokenReading; use TokenReading;

package Lexer is

   type Object is new Lexer_Base.Object and TokenReading.Object with private;

   overriding function ReadToken (O : Object) return TokenValue.Object;

private
   type Object is new Lexer_Base.Object and TokenReading.Object with record
      O : TokenValue.Object;
   end record;

end Lexer;
