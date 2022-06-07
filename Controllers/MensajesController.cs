using AIMLbot;
using ChatBotAILM.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChatBotAILM.Controllers
{
    public class MensajesController : Controller
    {
        Bot AI = new Bot();
        static List<Mensaje> mensajes = new List<Mensaje>();
        public IActionResult irChat()
        {
            return View(mensajes);
        }
        [HttpPost]
        public ActionResult RegistrarChat(string msj)
        {

            Mensaje nuevo = new Mensaje();
            Mensaje nuevo2 = new Mensaje();

            AI.loadSettings();
            AI.loadAIMLFromFiles();
            AI.isAcceptingUserInput = false;
            User myUser = new User("Username", AI);
            AI.isAcceptingUserInput = true;
            Request r = new Request(msj, myUser, AI);
            Result res = AI.Chat(r);

            nuevo.Name = msj;

            nuevo2.Name = res.ToString();

            mensajes.Add(nuevo);
            mensajes.Add(nuevo2);
            return View("irChat", mensajes);


        }

    }
}
