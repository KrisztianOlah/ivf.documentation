namespace PresentationWpfExamples.CustomizePresentations.fbCounter
{
    using System;
    using System.Linq;
    using System.Windows.Controls;
    using Vortex.Presentation.Wpf;
    using PlcPresentationExamplesConnector;

    /// <summary>
    /// Interaction logic for CounterCustomizedView.xaml
    /// </summary>
    public partial class CounterCustomizedView : UserControl
    {
        public CounterCustomizedView()
        {
            InitializeComponent();

            #region RendererWithBaseType
            this.stCounterBase.Content = Renderer.Get.CreatePresentation("Base", Entry.PresentationPlc.MAIN._counter);
            #endregion

            #region RenderedWithManualType
            this.stCounterManual.Content = Renderer.Get.CreatePresentation("Manual", Entry.PresentationPlc.MAIN._counter);
            #endregion

            #region RenderedWithPipelineDiagnosticsManual
            this.stCounterDiagnosticsManual.Content = Renderer.Get.CreatePresentation("Diagnostics-Manual", Entry.PresentationPlc.MAIN._counter);
            #endregion

            #region RenderedWithPipelineDiagnosticsBase
            this.stCounterDiagnosticsBase.Content = Renderer.Get.CreatePresentation("Diagnostics-Base", Entry.PresentationPlc.MAIN._counter);
            #endregion            
        }
    }
}
