#light

module hw10

//
// max L
//
// Returns maximum element of L
// 
// Examples: max []          => raises an exception (Unhandled Exception: System.ArgumentException: The input sequence was empty.)
//           max [-2; 4]     => 4
//           max [34]        => 34
//           max [10; 10; 9] => 10
// 
// NOTE: you can solve using tail-recursion, or using
// higher-order approach.  Whatever you prefer.
// You may not call List.max directly in your solution.
// 
// 
// 

let rec _max L soFar = 
    match L with
    |[]-> soFar
    |hd::tl when (hd > soFar) -> _max tl hd
    |hd::tl -> _max tl soFar

let rec max L =
    _max L 0

[<EntryPoint>]
let main argv =
    let max2 = max [-2; 4]
    if max2 = 4 then
        printfn "Passed!"
    else
        printfn "Failed!"
        
    let max3 = max [34]
    if max3 = 34 then
        printfn "Passed!"
    else
        printfn "Failed!"
        
    let max4 = max [10; 10; 9]
    if max4 = 10 then
        printfn "Passed!"
    else
        printfn "Failed!"     
    0 // return an integer exit code
