# Inxton.Vortex.Presentation.Wpf

## RenderableContentControl

```RendenderableContentControl```  is the component used for placing renderable content into the user interface. ```RendererableContentControl``` can render [TwinObject or PrimitiveTwins](/apis/Inxton.vortex.compiler.console/Conceptual/Twins.md), these object come from the code created by the inxton.vortex.compiler.

## How to place an auto-rendered control into UI

~~~ XML
xmlns:vortex="http://vortex.mts/xaml"

<vortex:RenderableContentControl DataContext="{Binding TwinObject, Mode=OneWay}" PresentationType="Control"/>
~~~

### Renderable objects (DataContext)

```DataContext``` of a ```RenderableContentControl``` is the object that the rendering system will create and place into UI. The object that is assigned to the DataContext must be a [TwinObject](/apis/Inxton.vortex.compiler.console/Conceptual/TwinObjects.md).

 
# Need help?

🧪 Create an issue [here](https://github.com/Inxton/Feedback/issues/new/choose)

📫 We use mail too team@inxton.com 

🐤 Contact us on Twitter [@Inxton](https://twitter.com/inxtonteam)

📽 Checkout our [YouTube](https://www.youtube.com/channel/UCB3EcnWyLSsV5gqSt8PRDXA/featured)

🌐 For more info check out our website [INXTON.com](https://www.inxton.com/)

# Contributing

We are more than happy to hear your feedback, ideas!
Just submit it [here](https://github.com/Inxton/Feedback/issues/new/choose)  

---
Developed with ♥ at [MTS](https://www.mts.sk/en) - putting the heart into manufacturing.
