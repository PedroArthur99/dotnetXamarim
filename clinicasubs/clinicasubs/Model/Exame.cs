using System;
using System.Collections.Generic;
using System.Text;

namespace clinicasubs.Model
{
    public class Exame
    {
        public int Id { get; set; }

        public string Cpf { get; set; }

        public string NomePaciente { get; set; }

        public string resultado { get; set; }

        public DateTime dataExame { get; set; }
    }
}
