using EjercicioLogin.Controllers;
using EjercicioLogin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EjercicioLogin.Views.Filters
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class AuthorizeUser: AuthorizeAttribute
    {
        private DocentesBDEntities oContexto;
        private string oRol;

        public AuthorizeUser(string oRol = "Administrador") 
        {
            this.oRol = oRol;
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            oContexto = new DocentesBDEntities();
            var usuario = string.Empty;
            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                usuario = HttpContext.Current.User.Identity.Name;
            }
            var lista = from u in oContexto.Usuario where u.Nombre == usuario && u.Rol == oRol select u;
            //base.OnAuthorization(filterContext);
            if(lista.ToList().Count == 0) 
            {
                filterContext.Result = new RedirectResult("~/Home");
            }
        }
    }
}