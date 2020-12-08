# Introduction

**VortexBase** contains foundational libraries of Inxton.Vortex.Framework IVF.
This library contains object-oriented libraries aimed to build plc applications on Beckhoffs' TwinCAT3 platform.

## Terminology

*Function Block* and *class* are in this document considered synonyms. Some of the classes are prefixed with ```fb``` and data structures with an ```st``` prefix due to backward compatibility reasons, this document may omit these prefixes.

```Vortexer``` is any object that is extended by ```fbVortexer``` or ```stVortexer``` class. You can thing of ```Vortexer``` as an ```object``` in .net that is at the bottom of any class in .net. E

## Why VortexBase library

VortexBase brings the following features:

* **Vortex application** that encapsulates your application providing an infrastructure for a series of static methods and functions that are accessible via ```App``` property of each ```Vortexer``` object.

* **Messaging** easy single line messaging for that allow any ```Vortexer``` to report messages to upper-level application.

* **Commands** Commands are an implementation of *command pattern* that allows for invoking actions from the HMI or from within the application if necessary.

* **Remote procedure calls** allow you to call arbitrary routines in a .net application from the plc. This is useful when you want to deffer a task that would be otherwise hard to implement in plc and does not require hard-real time.

* **Auto-reset** auto-reset allows implementing so-called ```TierController``` that can detect that component was not called in the last cycle and execute the code that returns the component into the initial state.

## Architecture of a *Vortex* application

Any application in IVF is encapsulated into ```(fb)VortexApp`` class that provides the basic infrastructure for the application.

Each class used within ```vortex application``` should inherit/extend from ```fbVortexer```, and each structure should inherit/extend from ```stVortexer```. ```Vortexer``` will decorate the object with a series of abilities (simple messaging system, diagnostics, state auto-reset, etc.).

### Use of Vortexer object's methods

All call of a ```Vortexer``` object must be inside the call tree of the ```Main``` method of a ```VortexApp```.

~~~
MAIN.PRG
    |
    myVortexApp
        |
        Main();
        |
            // Any Vortexer object must be called in the call tree of application's main method
~~~