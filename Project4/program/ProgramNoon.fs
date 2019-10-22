#light

//slides.app.goo.gl/1XNGG
let mapVowel v =
  match v with
  | 'a' -> 'A' 
  | 'e' -> 'E'
  | 'i' -> 'I'
  | 'o' -> 'O'
  | 'u' -> 'U' 
  |  _  ->  v

let rec capitalizeVowels L = 
    _capitalizeVowels L []
//  match L with 
//  | []     -> []
//  | hd::tl -> (mapVowel hd) :: capitalizeVowels tl

let rec _capitalizeVowels L charListSoFar = 
  match L with 
  | []     -> charListSoFar //[]
  | hd::tl -> _capitalizeVowels tl (mapVowel hd)::charListSoFar //(mapVowel hd) :: capitalizeVowels tl

let rec _max L max =
  match L with
  | [] -> raise...
  | e::[] -> if e > max then e else max
  | e::rest -> _max rest (if e > max then e else max)

let rec _max curr_max L =
    match L with
    | [] -> curr_max
    | hd:tl when hd > curr_max -> _max hd tl
    | hd::tl -> _max curr_max tl

let rec _ max maxVal L
match L with 
| [] -> rasie System.ArugmentException("erroroororooror")
| n::next when n > maxVal -> _max n next
| n::next when n <= maxVal -> _max maxVal next


let _max L runningMax =
    match L with
    | [] -> runningMax
    | curr::tl when curr > runningMax -> _max tl curr
    | _ -> _max (List.tail L) runningMax


let max L =
    match L with
    | [] -> raise System.ArgumentException("Can not find maximum of an empty list.")
    | hd::tl -> _max L hd














//
// generate a random list of length N:
//
let ran = new System.Random(12345)
let genlist N = 
  List.init N (fun i -> ran.Next(0,10000))


let rec contains x L = 
  match L with
  | []               -> false
  | e::_    when e=x -> true
  | _::rest          -> (contains x rest)

let rec count x L = 
  match L with
  | []               -> 0
  | e::rest when e=x -> 1 + (count x rest)
  | _::rest          -> 0 + (count x rest)


//let rec _max maxSoFar L = 
//  match L with
//  | []                        -> maxSoFar
//  | hd::tl when hd > maxSoFar -> _max hd tl
//  | _::tl                     -> _max maxSoFar tl

//let max L = 
//  match L with
//  | []     -> raise (System.ArgumentException("L cannot be empty"))
//  | hd::tl -> _max hd tl


let rec max L = 
  match L with
  | []     -> raise (System.ArgumentException("L cannot be empty"))
  | hd::[] -> hd
  | hd::tl -> let other = max tl
              if hd > other then hd else other


[<EntryPoint>]
let main argv =
  //let N = 1000000
  //let L = genlist N
  //
  let strL =['H';'e';'l';'l';'o']
  printfn "List: %A" (capitalizeVowels strL)
  let L = [22; 19; 88; 4; 22; 11; 0; 22]
  printfn "List: %A" L
  printfn ""
  printfn "Max: %A" (max L)
  printfn ""
  //
  //printf "Enter an integer> "
  //let s = System.Console.ReadLine()
  //let x = System.Int32.Parse(s)
  //
  //printfn "Contains: %A" (contains x L)
  //printfn "Count: %A" (count x L)
  //
  printfn "Max: %A" (max L)
  //
  printfn ""
  0
