module FloatingPointArithmeticFunctions

// what we will cover in this chapter include the following 
//   1. Floating-point arithmetic functions 


(*

The operators module also offers a number of functions .


*)

printfn "(sqrt 16.0): %f" (sqrt 16.0)
printfn "(log 16.0): %f" (log 16.0)
printfn "(cos 1.6): %f" (cos 1.6)


(*

abs Returns the absolute value of the argument
acos Returns the inverse cosine (arccosine) of the argument, which should be specified in
radians
asin Returns the inverse sine (arcsine) of the argument, which should be specified in radians
atan Returns the inverse tangent (arctangent) of the argument, which should be specified in radians
atan2 Returns the inverse tangent (arctangent) of the two arguments, which should both be specified in radians
ceil Returns the next highest integer value by rounding up the value if necessary; the value returned is still of type float
floor Returns the next lowest integer value by rounding up the value if necessary; the value returned is still of type float 
exp Returns the exponential
infinity Returns the floating-point number that represents infinity
log Returns the natural log of the floating-point number
log10 Returns the base 10 log of the floating-point number
nan Returns the floating-point number that represents “not a number”
sqrt Returns the square root of the number
cos Returns the cosine of the parameter, which should be specified in radians
cosh Returns the hyperbolic cosine of the parameter, which should be specified in radians
sin Returns the sine of the parameter, which should be specified in radians
tan Returns the tangent of the parameter, which should be specified in radians
tanh Returns the hyperbolic tangent of the parameter, which should be specified in radians
truncate Returns the parameter converted to an integer
float Takes an integer and returns it as a float
float32 Takes an integer and returns it as a float32
*)