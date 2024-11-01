using System.ComponentModel.DataAnnotations;

public class MyQueue<T> : IQueue<T> 
{
    private int max = 5;
    private int front;
    private int rear = -1;
    private int itemCount = 0;
    private T[] array;

    public MyQueue(int maxItems)
    {
        max = maxItems;
        array = new T[max];
    }

    public void Enqueue(T t)
    {
        if(!IsFull())
        {
            if(rear == max - 1)
            {
                rear = -1;
            }
            rear++;
            array[rear] = t;
            itemCount++;
        }
        else {
            throw new Exception("Queue is full");
        }
    }

    public T Dequeue()
    {
        if(IsEmpty()) {
            throw new Exception("Queue is empty");
        }
        T data = array[front];
        front++;
        if(front == max) 
        {
            front = 0;
        }
        itemCount--;
        return data;
    }

    public T Peek()
    {
        if(itemCount == 0)
        {
            throw new Exception("No elements in queue");
        }
        return array[front];
    }

    public bool IsFull()
    {
        return itemCount >= max;
    }

    public bool IsEmpty() 
    {
        return itemCount == 0;
    }

    public int GetSize()
    {
        return itemCount;
    }

    public override string ToString()
    {
        return string.Join(", ", array) + "     front: " + front + " rear: " + rear + " size: " + itemCount;
    }
}