SparseMatrix sm = new SparseMatrix(new long[,]{
    {1,0,5,0},
    {0,0,8,0},
    {1,2,5,4},
    {0,0,0,0},
    {0,1,0,0}
});
Console.WriteLine(sm);
Console.WriteLine(string.Join(" ", sm.Select(x => x)));
Console.WriteLine(string.Join(" --- ", sm.GetNonZeroElements()));
Console.WriteLine(sm.GetCount(1));
Console.WriteLine(sm.GetCount(0));