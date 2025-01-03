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
