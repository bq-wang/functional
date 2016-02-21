//module ReturningTuples

#light 

module Strangelights.DemoModule
open System

// returns the hour and minute from the give date as a tuple 
let hourAndMinute (time : DateTime) = time.Hour, time.Minute

// return the hour from the given date
let hour (time : DateTime) = time.Hour

// returns the minutes from the given date
let minute (time : DateTime) = time.Minute 
