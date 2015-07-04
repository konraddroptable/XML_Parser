namespace XMLParser
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
            this.button1 = new System.Windows.Forms.Button();
            this.stationFrom = new System.Windows.Forms.ComboBox();
            this.stationTo = new System.Windows.Forms.ComboBox();
            this.fromHour = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.loadXmlBtn = new System.Windows.Forms.Button();
            this.loadXsdBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblXml = new System.Windows.Forms.Label();
            this.lblXsd = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(42, 175);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Generuj XML";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // stationFrom
            // 
            this.stationFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stationFrom.FormattingEnabled = true;
            this.stationFrom.Location = new System.Drawing.Point(42, 50);
            this.stationFrom.Name = "stationFrom";
            this.stationFrom.Size = new System.Drawing.Size(210, 21);
            this.stationFrom.TabIndex = 1;
            // 
            // stationTo
            // 
            this.stationTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.stationTo.FormattingEnabled = true;
            this.stationTo.Location = new System.Drawing.Point(42, 95);
            this.stationTo.Name = "stationTo";
            this.stationTo.Size = new System.Drawing.Size(210, 21);
            this.stationTo.TabIndex = 2;
            // 
            // fromHour
            // 
            this.fromHour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fromHour.FormattingEnabled = true;
            this.fromHour.Location = new System.Drawing.Point(42, 139);
            this.fromHour.Name = "fromHour";
            this.fromHour.Size = new System.Drawing.Size(210, 21);
            this.fromHour.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(154, 175);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(98, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Zapisz XML";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(42, 318);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(210, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Waliduj XML";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Stacja początkowa:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Stacja końcowa:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Godzina:";
            // 
            // loadXmlBtn
            // 
            this.loadXmlBtn.Location = new System.Drawing.Point(42, 242);
            this.loadXmlBtn.Name = "loadXmlBtn";
            this.loadXmlBtn.Size = new System.Drawing.Size(98, 23);
            this.loadXmlBtn.TabIndex = 9;
            this.loadXmlBtn.Text = "Załaduj XML";
            this.loadXmlBtn.UseVisualStyleBackColor = true;
            this.loadXmlBtn.Click += new System.EventHandler(this.loadXmlBtn_Click);
            // 
            // loadXsdBtn
            // 
            this.loadXsdBtn.Location = new System.Drawing.Point(42, 271);
            this.loadXsdBtn.Name = "loadXsdBtn";
            this.loadXsdBtn.Size = new System.Drawing.Size(98, 23);
            this.loadXsdBtn.TabIndex = 10;
            this.loadXsdBtn.Text = "Załaduj XSD";
            this.loadXsdBtn.UseVisualStyleBackColor = true;
            this.loadXsdBtn.Click += new System.EventHandler(this.loadXsdBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(39, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(176, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Generowanie dokumentu XML";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(42, 226);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(158, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Walidacja dokumentu XML";
            // 
            // lblXml
            // 
            this.lblXml.AutoSize = true;
            this.lblXml.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblXml.Location = new System.Drawing.Point(151, 247);
            this.lblXml.Name = "lblXml";
            this.lblXml.Size = new System.Drawing.Size(0, 13);
            this.lblXml.TabIndex = 13;
            // 
            // lblXsd
            // 
            this.lblXsd.AutoSize = true;
            this.lblXsd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblXsd.Location = new System.Drawing.Point(151, 276);
            this.lblXsd.Name = "lblXsd";
            this.lblXsd.Size = new System.Drawing.Size(0, 13);
            this.lblXsd.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 362);
            this.Controls.Add(this.lblXsd);
            this.Controls.Add(this.lblXml);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.loadXsdBtn);
            this.Controls.Add(this.loadXmlBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.fromHour);
            this.Controls.Add(this.stationTo);
            this.Controls.Add(this.stationFrom);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Rozkład Jazdy SKM";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox stationFrom;
        private System.Windows.Forms.ComboBox stationTo;
        private System.Windows.Forms.ComboBox fromHour;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button loadXmlBtn;
        private System.Windows.Forms.Button loadXsdBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblXml;
        private System.Windows.Forms.Label lblXsd;
    }
}

