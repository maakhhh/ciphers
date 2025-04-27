using System.ComponentModel;

namespace Ciphers.Client;

partial class MainForm
{
    private IContainer components = null;
    
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        encodeButton = new System.Windows.Forms.Button();
        decodeButton = new System.Windows.Forms.Button();
        hackButton = new System.Windows.Forms.Button();
        textInput = new System.Windows.Forms.TextBox();
        textInputHeader = new System.Windows.Forms.Label();
        processingText = new System.Windows.Forms.TextBox();
        resultOutput = new System.Windows.Forms.TextBox();
        processingTextHeader = new System.Windows.Forms.Label();
        resultHeader = new System.Windows.Forms.Label();
        keyInput = new System.Windows.Forms.TextBox();
        keyHeader = new System.Windows.Forms.Label();
        resultKey = new System.Windows.Forms.TextBox();
        resultKeuHeader = new System.Windows.Forms.Label();
        SuspendLayout();
        // 
        // encodeButton
        // 
        encodeButton.BackColor = System.Drawing.Color.FromArgb(((int)((byte)197)), ((int)((byte)198)), ((int)((byte)199)));
        encodeButton.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)31)), ((int)((byte)40)), ((int)((byte)51)));
        encodeButton.Font = new System.Drawing.Font("Bahnschrift SemiBold", 10F);
        encodeButton.Location = new System.Drawing.Point(107, 526);
        encodeButton.Name = "encodeButton";
        encodeButton.Size = new System.Drawing.Size(129, 30);
        encodeButton.TabIndex = 0;
        encodeButton.Text = "Зашифровать";
        encodeButton.UseVisualStyleBackColor = false;
        encodeButton.Click += Encode;
        // 
        // decodeButton
        // 
        decodeButton.Location = new System.Drawing.Point(342, 526);
        decodeButton.Name = "decodeButton";
        decodeButton.BackColor = System.Drawing.Color.FromArgb(((int)((byte)197)), ((int)((byte)198)), ((int)((byte)199)));
        decodeButton.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)31)), ((int)((byte)40)), ((int)((byte)51)));
        decodeButton.Font = new System.Drawing.Font("Bahnschrift SemiBold", 10F);
        decodeButton.Size = new System.Drawing.Size(129, 30);
        decodeButton.TabIndex = 1;
        decodeButton.Text = "Расшифровать";
        decodeButton.UseVisualStyleBackColor = true;
        decodeButton.Click += Decode;
        // 
        // hackButton
        // 
        hackButton.BackColor = System.Drawing.Color.FromArgb(((int)((byte)69)), ((int)((byte)162)), ((int)((byte)158)));
        hackButton.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)31)), ((int)((byte)40)), ((int)((byte)51)));
        hackButton.Font = new System.Drawing.Font("Bahnschrift SemiBold", 10F);
        hackButton.Location = new System.Drawing.Point(224, 576);
        hackButton.Name = "hackButton";
        hackButton.Size = new System.Drawing.Size(129, 30);
        hackButton.TabIndex = 2;
        hackButton.Text = "Взломать";
        hackButton.UseVisualStyleBackColor = false;
        hackButton.Click += Hack;
        // 
        // textInput
        // 
        textInput.BackColor = System.Drawing.Color.White;
        textInput.Font = new System.Drawing.Font("Bahnschrift SemiBold", 12F);
        textInput.Location = new System.Drawing.Point(35, 50);
        textInput.Multiline = true;
        textInput.Name = "textInput";
        textInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        textInput.Size = new System.Drawing.Size(513, 387);
        textInput.TabIndex = 3;
        // 
        // textInputHeader
        // 
        textInputHeader.BackColor = System.Drawing.Color.Transparent;
        textInputHeader.Font = new System.Drawing.Font("Bahnschrift SemiBold", 15F);
        textInputHeader.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)102)), ((int)((byte)252)), ((int)((byte)241)));
        textInputHeader.Location = new System.Drawing.Point(35, 20);
        textInputHeader.Name = "textInputHeader";
        textInputHeader.Size = new System.Drawing.Size(225, 27);
        textInputHeader.TabIndex = 4;
        textInputHeader.Text = "Исходный текст";
        // 
        // processingText
        // 
        processingText.BackColor = System.Drawing.Color.White;
        processingText.Font = new System.Drawing.Font("Bahnschrift SemiBold", 12F);
        processingText.Location = new System.Drawing.Point(573, 50);
        processingText.Multiline = true;
        processingText.Name = "processingText";
        processingText.ReadOnly = true;
        processingText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        processingText.Size = new System.Drawing.Size(410, 227);
        processingText.TabIndex = 5;
        // 
        // resultOutput
        // 
        resultOutput.Location = new System.Drawing.Point(573, 317);
        resultOutput.Font = new System.Drawing.Font("Bahnschrift SemiBold", 12F);
        resultOutput.Multiline = true;
        resultOutput.Name = "resultOutput";
        resultOutput.ReadOnly = true;
        resultOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        resultOutput.Size = new System.Drawing.Size(410, 239);
        resultOutput.TabIndex = 6;
        // 
        // processingTextHeader
        // 
        processingTextHeader.Font = new System.Drawing.Font("Bahnschrift SemiBold", 14F);
        processingTextHeader.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)102)), ((int)((byte)252)), ((int)((byte)241)));
        processingTextHeader.Location = new System.Drawing.Point(573, 23);
        processingTextHeader.Name = "processingTextHeader";
        processingTextHeader.Size = new System.Drawing.Size(225, 24);
        processingTextHeader.TabIndex = 7;
        processingTextHeader.Text = "Обработанный текст";
        // 
        // resultHeader
        // 
        resultHeader.Font = new System.Drawing.Font("Bahnschrift SemiBold", 14F);
        resultHeader.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)102)), ((int)((byte)252)), ((int)((byte)241)));
        resultHeader.Location = new System.Drawing.Point(573, 291);
        resultHeader.Name = "resultHeader";
        resultHeader.Size = new System.Drawing.Size(225, 23);
        resultHeader.TabIndex = 8;
        resultHeader.Text = "Результат";
        // 
        // keyInput
        // 
        keyInput.Location = new System.Drawing.Point(35, 484);
        keyInput.Font = new System.Drawing.Font("Bahnschrift SemiBold", 12F);
        keyInput.MaxLength = 100;
        keyInput.Name = "keyInput";
        keyInput.Size = new System.Drawing.Size(513, 23);
        keyInput.TabIndex = 9;
        // 
        // keyHeader
        // 
        keyHeader.Font = new System.Drawing.Font("Bahnschrift SemiBold", 15F);
        keyHeader.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)102)), ((int)((byte)252)), ((int)((byte)241)));
        keyHeader.Location = new System.Drawing.Point(35, 454);
        keyHeader.Name = "keyHeader";
        keyHeader.Size = new System.Drawing.Size(225, 27);
        keyHeader.TabIndex = 10;
        keyHeader.Text = "Ключ";
        // 
        // resultKey
        // 
        resultKey.Font = new System.Drawing.Font("Bahnschrift SemiBold", 12F);
        resultKey.Location = new System.Drawing.Point(573, 583);
        resultKey.Name = "resultKey";
        resultKey.ReadOnly = true;
        resultKey.Size = new System.Drawing.Size(410, 23);
        resultKey.TabIndex = 11;
        // 
        // resultKeuHeader
        // 
        resultKeuHeader.Font = new System.Drawing.Font("Bahnschrift SemiBold", 14F);
        resultKeuHeader.ForeColor = System.Drawing.Color.FromArgb(((int)((byte)102)), ((int)((byte)252)), ((int)((byte)241)));
        resultKeuHeader.Location = new System.Drawing.Point(573, 559);
        resultKeuHeader.Name = "resultKeuHeader";
        resultKeuHeader.Size = new System.Drawing.Size(225, 23);
        resultKeuHeader.TabIndex = 12;
        resultKeuHeader.Text = "Ключ";
        // 
        // MainForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.FromArgb(((int)((byte)11)), ((int)((byte)12)), ((int)((byte)16)));
        ClientSize = new System.Drawing.Size(1016, 636);
        Controls.Add(resultKeuHeader);
        Controls.Add(resultKey);
        Controls.Add(keyHeader);
        Controls.Add(keyInput);
        Controls.Add(resultHeader);
        Controls.Add(processingTextHeader);
        Controls.Add(resultOutput);
        Controls.Add(processingText);
        Controls.Add(textInputHeader);
        Controls.Add(textInput);
        Controls.Add(hackButton);
        Controls.Add(decodeButton);
        Controls.Add(encodeButton);
        Text = "Шифр Виженера";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Label resultKeuHeader;


    private System.Windows.Forms.TextBox resultKey;

    private System.Windows.Forms.TextBox keyInput;
    private System.Windows.Forms.Label keyHeader;

    private System.Windows.Forms.Label resultHeader;

    private System.Windows.Forms.Label processingTextHeader;

    private System.Windows.Forms.TextBox resultOutput;

    private System.Windows.Forms.TextBox processingText;

    private System.Windows.Forms.Label textInputHeader;

    private System.Windows.Forms.TextBox textInput;

    private System.Windows.Forms.Button encodeButton;
    private System.Windows.Forms.Button decodeButton;
    private System.Windows.Forms.Button hackButton;

    #endregion
}