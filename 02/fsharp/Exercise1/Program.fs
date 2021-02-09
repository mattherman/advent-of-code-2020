open System
open System.IO

type Policy = {
    Range: int * int;
    Letter: char;
}

let count x = Seq.filter ((=) x) >> Seq.length

let isValidPassword (policy, password) =
    let (min, max) = policy.Range
    password |> count policy.Letter |> (fun count -> count >= min && count <= max)

let parsePolicyAndPassword (text: string) =
    let parts = text.Split (" ")
    let [| min; max |] = parts.[0].Split ("-") |> Array.map int
    let letter = parts.[1] |> Seq.head
    let password = parts.[2]
    ({ Range = (min, max); Letter = letter }, password)

[<EntryPoint>]
let main argv =
    let input =
        File.ReadAllLines(argv.[0])
        |> Array.map parsePolicyAndPassword
    let validPasswords =
        input
        |> Array.filter isValidPassword
    Console.WriteLine(validPasswords.Length)
    0 // return an integer exit code
