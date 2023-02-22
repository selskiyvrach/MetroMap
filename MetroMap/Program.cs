using MetroMap;

var stations = new Stations().All;
var map = new Map(stations);
var navigator = new Navigator(map);
var dialogue = new Dialogue(navigator);
dialogue.Start();