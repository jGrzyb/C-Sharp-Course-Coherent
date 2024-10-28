public class Program
{
    public static void Main(string[] args) 
    {
        PointMass pointMass0 = new PointMass();
        Console.WriteLine(pointMass0);

        (pointMass0.X, pointMass0.Y, pointMass0.Z) = (2, 3, 4);
        Console.WriteLine(pointMass0);

        pointMass0.Mass = 15.3d;
        Console.WriteLine(pointMass0);

        pointMass0.Mass = -54.2d;
        Console.WriteLine(pointMass0);

        PointMass pointMass1 = new PointMass();
        (pointMass1.X, pointMass1.Y, pointMass1.Z) = (5,2,1);

        Console.WriteLine(pointMass0.DistanceFrom(pointMass1));
    }
}