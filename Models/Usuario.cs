using System.ComponentModel.DataAnnotations; //permite que adicione anotações nas entidades;
namespace SaudeMais.Models
{
    public class Usuario{
        [Key]
        public int Id {get;set;} //Propriedades e seus acessores;
        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [MaxLength(60, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]

        public string Email {get;set;}
        [Required(ErrorMessage = "Este campo é obrigatório!")]
        public string Senha {get;set;}
        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [MaxLength(60, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres!")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres!")]
         public string NomeUsuario {get;set;}
        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [MaxLength(60, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres!")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres!")]
        public string Nome {get;set;}
        [Required(ErrorMessage = "Este campo é obrigatório!")]
        [MaxLength(1024, ErrorMessage = "Este campo deve conter no máximo 1024 caracteres!")]
        public string Cpf {get;set;}
        [Required(ErrorMessage = "Este campo é obrigatório!")]
        public string Endereco {get;set;}

    }
}

