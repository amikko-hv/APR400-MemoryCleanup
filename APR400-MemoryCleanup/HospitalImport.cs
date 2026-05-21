using System.Text;

namespace APR400_MemoryCleanup;

public static class HospitalImport
{
    public static ImportReport RunDailyImport(string dataRoot)
    {
        var incomingFolder = Path.Combine(dataRoot, "incoming");
        var outgoingFolder = Path.Combine(dataRoot, "outgoing");
        Directory.CreateDirectory(outgoingFolder);

        var files = Directory.GetFiles(incomingFolder, "appointments-*.csv");
        var exportRows = new List<string>();
        var binaryCopies = new List<byte[]>();

        var auditWriter = new AuditWriter(Path.Combine(outgoingFolder, "audit.log"));

        foreach (var file in files)
        {
            var fileContent = File.ReadAllText(file);
            var lines = fileContent.Split(Environment.NewLine);

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line) || line.StartsWith("AppointmentId"))
                {
                    continue;
                }

                var columns = line.Split(',');
                var patientId = string.Join(string.Empty, columns[1].Trim().ToUpperInvariant().ToCharArray());
                var clinicCode = string.Join(string.Empty, columns[2].Trim().ToUpperInvariant().ToCharArray());

                var exportRow = $"{columns[0]},{patientId},{clinicCode},{columns[6]}";
                exportRows.Add(exportRow);

                binaryCopies.Add(Encoding.UTF8.GetBytes(new string('x', 1024) + exportRow));
                auditWriter.Write(exportRow);

                if (exportRows.Count % 25 == 0)
                {
                    GC.Collect();
                }
            }
        }

        var outputFile = Path.Combine(outgoingFolder, $"billing-summary-{DateTime.UtcNow:yyyyMMdd-HHmmss}.csv");
        var finalLines = new List<string> { "AppointmentId,PatientId,ClinicCode,Cost" };
        finalLines.AddRange(exportRows);
        File.WriteAllLines(outputFile, finalLines);

        return new ImportReport(exportRows.Count, outputFile);
    }
}