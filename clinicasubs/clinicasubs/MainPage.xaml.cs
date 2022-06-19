using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using clinicasubs.Service;
using clinicasubs.Model;

namespace clinicasubs
{
    public partial class MainPage : ContentPage
    {

        private ExameService exameService;
        public ObservableCollection<Exame> exames;

        public MainPage()
        {
            InitializeComponent();
            exameService = new ExameService();
            exames = new ObservableCollection<Exame>();

            listExames.ItemsSource = exames;

            Title = "Início";

            GetAllExames();
        }

        private async void GetAllExames()
        {
            List<Exame> result = await exameService.GetAll();
            foreach (var exame in result)
            {
                exames.Add(exame);
            }
        }

        private async void btnNewExame_Clicked(object sender, EventArgs e)
        {
            Exame exame = new Exame();
            exame.Id = int.Parse(entId.Text);
            exame.NomePaciente = entName.Text;
            exame.Cpf = entCpf.Text;
            exame.resultado = entResult.Text;
            exame.dataExame = DateTime.Parse(entData.Text);
            await exameService.Post(exame);
        }
    }
}
