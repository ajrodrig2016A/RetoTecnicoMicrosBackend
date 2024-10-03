using Core.RetoTecnico.API.Controllers;
using Core.RetoTecnico.Application.Contracts.Persistence;
using Core.RetoTecnico.Infrastructure.Context;
using Core.RetoTecnico.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetoTecnico.Tests;
[TestClass]
public class ClientesControllerTests
{
    private BancoContext _context;
    private ClientesController _controller;
    private ClientesRepository _clienteRepository;
    public ClientesControllerTests()
    {
        var builder = WebApplication.CreateBuilder();

        _context = new BancoContext(new DbContextOptionsBuilder<BancoContext>()
            .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")).Options);

        //_controller = new ClientesController(_clienteRepository);
        _clienteRepository = new ClientesRepository(_context);
}

    [TestMethod]
    public async Task Get_ReturnsAllClientes()
    {
        //Act
        var result = await _clienteRepository.GetAllClientes();

        //Assert
        Assert.AreEqual(3, result.Count());
    }

    [TestMethod]
    public async Task Get_ClienteById()
    {
        int id = 2;

        //Act
        var result = await _clienteRepository.GetClienteById(id);

        //Assert
        Assert.AreEqual("Myriam Simbaña", result.Nombre);
    }

    [TestMethod]
    public async Task Post_AddCliente()
    {
        //Act
        var result = await _clienteRepository.AddCliente(new Core.RetoTecnico.Domain.Entities.Clientes { Nombre = "Santiago Carrera", Genero = 'F', Edad = 51, Identificacion = "1425639874", Direccion = "Solanda", Telefono = "0993666590", Contrasenia = "1547896", Estado = true, Cuentas = [] });

        //Assert
        Assert.AreEqual("1425639874", result);
    }

    [TestMethod]
    public async Task Put_UpdateCliente()
    {
        //Act
        var result = await _clienteRepository.UpdateCliente(new Core.RetoTecnico.Domain.Entities.Clientes { Id = 5, Nombre = "Santiago Carrera", Genero = 'M', Edad = 51, Identificacion = "1713071965", Direccion = "Recreo", Telefono = "0993666590", Contrasenia = "24681012", Estado = false, Cuentas = [] });

        //Assert
        Assert.AreEqual(5, result);
    }

    [TestMethod]
    public async Task Delete_BorrarCliente()
    {
        int id = 5;
        //Act
        var result = await _clienteRepository.DeleteCliente(id);

        //Assert
        Assert.AreEqual(5, result);
    }

    [TestMethod]
    public async Task Delete_BorrarObjCliente()
    {
        //Act
        var result = await _clienteRepository.DeleteCliente(new Core.RetoTecnico.Domain.Entities.Clientes { Id = 5, Nombre = "Santiago Carrera", Genero = 'M', Edad = 51, Identificacion = "1713071965", Direccion = "Recreo", Telefono = "0993666590", Contrasenia = "24681012", Estado = false, Cuentas = [] });

        //Assert
        Assert.AreEqual(5, result);
    }

}
