using AIContinuous.Nuenv;

var timeData = Space.Linear(0.0, 50.0, 11);
var massFlowData = Space.Uniform(70.0, 11);

var rocket = new Rocket(
    750.0,
    Math.PI * 0.6 * 0.6 / 4.0,
    1916.0,
    0.8,
    timeData,
    massFlowData
);

Console.WriteLine(rocket.LaunchUntilMax());

