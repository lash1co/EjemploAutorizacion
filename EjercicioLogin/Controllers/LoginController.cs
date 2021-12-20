using EjercicioLogin.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EjercicioLogin.Controllers
{
    public class LoginController : Controller
    {
        DocentesBDEntities contexto = new DocentesBDEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LoginUsuario(string txtUsuario, string txtPassword, string btnRegistrar, string btnIngresar) 
        {
            if (btnRegistrar != null) 
            {
                return View("Registrarse");
            }
            else if(btnIngresar != null) 
            { 
                var usuExistente = contexto.Usuario.FirstOrDefault(u => u.Nombre.Equals(txtUsuario) 
                                                                            && u.Password.Equals(txtPassword));
                if(usuExistente != null) 
                {
                    FormsAuthentication.SetAuthCookie(usuExistente.Nombre, true);
                    return RedirectToAction("Index", "Home");
                }
                else 
                {
                    return View("LoginError");
                }
            }
            else { return View("LoginError"); }
        }

        public ActionResult Close() 
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Login");
        }

        public ActionResult LoginError() 
        {
            return View();
        }

        public ActionResult Registrarse() 
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RegistrarUsuario(Usuario usuario) 
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //var nuevoUsu = new Usuario();
                    //nuevoUsu.Nombre = usuario.Nombre;
                    //nuevoUsu.Password = usuario.Password;
                    //nuevoUsu.FechaIngreso = usuario.FechaIngreso;
                    //nuevoUsu.Rol = usuario.Rol;
                    // Aquí cualquier uso de las variables del Modelo
                    contexto.Usuario.Add(usuario);
                    contexto.SaveChanges();
                }
            }
            catch (DbEntityValidationException e)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "No se pueden guardar cambios. Intenta de nuevo, y si el problema persiste comunicate con el administrador.");
            }
            return View("Index");
        }
    }
}