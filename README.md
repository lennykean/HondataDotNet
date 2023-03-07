# HondataDotNet

HondataDotNet is a C# library for reading and writing Hondata KPro, FlashPro, and s300 datalog files. This library provides an easy-to-use set of classes to interact with the datalog files, making it simple to read, modify, and create new datalogs in the Hondata format.

## Installation
You can download and install the Hondata.NET package from NuGet using the following command in the Package Manager Console:

### .NET CLI
```bash
dotnet add package HondataDotNet
```
### Package Manager
```powershell
Install-Package HondataDotNet
```

## Usage
### Reading a datalog
To read a datalog, you can use the Datalog.FromFile method. This method takes a string argument that specifies the path to the datalog file, and returns an IDatalog object representing the contents of the datalog. For example:

```csharp
using HondataDotNet.Datalog;

IDatalog datalog = Datalog.FromFile(@"C:\MyDatalogs\MyKProDatalog.kdl");
```

The IDatalog interface provides methods and properties for accessing the contents of the datalog. The specific implementation of IDatalog returned by Datalog.FromFile depends on the type of datalog being read (KPro, FlashPro, or s300).

### Writing a datalog
To create a new datalog, you can use one of the concrete datalog classes provided by the library, such as KProDatalog. Once you have created a new datalog object, you can add frames to it using the Frames property, and add comments using the Comments property. Once you have added all the frames and comments you want, you can save the datalog to a file using the Save method. For example:

```csharp
using HondataDotNet.Datalog.KPro;

var datalog = new KProDatalog();
datalog.Frames.Add(new KProDatalogFrame());
datalog.Comments.Add(new KProDatalogFrameComment("This is a comment"));
datalog.Save(@"C:\MyDatalogs\NewDatalog.kdl");
```
## Datalog formats
Hondata.NET supports reading and writing datalogs in the following formats:
* KPro (.kdl)
* FlashPro (.fpd)
* s300 (.sdl)

When you read a datalog using Datalog.FromFile, the library will automatically determine the format of the file based on its contents. When you create a new datalog, you can specify the format by choosing the appropriate concrete datalog class (KProDatalog, FlashProDatalog, or S300Datalog).

## License
Hondata.NET is licensed under the MIT License.
