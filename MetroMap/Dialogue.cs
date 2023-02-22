namespace MetroMap;

internal class Dialogue
{
    private readonly Navigator _navigator;

    public Dialogue(Navigator navigator) => 
        _navigator = navigator;

    internal void Start()
    {
        Console.WriteLine("Welcome to the metro map application, citizen!");
        while (true)
        {
            var departure = GetStationNameInput(stationDescription: "departure");
            var destination = GetStationNameInput(stationDescription: "destination");
            var route = _navigator.FindRoute(departure, destination);
            Console.WriteLine("Your route is: {0}", route);
        }
    }

    private string GetStationNameInput(string stationDescription)
    {
        while (true)
        {
            Console.WriteLine("Please enter {0} station name", stationDescription);
            var input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input) && _navigator.StationNameValid(input))
                return input;
            Console.WriteLine("Station name is invalid!");
        }
    }
}