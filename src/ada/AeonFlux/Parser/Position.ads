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
