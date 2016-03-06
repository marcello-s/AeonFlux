-- Copyright (c) 2015-2016 Marcel Schneider
-- for details see License.txt

with Ada.Text_IO;  use Ada.Text_IO;
with Punctuation; use Punctuation;
with Tokens; use Tokens;
with Lexer; use Lexer;

with Ada.Strings.Unbounded; use Ada.Strings.Unbounded;
with Ada.Containers.Hashed_Maps; use Ada.Containers;

procedure AeonFlux is

   P : Punctuation.Object;
   TOK : Tokens.Token;
   
begin
   

   Put_Line ("AeonFlux");
   Put_Line ("--------");
  
   Initialize (P);
   
   TOK := Tokens.EOF;
   Put_Line (TOK'Img);
   TOK := P.Keywords.Element(To_Unbounded_String ("break"));
   Put_Line (TOK'Img);
   
   Clear (P);  
   Put_Line ("");
  
end AeonFlux;
