-- Copyright (c) 2015-2019 Marcel Schneider
-- for details see License.txt

with TokenValue; use TokenValue;
with Ada.Strings.Unbounded; use Ada.Strings.Unbounded;

package body Lexer is

   function ReadToken (O : Object) return TokenValue.Object is
      TO : TokenValue.Object;
   begin
      TO.Message := To_Unbounded_String ("Testing");
      return TO;
   end ReadToken;


end Lexer;
