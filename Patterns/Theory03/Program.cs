Console.WriteLine("Hello, this is Theory #03!");

Console.WriteLine("New bug created: " + new Bug(1234567890, "My first bug", 0).Description);

// TODO: Extract interface
// TODO: Create subclass
// TODO: Replace inheritance with delegation
public class Bug  {
    public Bug(long id, String description, int severity) {
        this.Id = id;
        this.Description = description;
        this.Severity = severity;
    }

    public long Id { get; }

    public string Description { get; }

    public int Severity { get; }
}