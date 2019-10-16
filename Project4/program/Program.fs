//
// F# program to analyze Divvy daily ride data.
//
// << YOUR NAME HERE >>
// U. of Illinois, Chicago
// CS 341, Fall 2019
// Project #04
//

#light

module project04

//
// ParseLine and ParseInput
//
// Given a sequence of strings representing Divvy data, 
// parses the strings and returns a list of lists.  Each
// sub-list denotes one bike ride.  Example:
//
//   [ [15,22,141,17,5,1124]; ... ]
//
// The values are station id (from), station id (to), bike
// id, starting hour (0..23), starting day of week (0 Sunday-6 Saturday)
// and trip duration (secs), 
//
let ParseLine (line:string) = 
  let tokens = line.Split(',')
  let ints = Array.map System.Int32.Parse tokens
  Array.toList ints

let rec ParseInput lines = 
  let rides = Seq.map ParseLine lines
  Seq.toList rides

//Every nth element
//let everyNth n list = 
  //list |> List.mapi (fun i el -> el, i)              // Add index to element
      //|> List.filter (fun (el, i) -> i % n = n - 1) // Take every nth element

//Create a list of bikeID
//Order doesn't matter we will use max function at end anyways
let rec ever3rd L =
    match L with
    |[] -> []
    |A::[] -> []
    |A::B::[] -> []
    |A::B::C::rest -> [C]
let rec bike_ID L =
    match L with
    |[]->[]
    |e::rest -> ever3rd e @ bike_ID rest
[<EntryPoint>]
let main argv =
  //
  // input file name, then input divvy ride data and build
  // a list of lists:
  //
  printf "filename> "
  let filename = System.Console.ReadLine()
  let contents = System.IO.File.ReadLines(filename)
  let ridedata = ParseInput contents
  //printfn "%A" ridedata
  let N = List.length ridedata
  let bikeID_list = bike_ID ridedata
  let max = List.max bikeID_list
  //display bikeID
  //let bikes = bikeID_list ridedata
  //let bikes_list = List.item(1) bikes 
  //let max = List.max bikes_list
  //let bikeID_list = every3rd ridedata
  //let max = List.max bikeID_list
  printfn ""
  printfn "# of riders: %A" N
  printfn "# of bikes: %A" ridedata
  printfn "# of bikes: %A" max
  //tprintfn "# of bikes: %A" ridedata.Item(3)
 // printfn "# of bikes: %A" bikeID
  //printfn "# of bikes: %A" ridedata
  //List.max bikeID |> printfn "high card is %i"
  0 

