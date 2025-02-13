namespace Notes // En lugar de Ejercicio2
{
    public partial class MainPage : ContentPage
    {
        string _fileName = Path.Combine(FileSystem.AppDataDirectory, "notes.txt");

        public const double MyFontSize = 28;

        public MainPage()
        {
            InitializeComponent();

            if (File.Exists(_fileName))
            {
                editor.Text = File.ReadAllText(_fileName);
            }
        }

        private void OnSaveButtonClicked(object sender, EventArgs e)
        {
            File.WriteAllText(_fileName, editor.Text);
            DisplayAlert("Success", "Note saved!", "OK");
        }

        private void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            if (File.Exists(_fileName))
            {
                File.Delete(_fileName);
                editor.Text = string.Empty;
                DisplayAlert("Success", "Note deleted!", "OK");
            }
        }
    }
}
