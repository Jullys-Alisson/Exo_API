using ExoApi.Contexts;
using ExoApi.Models;

namespace ExoApi.Repositories
{
    public class ProjetoRepository
    {
        private readonly ExoContext _context;

        public ProjetoRepository(ExoContext context)
        {
            _context = context;
        }

        public List<Projeto> Listar()
        {
            return _context.Projeto.ToList();
        }

        public Projeto BuscarPorId(int id)
        {
            return _context.Projeto.Find(id);
        }

        public void Cadastrar(Projeto projeto)
        {
            _context.Projeto.Add(projeto);
            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            Projeto projeto = _context.Projeto.Find(id);

            if (projeto != null)
            {
                _context.Projeto.Remove(projeto);
                _context.SaveChanges();
            }
        }

        public void Atualizar(int id, Projeto projeto)
        {
            Projeto projetoBuscado = _context.Projeto.Find(id);

            if (projetoBuscado != null)
            {
                projetoBuscado.Titulo = projeto.Titulo;
                projetoBuscado.StatusProjeto = projeto.StatusProjeto;
                projetoBuscado.DataProjeto = projeto.DataProjeto;
                projetoBuscado.RequisitosProjeto = projeto.RequisitosProjeto;
            }
            _context.Projeto.Update(projetoBuscado);
            _context.SaveChanges();
        }
    }
}

