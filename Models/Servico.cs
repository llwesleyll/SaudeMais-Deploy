using System;
using System.ComponentModel.DataAnnotations; //permite que adicione anotações nas entidades;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaudeMais.Models   
{
    public class Servico{
        [Key]
        public int Id {get;set;} //Propriedades e seus acessores;
        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [MaxLength(60, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]

        public string Mensagem {get;set;}
        public DateTime Data {get;set;}
        public Usuario Usuario {get;set;} //Propriedade setando que todo serviço precisa de um usuário;
        public Profissional Profissional {get;set;}//Propriedade setando que todo serviço precisa de um profissional;

    }
}