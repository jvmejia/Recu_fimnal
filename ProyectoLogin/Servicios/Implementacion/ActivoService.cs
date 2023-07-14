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
    public class ActivoService: IActivoService
    {
        private readonly DbpruebaContext _dbContext;
        public ActivoService(DbpruebaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Activo>> GetActivos()
        {
            try
            {
                var response = await _dbContext.Activos.ToListAsync();
                return response;
            }
            catch (Exception ex)
            {
                throw new Exception("Surgio un error: " + ex.Message);
            }
        }
        public async Task Crear(Activo i)
        {
            try
            {
                Activo activo = new Activo()
                {
                    Nombre = i.Nombre,
                    Descripcion = i.Descripcion,
                    Estatus = i.Estatus
                };
                _dbContext.Activos.Add(activo);
                await _dbContext.SaveChangesAsync();
                return;
            }
            catch (Exception ex)
            {
                throw new Exception("surgio un error " + ex.Message);
            }
        }
        public async Task Editor(Activo i, int id)
        {
            try
            {
                id = i.IdActivo;
                var res = _dbContext.Activos.Find(id);
                if (res != null)
                {
                    res.Nombre = i.Nombre;
                    res.Descripcion = i.Descripcion;
                    res.Estatus = i.Estatus;

                    _dbContext.Activos.Update(res);
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
                var res = _dbContext.Activos.Find(id);
                if (res != null)
                {
                    _dbContext.Activos.Remove(res);
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
