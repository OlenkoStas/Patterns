Console.WriteLine("Starting Homework 02!");

new Task01SafeDelete(10).Execute(42);
new NewClassName(20).Execute(11);
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
class NewClassName
{ // rename class name also considering the name in string

    private readonly int parameter;

    public NewClassName(int input)
    {
        parameter = input; // rename field to match parameter name

        Console.WriteLine("NewClassName initialized with " + input);
    }

    // rename method from "call" to "execute"
    public void Execute(int param)
    { // rename parameter "i" to "param"
        Console.WriteLine("NewClassName executed with " + param);
    }
}

/* TODO: Task 03: apply extract refactorings as specified in comments */
class Task03Extract
{
    private const int THE_ANSWER_TO_THE_ULTIMATE_QUESTION = 42;
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
                Add(first, second)
        );
        Print("add",
                THE_ANSWER_TO_THE_ULTIMATE_QUESTION, /* introduce constant named THE_ANSWER_TO_THE_ULTIMATE_QUESTION */
                second,
                /* Extract to method named add */
                Add(THE_ANSWER_TO_THE_ULTIMATE_QUESTION, second)
        );

        Print("subtract",
                first,
                second,
                /* Extract to method named subtract */
                Subtract(first, second)
        );

        Print("subtract",
                THE_ANSWER_TO_THE_ULTIMATE_QUESTION, /* this should automatically be refactored by the "introduce constant" change */
                second,
                /* Extract to method named subtract */
                Subtract(THE_ANSWER_TO_THE_ULTIMATE_QUESTION, second)
        );

        Print("multiply",
                first,
                second,
                /* Extract to method named multiply */
                Multiply(first, second)
        );
        Print("divide",
                first,
                second,
                /* Extract to method named divide */
                Divide(first, second)
        );
    }

    private int Divide(int first, int second)
    {
        return first / second;
    }

    private int Multiply(int first, int second)
    {
        return first * second;
    }

    private int Subtract(int first, int second)
    {
        return first - second;
    }

    private int Add(int first, int second)
    {
        return first + second;
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