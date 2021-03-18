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
        string TipoLanzamientoAnterior = "Ninguno", TipoLanzamiento, LanzamientosConContacto, TipoContacto, Problema;
        int Dia, PosibilidadContacto = 50, CantidadLanzamientos = 0, CantidadHits = 0, CantidadTotalLanzamientos = 0, CantidadTotalHits = 0;
        double PromedioBateo = 0;
        bool Bateo;
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
            DeterminarLanzamiento();
            AumentarPosibilidadContacto();
            DeterminarPosibilidadBatear(PosibilidadContacto);
            DeterminarTipoContacto();
            DeterminarProblema();
            DisminuirPosibilidadContacto();
        }

        private void SigteLanzamientoButton_Click(object sender, EventArgs e)
        {
            Simular();
            //10
        }

        private void SigteDiaButton_Click(object sender, EventArgs e)
        {
            int n = 80 - CantidadLanzamientos;//70

            for (int i = 0; i < n; i++)
            {
                Simular();
            }
            Dia++;
        }

        //Asignando jugador
        private void AaronJudgePB_Click(object sender, EventArgs e)
        {
            JugadorPictureBox.Image = AaronJudgePB.Image;
            JugadorTextBox.Text = "Aaron Judge";
            TabControl.SelectedIndex = 1;
        }
        private void AaronHicksPB_Click(object sender, EventArgs e)
        {
            JugadorPictureBox.Image = AaronHicksPB.Image;
            JugadorTextBox.Text = "Aaron Hicks";
            TabControl.SelectedIndex = 1;
        }
        private void BrettGardnerPB_Click(object sender, EventArgs e)
        {
            JugadorPictureBox.Image = BrettGardnerPB.Image;
            JugadorTextBox.Text = "Brett Gardner";
            TabControl.SelectedIndex = 1;
        }
        private void ClintFrazierPB_Click(object sender, EventArgs e)
        {
            JugadorPictureBox.Image = ClintFrazierPB.Image;
            JugadorTextBox.Text = "Clint Frazier";
            TabControl.SelectedIndex = 1;
        }
        private void DJLeMahieuPB_Click(object sender, EventArgs e)
        {
            JugadorPictureBox.Image = DJLeMahieuPB.Image;
            JugadorTextBox.Text = "DJ LeMahieu";
            TabControl.SelectedIndex = 1;
        }
        private void GarySanchezPB_Click(object sender, EventArgs e)
        {
            JugadorPictureBox.Image = GarySanchezPB.Image;
            JugadorTextBox.Text = "Gary Sanchez";
            TabControl.SelectedIndex = 1;
        }
        private void GiancarloStantonPB_Click(object sender, EventArgs e)
        {
            JugadorPictureBox.Image = GiancarloStantonPB.Image;
            JugadorTextBox.Text = "Giancarlo Stanton";
            TabControl.SelectedIndex = 1;
        }
        private void GioUrshelaPB_Click(object sender, EventArgs e)
        {
            JugadorPictureBox.Image = GioUrshelaPB.Image;
            JugadorTextBox.Text = "Gio Urshela";
            TabControl.SelectedIndex = 1;
        }
        private void GleyberTorresPB_Click(object sender, EventArgs e)
        {
            JugadorPictureBox.Image = GleyberTorresPB.Image;
            JugadorTextBox.Text = "Gleyber Torres";
            TabControl.SelectedIndex = 1;
        }
        private void JonathanArauzPB_Click(object sender, EventArgs e)
        {
            JugadorPictureBox.Image = JonathanArauzPB.Image;
            JugadorTextBox.Text = "Jonathan Arauz";
            TabControl.SelectedIndex = 1;
        }
        private void JuanSotoPB_Click(object sender, EventArgs e)
        {
            JugadorPictureBox.Image = JuanSotoPB.Image;
            JugadorTextBox.Text = "Juan Soto";
            TabControl.SelectedIndex = 1;
        }
        private void KyleHigashiokaPB_Click(object sender, EventArgs e)
        {
            JugadorPictureBox.Image = KyleHigashiokaPB.Image;
            JugadorTextBox.Text = "Kyle Higashioka";
            TabControl.SelectedIndex = 1;
        }
        private void LukeVoitPB_Click(object sender, EventArgs e)
        {
            JugadorPictureBox.Image = LukeVoitPB.Image;
            JugadorTextBox.Text = "Luke Voit";
            TabControl.SelectedIndex = 1;
        }
        private void MichaelChavisPB_Click(object sender, EventArgs e)
        {
            JugadorPictureBox.Image = MichaelChavisPB.Image;
            JugadorTextBox.Text = "Michael Chavis";
            TabControl.SelectedIndex = 1;
        }
        private void MiguelAndujarPB_Click(object sender, EventArgs e)
        {
            JugadorPictureBox.Image = MiguelAndujarPB.Image;
            JugadorTextBox.Text = "Miguel Andujar";
            TabControl.SelectedIndex = 1;
        }
        private void MikeFordPB_Click(object sender, EventArgs e)
        {
            JugadorPictureBox.Image = MikeFordPB.Image;
            JugadorTextBox.Text = "Mike Ford";
            TabControl.SelectedIndex = 1;
        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void MikeTauchmanPB_Click(object sender, EventArgs e)
        {
            JugadorPictureBox.Image = MikeTauchmanPB.Image;
            JugadorTextBox.Text = "Mike Tauchman";
            TabControl.SelectedIndex = 1;
        }
        private void RafaelDeversPB_Click(object sender, EventArgs e)
        {
            JugadorPictureBox.Image = RafaelDeversPB.Image;
            JugadorTextBox.Text = "Rafael Devers";
            TabControl.SelectedIndex = 1;
        }
        private void ThairoEstradaPB_Click(object sender, EventArgs e)
        {
            JugadorPictureBox.Image = ThairoEstradaPB.Image;
            JugadorTextBox.Text = "Thairo Estrada";
            TabControl.SelectedIndex = 1;
        }
        private void TylerWadePB_Click(object sender, EventArgs e)
        {
            JugadorPictureBox.Image = TylerWadePB.Image;
            JugadorTextBox.Text = "Tyler Wade";
            TabControl.SelectedIndex = 1;
        }
    }
}
