-- Copyright (c) 2015-2017 Marcel Schneider
-- for details see License.txt

with Ada.Strings.Unbounded; use Ada.Strings.Unbounded;

package Position is

   type Object is record
      Text : Unbounded_String;
      StartLine : Natural;
      EndLine : Natural;
      StartColumn : Natural;
      EndColumn : Natural;
   end record;

end Position;
