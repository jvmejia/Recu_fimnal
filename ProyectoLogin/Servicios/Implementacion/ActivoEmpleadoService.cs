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
    public class ActivoEmpleadoService:IActivoEmpleadoService
    {
        private readonly DbpruebaContext _dbContext;
        public ActivoEmpleadoService(DbpruebaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ActivoEmpleado>> GetActivoEmpleado()
        {
            try
            {
                var response = await _dbContext.ActivoEmpleados.ToListAsync();
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error: " + ex.Message);
            }
        }
        public async Task Crear(ActivoEmpleado i)
        {
            try
            {
                
                ActivoEmpleado activo = new ActivoEmpleado()
                {
                    FkEmpleado = i.FkEmpleado,
                    FkActivo = i.FkActivo,
                    FechaDeAsignacion = i.FechaDeAsignacion,
                    FechaDeLiberacion=i.FechaDeLiberacion,
                    FechaDeEntrega=i.FechaDeEntrega
                };
                _dbContext.ActivoEmpleados.Add(activo);
                await _dbContext.SaveChangesAsync();
                return;
            }
            catch (Exception ex)
            {
                throw new Exception("surgio un error " + ex.Message);
            }
        }
        public async Task Editor(ActivoEmpleado i, int id)
        {
            try
            {
                id = i.IdActivoEmpleado;
                var res = _dbContext.ActivoEmpleados.Find(id);
                if (res != null)
                {
                    res.FkEmpleado = i.FkEmpleado;
                    res.FkActivo = i.FkActivo;
                    res.FechaDeAsignacion = i.FechaDeAsignacion;
                    res.FechaDeLiberacion = i.FechaDeLiberacion;
                    res.FechaDeEntrega = i.FechaDeEntrega;
                    _dbContext.ActivoEmpleados.Update(res);
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
                var res = _dbContext.ActivoEmpleados.Find(id);
                if (res != null)
                {
                    _dbContext.ActivoEmpleados.Remove(res);
                    await _dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error: " + ex.Message);
            }

        }
    }
}
