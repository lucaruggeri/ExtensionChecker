using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ExtensionChecker;

namespace MyClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Initialize();
        }

        private void Initialize()
        {

        }

        private void objLoadFile_Click(object sender, EventArgs e)
        {
            // Show the dialog and get result
            DialogResult result = myOpenFileDialog.ShowDialog();
            if (result == DialogResult.OK) 
            {

                string filePath = myOpenFileDialog.FileName;
                string fileName = myOpenFileDialog.SafeFileName;
                objFileName.Text = fileName;

                //string declaredFileExtension = Path.GetExtension(fileName);
                //string realFileExtension = ExtensionReader.ExtensionReader.GetRealExtension(filePath);

                if (ExtensionChecker.ExtensionChecker.CheckFileExtension(filePath) == true)
                {
                    MessageBox.Show("L'estensione è vera.");
                }
                else
                {
                    MessageBox.Show("ERRORE: l'estensione non corrisponde all'header del file.");
                }

                
                //objEstensioneDichiarata.Text = "Estensione dichiarata: " + declaredFileExtension.ToUpper();                
                //objEstensioneEffettiva.Text = "      Estensione reale: " + realFileExtension.ToUpper();

                //if (declaredFileExtension.ToUpper().Trim() == realFileExtension.ToUpper().Trim())
                //{
                //    objEstensioneEffettiva.ForeColor = System.Drawing.Color.DarkGreen;
                //}
                //else
                //{
                //    objEstensioneEffettiva.ForeColor = System.Drawing.Color.Red;
                //}



            }

        }

    }
}
