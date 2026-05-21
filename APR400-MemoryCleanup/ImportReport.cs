namespace APR400_MemoryCleanup;

public class ImportReport
{
    public ImportReport(int importedAppointments, string outputFile)
    {
        ImportedAppointments = importedAppointments;
        OutputFile = outputFile;
    }

    public int ImportedAppointments { get; }
    public string OutputFile { get; }
}