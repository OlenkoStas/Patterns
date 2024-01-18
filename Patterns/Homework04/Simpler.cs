using System.Text;
using N = System.Int64;

public class Simpler
{
    // task: https://codeforces.com/contest/1707/problem/A
    // source code: https://codeforces.com/contest/1707/submission/164541849
    
    public void Execute()
    {
        var reader = File.OpenRead("Input/simpler.input.txt");
        // var reader = Console.OpenStandardInput();
        var solver = new SolverA(reader, Console.OpenStandardOutput());
        solver.Solve();
    }
}

public class SolverA
{
    
    public readonly StreamScannerA sc;
    private readonly StreamWriter _writer;

    public SolverA(Stream reader, Stream writer)
    {
        sc = new StreamScannerA(reader);
        _writer = new StreamWriter(writer);
    }
    
    public void Solve()
    {
        int casecount = ri;
        for (int count = 0; count < casecount; count++)
        {
            int n = ri, q = ri;
            var a = new int[n];
            for (int i = 0; i < n; i++)
            {
                a[i] = ri;
            }
            var ans = new int[n];
            int x = 0;
            for (int i = n - 1; i >= 0; i--)
            {
                if (a[i] <= x) ans[i] = 1;
                else
                {
                    if (x == q) continue;
                    x++;
                    ans[i] = 1;
                }
            }
            WriteJoin("", ans);
        }
        
        _writer.Flush();
    }
 
 
 
    const long inf = (long)1 << 60;
    int ri { get { return (int)sc.Integer(); } }
    long rl { get { return sc.Integer(); } }
    double rd { get { return sc.Double(); } }
    string rs { get { return sc.Scan(); } }
 
    void WriteJoin<T>(string s, T[] t) { _writer.WriteLine(string.Join(s, t)); }
    void WriteJoin<T>(string s, List<T> t) { _writer.WriteLine(string.Join(s, t)); }
    void Write<T>(T t) { _writer.WriteLine(t.ToString()); }
    void YN(bool t) { _writer.WriteLine(t ? "YES" : "NO"); }
    void Yn(bool t) { _writer.WriteLine(t ? "Yes" : "No"); }
    void yn(bool t) { _writer.WriteLine(t ? "yes" : "no"); }
    void Swap(ref int x, ref int y) { x ^= y; y ^= x; x ^= y; }
    void Swap(ref N x, ref N y) { x ^= y; y ^= x; x ^= y; }
    void Swap<T>(ref T x, ref T y) { T t = y; y = x; x = t; }
}
 
 
public class StreamScannerA
{
    public StreamScannerA(Stream stream) { str = stream; }
    private readonly Stream str;
    private readonly byte[] buf = new byte[1024];
    private int len, ptr;
    public bool isEof = false;
    public bool IsEndOfStream { get { return isEof; } }
    private byte read()
    {
        if (isEof) throw new EndOfStreamException();
        if (ptr >= len)
        {
            ptr = 0;
            if ((len = str.Read(buf, 0, 1024)) <= 0) { isEof = true; return 0; }
        }
        return buf[ptr++];
    }
    public char Char()
    {
        byte b = 0;
        do b = read();
        while (b < 33 || 126 < b);
        return (char)b;
    }
    public string Scan()
    {
        var sb = new StringBuilder();
        for (var b = Char(); b >= 33 && b <= 126; b = (char)read()) sb.Append(b);
        return sb.ToString();
    }
    public long Integer()
    {
        long ret = 0; byte b = 0; var ng = false;
        do b = read();
        while (b != '-' && (b < '0' || '9' < b));
        if (b == '-') { ng = true; b = read(); }
        for (; true; b = read())
        {
            if (b < '0' || '9' < b) return ng ? -ret : ret;
            else ret = ret * 10 + b - '0';
        }
    }
    public double Double() { return double.Parse(Scan()); }
}