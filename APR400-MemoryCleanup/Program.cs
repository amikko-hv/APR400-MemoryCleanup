using System.Diagnostics;
using APR400_MemoryCleanup;

const int dailyFileCount = 3;
const int rowsPerFile = 80;

var dataRoot = Path.Combine(AppContext.BaseDirectory, "WorkshopData");
SampleData.EnsureSampleData(dataRoot, dailyFileCount, rowsPerFile);

Console.WriteLine("Hospital Appointment Import Workshop (Compact Version)");
Console.WriteLine($"Input folder: {Path.Combine(dataRoot, "incoming")}");

var stopwatch = Stopwatch.StartNew();
var report = HospitalImport.RunDailyImport(dataRoot);
stopwatch.Stop();

Console.WriteLine();
Console.WriteLine("Run completed.");
Console.WriteLine($"Appointments imported: {report.ImportedAppointments}");
Console.WriteLine($"Output file: {report.OutputFile}");
Console.WriteLine($"Elapsed ms: {stopwatch.ElapsedMilliseconds}");
