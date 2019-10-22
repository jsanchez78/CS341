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
let convert_to_int = List.map (fun elem -> int elem)
let ParseLine (line:string) = 
  let tokens = line.Split(',')
  let ints = Array.map System.Int32.Parse tokens
  Array.toList ints

let rec ParseInput lines = 
  let rides = Seq.map ParseLine lines
  Seq.toList rides


let rec contains x L = 
  match L with
  | []               -> false
  | e::_    when e=x -> true
  | _::rest          -> (contains x rest)

//Tail Recursive Count
//Avoids stack overflow
let rec _count x L soFar =
    match L with 
        |[]->soFar
        |e::rest when e=x -> _count x rest (soFar+1)
        |_::rest -> _count x rest (soFar)
let count x L = 
    _count x L 0

let rec _count2 L soFar =
    match L with 
        |[]->soFar
        |e::rest when contains e L=false-> _count2 rest (soFar+1)
        |_::rest -> _count2 rest (soFar) 


let count2 L =
    _count2 L 0
//Creates distinct list
let rec unique L =
    match L with 
        |[]->[]
        |e::rest when contains e rest=false-> [e] :: unique rest
        |_::rest -> unique rest           



let rec nth_elem n l  =
    match n, l with
      | 0,(elem::rest)->elem
      | m_int,(_m::rest)->nth_elem (n-1) rest
      |new_n,[]->invalidArg "n" "list too short"


 //List of duplicates
let rec _helper n l = 
    match l with
        |[] -> []
        |hd::tl -> nth_elem n hd :: _helper n tl     
//length function
let rec length list = 
       match list with
         | [] -> 0
         | _ :: tail -> 1 + length tail

 //List of duplicates
let rec _helper_bikeID value n l = 
    match l with
        |[] -> []
        |hd::tl when nth_elem n hd = value -> hd :: _helper_bikeID value n tl
        |hd::tl -> _helper_bikeID value n tl
let bikeID_list l = 
    _helper_bikeID 102 2 l
let stationID_list l = 
    _helper_bikeID 20 1 l
let rec sum values = 
    match values with
    |[]->0
    |e::rest -> e + sum rest
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
  let N = length ridedata


  //num bikes
  let bike_ID_list = _helper 2 ridedata
  let num_bikes = count2 bike_ID_list


  //bike_ID
  let unique_bike_list = unique bike_ID_list
  let num_bikes = unique_bike_list.Length
  let bike_ID_list = bikeID_list ridedata

  
  let unique_bikeID = bike_ID_list.Item(0).Item(2)
  let bikeID_length = bike_ID_list.Length

  //total_time
  let total_time_list = _helper 5 bike_ID_list
  let total_time = sum total_time_list
  let minutes = total_time/60
  let seconds = total_time % 60

  //avg time
  let avg_time = float total_time/float bikeID_length



  //to stationID (2nd paramter in list of list)
  let stationID_list = stationID_list ridedata
  let sID = stationID_list.Item(0).Item(1)
  let to_stationID = stationID_list.Length
  let total_time_StationID_list = _helper 5 stationID_list
  let total_time_stationID = sum total_time_StationID_list
  let avg_time_stationID = float total_time_stationID/float to_stationID

  printfn "\n# of rides: %A\n" N
  printfn "# of bikes: %A\n" num_bikes
  printfn"BikeID> %A\n"  unique_bikeID
  printfn"# of rides for BikeID 102: %A\n" bikeID_length
  printfn"Total time spent riding BikeID %i: %A minutes %A seconds\n" unique_bikeID minutes seconds
  printfn"Average time spent riding BikeID %i: %A seconds\n" unique_bikeID avg_time
  printfn "StationID> %A\n" sID
  printfn "# of rides to StationID %A: %A\n" sID to_stationID
  printfn"Average time spent on trips leading to StationID %A: %A seconds\n" sID avg_time_stationID
  0// 

