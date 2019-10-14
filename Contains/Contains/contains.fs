


#light
[<EntryPoint>]
let main argv = 
    let L = [59;79;82;42]
    let element = 42
    let rec contains x L =
        match L with
        | [] -> false
        | e::rest when e=x -> true
        | e::rest -> contains x rest

    printfn "%A" (contains element L)
    0
  