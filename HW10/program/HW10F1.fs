#light

module hw10

//Multiply two list function
let multiply L1 L2 = 
    List.map2 (fun x y -> x*y) L1 L2

[<EntryPoint>]
let main argv =
    let result = multiply [7;2;9;4] [3;1;0;2]
    printfn"%A" result
    0 // return an integer exit code    