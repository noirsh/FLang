namespace RiverCompiler.IO;

public class Writer
{
    public static void Write(string text)
    {
        Logger.ConsoleLog($"Start writing output into : {OutputFilePath}", White, false);

        try
        {
            File.WriteAllText(OutputFilePath, text);
        }

        catch (Exception e)
        {
            Logger.ConsoleLog(e.Message, Red);
            throw;
        }

        Logger.ConsoleLog("Writing Successfully Done ...", Green);
    }
}
