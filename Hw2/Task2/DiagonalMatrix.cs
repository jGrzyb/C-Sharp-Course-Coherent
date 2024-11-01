namespace Matrix
{
    public delegate T AddElementsDelegate<T>(T a, T b);
    public class DiagonalMatrix<T>
    {
        private T[] _diagonal;
        public int Size
        {
            get { return _diagonal.Length;}
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
                return getElement(i, j);
            }
            set 
            { 
                setElement(i, j, value);
            }
        }

        private T getElement(int i, int j) 
        {
            if(i == j)
            {
                return _diagonal[i];
            }
            else if(i >= 0 && i < Size && j >= 0 && j < Size) 
            {
                return default;
            }
            else
            {
                throw new IndexOutOfRangeException("Index out of range");
            }
        }

        private void setElement(int i, int j, T el) 
        {
            if(i == j)
            {
                if(_diagonal[i] is not null && !_diagonal[i]!.Equals(el))
                {
                    // Console.WriteLine("Set: " + string.Join(" ", [i, j, _diagonal[i], el]));
                    OnElementChanged(i, j, _diagonal[i], el);
                    _diagonal[i] = el;   
                }
            }
            else if(i < 0 || i >= Size || j < 0 || j >= Size) 
            {
                throw new IndexOutOfRangeException("Index out of range");
            }
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