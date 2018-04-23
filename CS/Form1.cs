using System;
using System.Windows.Forms;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.Localization;
// ...

namespace PageHeader {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {
            this.categoriesTableAdapter.Fill(this.nwindDataSet.Categories);
        }

        private void button1_Click(object sender, EventArgs e) {
            // The following syntax is recommended for use with localized applications.
            string leftColumn = 
                "Pages: " + PreviewLocalizer.GetString(PreviewStringId.PageInfo_PageNumberOfTotal);
            string middleColumn = 
                "User: " + PreviewLocalizer.GetString(PreviewStringId.PageInfo_PageUserName);
            string rightColumn = 
                "Date: " + PreviewLocalizer.GetString(PreviewStringId.PageInfo_PageDate);

            // Create a PageHeaderFooter object and initializing it with
            // the link's PageHeaderFooter.
            PageHeaderFooter phf = printableComponentLink1.PageHeaderFooter as PageHeaderFooter;

            // Clear the PageHeaderFooter's contents.
            phf.Header.Content.Clear();

            // Add custom information to the link's header.
            phf.Header.Content.AddRange(new string[] { leftColumn, middleColumn, rightColumn });
            phf.Header.LineAlignment = BrickAlignment.Far;

            // Show the document's preview.
            printableComponentLink1.ShowPreview();

        }
    }
}