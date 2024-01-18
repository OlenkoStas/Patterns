// TODO 00: Double click, triple click, double click and move
// TODO 01: Double ⇧: Search Everywhere
// TODO 02: Use Search Everywhere to find actions: duplicate, commit, method, parameter, format code
// TODO 03: ⌥ ⏎ : Show Context Actions
// TODO 04: ⌥ ↑ , ⌥ ↓ : Extend or shrink selection
// TODO 05: ⌘ / , ⌥ ⌘ / : Add/remove line or block comment
// TODO 06:  ⇧ ⌘ ↑, ⇧ ⌘ ↓ : Move function up / down
// TODO 07: Multiple carets
//      ⇧ ⌥ : Rectangular selection : cut
//      ⌥ Click : add caret : show paste
// TODO 08: Tab , ⇧ Tab: Indent/Unindent selected lines
// TODO 09: ⌥ ⌘ ], ⌥ ⌘ [ : Move to code block start/end
// TODO 10: ⌘ B: Go to declaration
// TODO 11: ⌥ ⌘ ← , ⌥ ⌘ → : Navigate back / Navigate forward
// TODO 12: ⌥ ⇧ ⌘ ← , ⌥ ⇧ ⌘ → : move (swap) a code element left/right.
// TODO 13: introduce field for 'newfile.txt'
// TODO 14: show how introduce constant is different (replace 2 occurences works only for global)
// TODO 15: ⌘ N : Generate code : create constructor : use path to be initialized
// TODO 16: Introduce parameter for "this.data"
// TODO 17: ⌥ F7 : Find Usages
// TODO 18: renaming using find and replace


Console.WriteLine("Hello, this is Theory #02");

// TODO: action 03: add parameter
new WorkingWithFileDemo().WriteToFile("p1", 2).ReadFromFile(); ; ; ;

String configFile = null;;;; // TODO: action 03
String configDir = null;
String configValue = null;


class WorkingWithFileDemo
{
    private String data = "Demo file contents";

    private void UnusedMethod()
    {
        // TODO: action 03
    }

    // TODO: action 12: swap
    public WorkingWithFileDemo WriteToFile(String p1, int p2)
    {
        File.WriteAllText("newfile.txt", p1);

        return this;
    }

    public void ReadFromFile()
    {
        try
        {
            String data = File.ReadAllText("newfile.txt");

            Console.WriteLine("File content is: " + this.data);
        }
        catch (FileNotFoundException e)
        {
            Console.WriteLine("File reading error: " + e.Message);
        }
    }
}