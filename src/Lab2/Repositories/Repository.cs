namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories;

public class Repository<T> where T : IIdentify
{
    private ICollection<T> _objects;

    public Repository(ICollection<T> objects)
    {
        Objects = objects;
        _objects = Objects;
    }

    public ICollection<T> Objects
    {
        get => _objects;
        private set
        {
            ArgumentNullException.ThrowIfNull(value);
            _objects = value;
        }
    }

    public void Add(T myObject)
    {
        _objects.Add(myObject);
    }

    public T Get(Guid objectId)
    {
        if (_objects is null)
        {
            throw new InvalidOperationException("The object list is empty.");
        }

        foreach (T myObject in _objects)
        {
            if (myObject.Id == objectId)
            {
                return myObject;
            }
        }

        throw new ArgumentException("No lab work found with this id");
    }

    public void Remove(Guid objectId)
    {
        foreach (T myObject in _objects)
        {
            if (myObject.Id == objectId)
            {
                _objects.Remove(myObject);
                return;
            }
        }
    }
}