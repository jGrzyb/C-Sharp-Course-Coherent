public class PointMass
{
    private int[] _coordinates = new int[3];
    private double _mass;
    
    public int X
    {
        get { return _coordinates[0]; }
        set { _coordinates[0] = value; }
    }

    public int Y
    {
        get { return _coordinates[1]; }
        set { _coordinates[1] = value; }
    }

    public int Z
    {
        get { return _coordinates[2]; }
        set { _coordinates[2] = value; }
    }

    public double Mass 
    {
        get { return _mass; }
        set { _mass = value >= 0 ? value : 0; }
    }

    public bool IsZero() 
    {
        return _coordinates.All(a => a == 0);
    }

    public double DistanceFrom(PointMass pointMass) 
    {
        return MathF.Sqrt(MathF.Pow(X - pointMass.X, 2) + MathF.Pow(Y - pointMass.Y, 2) + MathF.Pow(Z - pointMass.Z, 2));
    }

    public override string ToString()
    {
        return "X: " + _coordinates[0] + " Y: " + _coordinates[1] + " Z: " + _coordinates[2] + " Mass: " + _mass;
    }
}