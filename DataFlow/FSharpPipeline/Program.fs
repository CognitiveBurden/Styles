// Learn more about F# at http://fsharp.net
// See the 'F# Tutorial' project for more help.
open System
open System.IO

let readLines (filePath:string) = seq {
    use sr = new StreamReader (filePath)
    while not sr.EndOfStream do
        yield sr.ReadLine ()
}

let shiftWords (words:string[]) = seq {
    if words.Length <= 1 then yield words.[0]
    else
        let firstWord = words.[1]
        yield firstWord
        let upperBound = words.GetUpperBound(0) 
        for i = 2 to upperBound do
            yield words.[i]
        yield words.[0]
    }


let shiftLine (item:string) = seq {
    let words = ref (item.Split([|' '|]))
    let upperBound = words.contents.GetUpperBound(0)
    for i = 0 to upperBound do
        yield String.Join(" ", !words)
        let newWords = shiftWords !words
        let newWordsArray = newWords |> Seq.toArray 
        words := newWordsArray 
    }


let circularShift lines = seq {
    for (item:string) in lines do
        let shifts = item |> shiftLine
        for shift in shifts -> shift
        }


[<EntryPoint>]
let main argv =
    let lines = readLines  @"data\TestData.txt"
    lines
    |> circularShift
    |> Seq.sortBy(fun x -> x)
    |> Seq.iter(fun x -> printfn  "%s" x)   

    printfn "Press any key to continue"
    Console.ReadKey() |> ignore
    0 // return an integer exit code
