namespace Scenarios;

public class AllScenarios
{
    private readonly List<IScenario> _scenarios;

    public AllScenarios(IEnumerable<IScenario> scenarios)
    {
        _scenarios = scenarios.ToList();
    }

    public IEnumerable<IScenario> Scenarios => _scenarios;

    public void AddScenario(IScenario scenario)
    {
        _scenarios.Add(scenario);
    }
}