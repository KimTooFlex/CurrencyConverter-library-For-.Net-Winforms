# Developed by KimToo

 Jsut a simple currency converter .
 

### Installation
 Add the dll to your reference
 
 ### code
 
 ```csharp
  public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            currencyConverter1.Convert(1000, "GBP", "KES");
        }

        private void currencyConverter1_onConvertSeccess(object sender, EventArgs e)
        {
            MessageBox.Show(currencyConverter1.Value.ToString());
        }

        private void currencyConverter1_onConvertFail(object sender, EventArgs e)
        {
            MessageBox.Show(((Exception)sender).Message);
        }


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
            this.currencyConverter1 = new ktf.CurrencyConverter();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(90, 112);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // currencyConverter1
            // 
            this.currencyConverter1.Location = new System.Drawing.Point(102, 27);
            this.currencyConverter1.Name = "currencyConverter1";
            this.currencyConverter1.Size = new System.Drawing.Size(32, 34);
            this.currencyConverter1.TabIndex = 1;
            this.currencyConverter1.onConvertSuccess += new System.EventHandler(this.currencyConverter1_onConvertSeccess);
            this.currencyConverter1.onConvertFail += new System.EventHandler(this.currencyConverter1_onConvertFail);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.currencyConverter1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private ktf.CurrencyConverter currencyConverter1;
 ```
 
 
  
