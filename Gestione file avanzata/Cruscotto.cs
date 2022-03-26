using GestioneFileAvanzata.BaseDati;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestione_file_avanzata
{
    public partial class Cruscotto : Form
    {

        public Cruscotto()
        {
            InitializeComponent();
        }

        private void carica(object sender, EventArgs e)
        {
            Func<string,string, bool> Visibile = (Dove,Cosa)=> { return Cosa.Split(" ").Contains(Dove); };

            FlowContainer.Controls.Clear();
            var tutti = DB.Divisi;
            foreach (var file in tutti)
            {
                var g = new GroupBox();
                g.Top = 10;
                g.Text = file.Key;
                g.Visible = file.Value.Count > 0;
                g.Font = new Font("Arial", 18, FontStyle.Bold);
                
                
                var sWidth = g.CreateGraphics().MeasureString(g.Text, g.Font).Width;
                g.Width =(int)(sWidth *1.3);

                string totFi = file.Value.Count + " Files";
                var labWidth = g.CreateGraphics().MeasureString(totFi, g.Font).Width;
                if(labWidth > g.Width)
                    g.Width = (int)(labWidth * 1.3);


                g.BackColor = Color.LightBlue;
                //if ()
                //    g.Visible = Visibile("", file.Key);

                g.Controls.Add(new Label()
                {
                    Top =50,
                    Font = new Font("Arial", g.Font.Size -3, FontStyle.Regular),
                    AutoSize = false,
                    Text = totFi,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Left = 10,
                    Width = g.Width - 10
                });

                FlowContainer.Controls.Add(g);
            }
        }

        private void Cruscotto_Load(object sender, EventArgs e)
        {
            carica(sender,e);

        }
    }
}
