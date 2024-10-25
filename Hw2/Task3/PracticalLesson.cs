public class PracticalLesson : Lesson
{
    public string? TaskCondidionLink;
    public string? SolutionLink;

    public PracticalLesson(string? desc = null, string? condLink = null, string? solLink = null) {
        Description = desc;
        TaskCondidionLink = condLink;
        SolutionLink = solLink;
    }

    public override Lesson Clone()
    {
        return new PracticalLesson(Description, TaskCondidionLink, SolutionLink);
    }

    public override string ToString()
    {
        return "Practical lesson: " + Description + " " + TaskCondidionLink + " " + SolutionLink;
    }
}