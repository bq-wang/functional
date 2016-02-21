
// what will be covered in this chapter include the folllowing
//   1. how to uset he HTTP 


#r "System.xml.dll"

open System
open System.Diagnostics
open System.Net
open System.Xml

/// makes a http request to the given url
let getUrlAsXml(url: string) =
    let request = WebRequest.Create(url)
    let response = request.GetResponse()
    let stream = response.GetResponseStream()
    let xml = new XmlDocument()
    xml.Load(stream)
    xml

/// the url we interesed in 
let url = "http://newsrss.bbc.co.uk/rss/newsonline_uk_edition/sci/tech/rss.xml"

// main application function 
let main() = 
    //read the rss feed
    let xml = getUrlAsXml url 
    // write out the titles of all the new items
    let nodes = xml.SelectNodes("/rss/channel/item/title")

    for i in 0 .. (nodes.Count - 1) do
        printf "%i. %s\r\n" (i + 1) (nodes.[i].InnerText) 

    // read the number the user wants from the console
    let item = int(Console.ReadLine())

    // find the new Url
    let newUrl = 
        let xpath = sprintf "/rss/channel/item[%i]/link" item
        let node = xml.SelectSingleNode(xpath)
        node.InnerText
    // start the url using the shell, this automaticall opens
    // the default browser
    let procStart = new ProcessStartInfo(UseShellExecute = true,
                                         FileName = newUrl)
    let proc = new Process(StartInfo = procStart)
    proc.Start() |> ignore 
do main()

(*

when you run this program, you might get the following output 


1. Moon rover sends back first photos
2. Savvy godwit up to climate challenge
3. Farmers protest against subsidy cuts
4. Iran 'sends second monkey to space'
5. Mud volcano to stop 'by decade's end'
6. Tibetans displaced 'amid mining'
7. Global cancer cases reach 14 million
8. Titan's colossal methane seas
9. Data to expose 'sleeping ice giant'
10. Massive offshore wind plans dropped
11. Hydrogen is squeezed from stone
12. Dinosaur mummy's fleshy head crest
13. James Bond is an 'impotent drunk'
14. Discovery gives bird 11th hour hope
15. VIDEO: Hadfield sings Space Oddity live
16. Problem hits ISS cooling system
17. Synthetic gel mimics amphibians
18. Grades 'more nature than nurture'
19. Supervolcano 'even more colossal'
20. Movie captures Earth-Moon 'dance'
21. Peter Higgs receives Nobel medal
22. Weather 'behind ozone hole changes'
23. Cave holds stunning tsunami clues
24. Horsemeat: UK food crime unit urged
25. Satellite detects Antarctic ice loss
26. US to curb antibiotics in livestock
27. 'No case' to water down CO2 targets
28. Seals 'fared better than feared'
29. Fruit-mad monkeys eat 50 per day
30. Beached whales dead in Florida
31. AUDIO: Hadfield: 'Space changes your outlook'
32. VIDEO: Scotland's killer avalanches explained
33. AUDIO: Supervolcano eruption 'would affect the world'
34. VIDEO: Sun displayed in spectacular detail
35. VIDEO: How to encourage girls into 'boy-biased' A-levels
36. AUDIO: Universe is 'puzzle with missing pieces'
37. VIDEO: Ancient DNA find is 'very exciting'
38. AUDIO: 'Jumbled up' tongue twister most difficult
39. 'I was mistaken for the tea lady'
40. Could Los Angeles withstand a 'megaquake'?
41. Soldier moves bionic arm by thoughts
42. Countdown begins for comet chaser
43. Scramble for cash as farm subsidies pot shrinks
44. TB resistance is a 'ticking time bomb'
45. 'Love island' in space pic shortlist
46. UK Floods: Learning lessons from the past
47. Infections: War's true beneficiaries
48. Could hi-tech make cyclists safer?
41

and once you input some value, such as the "41", the 41's article shall be opened.

Soldier Andrew Garthwaite moves bionic arm by thoughts: 
    http://www.bbc.co.uk/news/uk-england-tyne-25320455#


*)

