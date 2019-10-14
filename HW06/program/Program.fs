// Learn more about F# at http://fsharp.org

open System

[<EntryPoint>]
let main argv =
    printf "filename> "
    let filename  = System.Console.ReadLine()
    let data_array = System.IO.File.ReadAllLines(filename)
    let data_list = Array.toList data_array
     //
     // convert strings to integers:
     //
    let values = List.map (fun s -> int s) data_list
    printfn "%A" values
     //
     //Recursive call to legnth function using tail method
    let rec length list = 
       match list with
         | [] -> 0
         | _ :: tail -> 1 + length tail

    let len = length values
    printfn "%A" len
     //Recursive sum list
    let rec sum list = 
        match list with
            | [] -> 0
            | curr :: new_value -> curr + sum new_value
            //| curr:: tail -> curr + sum tail
    let total = sum values
    printfn "%A" total
     //
    0 // return an integer exit code
