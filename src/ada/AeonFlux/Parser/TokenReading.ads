-- Copyright (c) 2015-2017 Marcel Schneider
-- for details see License.txt

with TokenValue; use TokenValue;

package TokenReading is

   type Object is interface;

   function ReadToken (O : Object) return TokenValue.Object is abstract;

end TokenReading;
