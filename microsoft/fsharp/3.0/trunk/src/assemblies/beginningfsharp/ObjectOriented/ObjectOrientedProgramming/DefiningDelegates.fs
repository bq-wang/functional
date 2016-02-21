module DefiningDelegates

// Delegates are the mechanism that both C# and Visual Basic use to treat their methods as values.

// what will be covered in this chapter include this:
//   delegate as  value (in this regards, you don't need to define delegate as function can be passed just as any other value)
//   how to define a delegate


// the syntax to define a delegate is as follow
// type delegate-name = delegate of delegate-type
// delegate-type:: parameter-list -> return-type (where the parameter-type can be tuple style or the record style)
type MyDelegate = delegate of int -> unit

let inst = new MyDelegate( fun i -> printf "%i" i)

let ints = [1; 2; 3 ]


ints 
|> List.iter (fun i -> inst.Invoke(i))

