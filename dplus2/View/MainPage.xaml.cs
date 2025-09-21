namespace dplus2.View;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private void BtnSimulacao_Clicked(object sender, EventArgs e)
    {
        graphicsView.Invalidate();
    }
}
