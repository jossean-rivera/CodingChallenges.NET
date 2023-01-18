
Task Schedule(Action action, int milliseconds) => Task.Delay(milliseconds).ContinueWith(_ => action());

Console.WriteLine("Starting at {0}", DateTime.Now);

async Task RunAsync(int milliseconds = 3000)
{
    Console.WriteLine("Calling shedule job to run in {0} milliseconds", milliseconds);
    await Schedule(() => Console.WriteLine("\tFunction ran after {0} milliseconds", milliseconds), milliseconds);
} 

Task.WhenAll(
    RunAsync(1000),
    RunAsync(2000),
    RunAsync(3000),
    RunAsync(5000)).Wait();

Console.WriteLine("Done.");
