using ICSharpCode.AvalonEdit.Highlighting;
using System.Windows;
using System.Windows.Media;

namespace FDevelopmentEnv;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        Editor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinition("C#");
        Editor.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#1E1E1E"));
        Editor.Foreground = new SolidColorBrush(Colors.White);
    }
}
