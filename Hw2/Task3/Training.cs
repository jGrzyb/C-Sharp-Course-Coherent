public class Training : AbstractCoherentEntity
{
    private Lesson[] Entities = [];

    public Training(string? desc, Lesson[] lessons) 
    {
        Description = desc;
        Entities = lessons;
    }

    public Training(Lesson[] lessons) 
    {
        Entities = lessons;
    }

    public bool IsPractical() 
    {
        return Entities.All(x => x is PracticalLesson);
    }

    public Training Clone() 
    {
        Lesson[] newEntities = Entities.Select(x => x.Clone()).ToArray();
        return new Training(Description, newEntities);
    }

    public override string ToString()
    {
        return Description + "\n" + string.Join("\n", Entities.Select(x => x.ToString())) + "\n";
    }

    public Training Add(Lesson entity)
    {
        Entities = Entities.Concat([entity]).ToArray();
        return this;
    }
}