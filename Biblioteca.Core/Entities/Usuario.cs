using Biblioteca.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Core.Entities
{
    public class Usuario /*: BaseEntity*/
    {

        public Usuario(int id, string nome, string email)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Status = UsuarioStatusEnum.Ativo;

            Emprestimos = new List<Emprestimo>();
        }
        public int Id { get; private set; }
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

    }
}
