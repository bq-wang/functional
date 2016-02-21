module RecursiveTypeDefinitions

// you will need to reference a type that is declared later, it cannot typically do so, the only reason you willneed to do this is if the types are mutually recursive.

// represents an XML attributes

// the syntax is like this:
//   type type_name = 
//      { type_definition } 
//   and type_name = 
//      { type_definition } 

// reprent an XML element
type XmlAttribute = 
    { AttribName : string; 
      AttribValue: string; } 

// represents an XML element
type XmlElement = 
    { ElementName : string; 
      Attributes: list<XmlAttribute>;
      InnerXml: XmlTree } 

// represents an XML tree
// the following will cause error
//type XmlTree = 
and XmlTree = 
    | Element of XmlElement
    | ElementList of list<XmlTree>
    | Text of string
    | Comment of string
    | Empty