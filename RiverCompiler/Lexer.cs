namespace RiverCompiler;

public class Lexer
{
    public static string Analyser(string text)
    {
        Logger.ConsoleLog("Start Lexical Analysis", White, false);

        var stringBuilder = new StringBuilder();
        var lines = Spliter(text, "\n");

        foreach (var line in lines)
        {
            if (IsComment(line) || IsEmpty(line) || IsSpecialChar(line))
            {
                continue;
            }

            stringBuilder.Append(line);
            stringBuilder.Append("\n");
        }

        Logger.ConsoleLog("Lexical Analysis Finished Successfully ...", Green);
        return stringBuilder.ToString();
    }

    private static bool IsComment(string text)
    {
        return text.Trim().StartsWith("//");
    }

    private static bool IsEmpty(string text)
    {
        return string.IsNullOrEmpty(text.Trim());
    }

    private static bool IsSpecialChar(string text)
    {
        return text is "" or "\r";
    }
}
