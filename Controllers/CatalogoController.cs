// Controllers/CatalogoController.cs
using Microsoft.AspNetCore.Mvc;
using ProjetoFinal.Models; // Certifique-se de que este namespace corresponde ao seu Carro.cs
using System.Collections.Generic;

namespace ProjetoFinal.Controllers
{
    public class CatalogoController : Controller // Certifique-se de que herda de Controller
    {
        // ATENÇÃO: Em uma aplicação real, esta lista seria substituída por um banco de dados.
        // É 'static' para simular persistência em memória entre diferentes requisições,
        // mas os dados serão perdidos se a aplicação for reiniciada.
        private static List<Carro> _carros = new List<Carro>
        {
            new Carro
            {
                ImagemUrl = "~/IMG/911 GT3/Gemini_Generated_Image_oe1azdoe1azdoe1a.png",
                Titulo = "Porsche 911 GT3",
                Descricao = "O equilíbrio perfeito entre desempenho de pista e usabilidade no dia a dia.",
                LinkUrl = "/Catalogo/Detalhes?carro=Porsche911GT3" // Exemplo de LinkUrl
            },
            new Carro
            {
                ImagemUrl = "~/IMG/dodge demon/Gemini_Generated_Image_mcdj98mcdj98mcdj.png",
                Titulo = "Dodge Demon",
                Descricao = "Potência bruta e desempenho extremo para as ruas.",
                LinkUrl = "/Catalogo/Detalhes?carro=DodgeDemon"
            },
            new Carro
            {
                ImagemUrl = "~/IMG/ferrari f40/Gemini_Generated_Image_sh7cvdsh7cvdsh7c.png",
                Titulo = "Ferrari F40",
                Descricao = "Um ícone atemporal de velocidade e paixão automotiva.",
                LinkUrl = "/Catalogo/Detalhes?carro=FerrariF40"
            },
            new Carro
            {
                ImagemUrl = "~/IMG/ferrari purosangue/Gemini_Generated_Image_4dl8um4dl8um4dl8.png",
                Titulo = "Ferrari Purosangue",
                Descricao = "O primeiro SUV da Ferrari, combinando luxo e performance.",
                LinkUrl = "/Catalogo/Detalhes?carro=FerrariPurosangue"
            },
            new Carro
            {
                ImagemUrl = "~/IMG/GTR/Gemini_Generated_Image_q7gj4fq7gj4fq7gj.png",
                Titulo = "Nissan GTR",
                Descricao = "O lendário 'Godzilla', mestre das pistas e das ruas.",
                LinkUrl = "/Catalogo/Detalhes?carro=NissanGTR"
            },
            new Carro
            {
                ImagemUrl = "~/IMG/lamborghini sterrato/Gemini_Generated_Image_cfj8s7cfj8s7cfj8.png",
                Titulo = "Lamborghini Sterrato",
                Descricao = "Um superesportivo para desbravar qualquer terreno.",
                LinkUrl = "/Catalogo/Detalhes?carro=LamborghiniSterrato"
            },
            new Carro
            {
                ImagemUrl = "~/IMG/McLaren Senna/Gemini_Generated_Image_28bgnt28bgnt28bg.png",
                Titulo = "McLaren Senna",
                Descricao = "Homenagem ao lendário Ayrton Senna, feito para a pista.",
                LinkUrl = "/Catalogo/Detalhes?carro=McLarenSenna"
            },
            new Carro
            {
                ImagemUrl = "~/IMG/Rs6/Gemini_Generated_Image_y0ov6sy0ov6sy0ov.png",
                Titulo = "Audi RS6",
                Descricao = "A perua esportiva definitiva, com performance de supercarro.",
                LinkUrl = "/Catalogo/Detalhes?carro=AudiRS6"
            },
            new Carro
            {
                ImagemUrl = "~/IMG/Rubicon/Gemini_Generated_Image_q1r191q1r191q1r1.png",
                Titulo = "Jeep Rubicon",
                Descricao = "O aventureiro imparável, pronto para qualquer desafio off-road.",
                LinkUrl = "/Catalogo/Detalhes?carro=JeepRubicon"
            }
        };

        // Ação Index para listar todos os carros
        public IActionResult Index()
        {
            return View(_carros); // Passa a lista de carros para a View
        }

        // Você pode adicionar outras ações aqui, como Detalhes, Adicionar, Editar, etc.
        // Exemplo de uma ação Detalhes (você precisaria de uma View Detalhes.cshtml)
        public IActionResult Detalhes(string carro)
        {
            // Lógica para encontrar o carro pelo nome ou ID e passar para a View
            // Por enquanto, apenas um exemplo simples:
            var carroEncontrado = _carros.FirstOrDefault(c => c.Titulo.Replace(" ", "") == carro);
            if (carroEncontrado == null)
            {
                return NotFound(); // Retorna 404 se o carro não for encontrado
            }
            return View(carroEncontrado);
        }

        // GET: Catalogo/Adicionar
        public IActionResult Adicionar()
        {
            return View(); // Retorna a View com o formulário de adição
        }

        // POST: Catalogo/Adicionar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Adicionar(Carro novoCarro)
        {
            if (ModelState.IsValid)
            {
                _carros.Add(novoCarro);
                return RedirectToAction(nameof(Index)); // Redireciona de volta para a lista de carros
            }
            return View(novoCarro); // Se houver erros de validação, retorna a View com o formulário
        }
    }
}