using Eguru.Ecommerce.Application;
using Eguru.Ecommerce.Domain.Entities;
using Eguru.Ecommerce.Domain.Enums;
using Eguru.Ecommerce.Web.Singleton;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eguru.Ecommerce.Web.Controllers
{
    public class CarrinhoController : Controller
    {
        public JsonResult Adicionar(int id, int quantity)
        {
            var order = new Order();
            order.Items = new List<Item>();

            if (Session["MeuCarrinho"] != null)
            {
                order = (Order)Session["MeuCarrinho"];
            }

            if (!order.Items.Any(x => x.ProductId == id))
            {
                var productApplication = new ProductApplication(SessionManager.GetInstance());
                var product = productApplication.Get(id);

                order.Items.Add(new Item
                {
                    ProductId = product.Id,
                    Price = product.Price,
                    Quantity = quantity,
                    Product = product
                });

                Session["MeuCarrinho"] = order;

                return Json(new { Resultado = "Sucesso" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { Resultado = "JaExiste" }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult FinalizarPedido(FormOfPayment formaPagamento)
        {
            if (Session["MeuCarrinho"] != null)
            {
                var order = (Order)Session["MeuCarrinho"];
                order.FormOfPayment = (int) formaPagamento;
                var orderApplication = new OrderApplication(SessionManager.GetInstance());
                orderApplication.Save(order);
                Session["MeuCarrinho"] = null;
                return Json(new { Resultado = "Sucesso" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { Resultado = "Erro" }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult VerItens()
        {
            var order = new Order();
            order.Items = new List<Item>();

            if (Session["MeuCarrinho"] != null)
            {
                order = (Order)Session["MeuCarrinho"];
            }

            return View(order);
        }
    }
}