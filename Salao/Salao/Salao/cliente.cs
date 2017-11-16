using System.ComponentModel.DataAnnotations;
namespace Salao
{
    using System;
    using System.Collections.Generic;
    
    public partial class cliente
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public cliente()
        {
            this.funcionario = new HashSet<funcionario>();
        }
    
        public int IdCliente { get; set; }

        public string Nome { get; set; }

        [Display(Name = "CPF")]
        public string Cpf { get; set; }

        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"(^[2-9]\d{1})\d{5}\d{4}$", ErrorMessage = "Você deve digitar um telefone no formato ##-#####-#### utilize os traços")]
        public string Telefone { get; set; }

        [Display(Name = "Nome do Salão")]
        public string NomeSalao { get; set; }

        [Display(Name = "CEP")]
        public string Cep { get; set; }

        public string Rua { get; set; }

        [Display(Name = "Número")]
        public string Numero { get; set; }

        public string Complemento { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        [Display(Name = "E-mail")]
        [RegularExpression(@"^([0-9a-zA-Z]([\+\-_\.][0-9a-zA-Z]+)*)+@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,3})$", ErrorMessage = "Informe um email válido.")]
        public string Email { get; set; }

        [StringLength(100, ErrorMessage = "Deve conter no mínimo 6 caracteres", MinimumLength = 6)]
        [Required(ErrorMessage = "Obrigatório informar a Senha")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [Display(Name = "Confirme Senha")]
        [Compare("Senha", ErrorMessage = "Os campos Senhas devem ser iguais")]
        public string ConfirmaSenha { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<funcionario> funcionario { get; set; }
    }
}
