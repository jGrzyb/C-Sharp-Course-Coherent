namespace Matrix
{
    public class MatrixTracker<T>
    {
        private Stack<ElementChangedEventArgs<T>> changes = new();
        private DiagonalMatrix<T> matrix;
        public MatrixTracker(DiagonalMatrix<T> matrix)
        {
            matrix.ElementChanged += OnMatrixChanged;
            this.matrix = matrix;
        }

        private void OnMatrixChanged(object sender, ElementChangedEventArgs<T> e)
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
            matrix.ElementChanged -= OnMatrixChanged;
            // Console.WriteLine("Undo: " + string.Join(" ", [change.I, change.J, change.OldValue, change.NewValue]));
            matrix[change.I, change.J] = change.OldValue;
            matrix.ElementChanged += OnMatrixChanged;
        }
    }
}