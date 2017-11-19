module GameOfLife

    type Colour =
        | Black
        | Red
        | Blue
        | Green
        | Yellow

    let getMissingColour neighbours =
        let alive = [Colour.Red; Colour.Blue; Colour.Green; Colour.Yellow]
        Set.difference (Set.ofList alive) (Set.ofList neighbours)
        |> Set.toList
        |> List.head

    let getMostPopularColour neighbours =
        neighbours
        |> List.countBy (fun colour -> colour)
        |> List.sortBy (fun (_, v) -> -v) // sort descending
        |> List.head

    let getColour neighbours =
        let colour, _ = getMostPopularColour neighbours
        colour

    let calculateColour neighbours =
        let distinct = neighbours |> List.distinct
        match neighbours.Length, distinct.Length with
        | 3, 3 -> getMissingColour neighbours // 3 neighbours of different colour
        | _, _ -> getColour neighbours

    let isAlive (neighbours:Colour list) state =
        match neighbours.Length, state with
        | 3, Colour.Black -> calculateColour neighbours
        | 3, _ | 2, _ -> state
        | _, _ -> Colour.Black
    
    let notSourceCell x y x' y' =
        not (x = x' && y = y')

    let inBounds x y size =
        x >= 0 && x < size && y >= 0 && y < size
    
    let neighbourCount x y (board:Colour[,]) =
        [ for dx in -1 .. +1 do
            for dy in -1 .. +1 do
                let m, n = x + dx, y + dy
                if (notSourceCell x y m n) && (inBounds m n (board.GetLength 0) ) then
                    yield board.[m, n] ]
        |> List.filter (fun x -> x <> Colour.Black)

    let tick board =
        board
        |> Array2D.mapi (fun x y v -> isAlive (neighbourCount x y board) v)

