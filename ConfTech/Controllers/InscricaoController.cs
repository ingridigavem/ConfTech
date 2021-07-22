using ConfTech.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfTech.Controllers {
    public class InscricaoController : Controller {

        private IMongoCollection<FormularioModel> _inscricao;

        public InscricaoController(IMongoClient client) {

            var database = client.GetDatabase("confTech");
            _inscricao = database.GetCollection<FormularioModel>("inscricao");
        }

        // GET: InscricaoController
        public ActionResult Index() {
            return View();
        }

        public ActionResult InscricaoRealizada() {   
            return View();
        }

        [HttpGet]
        public IEnumerable<FormularioModel> GetInscricoes() {
            return _inscricao.Find(c => true).ToList();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FormularioModel modelForm) {
            if (modelForm.Checkbox == null) modelForm.Checkbox = "off";
            if (!modelForm.InscricaoValida(modelForm.Nome, modelForm.Email)) return RedirectToAction(nameof(Index));               
            
            _inscricao.InsertOne(modelForm);
            return RedirectToAction(nameof(InscricaoRealizada));                         
        }

    }
}
