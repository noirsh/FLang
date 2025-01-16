namespace RiverCompiler;

public class Utility
{
    public static string[] Spliter(string text, string seperator)
    {
        return text.Split(seperator);
    }

    public static bool isModStatement(string line)
    {
        return line.StartsWith("mod ");
    }

    public static bool isFunctionSigniture(string line)
    {
        return line.StartsWith("gl") || line.StartsWith("pr");
    }

    public static bool isVariableDeclaration(string line)
    {
        bool arrow = line.Contains("<-");
        bool type = false;

        foreach (string word in Spliter(line, " "))
        {
            if (word is "<-")
                type = true;
        }

        return arrow && type;
    }

    public static bool isCurlyBracket(string line)
    {
        return line.Trim() is "{" or "}";
    }

    public static bool isReturnLine(string line)
    {
        return line.Contains("out");
    }
}
