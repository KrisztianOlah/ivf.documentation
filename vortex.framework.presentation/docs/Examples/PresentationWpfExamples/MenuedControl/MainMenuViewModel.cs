using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationWpfExamples.MenuedControl
{
    public class MainMenuViewModel : Vortex.Presentation.Wpf.MenuControlViewModel
    {
        public MainMenuViewModel()
        {
            this.NavCommands.Add(this.AddCommand(typeof(Operator.OperatorView), "Operator"));                       
        }        
    }
}
