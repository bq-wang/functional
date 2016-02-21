// README.txt

what will be covered in this chapter include the following 
1.  you might learn how to build your own DSL language with the fslex, and fsyacc.exe
2.  you can start commencing the simple task of parsing comma separated text file 
3.  you will lean how to use the tools such as fslex and fsyacc and the lib that is called FParsec

-- tools downloading 

you will need the tool "FsLex and FsYacc to make a parser int F#"

actually if you have download the libraries that is called "F# Powerpack", you will already have the acess to the tool
called FSYacc.exe and the FSLex.exe, from my box, the tools are installed to the following folder:

C:\ProgramFiles\FSharpPowerPack-4.0.0.0\bin


C:\ProgramFiles\FSharpPowerPack-4.0.0.0\bin>dir *.exe
 Volume in drive C is OSDisk
 Volume Serial Number is 9C83-A1DC

 Directory of C:\ProgramFiles\FSharpPowerPack-4.0.0.0\bin

02/17/2013  12:10 PM           154,112 fshtmldoc.exe
02/17/2013  12:09 PM           255,488 fslex.exe
02/17/2013  12:09 PM           379,392 fsyacc.exe
               3 File(s)        788,992 bytes
               0 Dir(s)  357,516,869,632 bytes free


-- notes on the FSL.

extension: the extension of the fslex.exe file has the extension .fsl 
optional header: which is placed between braces ({}) and is pure F# code, generally used to pen moduels or possibly to define helper functions.
regular expression: you can use the let binding to define regular expression and assign a ame to the regular expessions
	e.g. let digit = ['0' - '9']; 
	note: you can define a regular expression inside a rule
rule: a collection of regular expression that are in competition to match sections of the text
	syntax of the rule is "rule rule_name = parse regular_expressions_with_actions
	the syntax of the regular expression is as follow: 
		| regular_expression { action }
	each rule is separated by a vertical bar
	NOTE:
		though actions can be any valid F# expressions, it is normal to return the token declarations 
		that you will make in the fsyacc file, see the next section, "Generating a parser Fsyacc", for more information about his 
General parsing principle:
	you usually do one or two things inthe actions. if you are interested in the match, you return a token that has been defined inthe parser file 
	These are the identifiers in block capitabls like RPAREN or MULTI, if you are not that interested, you call "token" with the spcial "lexbuf"
token: 
	These are the identifiers in block capitabls like RPAREN or MULTI
lexbuf: 
	The lexbuf value is automatically placed in your parser definition and represents the text stream being processed. It
	is of type Microsoft.FSharp.Text.Lexing.LexBuffer
Action notice: 
	Also notice how in places where you’re actually interested in the value found rather than just the fact a value was found that you use a function called
	curLexeme to get the string representing the match from the
	
Rule resolution:
	if there are more than one rules has been found, the longest match should win

-- note on the scanner, the notes on the fsy (the extension of the fsyacc.exe is the .fsy)

the scanner that we will use is called fsyacc

the yacc stands for yet another compiler compiler

there are three parts in the Parser.

header: %{ and closed by the %} where the AST module and and to define short helper functions for creating the AST.
terminals: the declaration parts, defining the terminals of the language. A terminal is something concrete in your grammer such as an identifier name or a symbol. Typically there are found by the lexer. Declarations have several different forms that summarized in Table 13.1
rules: the rules that makes up the grammer which will be described later 


%token						This declares the given symbol as the token in the language.
%token<type>				This declares the given symbol as a token, like %token, but with arguments of the
given type. This is useful for things such as identifiers and literals when you need to
store information about them.
%start						This declares the rule at which the parser should start parsing.
%type<type>					hpeThis declares the type of a particular rule; it is mandatory for the start rule but
optional for all other rules.
%left						This declares a token as left-associative, which can help resolve ambiguity in the
grammar.
%right						This declares a token as right-associative, which can help resolve ambiguity in the
grammar.
%nonassoc					This declares a token as nonassociative, which can help resolve ambiguity in the
grammar.

%%: separate the rules and the dscription


-- the format of the fsyacc compiler
first is the %{ %} separated pure F# , - used to open your AST module adn to define short helper functions for creating the AST
second: declarations, defining the terminals of your language. - a terminal is something concrete in your grammer such as an identifier name or a symbol 
third:, contains rules that make up grammer and are described above. 


an example of the rule is as follow. 

 Expression: ID { Ident($1) }
| FLOAT { Val($1) }


-- compiling the .fsl file 

C:\ProgramFiles\FSharpPowerPack-4.0.0.0\bin\fslex.exe Fslex.fsl

C:\ProgramFiles\FSharpPowerPack-2.0.0.0\bin\fslex.exe Fslex.fsl



-- compiling the .fsy file 

C:\ProgramFiles\FSharpPowerPack-4.0.0.0\bin\fsyacc.exe Fsyacc.fsy

C:\dev\workspaces\functional\microsoft\fsharp\3.0\trunk\src\assemblies\beginningfsharp\ParsingText\ParsingText>C:\ProgramFiles\FSharpPowerPack-2.0.0.0\bin\fslex.exe Fslex.fsl
compiling to dfas (can take a while...)
21 states
writing output


It generate one files, that is called "Fslex.fs"

C:\dev\workspaces\functional\microsoft\fsharp\3.0\trunk\src\assemblies\beginningfsharp\ParsingText\ParsingText>dir Fslex*
 Volume in drive C is OSDisk
 Volume Serial Number is 9C83-A1DC

 Directory of C:\dev\workspaces\functional\microsoft\fsharp\3.0\trunk\src\assemblies\beginningfsharp\ParsingText\ParsingText

