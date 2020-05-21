using System;

namespace Lanche.Domain.Core.Models
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.Now;
    }
}
