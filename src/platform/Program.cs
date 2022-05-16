// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var tester = new demoapi.Platform();

tester.SupportedOnWindowsAndIos14();
tester.SupportedOnLinuxAndIos14();
tester.Caller();


Console.ReadLine();