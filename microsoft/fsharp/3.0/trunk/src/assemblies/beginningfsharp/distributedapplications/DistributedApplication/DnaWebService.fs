//module DnaWebService
namespace Strangelights.WebService

open System.Web.Services
// the web service class
[<WebService(Namespace = "http://strangelights.com/FSharp/Foundations/DnaWebService")>]
type DnaWebService() = 
    inherit WebService ()
    // the web method 
    [<WebMethod(Description = "Gets a representation of a yeast molecule")>]
    member x.GetYeastMolecule() = 
        // the code that populates the yeast xml structure 
        (*
        as you can see that you can quote the symbol with the `` symbol, which  you can convert some 
        keyword or other reserved word for the use of identifiers 
        *)
        let tax = new taxonomy(domain = "Eukaryota", kingdom = "Fungi",
                                phylum = "Ascomycota", ``class`` = "Saccharomycetes",
                                order = "Saccharomycetales",
                                family = "Saccharomycetaceae",
                                genus = "Saccharomyces",
                                species = "Saccharomyces cerevisiae")
        let id = new identity(name = "Saccharomyces cerevisiae tRNA-Phe",
                              taxonomy = tax)
        let yeast = new molecule(id = "Yeast-tRNA-Phe", identity = id)
        let numRange1 = new numberingrange(start = "1", Item = "10")
        let numRange2 = new numberingrange(start = "11", Item = "66")
        let numSys = new numberingsystem(id = "natural", usedinfile=true)
        numSys.Items <- [|box numRange1; box numRange2|]
        let seqData = new seqdata()
        seqData.Value <- "GCGGAUUUAG CUCAGUUGGG AGAGCGCCAG ACUGAAGAUC UGGAGGUCCU GUGUUCGAUC CACAGAAUUC GCACCA"
        let seq = new sequence(numberingsystem = [| numSys |], seqdata = seqData) 
        yeast.sequence <- [|seq|]
        yeast 

(*

the result that you might get is as follow.

<molecule xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" id="Yeast-tRNA-Phe">
<identity>
<name>Saccharomyces cerevisiae tRNA-Phe</name>
<taxonomy>
<domain>Eukaryota</domain>
<kingdom>Fungi</kingdom>
<phylum>Ascomycota</phylum>
<class>Saccharomycetes</class>
<order>Saccharomycetales</order>
<family>Saccharomycetaceae</family>
<genus>Saccharomyces</genus>
<species>Saccharomyces cerevisiae</species>
</taxonomy>
</identity>
<sequence>
<numbering-system id="natural" used-in-file="true">
<numbering-range>
<start>1</start>
<end>10</end>
</numbering-range>
<numbering-range>
<start>11</start>
<end>66</end>
</numbering-range>
</numbering-system>
<seq-data>
GCGGAUUUAG CUCAGUUGGG AGAGCGCCAG ACUGAAGAUC UGGAGGUCCU GUGUUCGAUC CACAGAAUUC GCACCA
</seq-data>
</sequence>
</molecule>
*)
