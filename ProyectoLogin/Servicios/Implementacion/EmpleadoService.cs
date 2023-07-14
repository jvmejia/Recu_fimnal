using Azure;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ProyectoLogin.Models;
using ProyectoLogin.Servicios.Contrato;
using System.Data;

namespace ProyectoLogin.Servicios.Implementacion
{
    public class EmpleadoService : IEmpleadoService
    {
        private readonly DbpruebaContext _dbContext;
        public EmpleadoService(DbpruebaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Empleado>> GetEmpleados()
        {
            try
            {
                var response = await _dbContext.Empleados.ToListAsync();
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error: " + ex.Message);
            }
        }
        public async Task Crear(Empleado i)
        {
            try
            {
                Empleado empleado = new Empleado()
                {
                    NumEmpleado = i.NumEmpleado,
                    FechaIngreso = i.FechaIngreso,
                    Estatus = i.Estatus
                };
                _dbContext.Empleados.Add(empleado);
                await _dbContext.SaveChangesAsync();
                return;
            }
            catch (Exception ex)
            {
                throw new Exception("surgio un error " + ex.Message);
            }
        }
        public async Task Editor(Empleado i, int id)
        {
            try
            {
                id = i.IdEmpleado;
                var res = _dbContext.Empleados.Find(id);
                if (res != null)
                {
                    res.NumEmpleado = i.NumEmpleado;
                    res.FechaIngreso = i.FechaIngreso;
                    res.Estatus = i.Estatus;

                    _dbContext.Empleados.Update(res);
                    await _dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error: " + ex.Message);
            }
        }
        public async Task Eliminar(int id)
        {
            try
            {
                var res = _dbContext.Empleados.Find(id);
                if (res != null)
                {
                    _dbContext.Empleados.Remove(res);
                     await _dbContext.SaveChangesAsync();
                }
            }
            catch(Exception ex)
            {
                throw new Exception("Ocurrio un error: " + ex.Message);
            }

        }
    }
}
