using dplus2.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace dplus2.ViewModel
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private Command ComandoIniciarSimulacao;
        private float _precoInicial;
        private float _volatilidade;
        private float _mediaRetorno;
        private int _quantidadeDeSimulacoes;
        private int _tempo;

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
        public Action? RedrawGraphicsView { get; set; }
        public float PrecoInicial 
        { 
            get => _precoInicial;
            set
            {
                if (_precoInicial != value)
                {
                    _precoInicial = value;
                    OnPropertyChanged();
                }
            }
        }
        public float Volatilidade
        { 
            get => _volatilidade;
            set
            {
                if (_volatilidade != value)
                {
                    _volatilidade = value;
                    OnPropertyChanged();
                }
            }
        }
        public float MediaRetorno
        { 
            get => _mediaRetorno;
            set
            {
                if (_mediaRetorno != value)
                {
                    _mediaRetorno = value;
                    OnPropertyChanged();
                }
            }
        }
        public int QuantidadeDeSimulacoes
        { 
            get => _quantidadeDeSimulacoes;
            set
            {
                if (_quantidadeDeSimulacoes != value)
                {
                    _quantidadeDeSimulacoes = value;
                    OnPropertyChanged();
                }
            }
        }
        public int Tempo
        { 
            get => _tempo;
            set
            {
                if (_tempo != value)
                {
                    _tempo = value;
                    OnPropertyChanged();
                }
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void IniciarSimulacao()
        {
            if (Tempo <= 0 || RedrawGraphicsView == null) return;

            double[][] matrix_ypoints = new double[QuantidadeDeSimulacoes][];

            for (int i = 0; i < QuantidadeDeSimulacoes; i++)
            {
                matrix_ypoints[i] = BrownianMotion.GenerateBrownianMotion(Volatilidade, MediaRetorno, PrecoInicial, Tempo);
            }

            GraphicsDrawable.Add_YPoints_And_NSimulation(matrix_ypoints, QuantidadeDeSimulacoes);
            RedrawGraphicsView.Invoke();
        }
    }
}
