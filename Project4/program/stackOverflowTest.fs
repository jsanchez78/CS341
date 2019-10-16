#light

//
// generate a random list of length N:
//
let ran = new System.Random(12345)
let genlist N = 
  List.init N (fun i -> ran.Next(0,1000))


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


[<EntryPoint>]
let main argv =
  //let N = 5000
  //let L = genlist N
  //
  let L = [22; 19; 88; 4; 22; 11; 0; 22]
  printfn "List: %A" L
  //
  printf "Enter an integer> "
  let s = System.Console.ReadLine()
  let x = System.Int32.Parse(s)
  //
  printfn "Contains: %A" (contains x L)
  printfn "Count:    %A" (count x L)
  //
  0
