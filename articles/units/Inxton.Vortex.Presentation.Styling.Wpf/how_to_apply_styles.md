### How to apply styles

Add this resources to `App.xaml`.

~~~xml
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceDictionary Source="pack://application:,,,/Vortex.Presentation.Styling.Wpf;component/VortexStyle.xaml" />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
~~~