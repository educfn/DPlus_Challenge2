using dplus2.ViewModel;

namespace dplus2.View;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        ((MainPageViewModel)BindingContext).RedrawGraphicsView = GraphicsViewInvalidate;
    }

    private void GraphicsViewInvalidate()
    {
        graphicsView.Invalidate();
    }
}
