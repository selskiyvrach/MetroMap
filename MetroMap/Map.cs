namespace MetroMap;

internal class Map
{
    private readonly Dictionary<string, Station> _stationsByName;
    private readonly Station[] _stations;

    public Station this[string name] => _stationsByName[name];
    public Station this[int index] => _stations[index];
    public int StationsCount => _stations.Length;

    public Map(Station[] stations)
    {
        _stations = stations;
        _stationsByName = stations.ToDictionary(n => n.Name, n => n);
    }

    public bool NameExists(string stationName) => 
        _stationsByName.ContainsKey(stationName);
}