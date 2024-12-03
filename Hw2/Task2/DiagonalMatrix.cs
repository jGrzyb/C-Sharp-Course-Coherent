namespace Matrix
{
    public delegate T AddElementsDelegate<T>(T a, T b);
    public class DiagonalMatrix<T>
    {
        private T[] _diagonal;
        public int Size
        {
            get { return _diagonal.Length; }
        }

        public DiagonalMatrix(params T[] numbers) 
        {
            if(numbers == null) 
            {
                _diagonal = [];
            }
            else 
            {
                _diagonal = new T[numbers.Length];
                Array.Copy(numbers, _diagonal, numbers.Length);
            }
        }

        public DiagonalMatrix(int size)
        {
            if(size < 0)
            {
                throw new ArgumentException("size cannot be negative");
            }
            _diagonal = new T[size];
        }    

        public T this[int i, int j]
        {
            get 
            {
                return GetElement(i, j);
            }
            set 
            { 
                SetElement(i, j, value);
            }
        }

        private T GetElement(int i, int j) 
        {
            
            if(!IsInsideMatrix(i, j)) 
            {
                throw new IndexOutOfRangeException("Index out of range");
            }
            else if(IsOnDiagonal(i, j))
            {
                return _diagonal[i];
            }
            else
            {
                return default;
            }
        }

        private bool IsInsideMatrix(int i, int j)
        {
            return i >= 0 && i < Size && j >= 0 && j < Size;
        }

        private bool IsOnDiagonal(int i, int j)
        {
            return i == j;
        }

        private void SetElement(int i, int j, T el) 
        {
            if(!IsInsideMatrix(i, j)) 
            {
                throw new IndexOutOfRangeException("Index out of range");
            }
            else if(IsOnDiagonal(i, j))
            {
                if(_diagonal[i] is not null && !_diagonal[i]!.Equals(el))
                {
                    UpdateElement(i, j, el);
                }
            }
        }

        private void UpdateElement(int i, int j, T el) 
        {
            OnElementChanged(i, j, _diagonal[i], el);
            _diagonal[i] = el;   
        }

        // public int Track() 
        // {
        //     return _diagonal.Sum();
        // }

        // public override bool Equals(object? obj)
        // {
        //     if(obj is DiagonalMatrix dm) 
        //     {
        //         return Enumerable.SequenceEqual(_diagonal, dm._diagonal);
        //     }
        //     return false;
        // }

        public override string ToString()
        {
            return string.Join(" ", _diagonal);
        }

        public delegate void ElementChangedEventHandler(object sender, ElementChangedEventArgs<T> e);
        public event ElementChangedEventHandler? ElementChanged;
        protected virtual void OnElementChanged(int i, int j, T oldValue, T newValue)
        {
            ElementChanged?.Invoke(this, new ElementChangedEventArgs<T>(i, j, oldValue, newValue));
        }
    }
}