namespace AIChatbot
{
    public partial class Form1 : Form
    {
        private readonly ApiService _apiService;

        public Form1()
        {
            InitializeComponent();
            _apiService = new ApiService();

            // Welcome message
            AppendColoredText("AI: Hello! I am your AI assistant. How can I help you today?\n\n",
                Color.FromArgb(100, 200, 255));
        }

        private void AppendColoredText(string text, Color color)
        {
            txtChat.SelectionStart = txtChat.TextLength;
            txtChat.SelectionLength = 0;
            txtChat.SelectionColor = color;
            txtChat.AppendText(text);
            txtChat.SelectionColor = txtChat.ForeColor;
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            string userInput = txtInput.Text.Trim();

            if (string.IsNullOrEmpty(userInput))
            {
                MessageBox.Show("Please enter a message.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Show user message in yellow
            AppendColoredText($"You: {userInput}\n\n", Color.FromArgb(255, 210, 80));
            txtInput.Clear();

            btnSend.Enabled = false;
            btnSend.Text = "...";

            try
            {
                string response = await _apiService.SendMessageAsync(userInput);
                // Show AI response in light blue
                AppendColoredText($"AI: {response}\n\n", Color.FromArgb(100, 200, 255));
                AppendColoredText(new string('─', 60) + "\n\n", Color.FromArgb(50, 50, 80));
            }
            catch (Exception ex)
            {
                AppendColoredText($"Error: {ex.Message}\n\n", Color.FromArgb(255, 80, 80));
            }
            finally
            {
                btnSend.Enabled = true;
                btnSend.Text = "Send ➤";
                txtChat.ScrollToCaret();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtChat.Clear();
            AppendColoredText("AI: Chat cleared. How can I help you?\n\n",
                Color.FromArgb(100, 200, 255));
        }

        private void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSend_Click(sender, e);
                e.SuppressKeyPress = true;
            }
        }
    }
}