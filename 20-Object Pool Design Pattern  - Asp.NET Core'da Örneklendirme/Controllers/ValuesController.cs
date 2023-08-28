using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.ObjectPool;
using System.Xml.Linq;

namespace _20_Object_Pool_Design_Pattern____Asp.NET_Core_da_Örneklendirme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        readonly ObjectPool<X> _pool;
        readonly ObjectPool<Y> _pooly;

        public ValuesController(ObjectPool<X> pool, ObjectPool<Y> pooly)
        {
            _pool = pool;
            _pooly = pooly;
        }

        [HttpGet("get1")]
        public IActionResult get1()
        {
            var x1 = _pool.Get();
            x1.Count++;
            x1.Write();
            _pool.Return(x1);
            return Ok(x1.Count);
        }

        [HttpGet("get2")]
        public IActionResult get2()
        {
            var x2 = _pool.Get();
            x2.Count++;
            x2.Write();
            _pool.Return(x2);
            return Ok(x2.Count);
        }

        [HttpGet("get3")]
        public IActionResult get3()
        {
            var x2 = _pooly.Get();
            x2.Index++;
            x2.Write();
            _pooly.Return(x2);
            return Ok(x2.Index);
        }
    }
}
