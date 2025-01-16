namespace RiverCompiler;

public static class Logger
{
    public static void ConsoleLog(string msg, string color, bool indented = true)
    {
        try
        {
            ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), color, true);
            if (indented)
            {
                WriteLine($"\t -> {msg}");
            }
            else
            {
                WriteLine(msg);
            }
        }
        catch (Exception e)
        {
            ConsoleLog(e.Message, "red", true);
            return;
        }
        finally
        {
            ResetColor();
        }
    }
}
