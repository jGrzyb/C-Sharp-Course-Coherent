namespace Matrix
{
    public static class DiagonalMatrixExtensions
    {
        public static DiagonalMatrix<T> Add<T>(this DiagonalMatrix<T> dm1, DiagonalMatrix<T> dm2, AddElementsDelegate<T> AddElementsDelegate)
        {
            int maxSize = (int)MathF.Max(dm1.Size, dm2.Size);
            T[] result = new T[maxSize];

            for(int i=0; i<maxSize; i++) 
            {
                T v1 = i < dm1.Size ? dm1[i, i] : default!;
                T v2 = i < dm2.Size ? dm2[i, i] : default!;
                result[i] = AddElementsDelegate(v1!, v2!);
            }

            return new DiagonalMatrix<T>(result);
        }
    }
}