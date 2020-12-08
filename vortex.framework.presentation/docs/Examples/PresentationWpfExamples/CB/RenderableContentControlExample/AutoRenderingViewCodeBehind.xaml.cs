using System;
using System.Linq;
using System.Windows.Controls;
namespace PresentationWpfExamples.CB.RenderableContentControlExample
{
    using Vortex.Presentation.Wpf;

    /// <summary>
    /// Interaction logic for AutoRenderingViewCodeBehind.xaml
    /// </summary>
    public partial class AutoRenderingViewCodeBehind : UserControl
    {
        public AutoRenderingViewCodeBehind()
        {
            InitializeComponent();

            #region CodeBehindRenderingDisplay
            // Renders representation of MAIN._counter object from the PLC in read-only mode.
            this.CounterDisplay.Content = Renderer.Get.CreatePresentation("Display", App.Plc.MAIN._counter);
            #endregion

            #region CodeBehindRenderingControl
            // Renders representation of MAIN._counter object from the PLC in read/write mode.
            this.CounterControl.Content = Renderer.Get.CreatePresentation("Control", App.Plc.MAIN._counter);
            #endregion
        }
    }
}
