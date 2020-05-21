using System;
using Lanche.Application.Interfaces.Services;
using Lanche.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace Lanche.UI.Web.Controllers
{
    public class PromocoesController : Controller
    {
        private readonly IPromocaoService _service;

        public PromocoesController(IPromocaoService service)
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

            var promocao = _service.SP_GetById(id);

            #endregion

            //var promocao = _service.Get(id);

            if (promocao == null)
            {
                return NotFound();
            }

            return View(promocao.ToViewModel());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PromocaoVM promocaoVM)
        {
            if (ModelState.IsValid)
            {
                _service.Add(promocaoVM.ToModel());

                return RedirectToAction("Index");
            }
            return View(promocaoVM);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promocao = _service.Get(id);

            if (promocao == null)
            {
                return NotFound();
            }

            return View(promocao.ToViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, PromocaoVM promocaoVM)
        {
            if (id != promocaoVM.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _service.Update(promocaoVM.ToModel());
                }
                catch (Exception ex)
                {
                    if (!PromocaoExists(promocaoVM.Id))
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

            return View(promocaoVM);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var promocao = _service.Get(id);

            if (promocao == null)
            {
                return NotFound();
            }

            return View(promocao.ToViewModel());
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var promocao = _service.Get(id);
            _service.Remove(promocao);
            return RedirectToAction("Index");
        }

        private bool PromocaoExists(int id)
        {
            return _service.Get(id) == null ? false : true;
        }
    }
}
