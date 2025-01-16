namespace RiverCompiler.IO;

public class Reader
{
    public static string ReadFile()
    {
        Logger.ConsoleLog("Reading content from file ...", "white", false);

        string readedContent = string.Empty;
        try
        {
            using StreamReader reader = new(StaticInfo.FilePath);
            readedContent = reader.ReadToEnd();
        }

        catch (UnauthorizedAccessException e)
        {
            // check for denied spelling
            Logger.ConsoleLog("Access Denied ...", "red");
            Logger.ConsoleLog(e.Message, "red");
            throw;
        }

        catch (Exception e)
        {
            Logger.ConsoleLog(e.Message, "red");
        }

        return readedContent;
    }
}
