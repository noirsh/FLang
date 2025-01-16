if (args.Length is 0)
{
    Initializer.GetHelp();
    return;
}

if (!Initializer.IsArgsValid(args))
{
    return;
}

try
{
    var text = Reader.ReadFile();
    text = Lexer.Analyser(text);
    text = River.StartCompiling(text);
    Writer.Write(text);
}
catch 
{
    Logger.ConsoleLog($"Error detected. exiting ...", Red);
    return;
}