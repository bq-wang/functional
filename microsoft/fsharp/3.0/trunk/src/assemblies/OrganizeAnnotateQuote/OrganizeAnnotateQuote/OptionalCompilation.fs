module OptionalCompilation

// in this chapter, we will cover the following..
//    1. how to do optional compilation with the define keyword

// Optional compilation is a technique where the compiler can ignore various bits of text from a source file.
// this is supported by the "--define FLAG" and command "#if FLAG" in a source file. 



open System.Windows.Forms

// define a form 
let form = new Form() 

// do something different depending if we're running 
// as a compiled program of as a strict 

#if COMPILED
Application.Run form 
#else 
form.Show()
#endif 

