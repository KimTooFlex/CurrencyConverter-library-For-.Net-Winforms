using System;
using System.Windows.Forms;
namespace ktf
{
    public class CurrencyConverter: UserControl
    {
        private System.Windows.Forms.WebBrowser webBrowser1;
        string URL = "https://www.xe.com/currencyconverter/convert/?Amount=[A]&From=[F]&To=[T]";

        public double Value { get; private set; }

        public CurrencyConverter()
        {
            InitializeComponent();
        }

        public void Convert(Double Amount,string From, String To)
        {
            webBrowser1.Navigate(URL.Replace("[A]",Amount.ToString()).Replace("[F]",From).Replace("[T]",To));
             
        }
 
        private void InitializeComponent()
        {
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(-26, 29);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.Size = new System.Drawing.Size(20, 20);
            this.webBrowser1.TabIndex = 0;
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // CurrencyConverter
            // 
            this.Controls.Add(this.webBrowser1);
            this.Name = "CurrencyConverter";
            this.Size = new System.Drawing.Size(56, 60);
            this.ResumeLayout(false);

        }

        public event EventHandler onConvertSuccess = null;
        public event EventHandler onConvertFail = null;


        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

           
            try
            {
                if (webBrowser1.DocumentTitle.Trim().Contains("XE"))
                {
                    string html = webBrowser1.DocumentText;

                    ktf.Kuto Scrapper = new Kuto(html);

                    string val = Scrapper.Extract("<span class='uccResultAmount'>", "</span>").ToString();


                    this.Value = double.Parse(val.Replace(",", "").Replace(" ", "").Trim());
                    if (onConvertSuccess != null)
                    {
                        onConvertSuccess.Invoke(this, null);
                    }
                  
                }
                else
                {
                    if (onConvertFail != null)
                    {
                        onConvertFail.Invoke(new Exception("Connection Error"), null);
                    }
                }
            }
            catch (Exception Err)
            {
                if (onConvertFail != null)
                {
                   onConvertFail.Invoke(Err, null);
                }
            }

        }
    }
}
