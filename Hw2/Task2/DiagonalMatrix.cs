public class DiagonalMatrix
{
    private int[] _diagonal;
    public int Size
    {
        get { return _diagonal.Length;}
    }

    public DiagonalMatrix(params int[] numbers) 
    {
        if(numbers == null) 
        {
            _diagonal = [];
        }
        else 
        {
            _diagonal = new int[numbers.Length];
            Array.Copy(numbers, _diagonal, numbers.Length);
        }
    }

    public int this[int i, int j]
    {
        get 
        {
            return getElement(i, j);
        }
        set 
        { 
            setElement(i, j, value);
        }
    }

    private int getElement(int i, int j) 
    {
        if(i == j)
        {
            return _diagonal[i];
        }
        else if(i >= 0 && i < Size && j >= 0 && j < Size) 
        {
            return 0;
        }
        else
        {
            throw new IndexOutOfRangeException("Index out of range");
        }
    }

    private void setElement(int i, int j, int el) 
    {
        if(i == j)
        {
            _diagonal[i] = el;
        }
        else if(i < 0 || i >= Size || j < 0 || j >= Size) 
        {
            throw new IndexOutOfRangeException("Index out of range");
        }
    }

    public int Track() 
    {
        return _diagonal.Sum();
    }

    public override bool Equals(object? obj)
    {
        if(obj is DiagonalMatrix dm) 
        {
            return Enumerable.SequenceEqual(_diagonal, dm._diagonal);
        }
        return false;
    }

    // public override int GetHashCode()
    // {
    //     int hash = 104729;
    //     foreach (int element in _diagonal)
    //     {
    //         hash = hash * 31 + element.GetHashCode();
    //     }
    //     return hash;
    // }

    public override string ToString()
    {
        return string.Join(" ", _diagonal);
    }
}

public static class DiagonalMatrixExtensions
{
    public static DiagonalMatrix Add(this DiagonalMatrix dm1, DiagonalMatrix dm2)
    {
        int maxSize = (int)MathF.Max(dm1.Size, dm2.Size);
        int[] result = new int[maxSize];

        for(int i=0; i<maxSize; i++) 
        {
            int v1 = i < dm1.Size ? dm1[i, i] : 0;
            int v2 = i < dm2.Size ? dm2[i, i] : 0;
            result[i] = v1 + v2;
        }

        return new DiagonalMatrix(result);
    }
}