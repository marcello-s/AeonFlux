with Ada.Strings.Unbounded; use Ada.Strings.Unbounded;
with Ada.Containers.Hashed_Maps; use Ada.Containers;
with Token; use Token;

package body Punctuation is

   procedure Initialize (O : Object) is
      C : Object := O;
   begin
      -- Punctuators
      C.Punctuators.Insert(To_Unbounded_String ("("), Token.LeftBracket);
      C.Punctuators.Insert(To_Unbounded_String (")"), Token.RightBracket);
      C.Punctuators.Insert(To_Unbounded_String ("{"), Token.LeftBrace);
      C.Punctuators.Insert(To_Unbounded_String ("}"), Token.RightBrace);
      C.Punctuators.Insert(To_Unbounded_String ("["), Token.LeftSquareBracket);
      C.Punctuators.Insert(To_Unbounded_String ("]"), Token.RightSquareBracket);
      C.Punctuators.Insert(To_Unbounded_String (";"), Token.Semicolon);
      C.Punctuators.Insert(To_Unbounded_String (","), Token.Comma);
      C.Punctuators.Insert(To_Unbounded_String ("."), Token.Point);

      -- Operators
      C.Operators.Insert(To_Unbounded_String ("?"), Token.Question);
      C.Operators.Insert(To_Unbounded_String (":"), Token.Colon);
      C.Operators.Insert(To_Unbounded_String ("~"), Token.Tilde);
      C.Operators.Insert(To_Unbounded_String ("*"), Token.Asterisk);
      C.Operators.Insert(To_Unbounded_String ("*="), Token.AsteriskEqual);
      C.Operators.Insert(To_Unbounded_String ("%"), Token.Percent);
      C.Operators.Insert(To_Unbounded_String ("%="), Token.PercentEqual);
      C.Operators.Insert(To_Unbounded_String ("^"), Token.Carot);
      C.Operators.Insert(To_Unbounded_String ("^="), Token.CarotEqual);
      C.Operators.Insert(To_Unbounded_String ("/"), Token.Slash);
      C.Operators.Insert(To_Unbounded_String ("/="), Token.SlashEqual);
      C.Operators.Insert(To_Unbounded_String ("&"), Token.Ampersand);
      C.Operators.Insert(To_Unbounded_String ("&&"), Token.Ampersand2);
      C.Operators.Insert(To_Unbounded_String ("&&="), Token.AmpersandEqual);
      C.Operators.Insert(To_Unbounded_String ("|"), Token.Pipe);
      C.Operators.Insert(To_Unbounded_String ("||"), Token.Pipe2);
      C.Operators.Insert(To_Unbounded_String ("|="), Token.PipeEqual);
      C.Operators.Insert(To_Unbounded_String ("="), Token.Equal);
      C.Operators.Insert(To_Unbounded_String ("=="), Token.Equal2);
      C.Operators.Insert(To_Unbounded_String ("==="), Token.Equal3);
      C.Operators.Insert(To_Unbounded_String ("!"), Token.Exclamation);
      C.Operators.Insert(To_Unbounded_String ("!="), Token.ExclamationEqual);
      C.Operators.Insert(To_Unbounded_String ("!=="), Token.ExclamationEqual2);
      C.Operators.Insert(To_Unbounded_String ("+"), Token.Plus);
      C.Operators.Insert(To_Unbounded_String ("++"), Token.Plus2);
      C.Operators.Insert(To_Unbounded_String ("+="), Token.PlusEqual);
      C.Operators.Insert(To_Unbounded_String ("-"), Token.Minus);
      C.Operators.Insert(To_Unbounded_String ("--"), Token.Minus2);
      C.Operators.Insert(To_Unbounded_String ("-="), Token.MinusEqual);
      C.Operators.Insert(To_Unbounded_String ("<"), Token.LessThan);
      C.Operators.Insert(To_Unbounded_String ("<<"), Token.LessThan2);
      C.Operators.Insert(To_Unbounded_String ("<="), Token.LessThanEqual);
      C.Operators.Insert(To_Unbounded_String ("<<="), Token.LessThan2Equal);
      C.Operators.Insert(To_Unbounded_String (">"), Token.GreaterThan);
      C.Operators.Insert(To_Unbounded_String (">>"), Token.GreaterThan2);
      C.Operators.Insert(To_Unbounded_String (">="), Token.GreaterThanEqual);
      C.Operators.Insert(To_Unbounded_String (">>="), Token.GreaterThan2Equal);
      C.Operators.Insert(To_Unbounded_String (">>>"), Token.GreaterThan3);
      C.Operators.Insert(To_Unbounded_String (">>>="), Token.GreaterThan3Equal);

      -- reserved Keywords
      C.Keywords.Insert(To_Unbounded_String ("break"), Token.Break);
      C.Keywords.Insert(To_Unbounded_String ("case"), Token.Case_Tok);
      C.Keywords.Insert(To_Unbounded_String ("catch"), Token.Catch);
      C.Keywords.Insert(To_Unbounded_String ("continue"), Token.Continue);
      C.Keywords.Insert(To_Unbounded_String ("debugger"), Token.Debugger);
      C.Keywords.Insert(To_Unbounded_String ("default"), Token.Default);
      C.Keywords.Insert(To_Unbounded_String ("delete"), Token.Delete);
      C.Keywords.Insert(To_Unbounded_String ("do"), Token.Do_Tok);
      C.Keywords.Insert(To_Unbounded_String ("else"), Token.Else_Tok);
      C.Keywords.Insert(To_Unbounded_String ("finally"), Token.Finally);
      C.Keywords.Insert(To_Unbounded_String ("for"), Token.For_Tok);
      C.Keywords.Insert(To_Unbounded_String ("function"), Token.Function_Tok);
      C.Keywords.Insert(To_Unbounded_String ("if"), Token.If_Tok);
      C.Keywords.Insert(To_Unbounded_String ("in"), Token.In_Tok);
      C.Keywords.Insert(To_Unbounded_String ("instanceof"), Token.Instanceof);
      C.Keywords.Insert(To_Unbounded_String ("new"), Token.New_Tok);
      C.Keywords.Insert(To_Unbounded_String ("return"), Token.Return_Tok);
      C.Keywords.Insert(To_Unbounded_String ("switch"), Token.Switch);
      C.Keywords.Insert(To_Unbounded_String ("this"), Token.This);
      C.Keywords.Insert(To_Unbounded_String ("throw"), Token.Throw);
      C.Keywords.Insert(To_Unbounded_String ("try"), Token.Try);
      C.Keywords.Insert(To_Unbounded_String ("typeof"), Token.Typeof);
      C.Keywords.Insert(To_Unbounded_String ("var"), Token.Var);
      C.Keywords.Insert(To_Unbounded_String ("void"), Token.Void);
      C.Keywords.Insert(To_Unbounded_String ("while"), Token.While_Tok);
      C.Keywords.Insert(To_Unbounded_String ("with"), Token.With_Tok);
      C.Keywords.Insert(To_Unbounded_String ("true"), Token.True);
      C.Keywords.Insert(To_Unbounded_String ("false"), Token.False);
      C.Keywords.Insert(To_Unbounded_String ("null"), Token.Null_Tok);


   end Initialize;


end Punctuation;
