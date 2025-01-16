namespace RiverCompiler;

public class Initializer
{
    public static bool IsArgsValid(string[] args)
    {
        Logger.ConsoleLog("Validating Args ...", "white", false);

        if (File.Exists(args[0]))
        {
            Logger.ConsoleLog("File found.", "green");
            StaticInfo.FilePath = args[0];
            return true;
        }
        else
        {
            Logger.ConsoleLog("File was not found.", "red");
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
