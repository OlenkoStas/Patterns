Console.WriteLine("Starting Homework 02!");

new Task01SafeDelete(10).Execute(42);
new Task02Rename(20).Call(11);
new Task03Extract(20).Execute(11);
new Task04Inline(20).Execute(11);

/* TODO: Task 01: apply SafeDelete refactorings to not used code parts */
class Task01SafeDelete
{
    private readonly int usedInput;

    public Task01SafeDelete(int usedInput)
    {
        this.usedInput = usedInput;

        Print("initialized", this.usedInput);
    }

    public void Execute(int i)
    {
        Print("executed", i);
    }

    private void Print(String operation, int usedParam)
    {
        Console.WriteLine("SafeDeleteExample " + operation + " with " + usedParam);
    }
}

/* TODO: Task 02: apply Rename refactorings as specified in comments */
class Task02Rename
{ // rename class name also considering the name in string

    private readonly int usedInput;

    public Task02Rename(int input)
    {
        this.usedInput = input; // rename field to match parameter name

        Console.WriteLine("Task02Rename initialized with " + input);
    }

    // rename method from "call" to "execute"
    public void Call(int i)
    { // rename parameter "i" to "param"
        Console.WriteLine("Task02Rename executed with " + i);
    }
}

/* TODO: Task 03: apply extract refactorings as specified in comments */
class Task03Extract
{

    private readonly int first;

    public Task03Extract(int first)
    {
        this.first = first;
    }
    public void Execute(int second)
    {
        Print("add",
                first,
                second,
                /* Extract to method named add */
                first + second
        );
        Print("add",
                42, /* introduce constant named THE_ANSWER_TO_THE_ULTIMATE_QUESTION */
                second,
                /* Extract to method named add */
                42 + second
        );

        Print("subtract",
                first,
                second,
                /* Extract to method named subtract */
                first - second
        );

        Print("subtract",
                42, /* this should automatically be refactored by the "introduce constant" change */
                second,
                /* Extract to method named subtract */
                42 - second
        );

        Print("multiply",
                first,
                second,
                /* Extract to method named multiply */
                first * second
        );
        Print("divide",
                first,
                second,
                /* Extract to method named divide */
                first / second
        );
    }

    private void Print(String name, int a, int b, int result)
    {
        Console.WriteLine(String.Join("", name, "(", a, ",", b, ")=", result));
    }
}

/* TODO: Task 04: apply inline refactorings as specified in comments */
class Task04Inline
{

    // inline field
    private readonly int first;

    public Task04Inline(int first)
    {
        this.first = first;

        Print("initialized", first);
    }
    public void Execute(int second)
    {
        Print("executed", second);
    }

    // inline method "print"
    private void Print(String operation, int param)
    {
        Console.WriteLine("Task04Inline " + operation + " with " + param);
    }
}