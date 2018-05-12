using System;

public class DressingRooms
{

    private readonly ArrayBlockingQueue<int> buffer; //shared buffer
    internal long start; //wait timer variables
    internal long stop;
    internal long wait; //customer wait time
    internal long totalWait;
    internal int count = 0; //how many times wait occurs
    internal long waitAvg; //average wait time

    public DressingRooms(int rooms)
    {
        buffer = new ArrayBlockingQueue<int>(rooms);
    } //end constructor

        public virtual void RequestRoom(int items)
    {
        //start a timer if buffer is full (no dressing room avail)
        if (buffer.remainingCapacity() == 0 && start == 0)
        {
            DateTime startTime = DateTime.Now;
            start = startTime.Ticks;
            Console.WriteLine("Person arrives, no dressing room available, starting timer");
            buffer.put(items); 
            Console.Write("{0}{1,2:D}\t {2}{3:D}\n", "Person enters with: ", items, "Dressing rooms occupied: ", buffer.size());
        }
        else
        {
            buffer.put(items); //places a value in buffer
            Console.Write("{0}{1,2:D}\t {2}{3:D}\n", "Person enters with: ", items, "Dressing rooms occupied: ", buffer.size());
        } //end if/else
    } //end method set

    public virtual void vacateRoom()
    {
        //if buffer was full stop timer and print wait time
        if (buffer.remainingCapacity() == 0 && start > 0)
        {
            DateTime stopTime = DateTime.Now;
            stop = stopTime.Ticks;
            wait = stop - start;
            totalWait += wait;
            count++;
            start = 0; //reset timer
            Console.WriteLine("Dressing room now available, wait time was " + wait / 1000 + " seconds");
            int readItems = buffer.take(); //then retrieve value from buffer
            Console.Write("{0}{1,2:D}\t {2}{3:D}\n", "Person leaves with: ", readItems, "Dressing rooms occupied: ", buffer.size());
        }
        else
        {
            int readItems = buffer.take(); //retrieve value from buffer
            Console.Write("{0}{1,2:D}\t {2}{3:D}\n", "Person leaves with: ", readItems, "Dressing rooms occupied: ", buffer.size());
        } //end if/else
    } //end method get

    public virtual long averageWait()
    {
        waitAvg = totalWait / count;
        return waitAvg;
    } //end averageWait

} 
