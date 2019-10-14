// Learn more about F# at http://fsharp.org

open System
#light

        
//Checks if char is a vowel or not
//If it is we are converting it to a list
let isVowel c = 
    if(c='a' || c='e' || c='i' || c='o' || c='u') then [c]
    else []

//length function
let rec length list = 
       match list with
         | [] -> 0
         | _ :: tail -> 1 + length tail

//Creates a vowel list out of list given
let rec vowel L = 
    match L with 
        | [] -> []
        | x::rest -> isVowel x @ vowel rest //"Hey if thats a vowel concatenate that list with the smaller list"

///a
let A c = 
    if(c='a') then ['A']
    else []
///e
let E c = 
    if(c='e') then ['E']
    else []
///i
let I c = 
    if(c='i') then ['I']
    else []
///o
let O c = 
    if(c='o') then ['O']
    else []
///u
let U c = 
    if(c='u') then ['U']
    else []
//Capitalize
let Cap c = 
    if (c='a') then A c
    elif(c='e') then E c
    elif(c='i') then I c
    elif(c='o') then O c
    elif(c='u') then U c
    else [c]//Otherweise we don't capitalize but still have within the list
//This function will concatenate capital vowels with remaining string
let rec capitalizeList L = 
    match L with 
        | [] -> []
        | x::rest -> Cap x @ capitalizeList rest //"Hey if thats a vowel concatenate that list with the smaller list"


///a
let a c = 
    if(c='a') then [c]
    else []
///e
let e c = 
    if(c='e') then [c]
    else []
///i
let i c = 
    if(c='i') then [c]
    else []
///o
let o c = 
    if(c='o') then [c]
    else []
///u
let u c = 
    if(c='u') then [c]
    else []
//Creates a vowel list out of list given
let rec vowelA L = 
    match L with 
        | [] -> []
        | x::rest -> a x @ vowelA rest //"Hey if thats a vowel concatenate that list with the smaller list"

//Creates a vowel list out of list given
let rec vowelE L = 
    match L with 
        | [] -> []
        | x::rest -> e x @ vowelE rest //"Hey if thats a vowel concatenate that list with the smaller list"
//Creates a vowel list out of list given
let rec vowelI L = 
    match L with 
        | [] -> []
        | x::rest -> i x @ vowelI rest //"Hey if thats a vowel concatenate that list with the smaller list"
//Creates a vowel list out of list given
let rec vowelO L = 
    match L with 
        | [] -> []
        | x::rest -> o x @ vowelO rest //"Hey if thats a vowel concatenate that list with the smaller list"
//Creates a vowel list out of list given
let rec vowelU L = 
    match L with 
        | [] -> []
        | x::rest -> u x @ vowelU rest //"Hey if thats a vowel concatenate that list with the smaller list"
//
// explode:
//
// Given a string s, explodes the string into a list of characters.
// Example: explode "apple" => ['a';'p';'p';'l';'e']

//implode function
//
// The opposite of explode --- given a list of characters, returns
// the list as a string. Example: implode ['t';'h';'e'] => "the"
//
//
let explode s =
    Seq.toList s

let implode L =
    let sb = System.Text.StringBuilder()
    L |> List.iter(fun c-> ignore(sb.Append(c:char)))
    sb.ToString()


[<EntryPoint>]
let main argv =
    printf"input> "
    let input = System.Console.ReadLine()//Input from user
    let inputList = explode input///Convert string to list
    let inputLength = length inputList//length of list
    let vowels_list = vowel inputList//Create list of all vowels in users input
    let vowelLength = length vowels_list//length of vowels
    printfn"length: %i"  inputLength
    printfn"vowels: %i" vowelLength
    let aList  = vowelA vowels_list
    let aLength = length aList
    printfn"a: %i" aLength
    let eList  = vowelE vowels_list
    let eLength = length eList
    printfn"e: %i" eLength
    let iList  = vowelI vowels_list
    let iLength = length iList
    printfn"i: %i" iLength
    let oList  = vowelO vowels_list
    let oLength = length oList
    printfn"o: %i" oLength
    let uList  = vowelU vowels_list
    let uLength = length uList
    printfn"u: %i" uLength
    let cap_list = capitalizeList inputList
    let list1 = ['"']
    let list2 = ['"']
    let string = list1 @ cap_list
    let string2 = string @ list2
    let string_capitalized = implode string2
    //let final =  + string_capitalized + 
    //implode final answer
    printfn"Capitalized: %s" string_capitalized
    0//done