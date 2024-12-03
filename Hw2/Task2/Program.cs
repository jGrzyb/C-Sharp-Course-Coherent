using Matrix;

public class Program
{
    public static void Main(string[] args)
    {
        DiagonalMatrix<int> dm1 = new(1,3,5,2,4);
        DiagonalMatrix<int> dm2 = new(1,3,8,2,4);
        DiagonalMatrix<int> dm3 = new(1,2,3,4,5,6,7);
        
        Console.WriteLine(dm1);
        Console.WriteLine(dm1[3,3]);
        Console.WriteLine(dm1[1,2]);
        try
        {
            Console.WriteLine(dm1[-1,7]);
        }
        catch(Exception e)
        {
            Console.WriteLine(e);
        }
        

        dm1[2,2] = 8;
        dm1[1,2] = 4;
        try 
        {
            dm1[-5, 9] = 9;
        }
        catch(Exception e)
        {
            Console.WriteLine(e);
        }
        
        Console.WriteLine(dm1);
        
        Console.WriteLine(dm1.Equals(dm2));
        Console.WriteLine(dm1.Equals(dm3));

        Console.WriteLine(dm1.Add(dm3, (x, y) => x + y));
        Console.WriteLine();

        Console.WriteLine(dm1);
        MatrixTracker<int> matrixTracker = new(dm1);
        dm1[1, 1] = 100;
        dm1[2, 2] = 300;
        dm1[3, 3] = 800;
        Console.WriteLine(dm1);
        matrixTracker.Undo();
        Console.WriteLine(dm1);
        matrixTracker.Undo();
        Console.WriteLine(dm1);
        matrixTracker.Undo();
        Console.WriteLine(dm1);
    }
}