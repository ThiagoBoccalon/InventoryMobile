namespace InventoryMobile.Views;

public partial class AddProductPage : ContentPage
{
    private readonly AddProductViewModel _viewModel;
	public AddProductPage(AddProductViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = _viewModel = viewModel;
    }

    private void cameraView_BarcodeDetected(object sender, Camera.MAUI.ZXingHelper.BarcodeEventArgs args)
    {
        MainThread.BeginInvokeOnMainThread(() =>
        {
            _viewModel.Codebar = args.Result[0].Text;
        });
    }

    private async void cameraView_CamerasLoaded(object sender, EventArgs e)
    {
        if(cameraView.Cameras.Count > 0)
        {
            cameraView.Camera = cameraView.Cameras.First();
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await cameraView.StopCameraAsync();
                await cameraView.StartCameraAsync();
            });                
        }
    }

    protected override async void OnDisappearing()
    {
        base.OnDisappearing();
        await cameraView.StopCameraAsync();
    }
}