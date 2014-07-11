namespace RESTUtility
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
			this.baseUri = new System.Windows.Forms.TextBox();
			this.modeSelect = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.requestText = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.responseText = new System.Windows.Forms.TextBox();
			this.goButton = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.protocol = new System.Windows.Forms.ComboBox();
			this.requestUri = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.mediaType = new System.Windows.Forms.ComboBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.uriDisplay = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// baseUri
			// 
			this.baseUri.Location = new System.Drawing.Point(104, 21);
			this.baseUri.Name = "baseUri";
			this.baseUri.Size = new System.Drawing.Size(380, 20);
			this.baseUri.TabIndex = 1;
			this.baseUri.TextChanged += new System.EventHandler(this.UpdateUriDisplay);
			// 
			// modeSelect
			// 
			this.modeSelect.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.modeSelect.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.modeSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.modeSelect.FormattingEnabled = true;
			this.modeSelect.Items.AddRange(new object[] {
            "GET",
            "POST",
            "PUT",
            "DELETE"});
			this.modeSelect.Location = new System.Drawing.Point(104, 61);
			this.modeSelect.MaxDropDownItems = 4;
			this.modeSelect.Name = "modeSelect";
			this.modeSelect.Size = new System.Drawing.Size(87, 21);
			this.modeSelect.TabIndex = 4;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(505, 5);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(63, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Request Uri";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(101, 45);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(43, 13);
			this.label2.TabIndex = 0;
			this.label2.Text = "Method";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 92);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(47, 13);
			this.label3.TabIndex = 0;
			this.label3.Text = "Request";
			// 
			// requestText
			// 
			this.requestText.Location = new System.Drawing.Point(11, 109);
			this.requestText.Multiline = true;
			this.requestText.Name = "requestText";
			this.requestText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.requestText.Size = new System.Drawing.Size(748, 229);
			this.requestText.TabIndex = 5;
			this.requestText.WordWrap = false;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(8, 341);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(55, 13);
			this.label4.TabIndex = 0;
			this.label4.Text = "Response";
			// 
			// responseText
			// 
			this.responseText.CausesValidation = false;
			this.responseText.Cursor = System.Windows.Forms.Cursors.Default;
			this.responseText.Location = new System.Drawing.Point(11, 357);
			this.responseText.Multiline = true;
			this.responseText.Name = "responseText";
			this.responseText.ReadOnly = true;
			this.responseText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.responseText.Size = new System.Drawing.Size(748, 258);
			this.responseText.TabIndex = 0;
			this.responseText.TabStop = false;
			this.responseText.WordWrap = false;
			// 
			// goButton
			// 
			this.goButton.BackColor = System.Drawing.Color.MediumSeaGreen;
			this.goButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold);
			this.goButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.goButton.Location = new System.Drawing.Point(622, 47);
			this.goButton.Name = "goButton";
			this.goButton.Size = new System.Drawing.Size(137, 35);
			this.goButton.TabIndex = 6;
			this.goButton.Text = "Go!";
			this.goButton.UseVisualStyleBackColor = false;
			this.goButton.MouseClick += new System.Windows.Forms.MouseEventHandler(this.goButton_MouseClick);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(13, 45);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(36, 13);
			this.label5.TabIndex = 0;
			this.label5.Text = "Media";
			// 
			// protocol
			// 
			this.protocol.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.protocol.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.protocol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.protocol.FormattingEnabled = true;
			this.protocol.Items.AddRange(new object[] {
            "HTTP",
            "HTTPS"});
			this.protocol.Location = new System.Drawing.Point(12, 21);
			this.protocol.Name = "protocol";
			this.protocol.Size = new System.Drawing.Size(60, 21);
			this.protocol.TabIndex = 0;
			this.protocol.SelectedIndexChanged += new System.EventHandler(this.UpdateUriDisplay);
			// 
			// requestUri
			// 
			this.requestUri.Location = new System.Drawing.Point(508, 21);
			this.requestUri.Name = "requestUri";
			this.requestUri.Size = new System.Drawing.Size(251, 20);
			this.requestUri.TabIndex = 2;
			this.requestUri.TextChanged += new System.EventHandler(this.UpdateUriDisplay);
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(101, 5);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(53, 13);
			this.label7.TabIndex = 0;
			this.label7.Text = "Base Uri";
			// 
			// mediaType
			// 
			this.mediaType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.mediaType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.mediaType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.mediaType.FormattingEnabled = true;
			this.mediaType.Items.AddRange(new object[] {
            "JSON",
            "XML"});
			this.mediaType.Location = new System.Drawing.Point(11, 61);
			this.mediaType.Name = "mediaType";
			this.mediaType.Size = new System.Drawing.Size(87, 21);
			this.mediaType.TabIndex = 3;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(13, 5);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(46, 13);
			this.label6.TabIndex = 0;
			this.label6.Text = "Protocol";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(78, 24);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(20, 13);
			this.label8.TabIndex = 16;
			this.label8.Text = "://";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(490, 24);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(12, 13);
			this.label9.TabIndex = 17;
			this.label9.Text = "/";
			// 
			// uriDisplay
			// 
			this.uriDisplay.Cursor = System.Windows.Forms.Cursors.Default;
			this.uriDisplay.Location = new System.Drawing.Point(198, 61);
			this.uriDisplay.MinimumSize = new System.Drawing.Size(4, 21);
			this.uriDisplay.Name = "uriDisplay";
			this.uriDisplay.ReadOnly = true;
			this.uriDisplay.Size = new System.Drawing.Size(397, 20);
			this.uriDisplay.TabIndex = 18;
			this.uriDisplay.TabStop = false;
			this.uriDisplay.WordWrap = false;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(195, 44);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(70, 13);
			this.label10.TabIndex = 19;
			this.label10.Text = "Formatted Uri";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(766, 624);
			this.Controls.Add(this.label10);
			this.Controls.Add(this.uriDisplay);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.mediaType);
			this.Controls.Add(this.requestUri);
			this.Controls.Add(this.protocol);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.goButton);
			this.Controls.Add(this.responseText);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.requestText);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.modeSelect);
			this.Controls.Add(this.baseUri);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "Form1";
			this.Text = "REST Utility";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox baseUri;
		private System.Windows.Forms.ComboBox modeSelect;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox requestText;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox responseText;
		private System.Windows.Forms.Button goButton;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ComboBox protocol;
		private System.Windows.Forms.TextBox requestUri;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox mediaType;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox uriDisplay;
		private System.Windows.Forms.Label label10;
	}
}

