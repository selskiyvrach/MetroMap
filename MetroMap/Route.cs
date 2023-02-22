using System.Text;

namespace MetroMap;

internal class Route
{
    private readonly Station[] _stations;

    public Route(IEnumerable<Station> stations) => 
        _stations = stations.ToArray();


    public override string ToString()
    {
        var stringBuilder = new StringBuilder();
        WriteRouteDown(stringBuilder);
        return stringBuilder.ToString();
    }

    private void WriteRouteDown(StringBuilder stringBuilder)
    {
        const string ARROW = " -> ";
        var lineChanges = 0;
        var lastLine = default(string);
        var lastStation = default(Station);

        for (var i = 0; i < _stations.Length; i++)
        {
            var currentStation = _stations[i];
            CheckForLineChanges(currentStation, ref lastStation, ref lastLine, ref lineChanges);

            stringBuilder.Append(currentStation.Name);

            if (i < _stations.Length - 1)
                stringBuilder.Append(ARROW);
            else
                stringBuilder.Append($"\n Including line changes: {lineChanges}");
        }
    }

    private void CheckForLineChanges(Station currentStation, ref Station? lastStation, ref string? lastLine, ref int lineChanges)
    {
        if (lastStation != null)
        {
            var currentLine = currentStation.Lines.Intersect(lastStation.Lines).First();
            if (lastLine != default && currentLine != lastLine)
                lineChanges++;
            lastLine = currentLine;
        }

        lastStation = currentStation;
    }
}