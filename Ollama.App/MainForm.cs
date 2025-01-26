using System.Drawing.Imaging;
using System.Text;
using Microsoft.Extensions.Logging;

using OllamaSharp;

using Serilog.Sinks.InMemory;

using System.Windows.Forms;
using OllamaSharp.Models.Chat;

namespace Ollama.App;

public partial class MainForm : Form
{
    private readonly ILogger<MainForm> _logger;
    private long _logCounter = 0;

    private bool _isChatWithoutModelLoaded = false;
    private static readonly OllamaApiClient OllamaWithoutImages = new(new Uri("http://localhost:11434"));
    private const string ChatWithoutImagesModel = "llama3.1:8b";
    private static readonly Chat ChatWithoutImages = new(OllamaWithoutImages);

    private bool _isChatWithModelLoaded = false;
    private static readonly OllamaApiClient OllamaWithImages = new(new Uri("http://localhost:11434"));
    private const string ChatWithImagesModel = "llava:7b";
    private static readonly Chat ChatWithImages = new(OllamaWithImages);

    private bool _isProcessingScreenshot = false;

    public MainForm(ILogger<MainForm> logger)
    {
        _logger = logger;
        InitializeComponent();
        InitializeContextMenu();
    }

    private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
    {
        _logger.LogDebug("User clicked the About menu item.");
    }

    private void logTimer_Tick(object sender, EventArgs e)
    {
        var logs = InMemorySink.Instance.LogEvents.Skip((int)_logCounter).ToList();
        _logCounter += logs.Count;
        logsRichTextBox.AppendText(string.Join(Environment.NewLine, logs.Select(x => x.RenderMessage())));
        if (logs.Count > 0)
        {
            logsRichTextBox.AppendText(Environment.NewLine);
        }
    }

    private void sendChatButton_Click(object sender, EventArgs e)
    {
        var userInput = sendChatRichTextBox.Text;

        sendChatButton.Enabled = false;
        sendChatRichTextBox.Enabled = false;

        var message = userInput.Trim('\r', '\n');

        chatRichTextBox.SelectionStart = chatRichTextBox.TextLength;
        chatRichTextBox.SelectionLength = 0;
        chatRichTextBox.SelectionColor = Color.Blue;
        chatRichTextBox.SelectionFont = new Font(chatRichTextBox.Font, FontStyle.Bold);
        chatRichTextBox.AppendText("You: ");
        chatRichTextBox.SelectionFont = chatRichTextBox.Font;
        chatRichTextBox.SelectionColor = chatRichTextBox.ForeColor;

        chatRichTextBox.AppendText($"{message}{Environment.NewLine}");


        chatRichTextBox.SelectionStart = chatRichTextBox.TextLength;
        chatRichTextBox.SelectionLength = 0;
        chatRichTextBox.SelectionColor = Color.Red;
        chatRichTextBox.SelectionFont = new Font(chatRichTextBox.Font, FontStyle.Bold);
        chatRichTextBox.AppendText("OllamaWithoutImages: ");
        chatRichTextBox.SelectionFont = chatRichTextBox.Font;
        chatRichTextBox.SelectionColor = chatRichTextBox.ForeColor;

        _logger.LogDebug("User sent chat message: {UserInput}", message);

        Task.Factory.StartNew(async () => await SendChat(message))
            .Unwrap()
            .ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    _logger.LogError(task.Exception, "Error sending chat message: {UserInput}", userInput);
                    chatRichTextBox.AppendText($"Error: {task.Exception.Message}");
                }

                if (task.IsCompleted)
                {
                    sendChatRichTextBox.Clear();
                    sendChatButton.Enabled = true;
                    sendChatRichTextBox.Enabled = true;
                }

