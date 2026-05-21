namespace APR400_MemoryCleanup;

public static class SampleData
{
    public static void EnsureSampleData(string dataRoot, int fileCount, int rowsPerFile)
    {
        var incomingFolder = Path.Combine(dataRoot, "incoming");
        Directory.CreateDirectory(incomingFolder);

        var existingFiles = Directory.GetFiles(incomingFolder, "appointments-*.csv");
        if (existingFiles.Length >= fileCount)
        {
            return;
        }

        var random = new Random(42);

        for (var day = 0; day < fileCount; day++)
        {
            var date = DateTime.UtcNow.Date.AddDays(-day);
            var filePath = Path.Combine(incomingFolder, $"appointments-{date:yyyyMMdd}.csv");
            var lines = new List<string>
            {
                "AppointmentId,PatientId,ClinicCode,DoctorId,ScheduledAtUtc,DurationMinutes,Cost"
            };

            for (var row = 0; row < rowsPerFile; row++)
            {
                var appointmentId = $"A-{date:yyyyMMdd}-{row:0000}";
                var patientId = $"p{random.Next(1000, 9999)}";
                var clinicCode = random.Next(0, 2) == 0 ? "east" : "west";
                var doctorId = random.Next(100, 150).ToString();
                var scheduledAt = date.AddHours(8).AddMinutes(random.Next(0, 540));
                var durationMinutes = random.Next(15, 60);
                var cost = (random.Next(5000, 15000) / 100.0m).ToString("0.00");

                lines.Add($"{appointmentId},{patientId},{clinicCode},{doctorId},{scheduledAt:O},{durationMinutes},{cost}");
            }

            File.WriteAllLines(filePath, lines);
        }
    }
}