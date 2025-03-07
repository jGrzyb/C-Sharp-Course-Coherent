public class Rational : IComparable
{
    public int N {get; private set;}
    public int M {get; private set;}

    public Rational(int n, int m)
    {
        if(m < 0)
        {
            N = -1*n;
            M = -1*m;
        }
        else
        {
            N = n;
            M = m;
        }
        
        ToIrreductible();
    }

    private void ToIrreductible()
    {
        for(int i=(int)MathF.Min(MathF.Abs(N), MathF.Abs(M)); i>0; i--) 
        {
            if(N % i == 0 && M % i == 0)
            {
                N /= i;
                M /= i;
            }
        }
        if(N == 0) 
        {
            M = 1;
        }
    }

    public override bool Equals(object? obj)
    {
        return obj is Rational r && r.N == N && r.M == M;
    }

    public override string ToString()
    {
        return N + "/" + M;
    }

    public int CompareTo(object? obj)
    {
        if(obj is Rational r)
        {
            return (N * r.M).CompareTo(M * r.N);       
        }
        else
        {
            return 1;
        }
    }

    public static Rational operator +(Rational a, Rational b)
    {
        return new Rational(a.N * b.M + b.N * a.M, a.M * b.M);
    }
    public static Rational operator -(Rational a, Rational b)
    {
        return new Rational(a.N * b.M - b.N * a.M, a.M * b.M);
    }
    public static Rational operator *(Rational a, Rational b)
    {
        return new Rational(a.N * b.N, a.M * b.M);
    }
    public static Rational operator /(Rational a, Rational b)
    {
        if(b.N == 0)
        {
            throw new ArgumentException("Dividing by zoro!");
        }
        return new Rational((b.N > 0 ? 1 : -1) * a.N * b.M, (int)MathF.Abs(b.N) * a.M);
    }

    public static explicit operator double(Rational r)
    {
        return (double)r.N / r.M;
    }
    public static implicit operator Rational(int value)
    {
        return new Rational(value, 1);
    }
}