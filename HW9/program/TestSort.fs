#light

//
// generate a random list of length N:
//
let ran = new System.Random(12345)

let genlist N = 
  List.init N (fun i -> ran.Next())


//
// printf 1 element:
//
let printf1(a) = 
  printf "%A; " a

//
// printfn a list: if the list is long, we print first 3 ... last 3:
//
let doprintFirst3(L) = 
  printf "%A; %A; %A;" (List.item 0 L) (List.item 1 L) (List.item 2 L)
  
let doprintLast3(L)= 
  let len = List.length L
  printf "%A; %A; %A;" (List.item (len-3) L) (List.item (len-2) L) (List.item (len-1) L)

let doprint(L) = 
  if List.length L < 10 then
    ignore (List.map printf1 L)
  else
    doprintFirst3 L
    printf " ...; "
    doprintLast3 L

let printfnList(L) = 
  printf "%A: " (List.length L)
  printf "[ "
  doprint L
  printfn " ]"


//
// runit function: times the application of function F to list L, 
// outputting the result of F(L)
//
let runit(message, F, L) = 
  let stopwatch = System.Diagnostics.Stopwatch.StartNew()
  let result = F(L)
  stopwatch.Stop()
  let timeMS = stopwatch.Elapsed.TotalMilliseconds
  printfn ""
  printfn "%A: %A elements, time %A ms" message (List.length L) timeMS
  printf  " "
  printfnList(result)


//TAIL RECURSIVE MAX

let rec _max maxSoFar L = 
    match L with
    |[]->maxSoFar
    |hd::tl when hd > maxSoFar-> _max hd tl
    |hd::tl -> _max maxSoFar tl

let max L = 
    match L with
    |[]->raise(System.ArgumentException("L cannot be empty"))
    |hd::tl -> _max hd tl

//
// quicksort:
//
//let rec _quicksort L depth =
//  printf "%A " depth
//  match L with 
//  | []        -> []
//  | e::[]     -> [e]
//  | pivot::tl -> let (LTE, GT) = List.partition (fun x -> x <= pivot) tl
//                 (_quicksort LTE (depth+1)) @ [pivot] @ (_quicksort GT (depth+1))

//let quicksort L = 
//  _quicksort L 1


let rec quicksort L = 
  match L with 
  | []        -> []
  | e::[]     -> [e]
  | pivot::tl -> let (LTE, GT) = List.partition (fun x -> x <= pivot) tl
                 (quicksort LTE) @ [pivot] @ (quicksort GT)





//
// Main:
//
[<EntryPoint>]
let main agrv = 
  printfn ""
  printfn "** List.sort vs. Quicksort **"
  printfn ""
  let N = 1000
  let L = genlist N
  //let L = [1..N]

  printfnList L

  printfn ""
  printfn ""

  runit("List.sort", List.sort, L)

  printfn ""
  printfn ""

  runit("quicksort", quicksort, L)


  //
  // done:
  //
  printfn ""
  printfn ""
  printfn ""
  printfn "** done **"
  //let ignore = System.Console.ReadKey true
  0