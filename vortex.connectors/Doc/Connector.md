#Develop#
# Vortex Connector library #

Vortex connector library is result of tran-pile process where the vortex builder transforms the existing PLC program's data into matching C# classes and then emits .net class library that can be used in many scenarios combining hard-realtime PLC system and .net ecosystem.

The library's name is by convention [PlcName]Connector. Connector library is usually product of a C# Class library project which by convention has the same name. These classes can be used in various scenarios. The connector brings together a hard-real system and the wealth of .net ecosystem.

## Twin Controller ##

Controller twin is the root object that represents the entry point into a twin representation of a PLC controller. You can think about it as a mirror of the PLC program or more precisely of data of the PLC program. The name of such entry class is by convention [PlcName]ControllerTwin.

## Twin object ##

Twin object is the .net representation of a complex PLC data structure (STRUCT, FB, GVL, PRG). Each of these data structures is represented by a separate class of which name is the same as the name of the respective structure.

Each twin object implements two type of interfaces so called IOnline interface which exposes direct communication with the PLC system and IShadow interface with allows for an offline manipulation of object's data (about Shadow concept see later). There is a separate class so called Plainer that is produced during the tran-piling process which is a light (POCO like) representation of the same data structure, that can be is used in scenarios involving serialization  (about the Plain types see later.)

## Primitive Twin ##

Primitive twins are special type of objects that represent base PLC types (BOOL, BYTE, WORD, DWORD .. REAL, STRING, WSTRING). Each base type has its own representation in Vortex.Framework. Primitive Twins allows for Read and Write operations of the respective values. They also offer different ways of accessing the values: Cyclic, Synchronous, Batched.

### Cyclic access ###

**Cyclic access** allow for fast low performance cost access to PLC values. Cyclic values are read and written in a periodic loop. As you may have notice, the controller twin object contains entire PLC program, it does not discriminate between the variables and object that are used by the consumer and those that are not. However the Cyclic values are accessed via communication interface only after they are first time accessed by the consumer program. Once a Primitive Twin is accessed via its Cyclic property it is queued for the cyclic reading.

Primitive Twins implement notification change when the cyclic property changes (INotifyPropertyChanged interface). This feature is particularly useful for visualization scenarios in presentation frameworks that support data binding with change notification (WPF, in limited way WinForm).

Cyclic access may result in degraded performance when the cyclic loop contains too many cyclically accessed primitive twins. This is however true for very large programs, where combination of cyclic and batched access should be used.

Primitive twin is access via its *Cyclic* property

~~~ C#
// Cyclic Read
/*
Notice that the property Cyclic will return type's default value when called for the first time.
*/
Console.WriteLine($"{PlcController.MAIN.Counter.Symbol} : {PlcController.MAIN.Counter.Cyclic}");

// Cyclic Write
/*
Notice that the value of the Cyclic will be written to the PLC at the next cycle of the r/w cycle.
*/
PlcController.MAIN.RunCounter.Cyclic = true;
~~~

### Synchronous access ###

Synchronous access is two way access to the PLC variable, that is enacted in synchronous way. Variable is accessed via *Synchron* property of the Primitive Twin class. In contrast to the cyclical access the Synchron accesses the variable either reads or writes and only then returns the control to the caller. In other words the *Synchron* property allows for immediate access to the PLC variable.

~~~ C#
// Synchronous Read
/*
Notice that the property Synchron in contrast to Cyclic will return the value from the PLC immediately.
*/
Console.WriteLine($"{PlcController.MAIN.Counter.Symbol} : {PlcController.MAIN.Counter.Synchron}");

// Synchronous Write
/*
Notice that the value of the Synchron in contrast to Cyclic will be written to the PLC immediately.
*/
PlcController.MAIN.RunCounter.Synchron = true;
~~~

> NOTE: The Synchronous access is expensive to use in scenarios when more variables are required to be read or written in the same moment as it performs item by item access without any optimization. When you want to mitigate this effect use batched access instead.

### Batched access ###

Batched access allows you to read or write a group of variables in a single shot. Strictly speaking batched reading and writing are the operations that are performed with TwinObjects while Primitive Twins hold the values that are read or written.There are several ways to access the data in a batched way. Easiest and the most straight forward way is to use methods *Read()* or *Write()* which are extension methods for *IVortexObject* aka Twin Object. All variables that are contained in the represented structure are read or written when *Read()* or *Write()* methods are used respectively.

During the batched read operation is the values are stored in *LastValue* property of the respective Primitive Twin.

During batched write operation the values written to controller are those that were stored in the *Cyclic* property of respective Primitive Twin.

~~~ C#
// in this namespace are extension methods for batched operations.
using Vortex.Connector;

public class BatchedAccess
{
    public void ReadBatched()
    {
        // Reads whole structure settings
        PlcController.MAIN.Settings.Read();

        // Write values to the console
        Console.WriteLine($"{PlcController.MAIN.Settings.PosX.Symbol}:{PlcController.MAIN.Settings.PosX.LastValue});

        Console.WriteLine($"{PlcController.MAIN.Settings.PosY.Symbol}:{PlcController.MAIN.Settings.PosY.LastValue});

        Console.WriteLine($"{PlcController.MAIN.Settings.PosZ.Symbol}:{PlcController.MAIN.Settings.PosZ.LastValue});
    }


    public void WriteBatched()
    {
        PlcController.MAIN.Settings.PosX.Cyclic = 100.0f;
        PlcController.MAIN.Settings.PosY.Cyclic = 120.0f;
        PlcController.MAIN.Settings.PosZ.Cyclic = 130.0f;

        // Writes all value of the settings structure.
        PlcController.MAIN.Settings.Write();

    }
}
~~~
