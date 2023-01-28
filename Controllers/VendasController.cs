using Api.Data;
using Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("V1")]
public class VendasController : ControllerBase
{
    private readonly AppDataContext _context;

    public VendasController(AppDataContext context)
    {
        _context = context;
    }


    [HttpPost("CadastrarVenda")]
    public IActionResult Create(Venda venda)
    {
        _context.Vendas.Add(venda);
        _context.SaveChanges();

        return Ok(venda);
    }

    [HttpGet("Buscar{id}")]
    public IActionResult Get(int id)
    {
        var vendaDataBase = _context.Vendas.Find(id);

        return (vendaDataBase == null) ? NotFound() : Ok(vendaDataBase);
    }

    [HttpGet("ImprimirTudo")]
    public IActionResult GetAll()
    {
        return Ok(_context.Vendas.ToList());
    }


    [HttpPut("Atualizar{id}")]
    public IActionResult Atualizar(int id, Venda venda)
    {
        var vendaDataBase = _context.Vendas.Find(id);

        if(vendaDataBase == null)
            return NotFound();
        
        vendaDataBase.Data = venda.Data;
        vendaDataBase.Descricao = venda.Descricao;
        vendaDataBase.Preco = venda.Preco;

        _context.SaveChanges();

        return Ok(vendaDataBase);
    }

    [HttpDelete("Deletar{id}")]
    public IActionResult Delete(int id)
    {
        var vendaDataBase = _context.Vendas.Find(id);

        if(vendaDataBase == null)
            return NotFound();

        _context.Vendas.Remove(vendaDataBase);
        _context.SaveChanges();
        
        return NoContent();
    }
}