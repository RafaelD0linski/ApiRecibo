using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

[Route("api/[controller]")]
[ApiController]
public class ProdutoController : ControllerBase
{
    private static List<string> produtos = new List<string>
    {
        "Produto 1", "Produto 2", "Produto 3"
    };

    // GET: api/produto
    [HttpGet]
    public ActionResult<IEnumerable<string>> Get()
    {
        return Ok(produtos);
    }

    // GET: api/produto/1
    [HttpGet("{id}")]
    public ActionResult<string> Get(int id)
    {
        if (id < 0 || id >= produtos.Count)
            return NotFound("Produto não encontrado.");

        return Ok(produtos[id]);
    }

    // POST: api/produto
    [HttpPost]
    public ActionResult Post([FromBody] string produto)
    {
        produtos.Add(produto);
        return CreatedAtAction(nameof(Get), new { id = produtos.Count - 1 }, produto);
    }

    // PUT: api/produto/1
    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] string novoProduto)
    {
        if (id < 0 || id >= produtos.Count)
            return NotFound("Produto não encontrado.");

        produtos[id] = novoProduto;
        return NoContent();
    }

    // DELETE: api/produto/1
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        if (id < 0 || id >= produtos.Count)
            return NotFound("Produto não encontrado.");

        produtos.RemoveAt(id);
        return NoContent();
    }
}
