public class Training
{
    public string? Description;
    public AbstractCoherentEntity[] Entities = [];

    public bool IsPractical() 
    {
        return Entities.All(x => x is PracticalLesson);
    }

    public Training Clone() 
    {
        Training newTraining = new();
        newTraining.Description = Description;
        newTraining.Entities = new AbstractCoherentEntity[Entities.Length];
        for(int i=0; i<Entities.Length; i++) 
        {
            if(Entities[i] is Lecture lecture) 
            {
                Lecture newLecture = new Lecture();
                newLecture.Topic = lecture.Topic;
                newTraining.Entities[i] = newLecture;
            }
            else if(Entities[i] is PracticalLesson practicalLesson) 
            {
                PracticalLesson newLesson = new PracticalLesson();
                newLesson.SolutionLink = practicalLesson.SolutionLink;
                newLesson.TaskCondidionLink = practicalLesson.TaskCondidionLink;
                newTraining.Entities[i] = newLesson;
            }
        }
        return newTraining;
    }

    public override string ToString()
    {
        string result = Description + "\n";
        foreach(var e in Entities) 
        {
            if(e is Lecture lecture) 
            {
                result += "Lecture: " + lecture.Topic + lecture.Description + "\n";
            }
            else if(e is PracticalLesson ps) 
            {
                result += "Practical lesson: " + ps.Description + " " + ps.SolutionLink + " " + ps.TaskCondidionLink + "\n";
            }
        }
        return result;
    }
}

public static class TrainingExtension
{
    public static Training Add(this Training training, AbstractCoherentEntity entity)
    {
        training.Entities = training.Entities.Concat([entity]).ToArray();
        return training;
    }
}