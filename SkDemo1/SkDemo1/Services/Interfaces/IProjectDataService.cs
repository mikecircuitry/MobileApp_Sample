using SkDemo.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SkDemo1.Services.Interfaces
{
    public interface IProjectDataService
    {
        Task<Project> Add(Project model);
        Task<List<Project>> GetAllProjects();
    }
}
