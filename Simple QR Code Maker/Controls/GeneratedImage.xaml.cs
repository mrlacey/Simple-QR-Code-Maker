using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Media.Imaging;
using Simple_QR_Code_Maker.Extensions;
using Simple_QR_Code_Maker.Helpers;
using Simple_QR_Code_Maker.Models;
using Windows.ApplicationModel.DataTransfer;
using Windows.Storage;

namespace Simple_QR_Code_Maker.Controls;

public sealed partial class GeneratedImage : UserControl
{
    public GeneratedImage()
    {
        this.InitializeComponent();
    }

    public BarcodeImageItem Data
    {
        get { return (BarcodeImageItem)GetValue(DataProperty); }
        set { SetValue(DataProperty, value); }
    }

    public static readonly DependencyProperty DataProperty =
        DependencyProperty.Register("Data", typeof(BarcodeImageItem), typeof(GeneratedImage), new PropertyMetadata(null));


    //public Windows.UI.Color BackgroundColor
    //{
    //    get { return (Windows.UI.Color)GetValue(BackgroundColorProperty); }
    //    set { SetValue(BackgroundColorProperty, value); }
    //}

    //public static readonly DependencyProperty BackgroundColorProperty =
    //    DependencyProperty.Register("BackgroundColor", typeof(Windows.UI.Color), typeof(GeneratedImage), new PropertyMetadata(Windows.UI.Color.FromArgb(255, 255, 255, 255)));

    //public Windows.UI.Color ForegroundColor
    //{
    //    get { return (Windows.UI.Color)GetValue(ForegroundColorProperty); }
    //    set { SetValue(ForegroundColorProperty, value); }
    //}

    //public static readonly DependencyProperty ForegroundColorProperty =
    //    DependencyProperty.Register("ForegroundColor", typeof(Windows.UI.Color), typeof(GeneratedImage), new PropertyMetadata(Windows.UI.Color.FromArgb(255, 0, 0, 0)));

    //public ErrorCorrectionOptions ErrorCorrection
    //{
    //    get { return (ErrorCorrectionOptions)GetValue(ErrorCorrectionProperty); }
    //    set { SetValue(ErrorCorrectionProperty, value); }
    //}

    //public static readonly DependencyProperty ErrorCorrectionProperty =
    //    DependencyProperty.Register("ErrorCorrection", typeof(ErrorCorrectionOptions), typeof(GeneratedImage), new PropertyMetadata(new ErrorCorrectionOptions("Medium 15%", ZXing.QrCode.Internal.ErrorCorrectionLevel.M)));




    private async void QrCodeImage_DragStarting(UIElement sender, DragStartingEventArgs args)
    {
        if (sender is not Image image || image.Source is not WriteableBitmap bitmap)
            return;

        DragOperationDeferral deferral = args.GetDeferral();
        StorageFolder folder = ApplicationData.Current.LocalCacheFolder;
        string? imageNameFileName = $"{ToolTipService.GetToolTip(image)}" ?? "QR_Code";
        // remove characters that are not allowed in file names
        imageNameFileName = imageNameFileName.ToSafeFileName();
        imageNameFileName += ".png";
        StorageFile file = await folder.CreateFileAsync(imageNameFileName, CreationCollisionOption.ReplaceExisting);
        bool success = await bitmap.SavePngToStorageFile(file);

        if (!success)
        {
            deferral.Complete();
            return;
        }

        // ViewModel.SaveCurrentStateToHistory();
        args.Data.SetStorageItems(new[] { file });
        args.Data.RequestedOperation = DataPackageOperation.Copy;
        deferral.Complete();
    }

}
