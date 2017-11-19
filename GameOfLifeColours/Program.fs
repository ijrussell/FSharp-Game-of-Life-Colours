open System
open GameOfLife

let convertToConsoleColour colour =
    match colour with
    | Colour.Red -> ConsoleColor.Red
    | Colour.Blue -> ConsoleColor.Blue
    | Colour.Green -> ConsoleColor.Green
    | Colour.Yellow -> ConsoleColor.Yellow
    | _ -> ConsoleColor.Black

let printCell x y state =
    if (state <> Colour.Black) then
        System.Console.SetCursorPosition(x, y)
        System.Console.ForegroundColor <- convertToConsoleColour state
        System.Console.Write("#")

let printBoard board =
    System.Console.Clear()
    board
    |> Array2D.iteri (fun x y v -> printCell x y v)

let rec playGame (board:Colour[,]) =
    printBoard board
    System.Threading.Thread.Sleep(100)
    tick board 
    |> playGame

let rand = new System.Random()

let rndAlive = seq { while true do yield rand.Next(2) }
let rndColour = seq { while true do yield rand.Next(1, 5) }

let getRandomList rndSeq size = 
    rndSeq
    |> Seq.truncate (size*size)
    |> Seq.toList

let getRandomColour x y size =
    let i = x * (size-1) + y
    let isAlive = (getRandomList rndAlive size).[i]
    match isAlive with
    | 1 ->
        let col = (getRandomList rndColour size).[i]
        match col with
        | 1 -> Colour.Red
        | 2 -> Colour.Blue
        | 3 -> Colour.Green
        | 4 -> Colour.Yellow
        | _ -> Colour.Black
    | _ -> Colour.Black

let initialBoard size = 
    Array2D.init size size (fun x y -> getRandomColour x y size)

[<EntryPoint>]
let main argv = 
    playGame (initialBoard 30)
    0 // return an integer exit code
