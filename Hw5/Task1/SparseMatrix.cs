using System.Collections;
using System.Text;

public class SparseMatrix : IEnumerable<long>
{
    private Dictionary<(int, int), long> nonZero = new();
    public int Height {get; private set;}
    public int Width {get; private set;}

    public SparseMatrix(int height, int width)
    {
        if(height <= 0 || width <= 0) 
        {
            throw new ArgumentException("Neither height nor width can be less or equal to zero");
        }
        Height = height;
        Width = width;
    }
    public SparseMatrix(long[,] matrix)
    {
        if(matrix.GetLength(0) <= 0 || matrix.GetLength(1) <= 0) 
        {
            throw new ArgumentException("Neither height nor width of a matrix can be less or equal to zero");
        }
        Height = matrix.GetLength(0);
        Width = matrix.GetLength(1);
        for(int i = 0; i < Height; i++)
        {
            for(int j = 0; j < Width; j++)
            {
                if(matrix[i, j] != 0)
                {
                    this[i, j] = matrix[i, j];
                }
            }
        }
    }

    public long this[int i, int j]
    {
        get
        {
            return get(i, j);
        }
        set
        {
            set(i, j, value);
        }
    }

    private long get(int i, int j)
    {
        if(i < 0 || i >= Height || j < 0 || j >= Width) 
        {
            throw new IndexOutOfRangeException();
        }
        return nonZero.TryGetValue((i, j), out long value) ? value : 0;
    }

    private void set(int i, int j, long value)
    {
        if(i < 0 || i >= Height || j < 0 || j >= Width) 
        {
            throw new IndexOutOfRangeException();
        }
        if(value != 0) 
        {
            nonZero[(i, j)] = value;
        }
        else if(nonZero.ContainsKey((i, j)))
        {
            nonZero.Remove((i, j));
        }
    }
    public long[,] toMatrix()
    {
        long[,] matrix = new long[Height, Width];
        foreach(var k in nonZero)
        {
            matrix[k.Key.Item1, k.Key.Item2] = k.Value;
        }
        return matrix;
    }

    public override string ToString()
    {
        StringBuilder sb = new();
        long[,] matrix = toMatrix();
        int padding = matrix.Cast<long>().Max().ToString().Length + 1;
        for(int i=0; i< Height; i++)
        {
            for(int j=0; j<Width; j++)
            {
                sb.Append(matrix[i, j].ToString().PadLeft(padding));
            }
            sb.AppendLine();
        }
        return sb.ToString();
    }

    public IEnumerator<long> GetEnumerator()
    {
        for(int i=0; i<Height; i++)
        {
            for(int j=0; j<Width; j++)
            {
                yield return this[i, j];
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IEnumerable<(int, int, long)> GetNonZeroElements()
    {
        return nonZero.OrderBy(x => x.Key).Select(x => (x.Key.Item1, x.Key.Item2, x.Value));
    }

    public int GetCount(long value)
    {
        if(value == 0)
        {
            return Height * Width - nonZero.Count;
        }
        else
        {
            return nonZero.Select(x => x.Value).Count(x => x == value);
        }
    }
}