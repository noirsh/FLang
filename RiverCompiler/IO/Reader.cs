namespace RiverCompiler.IO;

public class Reader
{
    public static string ReadFile(string path)
    {
        Logger.ConsoleLog("Reading content from file ...", White, false);

        string readedContent = string.Empty;
        try
        {
            using StreamReader reader = new(path);
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

    public static string InjectDependencies(string text)
    {
        if (!text.Contains("mod "))
            return text;

        var lines = Spliter(text, "\r\n");
        Logger.ConsoleLog("Read Extra Files ...", White, false);

        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].Contains("mod "))
            {
                lines[i] = ModCompiler(lines[i]);
            }
        }

        Logger.ConsoleLog("Done ...", Green);
        return lines.GetFinallString();
    }

    private static string ModCompiler(string line)
    {
        var fileName = ExtractModFileName(line);
        if (File.Exists(fileName))
            return ReadFile(fileName);

        throw new FileNotFoundException(fileName);
    }
}
