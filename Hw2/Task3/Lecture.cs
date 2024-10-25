public class Lecture : Lesson
{
    public string? Topic;
    public Lecture(string? desc = null, string? topic = null) {
        Description = desc;
        Topic = topic;
    }
    public override Lesson Clone()
    {
        return new Lecture(Description, Topic);
    }

    public override string ToString()
    {
        return "Lecture: " + Description + " " + Topic;
    }
}