namespace RiverCompiler;

public static class Logger
{
    public static void ConsoleLog(string msg, ConsoleColor color = White, bool indented = true)
    {
        try
        {
            ForegroundColor = color;
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
            ConsoleLog(e.Message, Red, true);
            return;
        }
        finally
        {
            ResetColor();
        }
    }
}
