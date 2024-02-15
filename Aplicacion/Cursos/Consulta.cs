using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Cursos
{
    public class Consulta
    {
        public class ListaCurso : IRequest<List<Curso>>{ }
        public class Manejador : IRequestHandler<ListaCurso, List<Curso>>
        {
            private readonly CursosOnlineContext _context;
            public Manejador(CursosOnlineContext context){
                _context = context;
            }
            public async Task<List<Curso>> Handle(ListaCurso request, CancellationToken cancellationToken)
            {
                var cursos = await _context.Curso.ToListAsync(CancellationToken.None);
                return cursos;
            }
        }
    }
}