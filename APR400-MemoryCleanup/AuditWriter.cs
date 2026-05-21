
namespace APR400_MemoryCleanup;

public class AuditWriter : IDisposable
{
    private readonly StreamWriter _writer;

    public AuditWriter(string filePath)
    {
        _writer = new StreamWriter(File.Open(filePath, FileMode.Append, FileAccess.Write, FileShare.Read));
    }

    public void Write(string message)
    {
        _writer.WriteLine(message);
    }

    public void Dispose()
    {
        _writer.Dispose();
    }
}