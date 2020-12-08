using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Vortex.Framework.Abstractions.Presentation;

namespace PresentationWpfExamples
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App() : base()
        {
            CreateLayutProvider();
        }

        #region CreateLayoutProvider
        private static void CreateLayutProvider()
        {
            // Creates presentation provider for this WPF application.
            PresentationProvider.Create(new Vortex.Presentation.Wpf.WpfLayoutProvider());
        }
        #endregion

        /// <summary>
        /// Gets the vortex connector.
        /// </summary>
        public static PlcPresentationExamples.PlcPresentationExamplesTwinController Plc
        {
            get
            {
                CreateLayutProvider();
                return PlcPresentationExamplesConnector.Entry.PresentationPlc;
            }
        }
    }
}
