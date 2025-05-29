using Ciphers.Ciphers;

namespace Ciphers.Client;

public partial class MainForm : Form
{
    private readonly IEncoder<string> encoder;
    
    public MainForm(IEncoder<string> encoder)
    {
        this.encoder = encoder;
        InitializeComponent();
    }

    private void Encode(object sender, EventArgs e)
    {
        var text = textInput.Text;
        var key = keyInput.Text;
        var result = encoder.Encode(text, key);

        if (result.IsFailure)
        {
            MessageBox.Show(result.Error, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        
        processingText.Text = result.Value.ReceivedText;
        resultOutput.Text = result.Value.ResultText;
    }

    private void Decode(object sender, EventArgs e)
    {
        var text = textInput.Text;
        var key = keyInput.Text;
        var result = encoder.Decode(text, key);
        if (result.IsFailure)
        {
            MessageBox.Show(result.Error, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        processingText.Text = result.Value.ReceivedText;
        resultOutput.Text = result.Value.ResultText;
        
    }
    
    private void Clean(object sender, EventArgs e)
    {
        processingText.Text = "";
        resultOutput.Text = "";
        textInput.Text = "";
        keyInput.Text = "";
    }

    private void Hack(object sender, EventArgs e)
    {
        var text = textInput.Text;
        var result = encoder.Hack(text);
        if (result.IsFailure)
        {
            MessageBox.Show(result.Error, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        resultOutput.Text = result.Value.ResultText; 
        processingText.Text = result.Value.ReceivedText;
        keyInput.Text = result.Value.Key;
    }
}