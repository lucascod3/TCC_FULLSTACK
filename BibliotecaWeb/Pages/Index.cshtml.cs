using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BibliotecaWeb.Models;
using System.Collections.Generic;
using System.Linq;

namespace BibliotecaWeb.Pages
{
    public class IndexModel : PageModel
    {
        public List<Livro> Livros { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Busca { get; set; }

        public void OnGet()
        {
            var lista = new List<Livro>
            {
                new Livro { Numero = 1, Titulo = "Algoritmos e Estruturas de Dados", Autor = "N. Wirth", Ano = 1976, Descricao = "Fundamentos da programação." },
                new Livro { Numero = 2, Titulo = "Clean Code", Autor = "Robert C. Martin", Ano = 2008, Descricao = "Código limpo e sustentável." },
                new Livro { Numero = 3, Titulo = "Design Patterns", Autor = "Erich Gamma et al.", Ano = 1994, Descricao = "Padrões de projeto." },
                new Livro { Numero = 4, Titulo = "Inteligência Artificial: Uma Abordagem Moderna", Autor = "Russell & Norvig", Ano = 2010, Descricao = "Livro referência em IA." },
                new Livro { Numero = 5, Titulo = "Introdução à Programação em C#", Autor = "John Sharp", Ano = 2015, Descricao = "Guia prático para aprender C#." }
            };

            // Se o usuário digitou algo, filtra
            if (!string.IsNullOrEmpty(Busca))
            {
                Livros = lista
                    .Where(l =>
                        l.Titulo.Contains(Busca, System.StringComparison.OrdinalIgnoreCase) ||
                        l.Numero.ToString() == Busca)
                    .OrderBy(l => l.Titulo)
                    .ToList();
            }
            else
            {
                Livros = lista.OrderBy(l => l.Titulo).ToList();
            }
        }
    }
}