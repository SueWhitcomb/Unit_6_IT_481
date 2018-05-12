using System;
using System.Threading;

namespace Unit_6_IT_481

{ 
public class Customer
{
    private bool InstanceFieldsInitialized = false;

    private void InitializeInstanceFields()
    {
        totalTime = numberOfitems * timePerItem;
    }


    private static readonly Random generator = new Random();
    private readonly DressingRooms dressingRoom;

    internal int numberOfitems = generator.Next(5) + 1; //random No of items, 6 MAX
    internal int timePerItem = generator.Next(30000) + 1; //random time, 3min MAX
    internal int totalTime; //total time spent in room

    //constructor
    public Customer(DressingRooms room)
    {
        if (!InstanceFieldsInitialized)
        {
            InitializeInstanceFields();
            InstanceFieldsInitialized = true;
        }
        dressingRoom = room;
    } //end constructor

    public Customer()
    {
    }

    //request a room in DressingRooms class
    public virtual void run()
    {

        try
        {
            dressingRoom.RequestRoom(numberOfitems); //room request
            Thread.Sleep(totalTime); //time between in and out of room
            dressingRoom.vacateRoom(); //leave dressing room

        }
        catch (ThreadInterruptedException ex)
        {
            Console.WriteLine(ex.ToString());
            Console.Write(ex.StackTrace);
        } //end try/catch

    } //end run

    public virtual int NumberOfitems()
    {
        int items = this.numberOfitems;
        return items;
    } //end NumberOfitems

    public virtual int TimePerItem()
    {
        int itemTime = this.timePerItem;
        return itemTime;
    } //end NumberOfitems

    public virtual int TotalTime()
    {
        int time = this.totalTime;
        return time;
    } //end NumberOfitems

} //end class Customer
}