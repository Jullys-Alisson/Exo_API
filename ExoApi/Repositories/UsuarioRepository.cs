using ExoApi.Interfaces;
using ExoApi.Contexts;
using ExoApi.Models;

namespace ExoApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ExoContext _context;

        public UsuarioRepository(ExoContext context)
        {
            _context = context;
        }

        public void Atualizar(int id, Usuario usuario)
        {
            Usuario usuarioEncontrado = _context.Usuario.Find(id);

            if (usuarioEncontrado != null)
            {
                usuarioEncontrado.Email = usuario.Email;
                usuarioEncontrado.Senha = usuario.Senha;
                usuarioEncontrado.Tipo = usuario.Tipo;
            }

            _context.Usuario.Update(usuarioEncontrado);
            _context.SaveChanges();
        }

        public Usuario BuscarPorId(int id)
        {
            return _context.Usuario.Find(id);
        }

        public void Cadastrar(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            Usuario usuarioEncontrado = _context.Usuario.Find(id);
            _context.Usuario.Remove(usuarioEncontrado);
            _context.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return _context.Usuario.ToList();
        }

        public Usuario Login(string email, string senha)
        {
            return _context.Usuario.First(u => u.Email == email && u.Senha == senha);
        }
    }
}

