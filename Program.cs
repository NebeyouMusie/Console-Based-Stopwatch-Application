using System;
using System.Threading;

namespace ConsoleStopwatch
{
    // Delegate for stopwatch events
    public delegate void StopwatchEventHandler(string message);

    // Stopwatch class
    public class Stopwatch
    {
        private TimeSpan _timeElapsed;
        private bool _isRunning;

        // Allow these to be null initially
        private Timer? _timer;
        public event StopwatchEventHandler? OnStarted;
        public event StopwatchEventHandler? OnStopped;
        public event StopwatchEventHandler? OnReset;

        public Stopwatch()
        {
            _timeElapsed = TimeSpan.Zero;
            _isRunning = false;
        }

        public void Start()
        {
            if (_isRunning)
            {
                Console.WriteLine("Stopwatch is already running.");
                return;
            }

            _isRunning = true;
            OnStarted?.Invoke("Stopwatch Started!");
            _timer = new Timer(Tick, null, 0, 1000);
        }

        public void Stop()
        {
            if (!_isRunning)
            {
                Console.WriteLine("Stopwatch is not running.");
                return;
            }

            _isRunning = false;
            _timer?.Dispose();
            OnStopped?.Invoke("Stopwatch Stopped!");
        }

        public void Reset()
        {
            Stop();
            _timeElapsed = TimeSpan.Zero;
            OnReset?.Invoke("Stopwatch Reset!");
        }

        private void Tick(object? state)
        {
            _timeElapsed = _timeElapsed.Add(TimeSpan.FromSeconds(1));
            Console.Clear();
            Console.WriteLine($"Time Elapsed: {_timeElapsed}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopwatch = new Stopwatch();

            // Subscribe to events
            stopwatch.OnStarted += MessageHandler;
            stopwatch.OnStopped += MessageHandler;
            stopwatch.OnReset += MessageHandler;

            bool exit = false;

            Console.WriteLine("Console Stopwatch");
            Console.WriteLine("Press S to Start, T to Stop, R to Reset, and Q to Quit.");

            while (!exit)
            {
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;

                    switch (key)
                    {
                        case ConsoleKey.S:
                            stopwatch.Start();
                            break;

                        case ConsoleKey.T:
                            stopwatch.Stop();
                            break;

                        case ConsoleKey.R:
                            stopwatch.Reset();
                            break;

                        case ConsoleKey.Q:
                            stopwatch.Stop();
                            exit = true;
                            break;

                        default:
                            Console.WriteLine("Invalid input. Use S to Start, T to Stop, R to Reset, or Q to Quit.");
                            break;
                    }
                }

                Thread.Sleep(100); // Prevent excessive CPU usage
            }

            Console.WriteLine("Goodbye!");
        }

        static void MessageHandler(string message)
        {
            Console.WriteLine(message);
        }
    }
}
