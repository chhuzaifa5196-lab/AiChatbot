namespace AIChatbot
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private RichTextBox txtChat;
        private TextBox txtInput;
        private Button btnSend;
        private Button btnClear;
        private Label lblTitle;
        private Label lblSubtitle;
        private Panel topPanel;
        private Panel bottomPanel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtChat = new RichTextBox();
            this.txtInput = new TextBox();
            this.btnSend = new Button();
            this.btnClear = new Button();
            this.lblTitle = new Label();
            this.lblSubtitle = new Label();
            this.topPanel = new Panel();
            this.bottomPanel = new Panel();

            this.SuspendLayout();

            // ── Form ──────────────────────────────────────────
            this.Text = "AI Chatbot";
            this.Size = new Size(780, 650);
            this.MinimumSize = new Size(780, 650);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(18, 18, 30);
            this.ForeColor = Color.White;

            // ── Top Panel (Header) ────────────────────────────
            this.topPanel.Dock = DockStyle.Top;
            this.topPanel.Height = 70;
            this.topPanel.BackColor = Color.FromArgb(25, 25, 45);
            this.topPanel.Padding = new Padding(20, 0, 0, 0);

            // Title
            this.lblTitle.Text = "⚡ AI Chatbot";
            this.lblTitle.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.FromArgb(100, 200, 255);
            this.lblTitle.Location = new Point(20, 10);
            this.lblTitle.Size = new Size(280, 35);
            this.lblTitle.BackColor = Color.Transparent;

            // Subtitle
            this.lblSubtitle.Text = "Powered by Groq · llama-3.3-70b";
            this.lblSubtitle.Font = new Font("Segoe UI", 8);
            this.lblSubtitle.ForeColor = Color.FromArgb(120, 120, 160);
            this.lblSubtitle.Location = new Point(22, 44);
            this.lblSubtitle.Size = new Size(280, 18);
            this.lblSubtitle.BackColor = Color.Transparent;

            this.topPanel.Controls.Add(lblTitle);
            this.topPanel.Controls.Add(lblSubtitle);

            // ── Chat Display ──────────────────────────────────
            this.txtChat.Location = new Point(20, 85);
            this.txtChat.Size = new Size(730, 440);
            this.txtChat.Font = new Font("Segoe UI", 10.5f);
            this.txtChat.ReadOnly = true;
            this.txtChat.BackColor = Color.FromArgb(28, 28, 45);
            this.txtChat.ForeColor = Color.FromArgb(220, 220, 240);
            this.txtChat.BorderStyle = BorderStyle.None;
            this.txtChat.ScrollBars = RichTextBoxScrollBars.Vertical;
            this.txtChat.Padding = new Padding(10);

            // ── Bottom Panel ──────────────────────────────────
            this.bottomPanel.Dock = DockStyle.Bottom;
            this.bottomPanel.Height = 70;
            this.bottomPanel.BackColor = Color.FromArgb(25, 25, 45);
            this.bottomPanel.Padding = new Padding(15, 10, 15, 10);

            // Input Box
            this.txtInput.Location = new Point(15, 18);
            this.txtInput.Size = new Size(550, 35);
            this.txtInput.Font = new Font("Segoe UI", 11);
            this.txtInput.BackColor = Color.FromArgb(40, 40, 65);
            this.txtInput.ForeColor = Color.White;
            this.txtInput.BorderStyle = BorderStyle.FixedSingle;
            this.txtInput.KeyDown += new KeyEventHandler(this.txtInput_KeyDown);

            // Send Button
            this.btnSend.Text = "Send ➤";
            this.btnSend.Location = new Point(580, 16);
            this.btnSend.Size = new Size(85, 36);
            this.btnSend.BackColor = Color.FromArgb(80, 160, 255);
            this.btnSend.ForeColor = Color.White;
            this.btnSend.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            this.btnSend.FlatStyle = FlatStyle.Flat;
            this.btnSend.FlatAppearance.BorderSize = 0;
            this.btnSend.Cursor = Cursors.Hand;
            this.btnSend.Click += new EventHandler(this.btnSend_Click);

            // Clear Button
            this.btnClear.Text = "🗑 Clear";
            this.btnClear.Location = new Point(675, 16);
            this.btnClear.Size = new Size(80, 36);
            this.btnClear.BackColor = Color.FromArgb(60, 60, 90);
            this.btnClear.ForeColor = Color.FromArgb(200, 200, 220);
            this.btnClear.Font = new Font("Segoe UI", 9);
            this.btnClear.FlatStyle = FlatStyle.Flat;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.Cursor = Cursors.Hand;
            this.btnClear.Click += new EventHandler(this.btnClear_Click);

            this.bottomPanel.Controls.Add(txtInput);
            this.bottomPanel.Controls.Add(btnSend);
            this.bottomPanel.Controls.Add(btnClear);

            // ── Add to Form ───────────────────────────────────
            this.Controls.Add(txtChat);
            this.Controls.Add(topPanel);
            this.Controls.Add(bottomPanel);

            this.ResumeLayout(false);
        }
    }
}