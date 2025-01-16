namespace RiverCompiler;

public class Initializer
{
    public static bool IsArgsValid(string[] args)
    {
        Logger.ConsoleLog("Validating Args ...", White, false);

        if (File.Exists(args[0]))
        {
            Logger.ConsoleLog("File found.", Green);
            FilePath = args[0];
            return true;
        }
        else
        {
            Logger.ConsoleLog("File was not found.", Red);
            return false;
        }
    }

    public static void GetHelp()
    {
        WriteLine(
            """
            use this format: 

            river [FILE_NAME] {OPTIONS}

            OPTIONS : 
            	There is no option for now ...!
            
            """);
    }
}
