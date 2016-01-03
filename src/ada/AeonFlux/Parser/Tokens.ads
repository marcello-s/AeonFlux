-- Copyright (c) 2015-2016 Marcel Schneider
-- for details see License.txt

package Tokens is


   type Token is (
                  LeftBracket,
                  RightBracket,
                  LeftBrace,
                  RightBrace,
                  LeftSquareBracket,
                  RightSquareBracket,
                  Question,
                  Colon,
                  Semicolon,
                  Comma,
                  Point,
                  Tilde,
                  Asterisk,
                  AsteriskEqual,
                  Percent,
                  PercentEqual,
                  Carot,
                  CarotEqual,
                  Slash,
                  SlashEqual,
                  Ampersand,
                  Ampersand2,
                  AmpersandEqual,
                  Pipe,
                  Pipe2,
                  PipeEqual,
                  Equal,
                  Equal2,
                  Equal3,
                  Exclamation,
                  ExclamationEqual,
                  ExclamationEqual2,
                  Plus,
                  Plus2,
                  PlusEqual,
                  Minus,
                  Minus2,
                  MinusEqual,
                  LessThan,
                  LessThan2,
                  LessThanEqual,
                  LessThan2Equal,
                  GreaterThan,
                  GreaterThan2,
                  GreaterThanEqual,
                  GreaterThan2Equal,
                  GreaterThan3,
                  GreaterThan3Equal,
                  -- Puntuation dictionary end
                  -- Reserved Keyword
                  Break,
                  Case_Tok,
                  Catch,
                  Continue,
                  Debugger,
                  Default,
                  Delete,
                  Do_Tok,
                  Else_Tok,
                  Finally,
                  For_Tok,
                  Function_Tok,
                  If_Tok,
                  In_Tok,
                  Instanceof,
                  New_Tok,
                  Return_Tok,
                  Switch,
                  This,
                  Throw,
                  Try,
                  Typeof,
                  Var,
                  Void,
                  While_Tok,
                  With_Tok,
                  True,
                  False,
                  Null_Tok,
                  -- Reserved Keyword end
                  WhiteSpace,
                  NewLine,
                  LineComment,
                  BlockComment,
                  NumberLiteral,
                  StringLiteral,
                  Identifier,
                  RegEx,
                  Illegal,
                  EOF
                 );

end Tokens;