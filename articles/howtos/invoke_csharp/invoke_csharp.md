## How to invoke C# code from PLC

In your PLC project create an instance of `fbRemoteExec`
```pascal
FUNCTION_BLOCK fbApp EXTENDS VortexBase.fbVortexApp 
VAR
	CSharp : VortexBase.fbRemoteExec;
	Counter : INT;
END_VAR 
-------
Counter := Counter +1;
IF Counter > 100 THEN
  CSharp.Invoke();
END_IF
```
Run the Inxton builder.
In your C# Code
```csharp
private static fbApp MAIN;

static void Main(string[] args)
{
    Entry.Plc.Connector.BuildAndStart();
    MAIN = Entry.Plc.MAIN.App;
    MAIN.CSharp.Initialize(MethodToExecuteWhenInvokeIsCalledInPlc);
    Console.ReadKey();
}

private static bool MethodToExecuteWhenInvokeIsCalledInPlc()
{
    Console.WriteLine("Invoked from PLC");
    MAIN.Counter.Cyclic = 0;
    return true;
}
}
```
### Results

![inxton breakpoint plc project](invoked_from_plc.gif)

#### Breakpoint work too!
![inxton breakpoint plc project](breakpoint.gif)

