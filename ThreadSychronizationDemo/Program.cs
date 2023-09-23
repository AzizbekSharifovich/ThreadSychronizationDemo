using System;
using System.Threading;

namespace ThreadSychronizationDemo;

class Program
{
    //private static object _locker = new object();
    //static ManualResetEvent _manualResetEvent = new ManualResetEvent(false);
    //static AutoResetEvent _autoResetEvent = new AutoResetEvent(true);
    //static Mutex _mutex = new Mutex();
    static Semaphore _semaphore = new Semaphore(3,3);
    static void Main(string[] args)
    {
        //for (int i = 0; i < 5; i++)
        //{
        //    new Thread(DoWork).Start();
        //}

        //new Thread(Write).Start();

        for (int i = 0; i < 5; i++)
        {
            new Thread(Write).Start();
        }

        //Thread.Sleep(3000);
        //_autoResetEvent.Set();
        //_mutex.ReleaseMutex();

        Console.ReadKey();
    }

    public static void DoWork()
    {
        //lock(_locker)
        //{
        //    Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} starting..");
        //    Thread.Sleep(2000);
        //    Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} completed..");
        //}

        //Monitor.Enter(_locker);
        //Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} starting...");
        //Thread.Sleep(2000);
        //Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} completed...");
        //Monitor.Exit(_locker);
    }

    public static void Write()
    {
        Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} Waiting...");
        //_autoResetEvent.WaitOne();
        //_mutex.WaitOne();
        _semaphore.WaitOne();
        Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} Writing...");
        //_manualResetEvent.Reset();
        Thread.Sleep(5000);
        Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} Writing completed...");
        //_manualResetEvent.Set();
        //_autoResetEvent.Set();
        //_mutex.ReleaseMutex();
        _semaphore.Release();
    }

    //public static void Read()
    //{
    //    Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} Waiting...");
    //    _manualResetEvent.WaitOne();
    //    Thread.Sleep(2000);
    //    Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} Reading ...");
    //}
}