using Domain.Factories;
using Domain.Models;
using Domain.Repositories;
using Infrastructure.EF.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class MateriaRepository : IMateriaRepository
    {
        private readonly DbSet<Materia> Materias;
        private readonly DbSet<Registrado> Registrados;
        private readonly IMateriaFactory factory;

        public MateriaRepository(WriteDbContext context, IMateriaFactory factory)
        {
            Materias = context.Materias;
            Registrados = context.Registrados;
            this.factory = factory;
        }

        public async Task CreateAsync(Materia obj)
        {
            await Materias.AddAsync(obj);
        }

        public async Task<Materia> FindById(Guid id)
        {
            Materia? materia = await Materias.FindAsync(id);
            if (materia != null)
                return materia;

            return factory.CrearMateriaVacia(); 
        }

        public async Task RegistrarAlumnoAsync(Guid materiaId, Guid alumnoId)
        {
            Registrado obj = factory.CrearNuevoRegistrado(alumnoId, materiaId);
            await Registrados.AddAsync(obj);
        }
    }
}
