Console.WriteLine("Starting Homework 04!");

Console.WriteLine("Simpler task output: ");


try {
    new Simpler().Execute();
} catch (Exception e) {
    Console.Error.WriteLine(e);
}

Console.WriteLine();


Console.WriteLine("Harder task output: ");

try{
    new Harder().Execute();
}
catch (Exception e) {
    Console.Error.WriteLine(e);
}