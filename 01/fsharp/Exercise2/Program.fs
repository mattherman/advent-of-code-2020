open System
open System.IO

let toTriples listToPair =
    let rec triples pairingElement listToPair =
        let newPairs = listToPair |> List.map (fun element -> (pairingElement, element))
        match listToPair with
        | newPairingElement::remainingListToPair -> List.append newPairs (triples newPairingElement remainingListToPair)
        | _ -> newPairs

    match listToPair with
    | pairingElement::listToPair -> triples pairingElement listToPair
    | _ -> []

[<EntryPoint>]
let main argv =
    let entries =
        File.ReadAllLines(argv.[0])
        |> Array.map int
        |> Array.toList
    let answer = 
        entries
        |> toTriples
        |> List.find (fun (a, b) -> a + b = 2020)
        |> fun (a, b) -> a * b
    Console.WriteLine (answer)
    0 // return an integer exit code
