-- Copyright (c) 2015-2016 Marcel Schneider
-- for details see License.txt

with Ada.Strings.Unbounded; use Ada.Strings.Unbounded;
with Ada.Strings.Unbounded.Equal_Case_Insensitive;
with Ada.Strings.Unbounded.Hash_Case_Insensitive;
with Ada.Containers.Hashed_Maps; use Ada.Containers;
with Tokens; use Tokens;

package Punctuation is

   package TokenMap is new Ada.Containers.Hashed_Maps
     (Key_Type => Unbounded_String,
      Element_Type => Tokens.Token,
      Hash => Hash_Case_Insensitive,
      Equivalent_Keys => Equal_Case_Insensitive
     );

   type Object is record
      Punctuators : TokenMap.Map;
      Operators : TokenMap.Map;
      Keywords : TokenMap.Map;
   end record;

   procedure Initialize (O : in out Object);
   procedure Clear (O : in out Object);

end Punctuation;
