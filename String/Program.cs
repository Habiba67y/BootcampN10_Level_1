// Concatenation
using System.Runtime.InteropServices;
using System.Runtime.InteropServices;

#region Concatenation

var firstName = "John";
var lastName = "Bob";
var fullNameA = firstName + lastName;
var fullNameB = string.Concat(firstName, lastName);

#endregion 

// Escape characters
#region Escape characters
var comment = "U aytdiki :\"Ispeak C#\"";
var charValue = '\'';
var textValue = "\v C# \v .NET";
Console.WriteLine(textValue);
Console.WriteLine();
var greeting = "Hi John \nWelcome to our portal!";
Console.WriteLine(greeting);
Console.WriteLine();

// Verbatim string
#endregion

#region Verbatim string
// Verbatim string escape character maxsus vazifasinidan ozod qiladi
var filePath = @"D:\Projects\Repositories\Company\NajotTalim\Groups\Bootcamp N10\BootcampN10-Level-I\N3\Program.cs";

// Interpolation and Formatting
#endregion

#region Interpolation and Formatting
var firstNameB = "G`ayrat";
var appName = "Teshavoy App";
var url = "www.example.com";
// Interpolation
// Interpolation - shablon kod ichida bo'lsa ishlatiladi
var greetingB = $"Hello {firstName + lastName}, Welcome to our {1}. Enter this {2} to verify your account";
Console.WriteLine(greetingB);
Console.WriteLine();


// Formatting
// Formatting - shablon koddan tashqari bo'lsa ishlatiladi
var greetingA = "Hello {0}, Welcome to our {1}. Enter this {2} to verify your account";
var formattedGreetingA = string.Format(greetingA, firstNameB + lastName, appName, url);
Console.WriteLine(formattedGreetingA);
Console.WriteLine(greetingA, firstNameB, appName, url);

// Length, indexing va substring
#endregion
