namespace PlcPresentationExamples
{
    using System;
    using System.Windows;
    using Vortex.Presentation.Wpf;

    public class stCounterManualViewModel : RenderableViewModel
    {        
        private void InitializeCommands()
        {
            StartCountingCommand = new RelayCommand(a => this.StartCounting(), c => !Component._doCount.Cyclic);
            StopCountingCommand = new RelayCommand(a => this.StopCounting(), c => Component._doCount.Cyclic);
            ResetCounterCommand = new RelayCommand(a => this.ResetCounter(), c => !Component._doCount.Cyclic);
        }

        public stCounter Component { get; private set; } = new stCounter();
        public override object Model
        {
            get { return Component; }
            set { Component = (stCounter)value; InitializeCommands(); }
        }

        public RelayCommand StartCountingCommand { get; private set; }
        public RelayCommand StopCountingCommand { get; private set; }
        public RelayCommand ResetCounterCommand { get; private set; }
        private void StartCounting()
        {
            var answer = MessageBox.Show("Would you like to start counter?", "Counter start", MessageBoxButton.YesNo);

            if(answer == MessageBoxResult.Yes)
            {
                this.Component._doCount.Synchron = true;
            }
        }

        private void StopCounting()
        {
            var answer = MessageBox.Show("Would you like to stop counter?", "Counter stop", MessageBoxButton.YesNo);

            if (answer == MessageBoxResult.Yes)
            {
                this.Component._doCount.Synchron = false;
            }
        }
        private void ResetCounter()
        {            
            var answer = MessageBox.Show("Would you like to reset counter?", "Counter reset", MessageBoxButton.YesNo);

            if (answer == MessageBoxResult.Yes)
            {
                this.Component._resetCounterValue.Synchron = true;
            }
        }
    }
}