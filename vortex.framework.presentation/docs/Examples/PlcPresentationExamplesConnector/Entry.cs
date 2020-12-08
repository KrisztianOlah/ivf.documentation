using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlcPresentationExamplesConnector
{
    public class Entry
    {
        public PlcPresentationExamples.PlcPresentationExamplesTwinController Plc
        {
            get
            {
                return PresentationPlc;
            }
        }

        private static PlcPresentationExamples.PlcPresentationExamplesTwinController _presentationPlc;
        public static PlcPresentationExamples.PlcPresentationExamplesTwinController PresentationPlc
        {
            get
            {
                if (_presentationPlc == null)
                {
                    if (_presentationPlc == null)
                    {
                        var adapter = new Vortex.Connector.ConnectorAdapter(typeof(Vortex.Connector.DummyConnectorFactory));
                        //var adapter = Vortex.Adapters.Connector.Tc3.Adapter.Tc3ConnectorAdapter.Create("172.20.10.102.1.1", 852, true);
                        // var adapter = Vortex.Adapters.Connector.Tc3.Adapter.Tc3ConnectorAdapter.Create(null, 851, true);
                        _presentationPlc = new PlcPresentationExamples.PlcPresentationExamplesTwinController(adapter);
                        _presentationPlc.Connector.ReadWriteCycleDelay = 250;
                        _presentationPlc.Connector.BuildAndStart();
                    }
                }

                return _presentationPlc;
            }
        }
    }
}
