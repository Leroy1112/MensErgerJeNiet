﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUIWinForm.Screen
{
    public partial class Game : UserControl
    {
        System.Collections.Generic.List<System.Windows.Forms.Label> LijstNaamLabels = new List<Label>();
        public Game()
        {
            InitializeComponent();
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.pictureBox2 = new PionImage(Color.rood);
            this.pictureBox2.Parent = this.pictureBox1;
            //this.pictureBox2.BackColor = System.Drawing.Color.Transparent;


            //PionImage pa1 = new PionImage(Color.rood);
            //pa1.Parent = this.pictureBox1;//dit is niet nodig om dat je hem aan de controlls van de picturebox
            //let op de verhoudingen hierdoor zijn afhankelijk van de image

            //this.pictureBox1.Controls.Add(pa1);

            LijstNaamLabels = new System.Collections.Generic.List<System.Windows.Forms.Label>() { player1, player2, player3, player4 };
           

        }

        private void Game_Load(object sender, EventArgs e)
        {
            foreach(MensErgerJeNietLogic.Speler speler in Global.Spel.Spelers)
            {
                LijstNaamLabels[speler.ID].Text = speler.Naam;
                
                foreach(MensErgerJeNietLogic.Pion pion in speler.Hand)
                {
                    //pion.Locatie.
                    PionImage pionImage = new PionImage((Color)pion.Kleur);
                    this.pictureBox1.Controls.Add(pionImage);
                    VerplaatsPionNaar(pionImage, pion.Locatie);         
                }
            }
        }

        private void DobbelsteenImage_Click(object sender, EventArgs e)
        {
            //logica gooi dobbelsteen
            Global.Spel.DoeWorp();
            int gegooidewaard = (Global.Spel.Dobbelsteen.Value);

            switch (gegooidewaard)
            {
                case 1:
                    this.DobbelsteenImage.Image = global::GUIWinForm.Properties.Resources.dobbelsteen_1;
                    break;

                case 2:
                    this.DobbelsteenImage.Image = global::GUIWinForm.Properties.Resources.dobbelsteen_2;
                    break;

                case 3:
                    this.DobbelsteenImage.Image = global::GUIWinForm.Properties.Resources.dobbelsteen_3;
                    break;

                case 4:
                    this.DobbelsteenImage.Image = global::GUIWinForm.Properties.Resources.dobbelsteen_4;
                    break;

                case 5:
                    this.DobbelsteenImage.Image = global::GUIWinForm.Properties.Resources.dobbelsteen_5;
                    break;

                case 6:
                    this.DobbelsteenImage.Image = global::GUIWinForm.Properties.Resources.dobbelsteen_6;
                    break;

            }

            DobbelsteenImage.Click -= this.DobbelsteenImage_Click;              
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DobbelsteenImage.Click += this.DobbelsteenImage_Click;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.label2.Text = ""+(new BordPositions()).GetPosition(int.Parse(this.textBox1.Text));

            this.pictureBox2.Location = new Point(
                (new BordPositions()).GetPosition(int.Parse(this.textBox1.Text)).X * 66 + 432, 
                -1*(new BordPositions()).GetPosition(int.Parse(this.textBox1.Text)).Y * 66 + 3
                );

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            this.label2.Text = "" + (new BordPositions()).GetPosition(this.trackBar1.Value);

            this.pictureBox2.Location = new Point(
                (new BordPositions()).GetPosition(this.trackBar1.Value).X * 65 + 453,
                -1 * (new BordPositions()).GetPosition(this.trackBar1.Value).Y * 59 + 26
                );
        }

        /// <summary>
        /// Verplaats de pion naar een nieuwe locatie.
        /// </summary>
        /// <param name="pion"></param>
        /// <param name="nieuweLocatie"></param>
        private void VerplaatsPionNaar(PionImage pion, int nieuweLocatie)
        {
            this.label2.Text = "" + (new BordPositions()).GetPosition(this.trackBar1.Value);

            pion.Location = new Point(
                    (new BordPositions()).GetPosition(nieuweLocatie).X * 65 + 453, -1 * 
                    (new BordPositions()).GetPosition(nieuweLocatie).Y * 58 + 26);
        }
   
    }
}
