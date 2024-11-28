using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

namespace Simple_QR_Code_Maker.Controls;

public sealed partial class IconTextButton : Button
{
    public IconTextButton()
    {
        this.InitializeComponent();
    }

    public string Text
    {
        get { return (string)GetValue(TextProperty); }
        set { SetValue(TextProperty, value); }
    }

    // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty TextProperty =
        DependencyProperty.Register("Text", typeof(string), typeof(IconTextButton), new PropertyMetadata(null));

    public UIElement Icon
    {
        get { return (UIElement)GetValue(IconProperty); }
        set { SetValue(IconProperty, value); }
    }

    // Using a DependencyProperty as the backing store for Icon.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty IconProperty =
        DependencyProperty.Register("Icon", typeof(UIElement), typeof(IconTextButton), new PropertyMetadata(null));

}
