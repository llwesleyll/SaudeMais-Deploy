using System;
using System.ComponentModel.DataAnnotations; //permite que adicione anotações nas entidades;
namespace SaudeMais.Models
{
    public class Profissional{
        [Key]
        public int Id {get;set;} //Propriedades e seus acessores;
        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [MaxLength(60, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]

        public string Email {get;set;}
        public string Nome {get;set;}
         [MaxLength(1024, ErrorMessage = "Este campo deve conter no máximo 1024 caracteres!")]
        public string NumeroContato {get;set;}
        public string Imagem {get;set;}
        public string Cpf {get;set;}
        public string Formacao {get;set;}
        public DateTime TempoTrabalho {get;set;} //Propriedade para o usuario informar quantas horas pode se dedicar ao trabalho por dia;
        public string Periodo {get;set;} //Propriedade para o usuário setar qual período ele esta disponível, noturno, diurno ou ambos;
        public string Disponibilidade {get;set;}
        public Area Area {get;set;}

        public int AreaId {get;set;}

    }
}