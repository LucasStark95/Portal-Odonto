using System.Web.Mvc;
using Model.Models.Account;
using Model.Models;
using Negocio.Business;
using PortalOdonto.Util;
using System.Web.Security;


namespace PortalOdonto.Controllers
{
    public class UsuarioController : Controller
    {
        private GerenciadorUsuario gerenciador;

        public UsuarioController()
        {
            gerenciador = new GerenciadorUsuario();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel dadosLogin)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Obtendo o usuário.
                    //dadosLogin.Senha = Criptografia.GerarHashSenha(dadosLogin.Login + dadosLogin.Senha);
                    Usuario usuario = gerenciador.ObterByLoginSenha(dadosLogin.Login, dadosLogin.Senha);

                    // Autenticando.
                    if (usuario != null)
                    {
                        FormsAuthentication.SetAuthCookie(usuario.EmailUsuario, dadosLogin.LembrarMe);
                        if (usuario.TipoUsuario == 0)
                        {
                            SessionHelper.Set(SessionKey.ADMINISTRADOR, usuario);
                        }
                        else
                        {
                            SessionHelper.Set(SessionKey.USUARIO, usuario);
                        }

                        if (usuario.TipoUsuario == ((int)Model.Models.TipoUsuario.ALUNO))
                        {
                            return RedirectToAction("Index", "Aluno");
                        }
                        else if (usuario.TipoUsuario == ((int)Model.Models.TipoUsuario.PROFESSOR))
                        {
                            return RedirectToAction("Index", "Professor");
                        }
                        else if (usuario.TipoUsuario == ((int)Model.Models.TipoUsuario.TECNICO))
                        {
                            return RedirectToAction("Index", "Tecnico");
                        }
                        else
                            return RedirectToAction("Index", "Administrador");

                    }
                }
                ModelState.AddModelError("", "Usuário e/ou senha inválidos.");
            }
            catch
            {
                ModelState.AddModelError("", "A autenticação falhou. Forneça informações válidas e tente novamente.");
            }
            // Se ocorrer algum erro, reexibe o formulário.
            return View();
        }

        [Authenticated]
        public ActionResult Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                FormsAuthentication.SignOut();
                Session.Abandon();
            }
            return RedirectToAction("Index", "Home");
        }

        [Authenticated]
        [CustomAuthorize(NivelAcesso = Util.TipoUsuario.ADMINISTRADOR, MetodoAcao = "Index", Controladora = "AdministradorController")]
        public ActionResult IndexAdmnistrador()
        {
            return View();
        }

        [Authenticated]
        [CustomAuthorize(NivelAcesso = Util.TipoUsuario.ALUNO, MetodoAcao = "Index", Controladora = "AlunoController")]
        public ActionResult IndexAluno()
        {
            return View();
        }

        [Authenticated]
        [CustomAuthorize(NivelAcesso = Util.TipoUsuario.TECNICO, MetodoAcao = "Index", Controladora = "TecnicoController")]
        public ActionResult IndexTecnico()
        {
            return View();
        }

        [Authenticated]
        [CustomAuthorize(NivelAcesso = Util.TipoUsuario.PROFESSOR, MetodoAcao = "Index", Controladora = "ProfesorController")]
        public ActionResult IndexProfesor()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    collection["Senha"] = Criptografia.GerarHashSenha(collection["Login"] + collection["Senha"]);
                    Usuario usuario = new Usuario();
                    TryUpdateModel<Usuario>(usuario, collection.ToValueProvider());

                    gerenciador.Adicionar(usuario);
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}