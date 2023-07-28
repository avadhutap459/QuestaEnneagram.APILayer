using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ILogger = QuestaEnneagram.ServiceLayer.Interface.ILogger;

namespace QuestaEnneagram.APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyClassController : ControllerBase
    {
        private ILogger Logger { get; set; }


        public MyClassController(ILogger logger)
        {
            Logger = logger;
        }

        public void MyMethod()
        {
            //other code
            Logger.Log();
        }
    }
}
