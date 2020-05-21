using Lanche.Application.Interfaces.Services;
using Lanche.Application.Services;
using Lanche.Domain.Helpers.LancheHelper;
using Lanche.Domain.Models;
using System.Linq;
using Xunit;

namespace Lanche.UnitTest.Tests.LancheServiceTests
{
    public class DescontosLanches
    {
        private readonly ILancheService _lancheService;
        private readonly IIngredienteService _serviceIngrediente;

        public DescontosLanches()
        {
            _lancheService = new LancheService(new LancheRepositoryTest(), new LancheIngredienteRepositoryTest());
            _serviceIngrediente = new IngredienteService(new IngredienteRepositoryTest());

            if (!DBFake.Ingredientes.Any())
            {
                DBFake.CarregarBase();
            }
        }

        [Fact]
        public void DescontoCadaTresQueijosPagaDois()
        {
            // Lanche
            Domain.Models.Lanche seisQueijos = new Domain.Models.Lanche { Id = 1, Nome = "SeisQueijos" };
            // Ingrediente
            Ingrediente queijo = _serviceIngrediente.Get(5);
            // Lanche Ingrediente
            LancheIngrediente li = new LancheIngrediente
            {
                Id = 1,
                Lanche = seisQueijos,
                LancheId = 1,
                Ingrediente = queijo,
                IngredienteId = queijo.Id,
                QtdIngrediente = 6
            };
            // Add Lanche Ingrediente
            seisQueijos.LanchesIngredientes.Add(li);
            // Calcula preço do lanche
            seisQueijos.CalcularPreco();

            //6 queijos, desconta 2 queijos, da um total de 4 queijos
            var precoFinalDoLanche = queijo.Preco * 4;

            Assert.True(precoFinalDoLanche == seisQueijos.Preco);
        }

        [Fact]
        public void DescontoDeDezPorCentoCasoTenhaAlface()
        {
            // Lanche
            Domain.Models.Lanche xOvo = new Domain.Models.Lanche { Id = 1, Nome = "xOvo" };
            // Ingredientes
            Ingrediente ovo = _serviceIngrediente.Get(4);
            Ingrediente alface = _serviceIngrediente.Get(1);
            // União Lanche Ingrediente
            LancheIngrediente liOvo = new LancheIngrediente
            {
                Id = 1,
                Lanche = xOvo,
                LancheId = 1,
                Ingrediente = ovo,
                IngredienteId = ovo.Id,
                QtdIngrediente = 10
            };
            LancheIngrediente liAlface = new LancheIngrediente
            {
                Id = 1,
                Lanche = xOvo,
                LancheId = 1,
                Ingrediente = alface,
                IngredienteId = alface.Id,
                QtdIngrediente = 1
            };
            // União Lanche Ingrediente
            xOvo.LanchesIngredientes.Add(liOvo);
            xOvo.LanchesIngredientes.Add(liAlface);
            // Calcula Preco do lanche.
            xOvo.CalcularPreco();

            var precoDoLancheSemDesconto = (ovo.Preco * 10) + alface.Preco;
            var precoDoLancheComDesconto = precoDoLancheSemDesconto - ((precoDoLancheSemDesconto / 100) * 10);

            Assert.True(precoDoLancheComDesconto == xOvo.Preco);
        }

        [Fact]
        public void SemDescontoDeDezPorCentoPorTerAlfaceEBacon()
        {
            // Lanche
            Domain.Models.Lanche xOvo = new Domain.Models.Lanche { Id = 1, Nome = "xOvo" };
            // Ingredientes
            Ingrediente ovo = _serviceIngrediente.Get(4);
            Ingrediente alface = _serviceIngrediente.Get(1);
            Ingrediente bacon = _serviceIngrediente.Get(2);
            // União Lanche Ingrediente
            LancheIngrediente liOvo = new LancheIngrediente
            {
                Id = 1,
                Lanche = xOvo,
                LancheId = 1,
                Ingrediente = ovo,
                IngredienteId = ovo.Id,
                QtdIngrediente = 10
            };
            LancheIngrediente liAlface = new LancheIngrediente
            {
                Id = 1,
                Lanche = xOvo,
                LancheId = 1,
                Ingrediente = alface,
                IngredienteId = alface.Id,
                QtdIngrediente = 1
            };
            LancheIngrediente liBacon = new LancheIngrediente
            {
                Id = 1,
                Lanche = xOvo,
                LancheId = 1,
                Ingrediente = bacon,
                IngredienteId = bacon.Id,
                QtdIngrediente = 1
            };
            // União Lanche Ingrediente
            xOvo.LanchesIngredientes.Add(liOvo);
            xOvo.LanchesIngredientes.Add(liAlface);
            xOvo.LanchesIngredientes.Add(liBacon);
            // Calcula Preco do lanche.
            xOvo.CalcularPreco();

            var precoDoLancheSemDesconto = (ovo.Preco * 10) + alface.Preco + bacon.Preco;
            var precoDoLancheComDesconto = precoDoLancheSemDesconto;

            Assert.True(precoDoLancheComDesconto == xOvo.Preco);
        }
    }
}
