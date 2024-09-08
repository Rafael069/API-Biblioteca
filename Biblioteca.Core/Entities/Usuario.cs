using Biblioteca.Core.Enum;


namespace Biblioteca.Core.Entities
{
    public class Usuario : BaseEntity
    {

        public Usuario(string nome, string email)
        {
            
            Nome = nome;
            Email = email;
            Status = UsuarioStatusEnum.Ativo;

            Emprestimos = new List<Emprestimo>();
        }
        
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public UsuarioStatusEnum Status { get; set; }

        public List<Emprestimo> Emprestimos { get; set; }


        public void Cancel()
        {
            if (Status == UsuarioStatusEnum.Ativo)
            {
                Status = UsuarioStatusEnum.Removido;
            }
        }


        public void Update(string nome, string email)
        {
            Nome = nome;
            Email = email;

        }

    }
}
