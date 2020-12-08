namespace PresentationWpfExamples.MVVM
{
    using PlcPresentationExamples;
    
    /// <summary>
    /// View model for <see cref="AutoRenderingView"/>
    /// </summary>
    public class AutoRenderingViewModel
    {   
        /// <summary>
        /// Gets .net representation of MAIN prg from the PLC program.
        /// </summary>
        public MAIN MAIN
        {
            get
            {
                return App.Plc.MAIN; 
            }
        }
    }
}
