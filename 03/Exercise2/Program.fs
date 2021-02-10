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

// This does not work for down values greater than 1, it results in the right values to be too large
let positions right down max =
    seq { for i in 0 .. down .. (max - 1) -> (i * right, i) }

[<EntryPoint>]
let main argv =
    let filename = argv.[0]

    let inputLines =
        System.IO.File.ReadAllLines (filename)
        |> Array.toList

    let skiMap =
        inputLines
        |> List.map generateRow

    let routes = [
        positions 1 1 skiMap.Length
        positions 3 1 skiMap.Length
        positions 5 1 skiMap.Length
        positions 7 1 skiMap.Length
        positions 1 2 skiMap.Length // This one is failing with the test data, see positions function
    ]

    let treesInRoute route =
        route
        |> Seq.map (fun (x, y) -> skiMap.[y] |> Seq.item x)
        |> Seq.fold (fun acc cell ->
            match cell with
            | Tree -> acc + 1
            | _ -> acc)
            0

    let answer =
        routes
        |> List.map (fun r ->
            let x = treesInRoute r
            Console.WriteLine(x)
            x)
        |> List.reduce (*)

    Console.WriteLine(answer)
    0 // return an integer exit code
