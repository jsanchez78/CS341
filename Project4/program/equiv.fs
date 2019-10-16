// Learn more about F# at http://fsharp.org

open System

//Cover false cases
let rec equiv L1 L2 = 
    match L1, L2 with
    | [], [] -> true
    | [], e2 -> false
    | e1, [] -> false
    | e1::rest1, e2::rest2 when e1=e2 -> equiv rest1 rest2
    
[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"
    let list1 = [1;2;3]
    let list2 = [1;2;4]
    let ans = equiv list1 list2
    printf"%b" ans
    0 // return an integer exit code