12/24/2013  11:29 AM            50,329 Fslex.fs
12/20/2013  10:35 AM               726 Fslex.fsl
12/19/2013  04:07 PM               257 FslexComment.fsl
               3 File(s)         51,312 bytes
               0 Dir(s)  356,519,415,808 bytes free


C:\ProgramFiles\FSharpPowerPack-2.0.0.0\bin\fsyacc.exe Fsyacc.fsy

C:\dev\workspaces\functional\microsoft\fsharp\3.0\trunk\src\assemblies\beginningfsharp\ParsingText\ParsingText>C:\ProgramFiles\FSharpPowerPack-2.0.0.0\bin\fsyacc.exe Fsyacc.fsy
building tables
computing first function...time: 00:00:00.0724203
building kernels...time: 00:00:00.0458396
building kernel table...time: 00:00:00.0308726
computing lookahead relations..................time: 00:00:00.0389451
building lookahead table...time: 00:00:00.0188197
building action table...time: 00:00:00.0108536
building goto table...time: 00:00:00.0008738
returning tables.
15 states
2 nonterminals
11 terminals
8 productions
#rows in action table: 15


it helps generating two files, one is called the "Fsyacc.fsi", and one is caled "Fsyacc.fs"

C:\dev\workspaces\functional\microsoft\fsharp\3.0\trunk\src\assemblies\beginningfsharp\ParsingText\ParsingText>dir Fsyacc*
 Volume in drive C is OSDisk
 Volume Serial Number is 9C83-A1DC

 Directory of C:\dev\workspaces\functional\microsoft\fsharp\3.0\trunk\src\assemblies\beginningfsharp\ParsingText\ParsingText

12/24/2013  11:29 AM            10,870 Fsyacc.fs
12/24/2013  11:29 AM             1,134 Fsyacc.fsi
12/24/2013  10:54 AM               680 Fsyacc.fsy
               3 File(s)         12,684 bytes
               0 Dir(s)  356,519,415,808 bytes free


NOTE: you'd better supply the fsyacc compilatio with the following flags

--module

e..g 

C:\dev\workspaces\functional\microsoft\fsharp\3.0\trunk\src\assemblies\beginningfsharp\ParsingText\ParsingText>C:\ProgramFiles\FSharpPowerPack-2.0.0.0\bin\fsyacc.exe Fsyacc.fsy --module Strangelights.ExpressionParser.Parser


-- Error compiling the .fsl or the .fsy files

C:\ProgramFiles\FSharpPowerPack-4.0.0.0\bin>fslex

Unhandled Exception: System.IO.FileNotFoundException: Could not load file or assembly 'FSharp.Core, Version=4.3.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a' or one of its dependencies. The system cannot find the file specified.
   at <StartupCode$fslex>.$FSharp.PowerPack.FsLex.Driver.main@()


so you have to use the FSLex and FSYacc from the FSharpPowerpack-2.0.0.0 rather from the FSharpPowerpack-4.0.0.0


-- Error "Module or namespace "Lexing" not defiend" or "Module or namespace "Parsing" not defined" 

to do this, you will need to remove all the reference to FSharp.PowerPack.dll" from the references tabs (do not try to add reference from the .NET reference category), rather you will add them back by "Browsing category", and loads all the files from disk locations.

-- Error: System.MissingMethodException was unhandled
Message: Method not found: 'System.Object Microsoft.FSharp.Text.Parsing.Tables`1.Interpret(Microsoft.FSharp.Core.FSharpFunc`2<Microsoft.FSharp.Text.Lexing.LexBuffer`1<Byte>,!0>, Microsoft.FSharp.Text.Lexing.LexBuffer`1<Byte>, Int32)'.

Problem with F# Powerpack. Method not found error http://stackoverflow.com/questions/5447539/problem-with-f-powerpack-method-not-found-error

the reason might because of the 

Don't install VS2010 SP1 http://fsharpnews.blogspot.hk/2011/03/dont-install-vs2010-sp1.html 
"Our F# implementation of Okasaki's purely functional real-time queue data structure started to suffer from MissingMethodExceptions after we installed SP1. Two of our clients are experiencing problems using F# with Silverlight only after having installed SP1."

another solution is to switch target framework as 
	--  "I've got the same error when trying to build WikiBooks Lexing/Parsing example in Visual Studio 2012. I resolved the problem by switching target framework from 4.0 to 4.5 in project settings."

and there is a work-around
	-- "A workaround to get you going again is to recompile the F# Power Pack for .NET 4.0 (it is a .NET 2.0 binary, and this related to the issue you're seeing)"




-- reference 

Use FsLex and FsYacc to make a parser in F#: http://blogs.msdn.com/b/jomo_fisher/archive/2010/06/15/use-fslex-and-fsyacc-to-make-a-parser-in-f.aspx
F Sharp Programming/Lexing and Parsing http://en.wikibooks.org/wiki/F_Sharp_Programming/Lexing_and_Parsing
Why is this fsyacc input producing F# that does not compile? http://stackoverflow.com/questions/7999019/why-is-this-fsyacc-input-producing-f-that-does-not-compile
CalcExample https://code.google.com/p/recursive-ascent/wiki/CalcExample
--internal for FsYacc https://groups.google.com/forum/#!topic/fsharp-opensource/yjBK13ZY89k

