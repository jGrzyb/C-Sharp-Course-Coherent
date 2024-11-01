namespace Matrix
{
    public class MatrixTracker<T>
    {
        private Stack<ElementChangedEventArgs<T>> changes = new();
        private DiagonalMatrix<T> matrix;
        public MatrixTracker(DiagonalMatrix<T> matrix)
        {
            matrix.ElementChanged += onMatrixChanged;
            this.matrix = matrix;
        }

        private void onMatrixChanged(object sender, ElementChangedEventArgs<T> e)
        {
            changes.Push(e);
            // Console.WriteLine("Change: " + string.Join(" ", [e.I, e.J, e.OldValue, e.NewValue]));
        }

        public void Undo()
        {
            if(changes.Count == 0)
            {
                return;
            }
            ElementChangedEventArgs<T> change = changes.Pop();
            // Console.WriteLine("Undo: " + string.Join(" ", [change.I, change.J, change.OldValue, change.NewValue]));
            matrix[change.I, change.J] = change.OldValue;
            changes.Pop();
        }
    }
}