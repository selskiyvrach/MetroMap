namespace MetroMap;

internal class Stations
{
    const string RED = "Red";
    const string BLACK = "Black";
    const string GREEN = "Green";
    const string BLUE = "Blue";

    public Station[] All { get; } = new Station[]
    {
        new(Name: "A", Lines: new[] { RED }, Neighbours: new[] { "B" }),
        new(Name: "B", Lines: new[] { RED, BLACK }, Neighbours: new[] { "A", "H", "C" }),
        new(Name: "C", Lines: new[] { RED, GREEN }, Neighbours: new[] { "B", "J", "D", "K" }),
        new(Name: "D", Lines: new[] { RED, BLUE }, Neighbours: new[] { "C", "J", "E", "L", "K" }),
        new(Name: "E", Lines: new[] { RED, GREEN }, Neighbours: new[] { "D", "J", "F", "M" }),
        new(Name: "F", Lines: new[] { RED, BLACK }, Neighbours: new[] { "J", "E", "G" }),
        new(Name: "G", Lines: new[] { BLACK }, Neighbours: new[] { "F" }),
        new(Name: "H", Lines: new[] { BLACK }, Neighbours: new[] { "B", "J" }),
        new(Name: "J", Lines: new[] { BLACK, BLUE, GREEN }, Neighbours: new[] { "H", "C", "D", "E", "O" }),
        new(Name: "K", Lines: new[] { GREEN }, Neighbours: new[] { "C", "L" }),
        new(Name: "L", Lines: new[] { GREEN, BLUE }, Neighbours: new[] { "K", "D", "M", "N" }),
        new(Name: "M", Lines: new[] { GREEN }, Neighbours: new[] { "L", "E" }),
        new(Name: "N", Lines: new[] { BLUE }, Neighbours: new[] { "L" }),
        new(Name: "O", Lines: new[] { BLUE }, Neighbours: new[] { "J" }),
    };
}