#light

module hw10

//
// nth n L
//
// Returns nth element of L
// 
// Examples: nth 0  []          => raises an exception
//           nth 2  [94]        => raises an exception
//           nth 1  [94]        => 94
//           nth -1 [94]        => raises an exception 
//           nth 2  [1; 45; 6]  => 45
// NOTE: you can solve using tail-recursion, or using
// higher-order approach.  Whatever you prefer.
// You may not call List.nth, List.Item, .[], etc directly in your solution.
// 
// 
// 
let rec nth n L =
    match n with
    |1-> List.head L
    |_-> if(n<1 || (n > (List.tail L).Length)) then raise (System.ArgumentException("Invalid n!")) 
            else nth (n-1) (List.tail L)


[<EntryPoint>]
let main argv =
    let nth2 = nth 1 [94]
    if nth2 = 94 then
        printfn "Passed!"
    else
        printfn "Failed!"
        
    let nth3 = nth 2 [1; 45; 6]
    if nth3 = 45 then
        printfn "Passed!"
    else
        printfn "Failed!"
    //let nth4 = nth -1 [94]
    //printf"%A" nth4
    //let nth5 = nth 0  [] 
    //printf"%A" nth5
    //let nth6 = nth 2 [94]
    //printf"%A" nth6
      
    0 // return an integer exit code
