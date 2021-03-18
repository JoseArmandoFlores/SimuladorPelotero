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
        string TipoLanzamientoAnterior = "Ninguno", TipoLanzamiento, TipoContacto, Problema = "Ninguno", ProblemaMasAfecto, LanzamientoMasDominado;
        int CantidadDiariaHits = 0, CantidadTotalLanzamientos = 0, CantidadTotalHits = 0, Covid = 0, Gripe = 0, Alcohol = 0, Trasnocho = 0;
        int Dia = 0, PosibilidadContacto = 50, CantidadDiariaLanzamientos = 0, CantidadLanzamientosConContacto = 0, AuxLanzamiento = 0;
        int Curva = 0, Recta = 0, Cambio = 0, Nudillo = 0, Slider = 0;
        float PromedioTotalBateo = 0, PromedioDiarioBateo = 0;
        bool Bateo;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }

        public void LlenaCampos()
        {
            CantLanzamientosTextBox.Text = Convert.ToString(CantidadDiariaLanzamientos);
            TipoLanzamientoTextBox.Text = Convert.ToString(TipoLanzamiento);
            CantLanzamientosContactoTextBox.Text = Convert.ToString(CantidadLanzamientosConContacto);
            TipoContactoTextBox.Text = Convert.ToString(TipoContacto);
            CantHitsTextBox.Text = Convert.ToString(CantidadDiariaHits);
            ProblemaTextBox.Text = Convert.ToString(Problema);
            PromedioBateoTextBox.Text = PromedioDiarioBateo.ToString("N3");
            ProblemaMasAfectoTextBox.Text = Convert.ToString(ProblemaMasAfecto);
            LanzamientosMasDominadosTextBox.Text = Convert.ToString(LanzamientoMasDominado);
            CantTotalHitsTextBox.Text = Convert.ToString(CantidadTotalHits);
            CantTotalLanzamientosTextBox.Text = Convert.ToString(CantidadTotalLanzamientos);
            PromedioBateoFinalTextBox.Text = PromedioTotalBateo.ToString("N3");
            DiaLabel.Text = Convert.ToString(Dia);
        }

        public void Limpiar()
        {
            CantidadDiariaLanzamientos = 0;
            TipoLanzamiento = string.Empty;
            CantidadLanzamientosConContacto = 0;
            TipoContacto = string.Empty;
            CantidadDiariaHits = 0;
            PromedioDiarioBateo = 0;
            ProblemaMasAfecto = string.Empty;
            LanzamientoMasDominado = string.Empty;
        }

        public void LimpiarTodo()
        {
            Limpiar();
            CantidadTotalHits = 0;
            CantidadTotalLanzamientos = 0;
            PromedioTotalBateo = 0;
            Dia = 0;

            CantLanzamientosTextBox.Text = string.Empty;
            TipoLanzamientoTextBox.Text = string.Empty;
            CantLanzamientosContactoTextBox.Text = string.Empty;
            TipoContactoTextBox.Text = string.Empty;
            CantHitsTextBox.Text = string.Empty;
            ProblemaTextBox.Text = string.Empty;
            PromedioBateoTextBox.Text = string.Empty;
            ProblemaMasAfectoTextBox.Text = string.Empty;
            LanzamientosMasDominadosTextBox.Text = string.Empty;
            CantTotalHitsTextBox.Text = string.Empty;
            CantTotalLanzamientosTextBox.Text = string.Empty;
            PromedioBateoFinalTextBox.Text = string.Empty;
            DiaLabel.Text = "0";
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

            CantidadDiariaLanzamientos++;
            AuxLanzamiento++;
        }

        public void AumentarPosibilidadContacto()
        {
            if (TipoLanzamiento == TipoLanzamientoAnterior)
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
                int aux = aleatorio.Next(1, 6);

                if (aux < 4)
                {
                    TipoContacto = "Hit";
                    if (TipoLanzamiento == "Curva")
                        Curva++;
                    else if (TipoLanzamiento == "Recta")
                        Recta++;
                    else if (TipoLanzamiento == "Cambio")
                        Cambio++;
                    else if (TipoLanzamiento == "Nudillo")
                        Nudillo++;
                    else if (TipoLanzamiento == "Slider")
                        Slider++;

                    CantidadDiariaHits++;
                }
                else
                    TipoContacto = "Foul";

                CantidadLanzamientosConContacto++;
            }
            else
                TipoContacto = "Ninguno";
        }

        public void DeterminarProblema()
        {
            Random aleatorio = new Random();
            int aux = aleatorio.Next(1, 8);

            if (aux < 4)
                Problema = "Ninguno";
            else if (aux == 4)
            {
                Problema = "Covid";
                Covid++;
            }
            else if (aux == 5)
            {
                Problema = "Gripe";
                Gripe++;
            }
            else if (aux == 6)
            {
                Problema = "Alcohol";
                Alcohol++;
            }
            else if (aux == 7)
            {
                Problema = "Trasnocho";
                Trasnocho++;
            }
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

        public void CalcularPromedioTotalBateo()
        {
            PromedioTotalBateo += PromedioDiarioBateo / 5;
        }

        public void CalcularPromedioDiarioBateo()
        {
            PromedioDiarioBateo = ((float)CantidadDiariaHits / (float)CantidadDiariaLanzamientos);
        }

        public void DeterminarProblemaMasAfecto()
        {
            if((Covid*20) > (Gripe*15) && (Covid * 20) > (Alcohol * 10) && (Covid * 20) > (Trasnocho * 5))
                ProblemaMasAfecto = "Covid";
            else if ((Gripe * 15) > (Covid * 20) && (Gripe * 15) > (Alcohol * 10) && (Gripe * 15) > (Trasnocho * 5))
                ProblemaMasAfecto = "Gripe";
            else if ((Alcohol * 10) > (Covid * 20) && (Alcohol * 10) > (Gripe * 15) && (Alcohol * 10) > (Trasnocho * 5))
                ProblemaMasAfecto = "Alcohol";
            else if ((Trasnocho * 5) > (Covid * 20) && (Trasnocho * 5) > (Gripe * 15) && (Trasnocho * 5) > (Alcohol * 10))
                ProblemaMasAfecto = "Trasnocho";
        }

        public void DeterminarLanzamientoMasDominado()
        {
            if (Curva > Recta && Curva > Cambio && Curva > Nudillo && Curva > Slider)
                LanzamientoMasDominado = "Curva";
            else if (Recta > Curva && Recta > Cambio && Recta > Nudillo && Recta > Slider)
                LanzamientoMasDominado = "Recta";
            else if (Cambio > Curva && Cambio > Recta && Cambio > Nudillo && Cambio > Slider)
                LanzamientoMasDominado = "Cambio";
            else if (Nudillo > Curva && Nudillo > Cambio && Nudillo > Recta && Nudillo > Slider)
                LanzamientoMasDominado = "Nudillo";
            else if (Slider > Curva && Slider > Cambio && Slider > Nudillo && Slider > Recta)
                LanzamientoMasDominado = "Slider";
        }

        public void Simular()
        {
            DeterminarLanzamiento();
            AumentarPosibilidadContacto();
            DeterminarPosibilidadBatear(PosibilidadContacto);
            DeterminarTipoContacto();
            CalcularPromedioDiarioBateo();

            if (CantidadDiariaLanzamientos == 80)
            {
                DeterminarProblema();
                DisminuirPosibilidadContacto();
                CalcularPromedioTotalBateo();
                CantidadTotalLanzamientos += CantidadDiariaLanzamientos;
                CantidadTotalHits += CantidadDiariaHits;
                Dia++;
            }

            if (Dia == 5)
            {
                DeterminarProblemaMasAfecto();
                DeterminarLanzamientoMasDominado();
            }
            LlenaCampos();
        }

        private void SigteLanzamientoButton_Click(object sender, EventArgs e)
        {
            Simular();//Simular lanzamiento

            if (Dia == 5)
            {
                MessageBox.Show("¡Límite de días alcanzado!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void SigteDiaButton_Click(object sender, EventArgs e)
        {
            int aux = 80 - AuxLanzamiento;

            for (int i = 0; i < aux; i++)//Simular lanzamientos faltantes para concluir el dia
                Simular();
            
            if (Dia == 5)
            {
                MessageBox.Show("¡Límite de días alcanzado!", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            AuxLanzamiento = 0;
            Limpiar();
        }

        //Asignando jugador
        private void AaronJudgePB_Click(object sender, EventArgs e)
        {
            LimpiarTodo();
            JugadorPictureBox.Image = AaronJudgePB.Image;
            JugadorTextBox.Text = "Aaron Judge";
            TabControl.SelectedIndex = 1;
        }
        private void AaronHicksPB_Click(object sender, EventArgs e)
        {
            LimpiarTodo();
            JugadorPictureBox.Image = AaronHicksPB.Image;
            JugadorTextBox.Text = "Aaron Hicks";
            TabControl.SelectedIndex = 1;
        }
        private void BrettGardnerPB_Click(object sender, EventArgs e)
        {
            LimpiarTodo();
            JugadorPictureBox.Image = BrettGardnerPB.Image;
            JugadorTextBox.Text = "Brett Gardner";
            TabControl.SelectedIndex = 1;
        }
        private void ClintFrazierPB_Click(object sender, EventArgs e)
        {
            LimpiarTodo();
            JugadorPictureBox.Image = ClintFrazierPB.Image;
            JugadorTextBox.Text = "Clint Frazier";
            TabControl.SelectedIndex = 1;
        }
        private void DJLeMahieuPB_Click(object sender, EventArgs e)
        {
            LimpiarTodo();
            JugadorPictureBox.Image = DJLeMahieuPB.Image;
            JugadorTextBox.Text = "DJ LeMahieu";
            TabControl.SelectedIndex = 1;
        }
        private void GarySanchezPB_Click(object sender, EventArgs e)
        {
            LimpiarTodo();
            JugadorPictureBox.Image = GarySanchezPB.Image;
            JugadorTextBox.Text = "Gary Sanchez";
            TabControl.SelectedIndex = 1;
        }
        private void GiancarloStantonPB_Click(object sender, EventArgs e)
        {
            LimpiarTodo();
            JugadorPictureBox.Image = GiancarloStantonPB.Image;
            JugadorTextBox.Text = "Giancarlo Stanton";
            TabControl.SelectedIndex = 1;
        }
        private void GioUrshelaPB_Click(object sender, EventArgs e)
        {
            LimpiarTodo();
            JugadorPictureBox.Image = GioUrshelaPB.Image;
            JugadorTextBox.Text = "Gio Urshela";
            TabControl.SelectedIndex = 1;
        }
        private void GleyberTorresPB_Click(object sender, EventArgs e)
        {
            LimpiarTodo();
            JugadorPictureBox.Image = GleyberTorresPB.Image;
            JugadorTextBox.Text = "Gleyber Torres";
            TabControl.SelectedIndex = 1;
        }
        private void JonathanArauzPB_Click(object sender, EventArgs e)
        {
            LimpiarTodo();
            JugadorPictureBox.Image = JonathanArauzPB.Image;
            JugadorTextBox.Text = "Jonathan Arauz";
            TabControl.SelectedIndex = 1;
        }
        private void JuanSotoPB_Click(object sender, EventArgs e)
        {
            LimpiarTodo();
            JugadorPictureBox.Image = JuanSotoPB.Image;
            JugadorTextBox.Text = "Juan Soto";
            TabControl.SelectedIndex = 1;
        }
        private void KyleHigashiokaPB_Click(object sender, EventArgs e)
        {
            LimpiarTodo();
            JugadorPictureBox.Image = KyleHigashiokaPB.Image;
            JugadorTextBox.Text = "Kyle Higashioka";
            TabControl.SelectedIndex = 1;
        }
        private void LukeVoitPB_Click(object sender, EventArgs e)
        {
            LimpiarTodo();
            JugadorPictureBox.Image = LukeVoitPB.Image;
            JugadorTextBox.Text = "Luke Voit";
            TabControl.SelectedIndex = 1;
        }
        private void MichaelChavisPB_Click(object sender, EventArgs e)
        {
            LimpiarTodo();
            JugadorPictureBox.Image = MichaelChavisPB.Image;
            JugadorTextBox.Text = "Michael Chavis";
            TabControl.SelectedIndex = 1;
        }
        private void MiguelAndujarPB_Click(object sender, EventArgs e)
        {
            LimpiarTodo();
            JugadorPictureBox.Image = MiguelAndujarPB.Image;
            JugadorTextBox.Text = "Miguel Andujar";
            TabControl.SelectedIndex = 1;
        }
        private void MikeFordPB_Click(object sender, EventArgs e)
        {
            LimpiarTodo();
            JugadorPictureBox.Image = MikeFordPB.Image;
            JugadorTextBox.Text = "Mike Ford";
            TabControl.SelectedIndex = 1;
        }
        private void MikeTauchmanPB_Click(object sender, EventArgs e)
        {
            LimpiarTodo();
            JugadorPictureBox.Image = MikeTauchmanPB.Image;
            JugadorTextBox.Text = "Mike Tauchman";
            TabControl.SelectedIndex = 1;
        }
        private void RafaelDeversPB_Click(object sender, EventArgs e)
        {
            LimpiarTodo();
            JugadorPictureBox.Image = RafaelDeversPB.Image;
            JugadorTextBox.Text = "Rafael Devers";
            TabControl.SelectedIndex = 1;
        }
        private void ThairoEstradaPB_Click(object sender, EventArgs e)
        {
            LimpiarTodo();
            JugadorPictureBox.Image = ThairoEstradaPB.Image;
            JugadorTextBox.Text = "Thairo Estrada";
            TabControl.SelectedIndex = 1;
        }
        private void TylerWadePB_Click(object sender, EventArgs e)
        {
            LimpiarTodo();
            JugadorPictureBox.Image = TylerWadePB.Image;
            JugadorTextBox.Text = "Tyler Wade";
            TabControl.SelectedIndex = 1;
        }
    }
}
