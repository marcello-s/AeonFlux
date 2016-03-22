-- Copyright (c) 2015-2016 Marcel Schneider
-- for details see License.txt

with Tokens; use Tokens;
with TokenValue; use TokenValue;
with Position; use Position;
with Ada.Strings.Unbounded; use Ada.Strings.Unbounded;

package Lexer_Base is

   type Object is tagged private;

   procedure OpenFile (O : in out Object;
                          File_Name : String);
   function ReadToken (O : Object) return TokenValue.Object;

private
   type Object is tagged record
      Line : Natural;
      Column : Natural;
      StartLine : Natural;
      StartColumns : Natural;
      Last : Token;
      NumberPunctuation : Unbounded_String := To_Unbounded_String (".-+abcdefx");
      HexNumberPunctuation : Unbounded_String := To_Unbounded_String ("abcdef");

      File_Name : Unbounded_String;
   end record;

   function ReadWhiteSpace return TokenValue.Object;
   function ReadString return TokenValue.Object;
   function ReadLineComment return TokenValue.Object;
   function ReadBlockComment return TokenValue.Object;
   function ReadRegEx return TokenValue.Object;
   function ReadOperator return TokenValue.Object;
   function ReadNumber return TokenValue.Object;
   function IsPunctuationUsed (C : Character) return Boolean;
   function SetNumberPunctuation (C : Character;
                                  IsHexNumber : Boolean) return Boolean;
   function ReadIdentifier return TokenValue.Object;

   function IsName (C : Character) return Boolean;
   function IsOperator (C : Character) return Boolean;
   function IsDigit (C : Character) return Boolean;
   function IsPunctuation (C : Character) return Boolean;

   function Peek return Character;
   function Advance return Character;
   function CreateToken (TokenId : Token;
                         Literal : Unbounded_String;
                         Message : Unbounded_String) return TokenValue.Object;
   function CreatePosition return Position.Object;

end Lexer_Base;
