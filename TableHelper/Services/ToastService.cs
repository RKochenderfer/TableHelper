using TableHelper.Layout;
using TableHelper.Models;

namespace TableHelper.Services;

/// <summary>
/// Services for displaying toast messages on the page
/// </summary>
public class ToastService
{
    private MainLayout? _layout;
    
    /// <summary>
    /// Registers the main layout
    /// </summary>
    /// <param name="layout"></param>
    public void RegisterLayout(MainLayout layout) => _layout = layout;

    /// <summary>
    /// Calls for the toast to be displayed on the main layout with the details of the request
    /// </summary>
    /// <param name="request"></param>
    public async Task ShowToast(ShowToastRequest request)
    {
        if (_layout is not null)
        {
            await _layout.ShowToast(request);
        }
    }
}