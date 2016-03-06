-- Copyright (c) 2015-2016 Marcel Schneider
-- for details see License.txt

package body Lexer_Base is

   function ReadToken (O : Object) return TokenValue.Object is
      TO : TokenValue.Object;
   begin
      return TO;
   end ReadToken;


   function ReadWhiteSpace return TokenValue.Object is
      O : TokenValue.Object;
   begin
      return O;
   end ReadWhiteSpace;

   function ReadString return TokenValue.Object is
      O : TokenValue.Object;
   begin
      return O;
   end ReadString;

   function ReadLineComment return TokenValue.Object is
      O : TokenValue.Object;
   begin
      return O;
   end ReadLineComment;

   function ReadBlockComment return TokenValue.Object is
      O : TokenValue.Object;
   begin
      return O;
   end ReadBlockComment;

   function ReadRegEx return TokenValue.Object is
      O : TokenValue.Object;
   begin
      return O;
   end ReadRegEx;

   function ReadOperator return TokenValue.Object is
      O : TokenValue.Object;
   begin
      return O;
   end ReadOperator;

   function ReadNumber return TokenValue.Object is
      O : TokenValue.Object;
   begin
      return O;
   end ReadNumber;

   function IsPunctuationUsed (C : Character) return Boolean is
      -- B : Boolean;
   begin
      return false;
   end IsPunctuationUsed;

   function SetNumberPunctuation (C : Character;
                                  IsHexNumber : Boolean) return Boolean is
   begin
      return false;
   end SetNumberPunctuation;

   function ReadIdentifier return TokenValue.Object is
      O : TokenValue.Object;
   begin
      return O;
   end ReadIdentifier;


   function IsName (C : Character) return Boolean is
   begin
      return false;
   end IsName;

   function IsOperator (C : Character) return Boolean is
   begin
      return false;
   end IsOperator;

   function IsDigit (C : Character) return Boolean is
   begin
      return false;
   end IsDigit;

   function IsPunctuation (C : Character) return Boolean is
   begin
      return false;
   end IsPunctuation;


   function Peek return Character is
      C : Character;
   begin
      return C;
   end Peek;

   function Advance return Character is
      C : Character;
   begin
      return C;
   end Advance;

   function CreateToken (TokenId : Token;
                         Literal : Unbounded_String;
                         Message : Unbounded_String) return TokenValue.Object is
      O : TokenValue.Object;
   begin
      return O;
   end CreateToken;

   function CreatePosition return Position.Object is
      O : Position.Object;
   begin
      return O;
   end CreatePosition;

end Lexer_Base;
