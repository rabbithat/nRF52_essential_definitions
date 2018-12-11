\ These are essential definitions which are leveraged by other programs

\ \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
\ General Purpose Constants

$00000000 constant _FALSE
$FFFFFFFF constant _TRUE
$000000FF constant maskByte0 \ bitmask for byte zero.
$FFFFFF00 constant maskByte321 \ bitmask for byte3 byte2 and byte1

\ \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
\
\ General Purpose simple variable manipulation
\

\ Return byte0 of the given variable
\ ( varAddr -- byte )
: var@b @ maskByte0 and ;

\ Write the given byte into byte0 of the given variable
\ ( byte varAddr -- )
: var!b dup @ maskByte321 and rot or swap ! ;

\ sets the variable to zero
\ (variableAddress -- )
: var0! 0 swap ! ;

\ sets the variable to one
\ (variableAddress -- )
: var1! 1 swap ! ;

\ increment the variable 
\ (variableAddress -- )
: var++! dup @ 1+ swap ! ;

\ decrement the variable 
\ (variableAddress -- )
: var--! dup @ 1- swap ! ;

\ decrement a variable by 2
\ (variableAddress -- )
: var-2! dup @ 2- swap ! ;

\
\ \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
\ General Purpose indexed list (one-dimensional array) manipulation
\

\ get the value of an indexed variable
\ ( indexValue baseAddressOfList -- valueAtIndexedLocation )
: ivList@ + @ ;

\ get the value of the low order byte at the indexed location
\ ( indexValue baseAddressOfList -- byte0AtIndexedLocation )
: ivList@b + var@b ;

\ write the given value at the indexed list location
\ ( value indexValue baseAddressOfList -- )
: ivList! + ! ;

\ write the given byte value into byte0 at indexed list location
\ ( byte indexValue baseAddressOfList -- )
: ivList!b + var!b ;

\ clear the value at the indexed list location
\ (indexValue baseAddressOfList -- )
: ivList0! + 0 swap ! ;

\ set the value at the indexed list location to 1
\ (indexValue baseAddressOfList -- )
: ivList1! + 1 swap ! ;

\ increment the value at the indexed list location
\ ( indexValue baseAddressOfList -- )
: ivList++! + var++! ;

\ decrement the value at the indexed list location
\ ( indexValue baseAddressOfList -- )
: ivList--! + var--! ;

\ get the value at the indexed location and then increment the index
\ (indexAddress baseAddressOfList -- value )
: i++List@ over @ + @ swap var++! ;

\ get the value at the indexed location and then increment the index
\ (indexAddress baseAddressOfList -- byte )
: i++List@b i++List@ maskByte0 and ;

\ get the value at the indexed location and then decrement the index
\ (indexAddress baseAddressOfList -- value )
: i--List@ over @ + @ swap var--! ;

\ write the value at the indexed location and then decrement the index
\ ( value indexAddress baseAddress -- )
: i--List! over @ + rot swap ! var--! ;

\ write the value at the indexed location and then increment the index
\ ( value indexAddress baseAddress -- )
: i++List! over @ + rot swap ! var++! ; 

\ write the byte to byte0 of the indexed location and then increment the given index
\ ( byte indexAddress baseAddress -- )
: i++List!b over over swap @ swap ivList@ maskByte321 and >R rot R> or rot rot i++List! ;