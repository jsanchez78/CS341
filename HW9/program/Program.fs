#light

module hw09
//
// superset S L
//
// Returns true if L is a superset of S, false if not.
// 
// Examples: superset [3; 1; 2] [1; 4; 2; 0; 3] => true
//           superset [1; 4; 2; 0; 3] [3; 1; 2] => false
//           superset [2; 1; 3] [1; 4; 0; 2; 8] => false
//           superset [] []                     => true
//           superset [] [1; 2; 3]              => true
//           superset [1..1000] [1..1000]       => true
// 
// NOTE: you can solve using tail-recursion, or using
// higher-order approach.  Whatever you prefer.  Beware
// that List.length is an O(N) operation, it actually
// traverses the list and counts the elements.
// 
// HINT: there are a variety of solutions.  One idea
// is write a helper function "contains e L" that 
// returns true if e is an element of L, and false 
// if not.  Then build on that to define superset.  This
// leads to an O(N^2) solution, which is fine.
// 

let rec contains x L = 
  match L with
  | []               -> false
  | e::_    when e=x -> true
  | _::rest          -> (contains x rest)

let rec superset S L = 
    match S with
    |[] -> true
    |e1::rest1 when contains e1 L=false -> false
    |e1::rest1 when contains e1 L=true -> superset rest1 L  //Elements match thus far
    |_::tl -> superset tl L



//
// remove e L
//
// Removes all occurrences of e from the list L, 
// returning the new list.
//
// Examples: remove 3  [3; 1; 2]   => [1; 2]
//           remove 99 [99; 0; 99] => [0]
//           remove -2 []          => []
//           remove "cat" ["dog"]  => ["dog"]
//           remove 99999 [1..99999] => [1..99998]
// 
// NOTE: write a tail-recursive version using a helper
// function; do not change the API of the original 
// remove function.  You'll also need to build the new
// list efficiently; you can use List.rev if need be.
//
let rec _remove x L new_list =
    match L with 
    |[]-> List.rev new_list
    |hd::tl when hd<>x -> _remove x tl (hd::new_list)
    |hd::tl -> _remove x tl new_list

let rec remove x L = 
    match L with
    |hd::tl when hd=x -> _remove x tl []
    |hd::tl -> _remove x tl [hd]
    |[]->[]
   
//
// remove e L
//
// Removes all occurrences of e from the list L, 
// returning the new list.
//
// Examples: remove 3  [3; 1; 2]   => [1; 2]
//           remove 99 [99; 0; 99] => [0]
//           remove -2 []          => []
//           remove "cat" ["dog"]  => ["dog"]
//           remove 99999 [1..99999] => [1..99998]
// 
// NOTE: write this using a higher-order approach.
//
let remove2 e L = L |> List.filter ((<>) e)


//
// mergesort L
//
// Sorts the given list using mergesort algorithm.
//
// Examples: mergesort [10; 9; 1; 0; 88; 2] => [0; 1; 2; 9; 10; 88]
// 
// NOTE: the code is given below, your task is to rewrite the
// merge function to be both safe (i.e. tail-recursive) and
// efficient.  You may use List.rev if need be, but no other
// List. functions may be used.
//
(*
let splitAt n L =
  let rec splitUtil n L acc =
     match L with
     | []           -> List.rev acc, []
     | _ when n = 0 -> List.rev acc, L
     | x::tl        -> splitUtil (n-1) tl (x::acc)
  splitUtil n L []
  
let rec merge L1 L2 = 
  match L1, L2 with
  | [], [] -> []
  | [], _  -> L2
  | _,  [] -> L1
  | hd1::tl1, hd2::tl2 when hd1 <= hd2 -> hd1 :: merge tl1 L2
  | hd1::tl1, hd2::tl2                 -> hd2 :: merge L1 tl2

let rec mergesort L = 
  match L with
  | []         -> []
  | e::[]      -> [e]
  | e1::e2::[] -> if e1<=e2 then [e1;e2] else [e2;e1]
  | _          -> let mid = List.length L / 2
                  let (L1, L2) = splitAt mid L
                  merge (mergesort L1) (mergesort L2)
*)
[<EntryPoint>]
let main argv =
    //

    let s1 = [3; 1; 2]
    let s2 = [1; 4; 2; 0; 3]
    let b = superset s1 s2

    let test = [99; 0; 99]
    let e = 99
    let e2 = 99999
    let test2 = [1;2;3;4;99999]
    let remove_test = remove e test
    let remove_test2 = remove2 e2 test2
    printfn"%A" b
    printfn"%A" remove_test
    printfn"%A" remove_test2
    0//