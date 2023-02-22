namespace MetroMap;

internal class Navigator
{
    private readonly Map _map;
    private readonly Dictionary<Station, int> _distances;
    private readonly Dictionary<Station, Station?> _previousStations;
    private readonly PriorityQueue<Station, int> _visitingQueue;
    
    public Navigator(Map map)
    {
        _map = map;
        var numberOfStations = _map.StationsCount;
        _distances = new Dictionary<Station, int>(numberOfStations);
        _previousStations = new Dictionary<Station, Station?>(numberOfStations);
        _visitingQueue = new PriorityQueue<Station, int>(numberOfStations);
        Reset();
    }

    public Route FindRoute(string startStationName, string targetStationName)
    {
        var startStation = _map[startStationName];
        var targetStation = _map[targetStationName];
        _distances[startStation] = 0;
        _visitingQueue.Enqueue(startStation, 0);
        
        while (_visitingQueue.Count > 0)
        {
            var currentStation = _visitingQueue.Dequeue();

            if (currentStation == targetStation)
                break;

            CheckNeighbours(currentStation);
        }
        
        var path = CreatePath(targetStation);
        Reset();
        return new Route(path);
    }

    private void CheckNeighbours(Station currentStation)
    {
        foreach (var neighborName in currentStation.Neighbours)
        {
            var neighbor = _map[neighborName];
            var newDistance = _distances[currentStation] + 1;

            if (newDistance >= _distances[neighbor])
                continue;
            _distances[neighbor] = newDistance;
            _previousStations[neighbor] = currentStation;
            _visitingQueue.Enqueue(neighbor, newDistance);
        }
    }

    private Stack<Station> CreatePath(Station targetStation)
    {
        var path = new Stack<Station>();
        var currentNode = targetStation;

        while (currentNode is not null)
        {
            path.Push(currentNode);
            currentNode = _previousStations[currentNode];
        }

        return path;
    }

    private void Reset()
    {
        for (int i = 0; i < _map.StationsCount; i++)
        {
            _distances[_map[i]] = int.MaxValue;
            _previousStations[_map[i]] = null;
        }
        _visitingQueue.Clear();
    }

    public bool StationNameValid(string stationName) => 
        _map.NameExists(stationName);
}