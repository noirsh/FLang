namespace RiverCompiler;

public class River
{
    public static string StartCompiling(string lexerOutput)
    {
        Logger.ConsoleLog("Start Compiling ...", "white", false);

        lexerOutput = lexerOutput.Replace("Inv::", "");
        var lines = Spliter(lexerOutput, "\r\n");

        for (int i = 0; i < lines.Length; i++)
        {
            if (isModStatement(lines[i]))
            {
                lines[i] = ModCompiler(lines[i]);
            }
            else if (isFunctionSigniture(lines[i]))
            {
                var returnType = Spliter(lines[i].Trim(), " ")[^1];
                int lastIndex = lines[i].LastIndexOf(" ");
                lines[i] = lines[i].Remove(lastIndex);

                lines[i] = lines[i].Replace("gl", "public");
                lines[i] = lines[i].Replace("pr", "private");
                lines[i] = lines[i].Replace("func", "");
                lines[i] = lines[i].Replace("<", " ");
                lines[i] = lines[i].Replace(">", "");
                lines[i] = lines[i].Replace("-", "");

                int index = lines[i].IndexOf(" ");
                index++;
                lines[i] = lines[i].Insert(index, returnType);
            }
            else
            {
                lines[i] = StatementCompiler(lines[i]);
            }
        }

        var stringBuilder = new StringBuilder();
        stringBuilder.Append("using static System.Console\n");
        foreach (var line in lines)
        {
            stringBuilder.Append(line);
            stringBuilder.Append("\n");
        }
        return stringBuilder.ToString();
    }

    private static string ModCompiler(string line)
    {
        return line.Replace("mod", "using");
    }

    private static string StatementCompiler(string line)
    {
        if (isModStatement(line))
        {
            line = ModCompiler(line);
        }
        else if (isReturnLine(line))
        {
            line = line.Replace("out", "return");
            line = line.Replace("->", " ");
        }
        else if (isVariableDeclaration(line))
        {
            line = line.Replace(" <- ", " = ");
            line = line.Replace("<", " ");
            line = line.Replace(">", "");
        }
        return line;
    }
}
