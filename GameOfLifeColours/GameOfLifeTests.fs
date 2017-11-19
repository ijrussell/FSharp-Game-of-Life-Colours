module GameOfLifeTests

open FsUnit
open NUnit.Framework
open GameOfLife

[<Test>]
let ``Validate except for Red`` () = 
    let input = [Colour.Yellow; Colour.Blue; Colour.Green]
    getMissingColour input
    |> should equal Colour.Red

[<Test>]
let ``Validate except for Blue`` () = 
    let input = [Colour.Yellow; Colour.Green; Colour.Red]
    getMissingColour input
    |> should equal Colour.Blue

[<Test>]
let ``Validate except for Green`` () = 
    let input = [Colour.Red; Colour.Yellow; Colour.Blue]
    getMissingColour input
    |> should equal Colour.Green

[<Test>]
let ``Validate except for Yellow`` () = 
    let input = [Colour.Blue; Colour.Red; Colour.Green]
    getMissingColour input
    |> should equal Colour.Yellow
    
[<Test>]
let ``Validate biggest for same colour`` () = 
    let input = [Colour.Blue; Colour.Blue; Colour.Blue]
    getColour input
    |> should equal Colour.Blue
    
[<Test>]
let ``Validate biggest for not same colour`` () = 
    let input = [Colour.Blue; Colour.Red; Colour.Blue]
    getColour input
    |> should equal Colour.Blue
