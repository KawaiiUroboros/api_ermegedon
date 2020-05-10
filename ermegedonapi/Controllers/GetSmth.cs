using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
namespace ermegedonapi.Controllers
{
    [ApiController]
    
    public class GetSmth : ControllerBase
    {
        string Header { get; set; } = null;
        [HttpPost("/post")]
        public SmthResponse Post([FromBody] SmthRequest smth)
        {
            try
            {
                Header = smth.Header;
                System.IO.File.WriteAllText("header.txt",smth.Header);
                return new SmthResponse()
                {
                    Header = this.Header
                };
            }
            catch (Exception Ex)
            {
                return new SmthResponse()
                {
                    Header = "NO"+Ex.Message

                };
            };
        }
        [HttpGet("/get")]
        public SmthResponse Get()
        {
            Header = System.IO.File.ReadAllText("header.txt");
            if (Header != null)
            {
                return new SmthResponse()
                {
                    Header = this.Header
                };
            }
            else
            {
                return new SmthResponse()
                {
                    Header = "ERROR"+this.Header
                };
            }
        }
    }
   
}
    

