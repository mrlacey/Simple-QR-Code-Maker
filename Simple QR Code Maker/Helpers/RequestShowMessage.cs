using Microsoft.UI.Xaml.Controls;

namespace Simple_QR_Code_Maker.Helpers;

public class RequestShowMessage
{
    public RequestShowMessage(string title, string message, InfoBarSeverity severity)
    {
        Title = title;
        Message = message;
        Severity = severity;
    }

    public string Message { get; set; }
    public string Title { get; set; }
    public InfoBarSeverity Severity { get; set; }
}
