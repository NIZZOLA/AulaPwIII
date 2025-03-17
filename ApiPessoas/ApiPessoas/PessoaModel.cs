using System.ComponentModel.DataAnnotations;

namespace ApiPessoas
{
    public class PessoaModel
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Nome { get; set; }
        [MaxLength (50)]
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        [MaxLength(18)]
        public string CPF { get; set; }
        [MaxLength(18)]
        public string RG { get; set; }
        
        [MaxLength(50)]
        public string Endereco { get; set; }
        [MaxLength(10)]
        public string Numero { get; set; }
        [MaxLength(50)]
        public string Complemento { get; set; }
        [MaxLength(50)]
        public string Bairro { get; set; }
        [MaxLength(50)]
        public string Cidade { get; set; }
        [MaxLength(2)]
        public string Estado { get; set; }
        [MaxLength(10)]
        public string CEP { get; set; }
        [MaxLength(15)]
        public string Telefone { get; set; }
        [MaxLength(15)]
        public string Celular { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        
    }
}
