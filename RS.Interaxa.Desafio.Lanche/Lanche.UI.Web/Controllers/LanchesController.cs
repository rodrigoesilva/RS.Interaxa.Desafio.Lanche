using System;
using System.Collections.Generic;
using System.Linq;
using Lanche.Application.Interfaces.Services;
using Lanche.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace Lanche.UI.Web.Controllers
{
    public class LanchesController : Controller
    {
        private readonly ILancheService _serviceLanche;
        private readonly IIngredienteService _serviceIngrediente;

        public LanchesController(ILancheService serviceLanche,
            IIngredienteService serviceIngrediente)
        {
            _serviceLanche = serviceLanche;
            _serviceIngrediente = serviceIngrediente;
        }

        public IActionResult Index()
        {
            #region Métodos utilizando Procedures

            return View(_serviceLanche.SP_ListAll().ToViewsModels());

            #endregion

            //return View(_serviceLanche.GetAll().ToViewsModels());
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            #region Métodos utilizando Procedures

            var lanche = _serviceLanche.SP_GetById(id);

            #endregion

            //var lanche = _serviceLanche.Get(id);

            if (lanche == null)
            {
                return NotFound();
            }

            return View(lanche.ToViewModel());
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lanche = _serviceLanche.Get(id);

            decimal valTotalLanche = 0;

            foreach (var ingrediente in lanche.LanchesIngredientes)
            {
                valTotalLanche += (ingrediente.Ingrediente.Preco * ingrediente.QtdIngrediente);
            }
            lanche.Preco = valTotalLanche;

            ViewBag.Ingredientes = (IEnumerable<Domain.Models.Ingrediente>)_serviceIngrediente.GetAll();

            if (lanche == null)
            {
                return NotFound();
            }

            return View(lanche.ToViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, LancheVM lanche)
        {
            if (id != lanche.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var lstIngredientes = _serviceIngrediente.GetAll();

                    var lancheUpdate = lanche.ToModel();

                    foreach (var item in lstIngredientes)
                    {
                        if (lancheUpdate.LanchesIngredientes.FirstOrDefault(li => li.IngredienteId == item.Id) != null)
                        {
                            lancheUpdate.LanchesIngredientes.First(li => li.IngredienteId == item.Id).Ingrediente = item;
                        }
                    }

                    _serviceLanche.Update(lancheUpdate);
                }
                catch (Exception ex)
                {
                    if (!LancheExists(lanche.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        ViewBag.Erro = ex.Message;
                        throw;
                    }
                }

                return Json(new { preco = _serviceLanche.Get(id).Preco });
            }

            return View(lanche);
        }

        private bool LancheExists(int id)
        {
            return _serviceLanche.Get(id) == null ? false : true;
        }
    }
}
