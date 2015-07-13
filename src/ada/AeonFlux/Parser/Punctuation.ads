with Ada.Strings.Unbounded; use Ada.Strings.Unbounded;
with Ada.Strings.Unbounded.Equal_Case_Insensitive;
with Ada.Strings.Unbounded.Hash_Case_Insensitive;
with Ada.Containers.Hashed_Maps; use Ada.Containers;
with Token; use Token;

package Punctuation is

   package Tokens is new Ada.Containers.Hashed_Maps
     (Key_Type => Unbounded_String,
      Element_Type => Token.Token,
      Hash => Hash_Case_Insensitive,
      Equivalent_Keys => Equal_Case_Insensitive
     );

   type Object is record
      Punctuators : Tokens.Map;
      Operators : Tokens.Map;
      Keywords : Tokens.Map;
   end record;

   procedure Initialize (O : Object);

end Punctuation;
