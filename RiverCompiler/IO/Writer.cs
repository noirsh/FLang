namespace RiverCompiler.IO;

public class Writer
{
    public static void Write(string text)
    {
        try
        {
            File.AppendAllText(StaticInfo.OutputFilePath, text);
        }

        catch (Exception e)
        {
            Logger.ConsoleLog(e.Message, "red");
        }
    }

    public static void GenerateOutputName()
    {
        if (!isExistFileName("Program.cs"))
        {
            Logger.ConsoleLog("Another Output file exist. Do you wan't to override it (y/N) ? ", "yellow", false);
            string input = ReadLine() ?? "n";
            input = input.ToLower().Trim();

            if (input is "n")
                return;

            StaticInfo.OutputFilePath = $"{Directory.GetCurrentDirectory()}/Program.cs";
        }
        else
            StaticInfo.OutputFilePath = $"{Directory.GetCurrentDirectory()}/Program.cs";
    }

    private static bool isExistFileName(string fileName)
    {
        return Directory.GetFiles(Directory.GetCurrentDirectory()).Contains(fileName);
    }
}
