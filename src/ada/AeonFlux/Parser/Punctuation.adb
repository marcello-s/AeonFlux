-- Copyright (c) 2015-2016 Marcel Schneider
-- for details see License.txt

with Ada.Strings.Unbounded; use Ada.Strings.Unbounded;
with Ada.Containers.Hashed_Maps; use Ada.Containers;
with Tokens; use Tokens;

package body Punctuation is

   procedure Initialize (O : in out Object) is
   begin
      -- Punctuators
      O.Punctuators.Insert(To_Unbounded_String ("("), Tokens.LeftBracket);
      O.Punctuators.Insert(To_Unbounded_String (")"), Tokens.RightBracket);
      O.Punctuators.Insert(To_Unbounded_String ("{"), Tokens.LeftBrace);
      O.Punctuators.Insert(To_Unbounded_String ("}"), Tokens.RightBrace);
      O.Punctuators.Insert(To_Unbounded_String ("["), Tokens.LeftSquareBracket);
      O.Punctuators.Insert(To_Unbounded_String ("]"), Tokens.RightSquareBracket);
      O.Punctuators.Insert(To_Unbounded_String (";"), Tokens.Semicolon);
      O.Punctuators.Insert(To_Unbounded_String (","), Tokens.Comma);
      O.Punctuators.Insert(To_Unbounded_String ("."), Tokens.Point);

      -- Operators
      O.Operators.Insert(To_Unbounded_String ("?"), Tokens.Question);
      O.Operators.Insert(To_Unbounded_String (":"), Tokens.Colon);
      O.Operators.Insert(To_Unbounded_String ("~"), Tokens.Tilde);
      O.Operators.Insert(To_Unbounded_String ("*"), Tokens.Asterisk);
      O.Operators.Insert(To_Unbounded_String ("*="), Tokens.AsteriskEqual);
      O.Operators.Insert(To_Unbounded_String ("%"), Tokens.Percent);
      O.Operators.Insert(To_Unbounded_String ("%="), Tokens.PercentEqual);
      O.Operators.Insert(To_Unbounded_String ("^"), Tokens.Carot);
      O.Operators.Insert(To_Unbounded_String ("^="), Tokens.CarotEqual);
      O.Operators.Insert(To_Unbounded_String ("/"), Tokens.Slash);
      O.Operators.Insert(To_Unbounded_String ("/="), Tokens.SlashEqual);
      O.Operators.Insert(To_Unbounded_String ("&"), Tokens.Ampersand);
      O.Operators.Insert(To_Unbounded_String ("&&"), Tokens.Ampersand2);
      O.Operators.Insert(To_Unbounded_String ("&&="), Tokens.AmpersandEqual);
      O.Operators.Insert(To_Unbounded_String ("|"), Tokens.Pipe);
      O.Operators.Insert(To_Unbounded_String ("||"), Tokens.Pipe2);
      O.Operators.Insert(To_Unbounded_String ("|="), Tokens.PipeEqual);
      O.Operators.Insert(To_Unbounded_String ("="), Tokens.Equal);
      O.Operators.Insert(To_Unbounded_String ("=="), Tokens.Equal2);
      O.Operators.Insert(To_Unbounded_String ("==="), Tokens.Equal3);
      O.Operators.Insert(To_Unbounded_String ("!"), Tokens.Exclamation);
      O.Operators.Insert(To_Unbounded_String ("!="), Tokens.ExclamationEqual);
      O.Operators.Insert(To_Unbounded_String ("!=="), Tokens.ExclamationEqual2);
      O.Operators.Insert(To_Unbounded_String ("+"), Tokens.Plus);
      O.Operators.Insert(To_Unbounded_String ("++"), Tokens.Plus2);
      O.Operators.Insert(To_Unbounded_String ("+="), Tokens.PlusEqual);
      O.Operators.Insert(To_Unbounded_String ("-"), Tokens.Minus);
      O.Operators.Insert(To_Unbounded_String ("--"), Tokens.Minus2);
      O.Operators.Insert(To_Unbounded_String ("-="), Tokens.MinusEqual);
      O.Operators.Insert(To_Unbounded_String ("<"), Tokens.LessThan);
      O.Operators.Insert(To_Unbounded_String ("<<"), Tokens.LessThan2);
      O.Operators.Insert(To_Unbounded_String ("<="), Tokens.LessThanEqual);
      O.Operators.Insert(To_Unbounded_String ("<<="), Tokens.LessThan2Equal);
      O.Operators.Insert(To_Unbounded_String (">"), Tokens.GreaterThan);
      O.Operators.Insert(To_Unbounded_String (">>"), Tokens.GreaterThan2);
      O.Operators.Insert(To_Unbounded_String (">="), Tokens.GreaterThanEqual);
      O.Operators.Insert(To_Unbounded_String (">>="), Tokens.GreaterThan2Equal);
      O.Operators.Insert(To_Unbounded_String (">>>"), Tokens.GreaterThan3);
      O.Operators.Insert(To_Unbounded_String (">>>="), Tokens.GreaterThan3Equal);

      -- reserved Keywords
      O.Keywords.Insert(To_Unbounded_String ("break"), Tokens.Break);
      O.Keywords.Insert(To_Unbounded_String ("case"), Tokens.Case_Tok);
      O.Keywords.Insert(To_Unbounded_String ("catch"), Tokens.Catch);
      O.Keywords.Insert(To_Unbounded_String ("continue"), Tokens.Continue);
      O.Keywords.Insert(To_Unbounded_String ("debugger"), Tokens.Debugger);
      O.Keywords.Insert(To_Unbounded_String ("default"), Tokens.Default);
      O.Keywords.Insert(To_Unbounded_String ("delete"), Tokens.Delete);
      O.Keywords.Insert(To_Unbounded_String ("do"), Tokens.Do_Tok);
      O.Keywords.Insert(To_Unbounded_String ("else"), Tokens.Else_Tok);
      O.Keywords.Insert(To_Unbounded_String ("finally"), Tokens.Finally);
      O.Keywords.Insert(To_Unbounded_String ("for"), Tokens.For_Tok);
      O.Keywords.Insert(To_Unbounded_String ("function"), Tokens.Function_Tok);
      O.Keywords.Insert(To_Unbounded_String ("if"), Tokens.If_Tok);
      O.Keywords.Insert(To_Unbounded_String ("in"), Tokens.In_Tok);
      O.Keywords.Insert(To_Unbounded_String ("instanceof"), Tokens.Instanceof);
      O.Keywords.Insert(To_Unbounded_String ("new"), Tokens.New_Tok);
      O.Keywords.Insert(To_Unbounded_String ("return"), Tokens.Return_Tok);
      O.Keywords.Insert(To_Unbounded_String ("switch"), Tokens.Switch);
      O.Keywords.Insert(To_Unbounded_String ("this"), Tokens.This);
      O.Keywords.Insert(To_Unbounded_String ("throw"), Tokens.Throw);
      O.Keywords.Insert(To_Unbounded_String ("try"), Tokens.Try);
      O.Keywords.Insert(To_Unbounded_String ("typeof"), Tokens.Typeof);
      O.Keywords.Insert(To_Unbounded_String ("var"), Tokens.Var);
      O.Keywords.Insert(To_Unbounded_String ("void"), Tokens.Void);
      O.Keywords.Insert(To_Unbounded_String ("while"), Tokens.While_Tok);
      O.Keywords.Insert(To_Unbounded_String ("with"), Tokens.With_Tok);
      O.Keywords.Insert(To_Unbounded_String ("true"), Tokens.True);
      O.Keywords.Insert(To_Unbounded_String ("false"), Tokens.False);
      O.Keywords.Insert(To_Unbounded_String ("null"), Tokens.Null_Tok);
   end Initialize;

   procedure Clear (O : in out Object) is
   begin
      O.Punctuators.Clear;
      O.Operators.Clear;
      O.Keywords.Clear;
   end Clear;

end Punctuation;
