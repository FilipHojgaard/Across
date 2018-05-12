using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Data;

namespace Across
{
    class Felt
    {
        private bool _real;  // Feltets rigtige værdi. er den 0 eller 1? det skal spilleren regne ud. Bliver random af Randomizer()
        public bool guess;  // spillerens nuværende gæt på feltet
        public bool correct = false;    // er _real og guess ens? bliver checket i check()
        public int rows;    // objekterne fra denne klasse bliver lavet som 2d array. dette er i'et fra nested for loop
        public int cols;    // dette er j'et fra nested for loop
        public int posX;    // udregnet position X fra rows i metoden Positionize()
        public int posY;    // udregnet position Y fra cols i metoden Positionize()
        public int id;      // id udregnet ved rows * 10 + cols
        PictureBox picture; // picturebox til at tegne front end for objektet
        Form1 form;          // reference til form så der kan tegnes Picturebox fra denne klasse.


        // Constructor. henter parametre og tegner.
        public Felt(Random rnd, Form1 formArg, int rowArg, int ColArg)
        {
            form = formArg;
            rows = rowArg + 1;
            cols = ColArg + 1;
            Randomize(rnd);
            Positionize(rows, cols);
            id = rows * 10 + cols;
            Draw();
            ID();
        }

        // Test metode man kan kalde for at vide hvilket felt man har med at gøre.
        public void ID()
        {
            Console.WriteLine("ID: " + id + " position: " + posX + " " + posY);
        }

        // Metode der tegner picturebox. det med at gange location med 10 var et tilfælde jeg opdagede men det virkede!
        public void Draw()
        {
            picture = new PictureBox {
                Name = "picturebox",
                Size = new Size(100, 100),
                Location = new Point(posX*10, posY*10),
                Image = Image.FromFile("C:/Users/filip/source/repos/Across/Across/sprites/tom_felt.png"),
            };
            form.Controls.Add(picture);

            // "type picture.MouseClick +=" og så TAB og den færdiggør en mouseclick event handler som ses lige under.
            picture.MouseClick += Picture_MouseClick;
        }

        // Mouse click event handler. Oprettet med TAB. Læs ovenover.
        private void Picture_MouseClick(object sender, MouseEventArgs e)
        {
            ID();
            if (e.Button == MouseButtons.Left) {
                picture.Image = Image.FromFile("C:/Users/filip/source/repos/Across/Across/sprites/felt_1.png");
                guess = true;
                Analyze();
            }

            if (e.Button == MouseButtons.Right) {
                picture.Image = Image.FromFile("C:/Users/filip/source/repos/Across/Across/sprites/felt_0.png");
                guess = false;
                Analyze();
            }
            if (e.Button == MouseButtons.Middle) {
                picture.Image = Image.FromFile("C:/Users/filip/source/repos/Across/Across/sprites/tom_felt.png");
                guess = false;
                Analyze();
            }
        }

        // Checker om _real og guess er ens og returner enten true eller false og gemmer det også i correct
        public void Check()
        {
            if (_real == guess) {
                correct = true;
            } else {
                correct = false;
            }
        }

        // Sætter 50% change om _real er false eller true
        public void Randomize(Random rnd)
        {
            int r = rnd.Next(0, 3);
            if (r == 0) {
                _real = false;
            } else {
                _real = true;
            }
        }

        // Sætter felternes position afhængig af deres id fra rows og cols
        public void Positionize(int rows, int cols)
        {
            posX = rows * 10;
            posY = cols * 10;
        }

        // metode skal i stedet skrives i Forms og loope over alle Felt objekterne og tjekke deres correct efter at have kørt Check(). 
        // Hvis de alle giver true har man vundet spillet.
        public void Analyze()
        {
            // Do checking stuff anytime a button is clicked
            Check();
            Console.WriteLine("real: " + _real + " guess: " + guess + " correct: " + correct);
            form.CheckForWin();
        }

        // Test metode der viser hvad _real er eftersom den er private.
        public bool ShowReal()
        {
            return _real;
        }

    }
}
