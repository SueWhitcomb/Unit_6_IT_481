using System;

internal class ArrayBlockingQueue<T>
{
    private int rooms;

    public ArrayBlockingQueue(int rooms)
    {
        this.rooms = rooms;
    }

    internal void put(int items)
    {
        throw new NotImplementedException();
    }

    internal int remainingCapacity()
    {
        throw new NotImplementedException();
    }

    internal int take()
    {
        throw new NotImplementedException();
    }

    internal object size()
    {
        throw new NotImplementedException();
    }
}