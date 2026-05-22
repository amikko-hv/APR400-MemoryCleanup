# APR400 Memory Cleanup Workshop

This repository contains a deliberately memory-inefficient C# console application.

The code is intended for educational purposes, to identify and fix memory management issues in C#.

## Task

The app processes multiple daily hospital appointment CSV-files and exports a billing summary. 
The implementation intentionally includes memory issues to be identifed and improved.

You should:

- Review the code and identify memory-management problems. 
- Refactor the code to improve memory behavior.
- Do not alter the existing functionality. The output should remain the same.

You are unlikley to be able to fix all issues in the code. Focus on a few changes. 
Make sure you truly understand why it is a problem and how your change improves the situation.

## Things to consider

- Heap allocations and object lifetime
- Garbage collection
- Use of the `IDisposable` interface
