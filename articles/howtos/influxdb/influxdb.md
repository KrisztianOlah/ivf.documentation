## InfluxDB

**[Video guide](https://youtu.be/MPF8enCphbs).**

In this example, we collect data from ```InfluxData``` PLC structure. Any primitive (base type) items added to this structure will be collected automatically into the database.

FB ```fbInfluxPerformanceLogging``` has simple logic that populates ```InfluxData``` structure with values and executes a remote request to the .net application that takes care of storing data into the database.

There are two C# projects Console and Wpf applications. The console application runs fast data collection cycles. The WPF application also displays some online data and data from the database.

![Solution](influx_solution_tree.png)
![WPF](influxdbwpf.png)
![Console](influxdbconsole.png)

### How it operates

~~~ PASCAL
// fbInfluxPerformanceLogging (BODY)
IF(_logStart <= _logDone) THEN
    _logStart := _logStart + 1; // .net app is subscribed for this variable change.
END_IF
~~~

~~~ C#
private void Register()
{
    // Gets object from the PLC twin
    var influx = HansPlc.Entry.HansPlc.prgInflux._influx;

    // Let's retrieve all value items from the our 'influx._data' twin.
    var primitives = influx._data.GetValueTags();

   // Subscribe for the change of the '_logStart' variable
   influx._logStart.Subscribe((sender, a) =>
   {
        SavePoint(); // for implementation of SavePoint() method see the code example.
   });
}
~~~

### How to run InfluxDB

For this example to work, you will need to set-up a working instance of the InfluxDB database. Visit [influxdata](https://portal.influxdata.com/downloads/) and download influxdb; these examples were tested with ```v1.8.0```. You will also need to run the server instance with a config file that has ```flux-enabled``` set to ```true``` in the http section of the config file.

~~~ c
[http]
  # Determines whether HTTP endpoint is enabled.
  enabled = true

  # Determines whether the Flux query endpoint is enabled.
  flux-enabled = true

  # Determines whether the Flux query logging is enabled.
  # flux-log-enabled = false
~~~

For the server to use the config file, you will need to run it with parameters.

~~~ Powershell
PS [YourDrive]:[InfluxDB bin directory]\> .\influxd.exe run -config .\influxdb.conf
~~~
