#light

module hw10

//Multiply two list function
let multiply L1 L2 = 
    List.map2 (fun x y -> x*y) L1 L2
//tail recursive version
let rec multiply_tailR L1 L2 product = 
    match L1,L2 with
    |[],[] -> product
    |hd::tl,hd2::tl2 -> List.rev (multiply_tailR tl tl2 ((hd*hd2)::product))
    |_,_->[]

let rec mult L1 L2 = 
    multiply_tailR L1 L2 []
///every_other [1;7;4;3] ----> [1;4]
let rec _every_other L result=
    match L with 
    |[]->result
    |hd::b::tl-> hd:: _every_other tl result
    //|hd::tl -> hd::result
    | _ -> (List.head L) :: result
    
let rec every_other L =
    _every_other L []


//Compute as you return count
let rec count x L = 
    match L with 
    |[]->0
    |hd::tl when hd=x -> 1 + count x tl
    |_::tl -> 0 + count x tl
//tail-recursive count
let rec _count x L soFar = 
    match L with 
    |[]->soFar
    |hd::tl when hd=x -> _count x tl (soFar+1)
    |_::tl -> _count x tl soFar
let rec countTR x L =
    _count x L 0
//tail-recursive contains function
let rec contains x L =
    match L with
    |[]->false
    |hd::tl when hd=x -> true
    |_::tl -> contains x tl  ///Otherwise opposite of true so TRY AGAIN
//Compute as you return scalar multiply
//ScalarMultiply [1;3;2]10 -> [10;30;20]
let rec ScalarMultiply L x = 
    match L with 
    |[]->[]
    |hd::tl -> (hd*x)::ScalarMultiply tl x
//Tail-recursive scalar multiply
//ScalarMultiply [1;3;2]10 -> [10;30;20]
let rec _ScalarMultiplyR L x soFar =
    match L with
    |[]->soFar
    |hd::tl -> List.rev (_ScalarMultiplyR tl x (hd*x :: soFar)) 

let rec ScalarMultiplyR L x =
    _ScalarMultiplyR L x []

//Higher order 
//ScalarMultiply [1;3;2]10 -> [10;30;20]

let ScalarMultiplyHigherOrder L x = List.map (fun a -> x*a) L

//Max function (non tail)
let rec maxR L =
    match L with 
    |[]-> raise (System.InvalidOperationException("Empty list"))
    |[e]->e
    |hd::tl-> let maxRest = (maxR tl)
              if (maxRest > hd) then maxRest  else hd

//Map 
let rec mapR F L =
    match L with 
    |[]->[]
    |hd::tl -> (F hd) :: mapR F tl


//reduceR
let rec reduceR F L = 
    match L with
    |[]-> raise (System.InvalidOperationException("Nothing to reduce"))
    |[e]->e
    |hd::tl-> (F hd (reduceR F tl))
//fold (tail recursive)
let rec foldR F start L =
    match L with
    |[]->start //No exception
    |hd::tl -> let result = (F start hd)
               foldR F result tl
//ApplyF
//Tail recursive!
let rec applyR F L =                          
    match L with
    |[]->()//Returns a unit
    |hd::tl->(F hd)
              (applyR F tl)//Peroform as you go


let rec flattenR  (L: 'a list list) =
    match L with 
    |[]->[]
    |hd::tl -> hd @ (flattenR tl)
[<EntryPoint>]
let main argv =
    let result = multiply [7;2;9;4] [3;1;0;2]
    printfn"%A" result
    let result2 = mult [7;2;9;4] [3;1;0;2]
    printfn"%A" result2
    let test = every_other [1;7;4;3]
    printfn"%A" test
    let test2 = every_other [1;7;4;3;0]
    printfn"%A" test2
    let test3 = every_other [1]
    printfn"%A" test3
    let test4 = every_other [1;7]
    printfn"%A" test4
    let test5 = every_other []
    printfn"%A" test5
    let test6 = every_other [1;2;3;1;7;4;3;0]
    printfn"%A" test6
    let count_as_return = count 2 [2;2;2;2;2;2;22;2;2;2;2;2;2;2]
    printfn"%A" count_as_return
    let mult_test = ScalarMultiply [1;3;2]10
    printfn"%A" mult_test
    let contains_test = contains 22 [2;2;2;2;2;2;22;2;2;2;2;2;2;2]
    printfn"%A" contains_test
    let counttail = countTR 2 [2;2;2;2;2;2;22;2;2;2;2;2;2;2]
    printfn"%A" counttail
    let mult_testTR = ScalarMultiplyR [1;3;2]10
    printfn"%A" mult_testTR
    let higherOrderMult = ScalarMultiplyHigherOrder [1;3;2]10
    printfn"%A" higherOrderMult
    let max = maxR [2;2;2;2;2;2;22;2;2;2;2;2;2;2]
    printfn"%A" max
    let test_map = mapR (fun x -> x*2) [2;2;2;2;2;2;22;2;2;2;2;2;2;2]
    printfn"%A" test_map
    let test_reduce = reduceR (fun x y -> x*y) [2;2;2;2;2;2;22;2;2;2;2;2;2;2]
    printfn"%A" test_reduce
    let test_fold = foldR (fun x y -> (x+y)) (2) [2;2;2;2;2;2;22;2;2;2;2;2;2;2]
    printfn"%A" test_fold
    let flatten_test = flattenR [[1,-1];[2,2]]
    printfn"%A" flatten_test

    0 // return an integer exit code    
