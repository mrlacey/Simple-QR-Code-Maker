using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Simple_QR_Code_Maker.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

namespace Simple_QR_Code_Maker.Controls;
public sealed partial class HistoryEntry : UserControl
{
    public HistoryEntry()
    {
        this.InitializeComponent();
    }

    public HistoryItem Data

    {
        get { return (HistoryItem)GetValue(DataProperty); }
        set { SetValue(DataProperty, value); }
    }

    public static readonly DependencyProperty DataProperty =
        DependencyProperty.Register("Data", typeof(HistoryItem), typeof(HistoryEntry), new PropertyMetadata(null));


}
