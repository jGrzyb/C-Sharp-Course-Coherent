PracticalLesson ps0 = new PracticalLesson();
PracticalLesson ps1 = new PracticalLesson();
PracticalLesson ps2 = new PracticalLesson();

ps0.SolutionLink = "ps0s";
ps0.TaskCondidionLink = "ps0t";
ps0.Description = "ps0d";
ps1.SolutionLink = "ps1s";
ps1.TaskCondidionLink = "ps1t";
ps1.Description = "ps1d";
ps2.SolutionLink = "ps2s";
ps2.TaskCondidionLink = "ps2t";
ps2.Description = "ps2d";

Training training = new Training();
training.Description = "t0desc";
training.Entities = [ps0, ps1, ps2];

Console.WriteLine(training.IsPractical());

Lecture l0 = new Lecture();
l0.Topic = "l0t";
training.Add(l0);

Console.WriteLine(training);

Training newTraining = training.Clone();
training.Entities[0].Description = "changed";

Console.WriteLine(training);
Console.WriteLine(newTraining);