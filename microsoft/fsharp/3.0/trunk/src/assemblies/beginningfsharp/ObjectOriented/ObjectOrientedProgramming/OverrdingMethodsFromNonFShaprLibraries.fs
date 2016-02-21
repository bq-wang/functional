module OverrdingMethodsFromNonFShaprLibraries

// Overriding methods from Non-F# libraries

// what shall be covered in this post include the following
//   When overriding methods from non-F# libraries, you must implement the method definition in the
//   tuple style; that is, you must surround the parameters with parentheses and separated them by commas.

// syntax:
// type type_name(comma-separated-constructor-parameter-list) = 
//     interface non-fsharp-type-interface with 
//       member instance_identifier.member_name(comma-separated-parameter-list) // this is the tuple style , you cannot use the record type, check the chapter 3 for details.
//          member-definition


// NOTE:
// the explicit class/interface/struct style (may not inculde the record or union(sometimes called sum) type 
// which has the following forms
// 
//type type_name[(comma-separated-constructor-parameter-list)] = class|interface|struct
//    class-definition | interface-definition | struct-definition
//end

// NOTE:
//  recommended to use the explict style when dealing with non-F# types. (personal preference by JOE)

type CredentialsFactory() = class
    interface System.Net.ICredentials with
        member x.GetCredential(uri, authType) = 
            new System.Net.NetworkCredential("rob", "whatever", "F# credentials")
    member x.GetCredential uri authTypes = 
        let y = (x :> System.Net.ICredentials)
        let getCredentail s = y.GetCredential(uri, s)
        List.map getCredentail authTypes
end