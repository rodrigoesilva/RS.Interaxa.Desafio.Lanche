using System;
using Lanche.Application.Interfaces.Services;
using Lanche.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Lanche.UI.Web.Controllers
{
    public class IngredientesController : Controller
    {
        private readonly IIngredienteService _service;

        public IngredientesController(IIngredienteService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            #region Métodos utilizando Procedures

            return View(_service.SP_ListAll().ToViewsModels());

            #endregion


            //return View(_service.GetAll().ToViewsModels());
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            #region Métodos utilizando Procedures

            var ingrediente = _service.SP_GetById(id);

            #endregion

            //var ingrediente = _service.Get(id);

            if (ingrediente == null)
            {
                return NotFound();
            }

            return View(ingrediente.ToViewModel());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(IngredienteVM ingrediente)
        {
            if (ModelState.IsValid)
            {
                _service.Add(ingrediente.ToModel());

                return RedirectToAction("Index");
            }
            return View(ingrediente);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingrediente = _service.Get(id);

            if (ingrediente == null)
            {
                return NotFound();
            }

            return View(ingrediente.ToViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, IngredienteVM ingrediente)
        {
            if (id != ingrediente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _service.Update(ingrediente.ToModel());
                }
                catch (Exception ex)
                {
                    if (!IngredienteExists(ingrediente.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        ViewBag.Erro = ex.Message;
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            return View(ingrediente);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ingrediente = _service.Get(id);

            if (ingrediente == null)
            {
                return NotFound();
            }

            return View(ingrediente.ToViewModel());
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var ingrediente = _service.Get(id);
            _service.Remove(ingrediente);
            return RedirectToAction("Index");
        }

        private bool IngredienteExists(int id)
        {
            return _service.Get(id) == null ? false : true;
        }
    }
}
