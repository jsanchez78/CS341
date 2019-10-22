#light

let rec equivalent L1 L2 =
    match L1, L2 with
    | [], [] -> true
    | _, [] -> false
    | [], _ -> false
    | e1::rest1, e2::rest2 -> (e1=e2) && equivalent rest1 rest2   // Uses boolean short circuiting to avoid recursion once different value is found
    //| e1::rest1, e2::rest2 -> if(e1=e2) then equivalent rest1 rest2 else false  // OK
    //| e1::rest1, e2::rest2 when e1 = e2 -> equivalent rest1 rest2  // nicer
    //| _, _ -> false // don't forget the default case if you are using pattern matching to check for equality
    //| e1::rest1, e2::rest2 -> if(e1 = e2) then true else false // Only checks first element
    //| e1::rest1, e2::rest2 -> equivalent rest1 rest2 //Only checks length, doesn't check elements
    //| e1::rest1, e1::rest2 -> equivalent rest1 rest2  // fails due to double binding
    //| _, _ -> false



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
  | _::rest          -> //let result = (contains x rest)
                        (contains x rest)

                        //#define result = (contains x rest)
let rec count x L = 
  match L with
  | []               -> 0
  | e::rest -> if(e=x) then 1 + (count x rest) else (count x rest)
  //| e::rest when e=x -> 1 + (count x rest)
  //| _::rest          -> (count x rest)


[<EntryPoint>]
let main argv =
  //let L1 = [27; 78; 15]
  //let LA = [27; 78]
  //let L2 = ["cat"; "dog"]
  //let LB = ["cat"; "dog"]
  //printfn "%A" (equivalent L1 LA)
  //printfn "%A" (equivalent L2 LB)








  //let L3 = ["mouse"; "elephant"]
  //printfn "%A" (equivalent L3 LB)





  
  let N = 5000000
  let L1 = genlist N
  let L = L1 @ [15000]
  //
  //let L = [22; 19; 88; 4; 22; 11; 0; 22]
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
