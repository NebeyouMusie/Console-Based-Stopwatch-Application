# Console Stopwatch Application

## Description

This is a simple console-based stopwatch application implemented in C#. The program allows users to start, stop, reset, and monitor the elapsed time through an interactive terminal interface.

## Features

- **Start Stopwatch**: Begin measuring elapsed time.
- **Stop Stopwatch**: Pause the stopwatch.
- **Reset Stopwatch**: Reset the elapsed time to zero.
- **Real-Time Updates**: Continuously displays the elapsed time while running.
- **Event-Driven Architecture**: Uses events to notify users of actions such as starting, stopping, and resetting the stopwatch.


### Commands
When the application starts, you'll see the following commands:
- **S**: Start the stopwatch.
- **T**: Stop the stopwatch.
- **R**: Reset the stopwatch.
- **Q**: Quit the application.

The elapsed time will display after any command is executed.

## Code Structure

### Stopwatch Class
- **Fields**:
  - `_timeElapsed`: Tracks the total elapsed time.
  - `_isRunning`: Indicates if the stopwatch is currently running.
  - `_timer`: A `Timer` object to handle periodic ticks.
- **Events**:
  - `OnStarted`: Triggered when the stopwatch starts.
  - `OnStopped`: Triggered when the stopwatch stops.
  - `OnReset`: Triggered when the stopwatch is reset.
- **Methods**:
  - `Start()`: Starts the stopwatch.
  - `Stop()`: Stops the stopwatch.
  - `Reset()`: Resets the stopwatch.
  - `Tick(object? state)`: Updates the elapsed time every second.

### Program Class
- Handles the user interface.
- Listens for user inputs and executes corresponding commands.
- Subscribes to the stopwatch events and displays messages in response.

## Requirements

- **Platform**: .NET 6.0 or higher
- **IDE**: Visual Studio, Visual Studio Code, or any compatible editor

## Running the Program

1. Clone the repository or copy the source code into a `.cs` file.
2. Build the program using the .NET CLI:
   ```bash
   dotnet build
3. Run the program
    ```bash
    dotnet run