                sendChatRichTextBox.Focus();
                chatRichTextBox.AppendText(Environment.NewLine);
            }, TaskScheduler.FromCurrentSynchronizationContext());
    }

    private async Task SendChat(string message)
    {
        if (!_isChatWithoutModelLoaded)
        {
            _logger.LogWarning("Model not loaded yet. Skipping chat message.");
            return;
        }

        await foreach (var answerToken in ChatWithoutImages.SendAsync(message))
        {
            Invoke((MethodInvoker)delegate
            {
                chatRichTextBox.AppendText(answerToken);
            });
        }
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
        _logger.LogInformation("Loading model {Model}", ChatWithoutImagesModel);
        statusStripStatusLabel.Text = $"Loading model {ChatWithoutImagesModel}...";

        sendChatButton.Enabled = false;
        sendChatRichTextBox.Enabled = false;

        sendChatRichTextBox.Text = "Wait for the model to be ready.";

        Task.Factory.StartNew(async () => await LoadModelWithoutImages())
            .Unwrap()
            .ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    _logger.LogError(task.Exception, "Error loading model {Model}", ChatWithoutImagesModel);
                    statusStripStatusLabel.Text = $"Error loading model: {task.Exception.Message}";
                    sendChatRichTextBox.Text = "Please reload the model.";
                }

                if (task.IsCompleted)
                {
                    OllamaWithoutImages.SelectedModel = ChatWithoutImagesModel;
                    statusStripStatusLabel.Text = $"Model loaded: {ChatWithoutImagesModel}";
                    _logger.LogInformation("Model loaded: {Model}", ChatWithoutImagesModel);

                    sendChatButton.Enabled = true;
                    sendChatRichTextBox.Enabled = true;
                    modelStripLabel.Text = ChatWithoutImagesModel;

                    sendChatRichTextBox.Clear();
                    _isChatWithoutModelLoaded = true;
                }

                _logger.LogInformation("Finished loading model {Model}", ChatWithoutImagesModel);

            }, TaskScheduler.FromCurrentSynchronizationContext());

        _logger.LogInformation("Loading model {Model}", ChatWithImagesModel);
        statusStripStatusLabel.Text = $"Loading model {ChatWithImagesModel}...";

        Task.Factory.StartNew(async () => await LoadModelWithImages())
            .Unwrap()
            .ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    _logger.LogError(task.Exception, "Error loading model {Model}", ChatWithImagesModel);
                    statusStripStatusLabel.Text = $"Error loading model: {task.Exception.Message}";
                    sendChatRichTextBox.Text = "Please reload the model.";
                }
                if (task.IsCompleted)
                {
                    OllamaWithImages.SelectedModel = ChatWithImagesModel;
                    statusStripStatusLabel.Text = $"Model loaded: {ChatWithImagesModel}";
                    _logger.LogInformation("Model loaded: {Model}", ChatWithImagesModel);

                    sendChatButton.Enabled = true;
                    sendChatRichTextBox.Enabled = true;
                    modelStripLabel.Text = ChatWithImagesModel;

                    sendChatRichTextBox.Clear();
                    _isChatWithModelLoaded = true;
                }
                _logger.LogInformation("Finished loading model {Model}", ChatWithImagesModel);
            }, TaskScheduler.FromCurrentSynchronizationContext());

    }

    private async Task LoadModelWithoutImages()
    {
        await foreach (var status in OllamaWithoutImages.PullModelAsync(ChatWithoutImagesModel))
        {
            Invoke((MethodInvoker)delegate
            {
                statusStripStatusLabel.Text = $@"Loading model: {ChatWithoutImagesModel} {$"{status.Percent:N2}%"}% {status?.Status}";
                loadingStripProgressBar.Value = (int)(status?.Percent ?? 0);
            });
        }
    }

    private async Task LoadModelWithImages()
    {
        await foreach (var status in OllamaWithImages.PullModelAsync(ChatWithImagesModel))
        {
            Invoke((MethodInvoker)delegate
            {
                statusStripStatusLabel.Text = $@"Loading model: {ChatWithImagesModel} {$"{status.Percent:N2}%"}% {status?.Status}";
                loadingStripProgressBar.Value = (int)(status?.Percent ?? 0);
            });
        }
    }

    private void sendChatRichTextBox_KeyPress(object sender, KeyPressEventArgs e)
    {
        // If enter is hit, we send the message
        if (e.KeyChar == (char)Keys.Enter)
        {
            e.Handled = true;
            sendChatButton_Click(sender, e);
        }
    }

    private void notifyIcon_DoubleClick(object sender, EventArgs e)
    {
        Show();
        WindowState = FormWindowState.Normal;
        BringToFront();
    }

    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        if (e.CloseReason == CloseReason.UserClosing)
        {
            e.Cancel = true;
            this.Hide();
            notifyIcon.ShowBalloonTip(1000, "Ollagent", "Ollagent.", ToolTipIcon.Info);
        }
    }

    private void InitializeContextMenu()
    {
        var contextMenu = new ContextMenuStrip();
        var exitItem = new ToolStripMenuItem("Exit");
        exitItem.Click += ExitItem_Click;
        contextMenu.Items.Add(exitItem);
        notifyIcon.ContextMenuStrip = contextMenu;
    }


    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ExitItem_Click(sender, e);
    }

    private void ExitItem_Click(object sender, EventArgs e)
    {
        notifyIcon.Visible = false;
        Application.Exit();
    }

    private void screenshotTimer_Tick(object sender, EventArgs e)
    {
        if (_isProcessingScreenshot)
        {
            return;
        }

        if (!_isChatWithModelLoaded)
        {
            _logger.LogWarning("Model not loaded yet. Skipping screenshot.");
            return;
        }

        _isProcessingScreenshot = true;

        Task.Factory.StartNew(async () => await SendChatWithImage())
            .Unwrap()
            .ContinueWith(task =>
            {
                if (task.IsFaulted)
                {
                    _logger.LogError(task.Exception, "Error sending chat message with image: {Message}", task.Exception.Message);
                }

                if (task.IsCompleted)
                {
                    _logger.LogInformation("Screenshot processed.");
                }

                _isProcessingScreenshot = false;
            });
    }

    private async Task SendChatWithImage()
    {
        if (Screen.PrimaryScreen == null)
        {
            throw new InvalidOperationException("No screen found.");
        }
        var bounds = Screen.PrimaryScreen.Bounds;
        using var bitmap = new Bitmap(bounds.Width, bounds.Height);
        using (var g = Graphics.FromImage(bitmap))
        {
            g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
        }

        var scaledBitmap = new Bitmap(bitmap, new Size(800, 600));

        Directory.CreateDirectory("screenshots");

        var filePath = Path.Combine(
            "screenshots",
            $"Screenshot_{DateTime.Now:yyyyMMdd_HHmmss}.png");

        scaledBitmap.Save(filePath, ImageFormat.Png);

        _logger.LogInformation("Screenshot saved to {FilePath}", filePath);

        var imageBytes = await File.ReadAllBytesAsync(filePath);

        var responseBuilder = new StringBuilder();

        await foreach (var answerToken in ChatWithImages.SendAsync("Describe the image.", [imageBytes]))
        {
            responseBuilder.Append(answerToken);
        }

        _logger.LogInformation("Response: {Response} for screenshot {FilePath}", responseBuilder.ToString(), filePath);
    }
}