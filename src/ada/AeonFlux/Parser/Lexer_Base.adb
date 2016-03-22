-- Copyright (c) 2015-2016 Marcel Schneider
-- for details see License.txt

with Ada.Streams.Stream_IO; use Ada.Streams.Stream_IO;
-- with Ada.Strings; use Ada.Strings;

with Ada.Text_IO; use Ada.Text_IO;

package body Lexer_Base is

   procedure OpenFile (O : in out Object;
                       File_Name : String) is
      B : Boolean;
   begin
      O.File_Name := To_Unbounded_String (File_Name);
      B := IsPunctuation('.');
      Put_Line(Boolean'Image(B));
   end OpenFile;

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
      return (C >= 'a' AND C <= 'z')
        OR (C >= 'A' AND C <= 'Z')
        OR C = '$'
        OR C = '_';
   end IsName;

   function IsOperator (C : Character) return Boolean is
      Op : constant String := "~!%^&*/-=+|/?<>:";
      I : Integer := 1;
   begin
      while I <= Op'Length loop
         if (Op(I) = C) then
            return true;
         end if;
         I := I + 1;
      end loop;

      return false;
   end IsOperator;

   function IsDigit (C : Character) return Boolean is
   begin
      return C >= '0' AND C <= '9';
   end IsDigit;

   function IsPunctuation (C : Character) return Boolean is
      P : constant String := "(){}[];,.";
      I : Integer := 1;
   begin
      while I <= P'Length loop
         if (P(I) = C) then
            return true;
         end if;
         I := I + 1;
      end loop;

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
