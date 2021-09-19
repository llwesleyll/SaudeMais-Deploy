using System;
using System.ComponentModel.DataAnnotations; //permite que adicione anotações nas entidades;
using System.ComponentModel.DataAnnotations.Schema;

namespace SaudeMais.Models   
{
    public class Area{ //Classe responsável por armazenar área de atuação do profissional;
        [Key]
        public int Id {get;set;} //Propriedades e seus acessores;
        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [MaxLength(60, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]

        public string Titulo {get;set;}

    }
}