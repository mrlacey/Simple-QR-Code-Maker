using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media;
using Simple_QR_Code_Maker.Models;

namespace Simple_QR_Code_Maker.Controls;

public sealed partial class TextBorder : UserControl
{
    public event RoutedEventHandler? TextBorder_Click;

    public TextBorderInfo BorderInfo { get; set; }

    public TextBorder(ZXing.Result result)
    {
        InitializeComponent();

        BorderInfo = new(result);
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        TextBorder_Click?.Invoke(this, e);
    }
}

// SymbolIcon is sealed 😢 so we need to wrap things in a UserControl
public partial class SettingsSymbol : UserControl
{
    public SettingsSymbol()
    {
        this.Content = new SymbolIcon(Symbol.Setting);
    }
}






// FontIcon isn't sealed 🎉





public partial class ScanIcon : FontIcon
{
    public ScanIcon()
    {
        this.FontFamily = (FontFamily)Application.Current.Resources["SymbolThemeFontFamily"];
        this.Glyph = "\uEE6F";
    }
}


















// ViewBox is sealed, so we need a UserControl
public partial class ScanSymbol : UserControl
{
    public ScanSymbol()
    {
        this.Content = new Viewbox
        {
            Height = 16,
            Child = new FontIcon
            {
                FontFamily = (FontFamily)Application.Current.Resources["SymbolThemeFontFamily"],
                Glyph = "\uEE6F",
            }
        };
    }
}
