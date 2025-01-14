public class Logger
{
    private static string _filePath = "log.txt";
    public static void Log(string message)
    {
        File.AppendAllText(_filePath, message + "\n");
    }

    public static void Clear()
    {
        File.WriteAllText(_filePath, "");
    }
}