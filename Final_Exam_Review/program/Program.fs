// Learn more about F# at http://fsharp.org

open System


(*

Solution1:
    Kinda defeats purpose of higher order
let _FixScores L = List.map (fun(x)-> (100)) L 

let rec FixScores L = 
    match L with
    |[]->[]
    |hd::tl when (hd < 100) -> hd::FixScores tl
    |_::tl -> _FixScores L
    

Solution2: Higher Order
let FixScores L = List.map (fun x -> if(x > 100) then 100 else x) L


Solution3: Tail-recursive

*)
let rec _FixScores L soFar = 
    match L with
    |[]-> soFar
    |hd::tl when (hd > 100) ->_FixScores tl (100::soFar)
    |hd::tl -> _FixScores tl (hd::soFar)

let FixScores L =
   List.rev (_FixScores L []) ///Tail recursive gives ya backwards list

let even_only L = List.filter (fun x -> x%2 = 0) L
[<EntryPoint>]
let main argv =
    let L = [98;82;102;100;1;200]
    let R = FixScores L 
    let even = even_only L
    printfn"%A" R
    printfn"%A" even
    0 // return an integer exit code
