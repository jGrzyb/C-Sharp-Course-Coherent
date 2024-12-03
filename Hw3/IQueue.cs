public interface IQueue<T>
{
    public void Enqueue(T t);
    public T Dequeue();
    public bool IsEmpty();
}