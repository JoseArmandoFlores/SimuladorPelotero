using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimuladorPelotero
{
    public partial class MainForm : Form
    {
        string TipoLanzamiento, TipoLanzamientoAnterior = "Recta",  TipoContacto, Problema;
        bool Bateo;
        int Dia, PosibilidadContacto = 50;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        public void DeterminarLanzamiento()
        {
            Random aleatorio = new Random();
            int aux = aleatorio.Next(1, 6);

            if (aux == 1)
                TipoLanzamiento = "Curva";
            else if (aux == 2)
                TipoLanzamiento = "Recta";
            else if (aux == 3)
                TipoLanzamiento = "Cambio";
            else if (aux == 4)
                TipoLanzamiento = "Nudillo";
            else if (aux == 5)
                TipoLanzamiento = "Slider";
        }

        public void AumentarPosibilidadContacto()
        {
            if(TipoLanzamiento == TipoLanzamientoAnterior)
            {
                PosibilidadContacto++;

                if (PosibilidadContacto >= 100)
                    PosibilidadContacto = 100;
            }

            TipoLanzamientoAnterior = TipoLanzamiento;
        }

        public void DeterminarPosibilidadBatear(int n)
        {
            Random aleatorio = new Random();
            int aux = aleatorio.Next(1, 101);

            if (aux <= n)
                Bateo = true;
            else
                Bateo = false;
        }

        public void DeterminarTipoContacto()
        {
            if (Bateo == true)
            {
                Random aleatorio = new Random();
                int aux = aleatorio.Next(1, 4);

                if (aux < 4)
                    TipoContacto = "Hit";
                else
                    TipoContacto = "Foul";
            }
        }

        public void DeterminarProblema()
        {
            Random aleatorio = new Random();
            int aux = aleatorio.Next(1, 8);

            if (aux < 4)
                Problema = "Ninguno";
            else if (aux == 4)
                Problema = "Covid";
            else if (aux == 5)
                Problema = "Gripe";
            else if (aux == 6)
                Problema = "Alcohol";
            else if (aux == 7)
                Problema = "Trasnocho";
        }

        public void DisminuirPosibilidadContacto()
        {
            if (Problema == "Covid")
                PosibilidadContacto -= 20;
            else if (Problema == "Gripe")
                PosibilidadContacto -= 15;
            else if (Problema == "Alcohol")
                PosibilidadContacto -= 10;
            else if (Problema == "Trasnocho")
                PosibilidadContacto -= 5;
        }
        public void Simular()
        {
            
            
        }
    }
}
