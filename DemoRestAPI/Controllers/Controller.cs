using BLL;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CustomerRestAPI.Controllers
{
	[EnableCors("MyPolicy")]
	[Produces("application/json")]
	[Route("api/addresses")]
	public class Controller : Microsoft.AspNetCore.Mvc.Controller
	{
        IBLLFacade facade;

        public Controller(IBLLFacade facade)
        {
            this.facade = facade;
        }
    }
}
