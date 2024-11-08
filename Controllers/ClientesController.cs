using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("[controller]")]
public class ClientesController : ControllerBase
{
    private static List<Cliente> Clientes = new List<Cliente>();

    [HttpGet]
    public ActionResult<List<Cliente>> GetAll()
    {
        return Clientes;
    }

    [HttpGet("{id}")]
    public ActionResult<Cliente> GetById(int id)
    {
        Cliente ClienteEncontrado = null;
        foreach (var Cliente in Clientes)
        {
            if (Cliente.Id == id)
            {
                ClienteEncontrado = Cliente;
                break;
            }
        }
        if (ClienteEncontrado == null)
        {
            return NotFound();
        }
        return ClienteEncontrado;
    }
    [HttpPost]
    public ActionResult Post(Cliente Cliente)
    {
        Clientes.Add(Cliente);
        return Created();
    }
    [HttpPut("{id}")]
    public ActionResult Put(int id, Cliente ClienteAtualizado)
    {
        Cliente ClienteEncontrado = null;
        foreach (var Cliente in Clientes)
        {
            if (Cliente.Id == id)
            {
                ClienteEncontrado = Cliente;
                break;
            }
        }
        if (ClienteEncontrado == null)
        {
            return NotFound();
        }
        ClienteEncontrado.Id = ClienteAtualizado.Id;
        ClienteEncontrado.Nome = ClienteAtualizado.Nome;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        Cliente ClienteEncontrado = null;
        foreach (var Cliente in Clientes)
        {
            if (Cliente.Id == id)
            {
                ClienteEncontrado = Cliente;
                break;
            }
        }
        if (ClienteEncontrado == null)
        {
            return NotFound();
        }
        Clientes.Remove(ClienteEncontrado);
        return NoContent();
    }

}