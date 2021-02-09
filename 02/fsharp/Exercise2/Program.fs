open System
open System.IO

type Policy = {
    ValidPositions: int * int;
    Letter: char;
}

let isValidPassword (policy, password: string) =
    let (firstPosition, secondPosition) = policy.ValidPositions
    (password.[firstPosition - 1] = policy.Letter) <> (password.[secondPosition - 1] = policy.Letter)

let parsePolicyAndPassword (text: string) =
    let parts = text.Split (" ")
    let [| firstPosition; secondPosition |] = parts.[0].Split ("-") |> Array.map int
    let letter = parts.[1] |> Seq.head
    let password = parts.[2]
    ({ ValidPositions = (firstPosition, secondPosition); Letter = letter }, password)

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
