using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp_ADO_NET_CodeFirst
{
    public partial class Window_Change : Window
    {
        public Project Project { get; set; }

        public Window_Change(Project project)
           : this()
        {
            this.Width = 400;
            this.Height = 740;

            Project = new Project
            {
                ProjectId = project.ProjectId,
                Title = project.Title,
                StartDate = project.StartDate,
                EndDate = project.EndDate,
                Description = project.Description
            };
            ValidateID += e => (e as Project).ProjectId = -1;

            this.DataContext = Project;

            this.mainGrid.Style = (Style)FindResource("styleChange_Project");

            CurrentObject = Project;
        }
    }
}
