using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Planejae.UI.Models;
using Microsoft.AspNet.Identity;

namespace Planejae.UI.Controllers
{
    public class AtividadeController : Controller
    {
        #region Propriedades
        public BLL.Classes.AtividadeBLL Bll = new BLL.Classes.AtividadeBLL();
        #endregion

        //
        // GET: /Atividade/
        [Authorize(Roles = "Gestor")]
        public ActionResult Index()
        {
            var listBll = Bll.GetAll();

            var modelList = new List<AtividadeModel>();

            listBll.ForEach(x => modelList.Add(new AtividadeModel(x)));

            return View("View", modelList);
        }

        //
        // GET: /Atividade/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Atividade/Create
        public ActionResult Create()
        {
            AtividadeModel model = new AtividadeModel();

            model.Responsaveis = Bll.GetResponsaveis();
            return View(model);
        }

        //
        // POST: /Atividade/Create
        [HttpPost]
        public ActionResult Create(AtividadeModel model)
        {
            try
            {
                var ativ = model.ToRow();

                ativ.Id_Usuario_Atualiz = User.Identity.GetUserId();

                Bll.InsertUpdate(ativ, model.IdsResponsaveis.ToList());                

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Atividade/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Atividade/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Atividade/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Atividade/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
