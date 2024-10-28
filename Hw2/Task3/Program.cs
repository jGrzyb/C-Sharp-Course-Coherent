PracticalLesson ps0 = new PracticalLesson("ps0s", "ps0t");
PracticalLesson ps1 = new PracticalLesson("ps1s", "ps1t");
PracticalLesson ps2 = new PracticalLesson("ps2s", "ps2t");

Training training = new Training("t0desc", [ps0, ps1, ps2]);

Console.WriteLine(training.IsPractical());

Lecture l0 = new Lecture();
l0.Topic = "l0t";

Console.WriteLine(training);

Training newTraining = training.Clone();
newTraining.Add(l0);

Console.WriteLine(training);
Console.WriteLine(newTraining);