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
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(127, 122);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Pobierz XML";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // stationFrom
            // 
            this.stationFrom.FormattingEnabled = true;
            this.stationFrom.Location = new System.Drawing.Point(42, 50);
            this.stationFrom.Name = "stationFrom";
            this.stationFrom.Size = new System.Drawing.Size(183, 21);
            this.stationFrom.TabIndex = 1;
            // 
            // stationTo
            // 
            this.stationTo.FormattingEnabled = true;
            this.stationTo.Location = new System.Drawing.Point(42, 87);
            this.stationTo.Name = "stationTo";
            this.stationTo.Size = new System.Drawing.Size(183, 21);
            this.stationTo.TabIndex = 2;
            // 
            // fromHour
            // 
            this.fromHour.FormattingEnabled = true;
            this.fromHour.Location = new System.Drawing.Point(42, 124);
            this.fromHour.Name = "fromHour";
            this.fromHour.Size = new System.Drawing.Size(79, 21);
            this.fromHour.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(42, 152);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(79, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "Zapisz";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(127, 152);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(98, 23);
            this.button3.TabIndex = 5;
            this.button3.Text = "Waliduj XML";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 210);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.fromHour);
            this.Controls.Add(this.stationTo);
            this.Controls.Add(this.stationFrom);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Rozkład Jazdy SKM";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox stationFrom;
        private System.Windows.Forms.ComboBox stationTo;
        private System.Windows.Forms.ComboBox fromHour;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}

