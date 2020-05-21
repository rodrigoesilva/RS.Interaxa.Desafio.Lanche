using Lanche.Application.Interfaces.Services;
using Lanche.Domain.Helpers.LancheHelper;
using Lanche.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Lanche.Application.Services
{
    public class LancheService : ILancheService, IDisposable
    {
        private readonly ILancheRepository _repoLanche;
        private readonly ILancheIngredienteRepository _repoLancheIngrediente;

        public LancheService(ILancheRepository repoLanche, ILancheIngredienteRepository repoLancheIngrediente)
        {
            _repoLanche = repoLanche;
            _repoLancheIngrediente = repoLancheIngrediente;
        }

        #region Métodos utilizando Procedures
        public IEnumerable<Domain.Models.Lanche> SP_ListAll()
        {
            return _repoLanche.SP_ListAll();
        }

        public Domain.Models.Lanche SP_GetById(int? id)
        {
            if (id == null) return null;

            return _repoLanche.SP_GetById(id);
        }
        #endregion
        public void Add(Domain.Models.Lanche lanche)
        {
            _repoLanche.Add(lanche);
        }

        public void AddRange(IEnumerable<Domain.Models.Lanche> lanches)
        {
            _repoLanche.AddRange(lanches);
        }

        public IEnumerable<Domain.Models.Lanche> Find(Expression<Func<Domain.Models.Lanche, bool>> lanche)
        {
            return _repoLanche.Find(lanche);
        }

        public Domain.Models.Lanche Get(int? id)
        {
            if (id == null) return null;

            return _repoLanche.Get(id);
        }

        public IEnumerable<Domain.Models.Lanche> GetAll()
        {
            return _repoLanche.GetAll();
        }

        public IEnumerable<Domain.Models.Lanche> GetAllEager()
        {
            return _repoLanche.GetAllEager();
        }

        public void Remove(Domain.Models.Lanche lanche)
        {
            _repoLanche.Remove(lanche);
        }

        public void RemoveRange(IEnumerable<Domain.Models.Lanche> lanches)
        {
            _repoLanche.RemoveRange(lanches);
        }

        public void Update(Domain.Models.Lanche lanche)
        {
            //Para gatantir vou aparga as associaçoes e criar novamente

            // associações desse lanche
            var associacoes = _repoLancheIngrediente.Find(li => li.LancheId == lanche.Id);
            _repoLancheIngrediente.RemoveRange(associacoes);

            // refaz associações
            var novas_associacoes = lanche.LanchesIngredientes;
            _repoLancheIngrediente.AddRange(novas_associacoes);

            // Calcula Preço
            lanche.CalcularPreco();

            _repoLanche.Update(lanche);
        }

        public void Dispose()
        {
            _repoLanche.Dispose();
        }
    }
}
