open System

module Seq =
    let rec repeat xs = seq { 
        yield! xs
        yield! repeat xs
    }

type Cell =
    | Tree
    | Empty

let generateRow text =
    let charToPosition c =
        match c with
        | '#' -> Tree
        | _ -> Empty

    text
    |> Seq.map charToPosition
    |> Seq.repeat

let positions right down max =
    seq { for i in 0 .. down .. (max - 1) -> (i * right, i)}

[<EntryPoint>]
let main argv =
    let filename = argv.[0]

    let inputLines =
        System.IO.File.ReadAllLines (filename)
        |> Array.toList

    let skiMap =
        inputLines
        |> List.map generateRow

    let route = positions 3 1 skiMap.Length

    let treesInRoute =
        route
        |> Seq.map (fun (x, y) -> skiMap.[y] |> Seq.item x)
        |> Seq.fold (fun acc cell ->
            match cell with
            | Tree -> acc + 1
            | _ -> acc)
            0
    
    Console.WriteLine(treesInRoute)
    0 // return an integer exit code
