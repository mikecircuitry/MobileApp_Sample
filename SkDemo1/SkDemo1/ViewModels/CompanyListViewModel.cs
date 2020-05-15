using PropertyChanged;
using SkDemo.Models;
using SkDemo1.Helpers;
using SkDemo1.Models;
using SkDemo1.Services;
using SkDemo1.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SkDemo1.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class CompanyListViewModel
    {
        private readonly IProjectDataService _projectService;

        public List<Project> Projects { get; set; }

        public CompanyListViewModel(IProjectDataService projectDataService)
        {
            _projectService =projectDataService;
            Projects = new List<Project>();
        }

        public async Task LoadProjects()
        {
            var results = await _projectService.GetAllProjects();
            Projects = results.OrderBy(c => c.Company).ToList();
        }

    }
}
