public abstract class Lesson
{
    public string? Description;

    public Lesson() {}
    public Lesson(string s) 
    {
        Description = s;
    }
    public abstract Lesson Clone();
}