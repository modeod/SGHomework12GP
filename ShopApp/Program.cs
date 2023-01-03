using System.Text;
using ShopApp.Facade;

Console.InputEncoding = Encoding.UTF8;
Console.OutputEncoding = Encoding.UTF8;

var consoleHandler = new ConsoleHandler();
await consoleHandler.ConfigureWorkWithSystem();