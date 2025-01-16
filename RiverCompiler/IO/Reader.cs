namespace RiverCompiler.IO;

public class Reader
{
    public static string ReadFile()
    {
        Logger.ConsoleLog("Reading content from file ...", White, false);

        string readedContent = string.Empty;
        try
        {
            using StreamReader reader = new(FilePath);
            readedContent = reader.ReadToEnd();
        }

        catch (UnauthorizedAccessException e)
        {
            // check for denied spelling
            Logger.ConsoleLog("Access Denied ...", Red);
            Logger.ConsoleLog(e.Message, Red);
            throw;
        }

        catch (Exception e)
        {
            Logger.ConsoleLog(e.Message, Red);
        }

        Logger.ConsoleLog("Done ...", Green);
        return readedContent;
    }
}
