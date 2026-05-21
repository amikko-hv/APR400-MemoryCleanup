# APR400 Memory Cleanup Workshop

This repository contains a deliberately memory-inefficient C# console application for a 2-hour workshop.

## Use case

The app processes multiple daily hospital appointment CSV files and exports a billing summary. The implementation intentionally includes memory issues for students to identify and refactor.

## Workshop timing (2 hours)

- 10 min: teacher introduction
- 80 min: group work (3-5 students)
- 30 min: debrief and verbal results

## Learning focus

- Heap allocations and object lifetime
- Garbage collection pressure and forced collections
- Unmanaged resources through file handles (`FileStream`/`StreamWriter`)
- `IDisposable` and ownership patterns

## Run the baseline app

```powershell
cd "C:\Users\anmi0012\Projects\APR400\APR400-MemoryCleanup\APR400-MemoryCleanup"
dotnet run
```

The app generates sample CSV files under `WorkshopData\incoming` and writes export files to `WorkshopData\outgoing`.

## Student task

1. Review the code and identify memory-management problems.
2. Refactor the code to improve memory behavior.
3. Explain what changed and why in the debrief.


