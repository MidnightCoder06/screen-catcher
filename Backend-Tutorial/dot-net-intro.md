.NET Components
The architecture of .Net framework is based on the following key components;

1. Common Language Runtime
The “Common Language Infrastructure” or CLI is a platform in .Net architecture on which the .Net programs are executed.

The CLI has the following key features:

Exception Handling – Exceptions are errors which occur when the application is executed.

Examples of exceptions are:

If an application tries to open a file on the local machine, but the file is not present.
If the application tries to fetch some records from a database, but the connection to the database is not valid.
Garbage Collection – Garbage collection is the process of removing unwanted resources when they are no longer required.

Examples of garbage collection are

A File handle which is no longer required. If the application has finished all operations on a file, then the file handle may no longer be required.
The database connection is no longer required. If the application has finished all operations on a database, then the database connection may no longer be required.
Working with Various programming languages –

As noted in an earlier section, a developer can develop an application in a variety of .Net programming languages.

Language – The first level is the programming language itself, the most common ones are VB.Net and C#.
Compiler – There is a compiler which will be separate for each programming language. So underlying the VB.Net language, there will be a separate VB.Net compiler. Similarly, for C#, you will have another compiler.
Common Language Interpreter – This is the final layer in .Net which would be used to run a .net program developed in any programming language. So the subsequent compiler will send the program to the CLI layer to run the .Net application.

Level 1 -> C#
Level 2 -> C# Compiler
Level 3 -> Common Language Interpeter 

2. Class Library
The .NET Framework includes a set of standard class libraries. A class library is a collection of methods and functions that can be used for the core purpose.

For example, there is a class library with methods to handle all file-level operations. So there is a method which can be used to read the text from a file. Similarly, there is a method to write text to a file.

Most of the methods are split into either the System.* or Microsoft.* namespaces. (The asterisk * just means a reference to all of the methods that fall under the System or Microsoft namespace)

A namespace is a logical separation of methods. We will learn these namespaces more in detail in the subsequent chapters.

3. Languages
The types of applications that can be built in the .Net framework is classified broadly into the following categories.

.NET framework

3) Security – The .NET Framework has a good security mechanism. The inbuilt security mechanism helps in both validation and verification of applications. Every application can explicitly define their security mechanism. Each security mechanism is used to grant the user access to the code or to the running program.

4) Memory management – The Common Language runtime does all the work or memory management. The .Net framework has all the capability to see those resources, which are not used by a running program. It would then release those resources accordingly. This is done via a program called the “Garbage Collector” which runs as part of the .Net framework. The garbage collector runs at regular intervals and keeps on checking which system resources are not utilized, and frees them accordingly.

5) Simplified deployment – The .Net framework also have tools, which can be used to package applications built on the .Net framework. These packages can then be distributed to client machines. The packages would then automatically install the application.