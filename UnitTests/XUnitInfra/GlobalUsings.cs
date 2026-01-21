global using Microsoft.Extensions.Logging;
global using System.Globalization;
global using Xunit.Abstractions;

// Disable test parallelization for the entire assembly to avoid issues with shared state.
[assembly: CollectionBehavior(CollectionBehavior.CollectionPerAssembly, DisableTestParallelization = true, MaxParallelThreads = 1)]
