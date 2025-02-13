namespace TipCalculator
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            tipPercentSlider.ValueChanged += OnTipPercentChanged;
            roundDown.Clicked += OnRoundDown;
            roundUp.Clicked += OnRoundUp;
        }

        private void CalculateTip()
        {
            // Validar y obtener el monto de la cuenta
            if (double.TryParse(billInput.Text, out double billAmount))
            {
                double tipPercentage = tipPercentSlider.Value;
                double tipAmount = billAmount * (tipPercentage / 100);
                double totalAmount = billAmount + tipAmount;

                // Actualizar los Labels
                tipOutput.Text = tipAmount.ToString("0.00");
                totalOutput.Text = totalAmount.ToString("0.00");
                tipPercent.Text = $"{tipPercentage}%";
            }
        }

        private void OnTipPercentChanged(object sender, ValueChangedEventArgs e)
        {
            CalculateTip();
        }

        private void OnNormalTip(object sender, EventArgs e)
        {
            tipPercentSlider.Value = 15;
        }

        private void OnGenerousTip(object sender, EventArgs e)
        {
            tipPercentSlider.Value = 20;
        }

        private void OnRoundDown(object sender, EventArgs e)
        {
            if (double.TryParse(totalOutput.Text, out double totalAmount))
            {
                totalOutput.Text = Math.Floor(totalAmount).ToString("0.00");
            }
        }

        private void OnRoundUp(object sender, EventArgs e)
        {
            if (double.TryParse(totalOutput.Text, out double totalAmount))
            {
                totalOutput.Text = Math.Ceiling(totalAmount).ToString("0.00");
            }
        }
    }
}
