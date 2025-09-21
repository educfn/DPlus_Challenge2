using dplus2.Model;
using System.Windows.Input;

namespace dplus2.ViewModel
{
    public class MainPageViewModel
    {
        private Command ComandoIniciarSimulacao;

        public MainPageViewModel()
        {
            PrecoInicial = 0;
            Volatilidade = 0;
            MediaRetorno = 0;
            Tempo = 0;
            GraphicsDrawable = new();

            ComandoIniciarSimulacao = new Command(() => IniciarSimulacao());
        }

        public ICommand BtnIniciarSimulacao => ComandoIniciarSimulacao;
        public GraphicsDrawable GraphicsDrawable { get; set; }
        public float PrecoInicial { get; set; }
        public float Volatilidade { get; set; }
        public float MediaRetorno { get; set; }
        public int Tempo { get; set; }

        private void IniciarSimulacao()
        {
            if (Tempo <= 0) return;

            GraphicsDrawable.AddY_Points(BrownianMotion.GenerateBrownianMotion(Volatilidade, MediaRetorno, PrecoInicial, Tempo));
        }
    }
}
