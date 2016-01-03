-- Copyright (c) 2015-2016 Marcel Schneider
-- for details see License.txt

with Ada.Strings.Unbounded; use Ada.Strings.Unbounded;
with Position; use Position;
with Tokens; use Tokens;

package TokenValue is

   type Object is record
      SourcePosition : Position.Object;
      TokenId : Token;
      Literal : Unbounded_String;
      Message : Unbounded_String;
   end record;

end TokenValue;
