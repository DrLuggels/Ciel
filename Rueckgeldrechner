using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Rückgeldrechner
{
    public partial class Form1 : Form
    {

        #region variablen
        int ZweiHundert, EinHundert, Funzig, Zwanzig, Zehn, Funf, Zwei, Eins, NFunf, NZwei, NEins, NNFunf, NNZwei, NNEins;

        private void pictureBox12_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {

        }

        decimal Eingabe, Kosten;
        #endregion



        #region Form1 inizialisieren
        public Form1()
        {
            InitializeComponent();

            // Verstecke alle Bilder der Münzen und Scheine
            for (int i = 1; i <= 19; i++)
            {
                Control pictureBox = this.Controls.Find("pictureBox" + i.ToString(), true).FirstOrDefault();

                if (pictureBox != null && pictureBox is PictureBox)
                {
                    pictureBox.Visible = false;
                }
            }

            //versteckt lbl
            lblcount.Visible = false;


        }
        #endregion


        #region tbEingabe Key_Press
        private void TbEingabe_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Wenn kein Steuerzeichen und kein Komma eingegeben wurde und
            // die Textbox bereits einen Komma enthält
            if (!char.IsControl(e.KeyChar) && e.KeyChar != ',' && tbEingabe.Text.Contains(","))
            {
                // Prüfen, ob die Eingabe eine Ziffer ist
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
                else
                {
                    // Prüfen, ob maximal zwei Ziffern nach dem Komma bereits eingegeben wurden
                    int commaIndex = tbEingabe.Text.IndexOf(",");
                    if (tbEingabe.Text.Length - commaIndex > 2)
                    {
                        e.Handled = true;
                    }
                }
            }
            // Wenn kein Steuerzeichen und kein Komma eingegeben wurde und
            // die Textbox noch keinen Komma enthält
            else if (!char.IsControl(e.KeyChar) && e.KeyChar != ',' && !tbEingabe.Text.Contains(","))
            {
                // Prüfen, ob die Eingabe eine Ziffer oder ein Komma ist
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',')
                {
                    e.Handled = true;
                }
            }
            // Wenn ein Komma eingegeben wurde
            else if (e.KeyChar == ',')
            {
                // Prüfen, ob bereits ein Komma vorhanden ist
                if (tbEingabe.Text.Contains(","))
                {
                    e.Handled = true;
                }
            }
        }
        #endregion


        #region tbEingabe_TextChanged
        private void tbEingabe_TextChanged(object sender, EventArgs e)
        {


            if (!string.IsNullOrEmpty(tbEingabe.Text))
            {
                Eingabe = decimal.Parse(tbEingabe.Text);
            }


        }
        #endregion


        #region tbKosten_TextChanged
        private void tbKosten_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbKosten.Text))
            {
                Kosten = decimal.Parse(tbKosten.Text);
            }
        }

        #endregion


        #region tbKosten_KeyPress
        private void tbKosten_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Wenn kein Steuerzeichen und kein Komma eingegeben wurde und
            // die Textbox bereits einen Komma enthält
            if (!char.IsControl(e.KeyChar) && e.KeyChar != ',' && tbKosten.Text.Contains(","))
            {
                // Prüfen, ob die Eingabe eine Ziffer ist
                if (!char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
                else
                {
                    // Prüfen, ob maximal zwei Ziffern nach dem Komma bereits eingegeben wurden
                    int commaIndex = tbKosten.Text.IndexOf(",");
                    if (tbKosten.Text.Length - commaIndex > 2)
                    {
                        e.Handled = true;
                    }
                }
            }
            // Wenn kein Steuerzeichen und kein Komma eingegeben wurde und
            // die Textbox noch keinen Komma enthält
            else if (!char.IsControl(e.KeyChar) && e.KeyChar != ',' && !tbKosten.Text.Contains(","))
            {
                // Prüfen, ob die Eingabe eine Ziffer oder ein Komma ist
                if (!char.IsDigit(e.KeyChar) && e.KeyChar != ',')
                {
                    e.Handled = true;
                }
            }
            // Wenn ein Komma eingegeben wurde
            else if (e.KeyChar == ',')
            {
                // Prüfen, ob bereits ein Komma vorhanden ist
                if (tbKosten.Text.Contains(","))
                {
                    e.Handled = true;
                }
            }
        }

        #endregion


        private void btnStart_Click(object sender, EventArgs e)
        {
            if (Eingabe >= Kosten)
            {

                #region Variablen-Initialisierung und Berechnung des Rückgelds
                // Initialisiere alle Variablen mit 0
                ZweiHundert = EinHundert = Funzig = Zwanzig = Zehn = Funf = Zwei = Eins = NFunf = NZwei = NEins = NNFunf = NNZwei = NNEins = 0;


                // Berechne das Rückgeld
                decimal a = Eingabe - Kosten;


                // Schreibe das Rückgeld in das Textfeld
                tbAusgabe.Text = a.ToString();


                // Definiere die Werte der verschiedenen Münzen und Scheine
                decimal[] values = { 200000000000m, 20000000000m, 200000000m, 2000000m, 20000m, 200m, 100m, 50m, 20m, 10m, 5m, 2m, 1m, 0.5m, 0.2m, 0.1m, 0.05m, 0.02m, 0.01m };

                // Definiere ein Array für die Anzahl von Münzen und Scheinen
                int[] counts = new int[19];

                // Zähle die Anzahl von Münzen und Scheinen
                for (int i = 0; i < 19; i++)
                {
                    while (a >= values[i])
                    {
                        a = a - values[i];
                        counts[i]++;
                    }
                }
                #endregion


                #region Zählung der Anzahl von Münzen und Scheinen
                // Schreibe die Anzahl von Münzen und Scheinen in die entsprechenden Variablen
                ZweiHundert = counts[0] * 1000000000 + counts[1] * 100000000 + counts[2] * 1000000 + counts[3] * 10000 + counts[4] * 100 + counts[5];
                EinHundert = counts[6];
                Funzig = counts[7];
                Zwanzig = counts[8];
                Zehn = counts[9];
                Funf = counts[10];
                Zwei = counts[11];
                Eins = counts[12];
                NFunf = counts[13];
                NZwei = counts[14];
                NEins = counts[15];
                NNFunf = counts[16];
                NNZwei = counts[17];
                NNEins = counts[18];

                #endregion


                #region Zuweisung der Anzahl von Münzen und Scheinen an die entsprechenden Variablen

                // Verstecke alle Bilder der Münzen und Scheine
                for (int i = 1; i <= 19; i++)
                {
                    Control pictureBox = this.Controls.Find("pictureBox" + i.ToString(), true).FirstOrDefault();

                    if (pictureBox != null && pictureBox is PictureBox)
                    {
                        pictureBox.Visible = false;
                    }
                }
                #endregion


                #region ListBox-Elemente hinzufügen und Anzeige aktualisieren

                //versteckt lbl
                lblcount.Visible = false;


                // Lösche alle Einträge aus der ListBox
                lbMoney.Items.Clear();


                // Beträge und zugehörige PictureBoxen
                int[] amounts = { ZweiHundert, EinHundert, Funzig, Zwanzig, Zehn, Funf, Zwei, Eins, NFunf, NZwei, NEins, NNFunf, NNZwei, NNEins };
                double[] values2 = { 200, 100, 50, 20, 10, 5, 2, 1, 0.5, 0.2, 0.1, 0.05, 0.02, 0.01 };

                // Schleife über die Beträge und zugehörigen PictureBoxen
                for (int i = 0; i < amounts.Length; i++)
                {
                    if (amounts[i] > 0)
                    {
                        // Füge die Anzahl und den Wert der Banknote/Münze in die ListBox-Steuerung hinzu
                        lbMoney.Items.Add(amounts[i] + "x " + values2[i] + "€");

                        // Wenn die Anzahl der 200-Euro-Scheine größer als 2 ist, aktualisiere das Label-Steuerung
                        if (amounts[i] > 2)
                        {
                            lblcount.Visible = true; 
                            lblcount.Text = amounts[i].ToString() + " x";
                        }

                    }
                }
                #endregion


                #region Anzeigen der Münzen und Scheine mit PictureBox-Elementen aktualisieren
                // Ein Array von PictureBox-Elementen wird erstellt, um sie später in einer Schleife sichtbar zu machen.
                PictureBox[] pictureBoxes = { pictureBox1, pictureBox2, pictureBox3, pictureBox4, pictureBox5, pictureBox6, pictureBox7, pictureBox8, pictureBox9, pictureBox10, pictureBox11, pictureBox12, pictureBox13, pictureBox14, pictureBox15, pictureBox16, pictureBox17, pictureBox18, pictureBox19 };

                // Ein Array von Zählerwerten für die verschiedenen PictureBox-Elemente wird erstellt.
                // Die Werte werden in der gleichen Reihenfolge wie die PictureBoxes im PictureBox-Array angeordnet.
                // Wenn der Zählerwert größer als Null ist, wird das entsprechende PictureBox-Element angezeigt.
                // Wenn der Zählerwert gleich 2 ist, wird das PictureBox-Element auch in einem anderen Array-Index gezählt.
                int[] counts2 = { ZweiHundert, ZweiHundert == 2 ? 1 : 0, EinHundert, Funzig, Zwanzig, Zwanzig == 2 ? 1 : 0, Zehn, Funf, Zwei, Zwei == 2 ? 1 : 0, Eins, NFunf, NZwei, NZwei == 2 ? 1 : 0, NEins, NNFunf, NNZwei, NNZwei == 2 ? 1 : 0, NNEins };

                // Eine Schleife wird erstellt, um durch alle PictureBox-Elemente im PictureBox-Array zu iterieren.
                // Wenn der entsprechende Zählerwert größer als Null ist, wird die Sichtbarkeit des PictureBox-Elements auf "true" gesetzt.
                for (int i = 0; i < pictureBoxes.Length; i++)
                {
                    if (counts2[i] > 0)
                    {
                        pictureBoxes[i].Visible = true;
                    }
                }
                #endregion



            }
        }

    }
}


