using PropertyChanged;
using SkDemo1.Helpers;
using SkDemo1.Models;
using SkDemo1.Services;
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
        private ProjectDataService _projectService;

        public List<Project> Projects { get; set; }

        public Command AddCompanyCommand { get; set; }

        public CompanyListViewModel()
        {
            _projectService = new ProjectDataService();
            Projects = new List<Project>();
            AddCompanyCommand = new Command(() => AddCompany());
        }

        public async Task LoadProjects()
        {
            var results = await _projectService.GetAllProjects();
            Projects = results.ToList();
        }

        public void AddCompany()
        {
            Logger.Log("AddCompany", "Add Company button was clicked");
        }

    }
}
