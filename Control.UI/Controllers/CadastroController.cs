﻿using Control.DAL;
using Control.Model.Entities;
using Control.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Control.UI.Controllers
{
    public class CadastroController : Controller
    {
        private IDALContext context;

        #region Clientes

        public ActionResult Clientes(string nomeCliente)
        {
            context = new DALContext();
            List<Customer> retorno = new List<Customer>();
            try
            {
                if (string.IsNullOrEmpty(nomeCliente))
                {
                    retorno = context.Customers.All().OrderBy(p => p.ShortName).ToList();
                }
                else
                {
                    retorno = context.Customers.All().Where(p => p.CompanyName.ToUpper().Contains(nomeCliente.ToUpper())).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return View(retorno);
        }

        public ActionResult ClientesEdit(int? ClientID)
        {
            ClienteViewModel model = new ClienteViewModel();
            context = new DALContext();

            if (ClientID > 0)
            {
                model.Customer = context.Customers.Find(p => p.Id == ClientID);
                model.Customer.Document = model.Customer.Document.Replace(".", "").Replace("-", "").Replace("/", "");
                model.Customer.ZipCode = model.Customer.ZipCode.Replace("-", "");
                model.Cities = context.Cities.Filter(p => p.StateId == model.Customer.AddressStateId).OrderBy(p => p.Name).ToList();
                model.Cities.Insert(0, new City() { Id = 0, Name = "SELECIONE..." });

                model.Vendedores = context.VendorsCustomer.Filter(p => p.CustomerID == ClientID).Select(p => p.Vendor).ToList();
                model.Vendedores.Insert(0, new Vendor() { Id = 0, Name = "SELECIONE..." });
            }

            return View(model);
        }




        public ActionResult FiltrarCliente(string FiltroCliente)
        {
            return RedirectToAction("Clientes");
        }

        public ActionResult ClientesSave(ClienteViewModel model)
        {
            context = new DALContext();

            try
            {
                //model.RegisterDate = DateTime.Now;
                //model.LastUpdate = DateTime.Now;
                //model.PhoneCode = 13;

                model.Customer.CommercialPolicy = 0;
                model.Customer.Discount = 0;

                model.Customer.Document = model.Customer.Document.Replace(".", "").Replace("-", "").Replace("/", "");
                model.Customer.ZipCode = model.Customer.ZipCode.Replace("-", "");

                model.Customer.ShippingId = model.Customer.ShippingId.HasValue && model.Customer.ShippingId.Value == 0 ? null : model.Customer.ShippingId;
                model.Customer.VendorId = model.Customer.VendorId.HasValue && model.Customer.VendorId.Value == 0 ? null : model.Customer.VendorId;

                if (model.Customer.Id > 0)
                {
                    context.Customers.Update(model.Customer);
                }
                else
                {
                    context.Customers.Create(model.Customer);
                }
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            ViewBag.Message = "Cliente cadastrado com sucesso.";

            return RedirectToAction("Clientes");
        }

        public ActionResult ClienteDelete(int? ClientID)
        {
            context = new DALContext();

            try
            {
                var retorno = context.Customers.Delete(p => p.Id == ClientID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            context.SaveChanges();

            ViewBag.Message = "Cliente excluído com sucesso.";

            return RedirectToAction("Clientes");
        }

        public JsonResult GetAddressByCep(string cep)
        {
            var CEP = new DAL.CEP.Objects.CEP();
            City objCityCEP = new City();

            try
            {
                objCityCEP = CEP.GetCityByCEP(cep);
                objCityCEP.CEP = Utility.Serialization.Deserialize<Utility.CEP>(Utility.Utilities.GetXmlAddressByCEP(cep));
                objCityCEP.Name = objCityCEP.CEP.Cidade.ToUpper();
                objCityCEP.CEP.Bairro = objCityCEP.CEP.Bairro.ToUpper();

                context = new DALContext();

                bool cityExists = context.Cities.Find(p => p.IBGECode == objCityCEP.IBGECode) == null ? false : true;

                if (!cityExists)
                {
                    var objCity = new City()
                    {
                        Name = objCityCEP.Name,
                        CEPInicial = objCityCEP.CEPInicial,
                        CEPFinal = objCityCEP.CEPFinal,
                        IBGECode = objCityCEP.IBGECode,
                        StateId = context.States.Find(p => p.UF.Trim().ToUpper() == objCityCEP.CEP.UF.Trim().ToUpper()).Id,
                        CEP = objCityCEP.CEP
                    };

                    context.Cities.Create(objCity);
                    context.SaveChanges();

                    var ListaCidades = context.Cities.All().OrderBy(p => p.Name).ToList();

                    return Json(new { Cidade = objCity, ListaCidades = ListaCidades }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    var objCity = context.Cities.Find(p => p.IBGECode == objCityCEP.IBGECode);
                    objCity.CEP = objCityCEP.CEP;

                    var ListaCidades = context.Cities.All().OrderBy(p => p.Name).ToList();

                    return Json(new { Cidade = objCity, ListaCidades = ListaCidades }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                throw ex;
                //return Json(new { Cidade = "", ListaCidades = "" }, JsonRequestBehavior.AllowGet);
            }


        }

        public JsonResult GetCitiesByState(int StateID)
        {
            context = new DALContext();

            var CityList = context.Cities.All().Where(p => p.StateId == StateID).OrderBy(p => p.Name).ToList();

            return Json(new { Cidades = CityList }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Contatos

        public ActionResult Contatos(string nomeContato)
        {
            context = new DALContext();
            List<Contact> retorno = new List<Contact>();
            try
            {
                if (string.IsNullOrEmpty(nomeContato))
                {
                    retorno = context.Contacts.All().ToList();
                }
                else
                {
                    retorno = context.Contacts.All().Where(p => p.ContatName.ToUpper().Contains(nomeContato.ToUpper())).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return View(retorno);
        }


        public ActionResult ContatosEdit(int? ContatoID)
        {
            Contact model = new Contact();
            context = new DALContext();

            var listaClientes = context.Customers.All().ToList();
            ViewBag.ListaClientes = listaClientes;

            var listaVendedores = context.Vendors.All().ToList();
            ViewBag.ListaVendedores = listaVendedores;


            if (ContatoID > 0)
            {
                model = context.Contacts.Find(p => p.Id == ContatoID);
            }
            return View(model);
        }

        public ActionResult FiltrarContato(string FiltroContato)
        {
            return RedirectToAction("Contatos");
        }

        public ActionResult ContatoSave(Contact model)
        {
            context = new DALContext();

            try
            {
                model.RegisterDate = DateTime.Now;
                model.LastUpdate = DateTime.Now;

                if (ModelState.IsValid)
                {

                    if (model.VendorID == null)
                    {
                        model.VendorID = 1;
                    }

                    if (model.Id > 0)
                    {
                        context.Contacts.Update(model);
                    }
                    else
                    {
                        context.Contacts.Create(model);
                    }
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            ViewBag.Message = "Contato cadastrado com sucesso.";

            return RedirectToAction("Contatos");
        }

        public ActionResult ContatoDelete(int? ContatoID)
        {
            context = new DALContext();

            try
            {
                var retorno = context.Contacts.Delete(p => p.Id == ContatoID);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            ViewBag.Message = "Contato excluído com sucesso.";

            return RedirectToAction("Contatos");
        }
        #endregion

        #region Vendedores

        public ActionResult Vendedores(string nomeVendedor)
        {
            context = new DALContext();
            List<Vendor> retorno = new List<Vendor>();
            try
            {
                if (string.IsNullOrEmpty(nomeVendedor))
                {
                    retorno = context.Vendors.All().ToList();
                }
                else
                {
                    retorno = context.Vendors.All().Where(p => p.Name.ToUpper().Contains(nomeVendedor.ToUpper())).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return View(retorno);
        }

        public ActionResult VendedoresEdit(int? VendedorID)
        {
            Vendor model = new Vendor();
            context = new DALContext();

            if (VendedorID > 0)
            {
                model = context.Vendors.Find(p => p.Id == VendedorID);
            }
            return View(model);
        }

        public ActionResult FiltrarVendedores(string FiltroVendedor)
        {
            return RedirectToAction("Vendedores");
        }

        public ActionResult VendedorSave(Vendor model)
        {
            context = new DALContext();

            try
            {
                if (model.PercentCommission <= 0)
                {
                    model.PercentCommission = 5;
                }

                if (model.Id > 0)
                {
                    context.Vendors.Update(model);
                }
                else
                {
                    context.Vendors.Create(model);
                }
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            ViewBag.Message = "Vendedor cadastrado com sucesso.";

            return RedirectToAction("Vendedores");
        }

        public ActionResult VendedorDelete(int? VendedorID)
        {
            context = new DALContext();

            try
            {
                var retorno = context.Vendors.Delete(p => p.Id == VendedorID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            context.SaveChanges();

            ViewBag.Message = "Vendedor excluído com sucesso.";

            return RedirectToAction("Vendedores");
        }
        #endregion

        #region Fornecedores

        public ActionResult Fornecedores(string nomeFornecedor)
        {
            context = new DALContext();
            List<Provider> retorno = new List<Provider>();
            try
            {
                if (string.IsNullOrEmpty(nomeFornecedor))
                {
                    retorno = context.Providers.All().ToList();
                }
                else
                {
                    retorno = context.Providers.All().Where(p => p.CompanyName.ToUpper().Contains(nomeFornecedor.ToUpper())).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return View(retorno);
        }

        public ActionResult FornecedoresEdit(int? FornecedorID)
        {
            Provider model = new Provider();
            context = new DALContext();

            if (FornecedorID > 0)
            {
                model = context.Providers.Find(p => p.Id == FornecedorID);
            }
            return View(model);
        }

        public ActionResult FiltrarFornecedor(string FiltroFornecedor)
        {
            return RedirectToAction("Fornecedores");
        }

        public ActionResult FornecedorSave(Provider model)
        {
            context = new DALContext();

            try
            {
                model.RegisterDate = DateTime.Now;
                model.LastUpdate = DateTime.Now;
                model.PhoneCode = 13;
                model.CommercialPolicy = 0;
                model.Discount = 0;

                if (model.Id > 0)
                {
                    context.Providers.Update(model);
                }
                else
                {
                    context.Providers.Create(model);
                }
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            ViewBag.Message = "Fornecedor cadastrado com sucesso.";

            return RedirectToAction("Fornecedores");
        }

        public ActionResult FornecedorDelete(int? FornecedorID)
        {
            context = new DALContext();

            try
            {
                var retorno = context.Providers.Delete(p => p.Id == FornecedorID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            context.SaveChanges();

            ViewBag.Message = "Fornecedor excluído com sucesso.";

            return RedirectToAction("Fornecedores");
        }
        #endregion

        #region Produtos

        public ActionResult Produtos(string nomeProduto)
        {
            context = new DALContext();
            List<Product> retorno = new List<Product>();
            try
            {
                if (string.IsNullOrEmpty(nomeProduto))
                {
                    retorno = context.Products.All().ToList();
                }
                else
                {
                    retorno = context.Products.All().Where(p => p.Name.ToUpper().Contains(nomeProduto.ToUpper())).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return View(retorno);
        }

        public ActionResult ProdutosEdit(int? ProdutoID)
        {
            ProdutoViewModel model = new ProdutoViewModel();
            context = new DALContext();

            if (ProdutoID > 0)
            {
                model.Product = context.Products.Find(p => p.Id == ProdutoID);
                model.ProviderID = model.Providers.Select(p => p.Id).First();
                model.ProductProviders = context.ProductProviders.Filter(p => p.ProductID == ProdutoID).ToList();
            }

            //model.AtualizarCodigoProdutoFornecedor();

            ViewBag.Unidades = context.TypesUnities.All().ToList();
            return View(model);
        }

        public ActionResult FiltrarProdutos(string FiltroProduto)
        {
            return RedirectToAction("Produtos");
        }

        public ActionResult ProdutosSave(ProdutoViewModel model)
        {
            context = new DALContext();

            try
            {
                //prod.AliqICMS = 3;
                //prod.CombinedProduct = false;
                //prod.MinimumStockAlert = 50;
                model.Product.ProductTypeUnitID = 1;

                if (model.Product.ProductTypeUnitID > 0)
                {
                    var unidade = context.TypesUnities.Find(p => p.Id == model.Product.ProductTypeUnitID).Description;

                    model.Product.UnitMeasure = unidade;
                }

                if (string.IsNullOrEmpty(model.Product.DescriptionNCC))
                {
                    model.Product.DescriptionNCC = model.Product.Description;
                }

                if (model.Product.Id > 0)
                {
                    model.Product.QuantityCurrentStock = model.Product.QuantityCurrentStock.HasValue ? model.Product.QuantityCurrentStock.Value : 0;
                    context.Products.Update(model.Product);
                }
                else
                {
                    model.Product.QuantityCurrentStock = model.Product.QuantityCurrentStock.HasValue ? model.Product.QuantityCurrentStock.Value : 0;
                    context.Products.Create(model.Product);
                }

                //var productProvider = context.ProductProviders.Filter(p => p.ProductID == model.Product.Id && p.ProviderID == model.ProviderID).FirstOrDefault();

                //if (productProvider == null)
                //{
                //    productProvider = new ProductProvider()
                //    {
                //        Code = model.CodigoProdutoFornecedor,
                //        ProductID = model.Product.Id,
                //        ProviderID = model.ProviderID
                //    };

                //    context.ProductProviders.Create(productProvider);
                //}
                //else
                //{
                //    productProvider.Code = model.CodigoProdutoFornecedor;
                //    context.ProductProviders.Update(productProvider);
                //}

                Storage EstoqueProduto = context.Storages.Find(q => q.ProductID == model.Product.Id);
                if (EstoqueProduto != null)
                {
                    EstoqueProduto.Quantity += model.Product.QuantityCurrentStock.HasValue ? model.Product.QuantityCurrentStock.Value : 0;
                    context.Storages.Update(EstoqueProduto);
                }
                else
                {
                    EstoqueProduto = new Storage
                    {
                        ProductID = model.Product.Id,
                        Quantity = model.Product.QuantityCurrentStock.HasValue ? model.Product.QuantityCurrentStock.Value : 0,
                        UpdateDate = DateTime.Now,

                    };
                    context.Storages.Create(EstoqueProduto);
                }

                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            ViewBag.Message = "Produto cadastrado com sucesso.";

            return RedirectToAction("Produtos");
        }

        public ActionResult ProdutoDelete(int? ProdutoID)
        {
            context = new DALContext();

            try
            {
                context.Storages.Delete(p => p.ProductID == ProdutoID);
                var retorno = context.Products.Delete(p => p.Id == ProdutoID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            context.SaveChanges();

            ViewBag.Message = "Produto excluído com sucesso.";

            return RedirectToAction("Produtos");
        }

        public PartialViewResult GetProductProviders(int ProductID)
        {
            try
            {
                context = new DALContext();
                var ProductProviders = context.ProductProviders.Filter(p => p.ProductID == ProductID).ToList();

                int i = 0;
                ProductProviders.ForEach(p =>
                {
                    p.Sequencial = ++i;
                });

                return PartialView("_ListFornecedorProduto", ProductProviders);
            }
            catch (Exception ex)
            {
                return PartialView("_ListFornecedorProduto", ex.Message);
            }
        }

        public JsonResult VerificarVinculoFornecedorProduto(int ProviderID, int ProductID)
        {
            try
            {
                context = new DALContext();

                bool vinculoExiste = context.ProductProviders.Filter(p => p.ProductID == ProductID && p.ProviderID == ProviderID).Count() > 0;

                return Json(vinculoExiste);
            }
            catch (Exception ex)
            {
                return Json(ex.Message);
            }
        }

        public JsonResult VincularFornecedorProduto(int ProviderID, int ProductID, long codigoProdutoFornecedor, string modeloFabricante)
        {
            try
            {
                context = new DALContext();

                var objProductProvider = new ProductProvider()
                {
                    ProductID = ProductID,
                    ProviderID = ProviderID,
                    Code = codigoProdutoFornecedor,
                    IsActive = true,
                    ModelProvider = modeloFabricante
                };

                context.ProductProviders.Create(objProductProvider);
                context.SaveChanges();

                return Json(new { erro = false });
            }
            catch (Exception ex)
            {
                return Json(new { erro = true, msg = ex.Message });
            }
        }

        public JsonResult ExcluirVinculoFornecedorProduto(int ProductProviderID)
        {
            try
            {
                context = new DALContext();

                var productProvider = context.ProductProviders.Find(p => p.Id == ProductProviderID);

                if (productProvider == null)
                    throw new Exception("Vínculo não encontrado!");

                context.ProductProviders.Delete(productProvider);
                context.SaveChanges();

                return Json(new { erro = false, msg = "Vínculo excluído com Sucesso!" });
            }
            catch (Exception ex)
            {
                return Json(new { erro = true, msg = ex.Message });
            }
        }

        #endregion

        #region CFOP

        #endregion

        #region Condição de Pagamento

        public ActionResult CondicaoPagamento()
        {
            context = new DALContext();
            List<PaymentTerm> retorno = new List<PaymentTerm>();
            try
            {
                retorno = context.PaymentTerms.All().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return View(retorno);
        }

        public ActionResult CondicaoPagamentoEdit(int? PaymentTermID)
        {
            var model = new PaymentTerm();
            context = new DALContext();

            if (PaymentTermID > 0)
                model = context.PaymentTerms.Find(p => p.Id == PaymentTermID);

            return View(model);
        }

        public ActionResult CondicaoPagamentoSave(PaymentTerm PaymentTerm)
        {
            context = new DALContext();

            try
            {
                //prod.AliqICMS = 3;
                //prod.CombinedProduct = false;
                //prod.MinimumStockAlert = 50;
                if (PaymentTerm.Id > 0)
                {
                    context.PaymentTerms.Update(PaymentTerm);
                }
                else
                {
                    context.PaymentTerms.Create(PaymentTerm);
                }
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            ViewBag.Message = "Condição de Pagamento cadastrada com sucesso.";

            return RedirectToAction("CondicaoPagamento");
        }

        public ActionResult CondicaoPagamentoDelete(int? PaymentTermID)
        {
            context = new DALContext();

            try
            {
                var retorno = context.PaymentTerms.Delete(p => p.Id == PaymentTermID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            context.SaveChanges();

            ViewBag.Message = "Condição de Pagamento excluída com sucesso.";

            return RedirectToAction("CondicaoPagamento");
        }

        public JsonResult ObterCalculoAliquota(int quantidadeDias)
        {
            context = new DALContext();

            try
            {
                var objCondicaoPagamento = context.PaymentTerms.Find(p => p.Days == 30);

                if (objCondicaoPagamento == null)
                    return Json(new { erro = false, aliquota = 0 });

                decimal percentualAliquota = (quantidadeDias * objCondicaoPagamento.Aliquota) / objCondicaoPagamento.Days;

                return Json(new { erro = false, aliquota = percentualAliquota }); 
            }
            catch (Exception ex)
            {
                return Json(new { erro = true, msg = ex.Message });
            }
        }

        #endregion

        #region Contatos Email
        public ActionResult ContatosEmailLista()
        {
            context = new DALContext();
            List<UserAdressBook> retorno = new List<UserAdressBook>();
            try
            {
                if (string.IsNullOrEmpty(User.Identity.Name))
                {
                    retorno = context.AddressBooks.All().ToList();
                }
                else
                {
                    retorno = context.AddressBooks.All().Where(p => p.Username.ToUpper().Contains(User.Identity.Name.ToUpper())).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return View(retorno);
        }

        public ActionResult ContatosEmailEdit(int? AddressBookID)
        {
            UserAdressBook model = new UserAdressBook();
            model.Username = User.Identity.Name;

            context = new DALContext();

            if (AddressBookID > 0)
            {
                model = context.AddressBooks.Find(p => p.Id == AddressBookID);
            }

            return View(model);
        }

        public ActionResult ContatosEmailSave(UserAdressBook model)
        {
            context = new DALContext();

            try
            {

                if (ModelState.IsValid)
                {
                    model.Username = User.Identity.Name;

                    if (model.Id > 0)
                    {
                        context.AddressBooks.Update(model);
                    }
                    else
                    {
                        context.AddressBooks.Create(model);
                    }
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            ViewBag.Message = "Contato cadastrado com sucesso.";

            return RedirectToAction("ContatosEmailLista");
        }

        public ActionResult ContatosEmailDelete(int? ContatoID)
        {
            context = new DALContext();

            try
            {
                var retorno = context.AddressBooks.Delete(p => p.Id == ContatoID);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            ViewBag.Message = "Contato excluído com sucesso.";

            return RedirectToAction("ContatosEmailLista");
        }
        #endregion
    }
}