using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PropertyChanged;
using SkDemo.Models;
using SkDemo1.Helpers;
using SkDemo1.Models;
using SkDemo1.Services;
using SkDemo1.Services.Interfaces;
using Xamarin.Forms;

namespace SkDemo1.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class NewProjectViewModel
    {
        public string ProjectName { get; set; }
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public string CompanyNameValidation { get; set; }

        public ICommand SaveNewProjectCommand{ get; set; }
        private readonly IProjectDataService _projectService;

        public NewProjectViewModel(IProjectDataService projectDataService)
        {
            _projectService = projectDataService;

            SaveNewProjectCommand = new Command(async () => await SaveProject());
        }

        public async Task SaveProject()
        {
            Logger.Log("Save Project", "Saved project called");

            try
            {
                var isValid = true;

                if (string.IsNullOrEmpty(CompanyName))
                {
                    isValid = false;
                    CompanyNameValidation = "Company name is required";
                }

                if (isValid)
                {
                    var proj = new Project
                    {
                        Name = ProjectName,
                        Company = CompanyName,
                        Description = Description,
                        ProjectDate = DateTime.Now
                    };

                    proj = await _projectService.Add(proj);
                }
               
            }
            catch (Exception ex)
            {
                Logger.LogError("SaveProject", ex);
                throw;
            }
          
        }

    }
}
