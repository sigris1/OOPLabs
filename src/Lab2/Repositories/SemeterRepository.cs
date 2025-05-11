using Itmo.ObjectOrientedProgramming.Lab2.ProgramParts;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories;

public class SemeterRepository : Repository<Semester>
{
    private SemeterRepository() : base([])
    {
    }

    private static readonly Lazy<SemeterRepository> _instance =
        new Lazy<SemeterRepository>(() => new SemeterRepository(), LazyThreadSafetyMode.ExecutionAndPublication);

    public static SemeterRepository Instance => _instance.Value;
}