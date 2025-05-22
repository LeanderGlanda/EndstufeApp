namespace AudioControl
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        Esp32Client esp32Client;

        public MainPage()
        {
            InitializeComponent();
            esp32Client = new Esp32Client("http://10.171.183.126/");
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            count += 5;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);

            var Result = await esp32Client.MuteAsync();
            Console.WriteLine($"Response: {Result?.Resp}");
        }
    }

}
