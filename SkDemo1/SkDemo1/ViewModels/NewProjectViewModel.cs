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
using Xamarin.Forms;

namespace SkDemo1.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class NewProjectViewModel
    {
        public string ProjectName { get; set; }
        public string CompayName { get; set; }
        public string Description { get; set; }
        public ICommand SaveNewProjectCommand{ get; set; }
        private ProjectDataService _projectService;

        public NewProjectViewModel()
        {
            _projectService = new ProjectDataService();
            SaveNewProjectCommand = new Command(async () => await SaveProject());
        }

        public async Task SaveProject()
        {
            Logger.Log("Save Project", "Saved project called");

            try
            {
                var proj = new Project
                {
                    Name = ProjectName,
                    Company = CompayName,
                    Description = Description,
                    ProjectDate = DateTime.Now
                };

             proj =  await _projectService.Add(proj);
            }
            catch (Exception ex)
            {
                Logger.LogError("SaveProject", ex);
                throw;
            }
          
        }

    }
}
