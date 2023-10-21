// See https://aka.ms/new-console-template for more information
using ConsoleSqlDependency;

Console.WriteLine("Hello, World!");
string CONNECTION_STRING = @"Data Source=QUOC\SQLEXPRESS;Initial Catalog=NotificationDb;Integrated Security=True;";
SqlNotificationService sqlNotificationService = new();
sqlNotificationService.Start(CONNECTION_STRING);
Console.ReadKey();
sqlNotificationService.Dispose();