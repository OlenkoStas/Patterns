
using System;
using System.ComponentModel;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.Intrinsics.X86;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using static Functions;
using static OutputLib;
 
using ModInt = StaticModInt<Mod998244353>;

public class Harder
{
    // task: https://codeforces.com/contest/1878/problem/F
    // source code: https://codeforces.com/contest/1878/submission/225339031


    public void Execute()
    {
        var reader = File.OpenRead("Input/harder.input.txt");
        var solver = new SolverB(reader, Console.OpenStandardOutput());
        Console.Out.Flush();
    }
}

public class SolverB
{
    public readonly StreamScannerB sc;
    private readonly StreamWriter _writer;

    public SolverB(Stream reader, Stream writer)
    {
        sc = new StreamScannerB(reader);
        _writer = new StreamWriter(writer);
        Solve();
    }
 
    void Solve()
    {
        const int max = 2000000;
        var pf = new int[max + 1];
        for (int p = 2; p <= max; p += (p & 1) + 1)
        {
            if (pf[p] != 0) continue;
            for (int i = p; i <= max; i += p)
                if (pf[i] == 0) pf[i] = p;
        }
 
        int t = ri;
        for (int cases = 0; cases < t; cases++)
        {
            int n = ri, q = ri;
            var map = new Map<int, int>();
            int x = n;
            while (x > 1)
            {
                map[pf[x]]++;
                x /= pf[x];
            }
            long d = 1;
            foreach (var p in map) d *= p.Value + 1;
            for (int i = 0; i < q; i++)
            {
                if (ri == 1)
                {
                    x = ri;
                    while (x > 1)
                    {
                        map[pf[x]]++;
                        d /= map[pf[x]];
                        d *= map[pf[x]] + 1;
                        x /= pf[x];
                    }
 
                    bool ans = true;
                    long y = d;
                    for (int p = 2; p * p <= y; p += (p & 1) + 1)
                    {
                        if (y % p != 0) continue;
                        int c = 0;
                        while (y % p == 0) { c++; y /= p; }
                        ans &= c <= map[p];
                    }
                    if (y > 1) ans &= 1 <= map[(int)y];
                    YN(ans);
                }
                else
                {
                    map = new Map<int, int>();
                    x = n;
                    while (x > 1)
                    {
                        map[pf[x]]++;
                        x /= pf[x];
                    }
                    d = 1;
                    foreach (var p in map) d *= p.Value + 1;
                }
            }
        }
    }
 
    const long INF = 1L << 60;
    int ri { [MethodImpl(256)] get => (int)sc.Integer(); }
    (int, int) ri2 { [MethodImpl(256)] get => (ri, ri); }
    (int, int, int) ri3 { [MethodImpl(256)] get => (ri, ri, ri); }
    (int, int, int, int) ri4 { [MethodImpl(256)] get => (ri, ri, ri, ri); }
    (int, int, int, int, int) ri5 { [MethodImpl(256)] get => (ri, ri, ri, ri, ri); }
    long rl { [MethodImpl(256)] get => sc.Integer(); }
    (long, long) rl2 { [MethodImpl(256)] get => (rl, rl); }
    (long, long, long) rl3 { [MethodImpl(256)] get => (rl, rl, rl); }
    (long, long, long, long) rl4 { [MethodImpl(256)] get => (rl, rl, rl, rl); }
    (long, long, long, long, long) rl5 { [MethodImpl(256)] get => (rl, rl, rl, rl, rl); }
    double rd { [MethodImpl(256)] get => sc.Double(); }
    string rs { [MethodImpl(256)] get => sc.Scan(); }
}
 
public static class Functions
{
    [MethodImpl(256)]
    public static int Popcount(ulong x)
    {
        x = (x & 0x5555555555555555UL) + ((x >> 1) & 0x5555555555555555UL);
        x = (x & 0x3333333333333333UL) + ((x >> 2) & 0x3333333333333333UL);
        x = (x & 0x0f0f0f0f0f0f0f0fUL) + ((x >> 4) & 0x0f0f0f0f0f0f0f0fUL);
        x = (x & 0x00ff00ff00ff00ffUL) + ((x >> 8) & 0x00ff00ff00ff00ffUL);
        x = (x & 0x0000ffff0000ffffUL) + ((x >> 16) & 0x0000ffff0000ffffUL);
        x = (x & 0x00000000ffffffffUL) + ((x >> 32) & 0x00000000ffffffffUL);
        return (int)x;
    }
    [MethodImpl(256)]
    public static int Popcount(int x)
    {
        x = (x & 0x55555555) + ((x >> 1) & 0x55555555);
        x = (x & 0x33333333) + ((x >> 2) & 0x33333333);
        x = (x & 0x0f0f0f0f) + ((x >> 4) & 0x0f0f0f0f);
        x = (x & 0x00ff00ff) + ((x >> 8) & 0x00ff00ff);
        x = (x & 0x0000ffff) + ((x >> 16) & 0x0000ffff);
        return x;
    }
    [MethodImpl(256)]
    public static int Ctz(long x)
    {
        if (x == 0) return -1;
        return Popcount((ulong)((x & -x) - 1));
    }
    [MethodImpl(256)]
    public static int CeilPow2(int n)
    {
        int x = 0;
        while ((1 << x) < n) x++;
        return x;
    }
    [MethodImpl(256)]
    public static int SafeMod(int x, int m)
    {
        int r = x % m;
        return r < 0 ? r + Math.Abs(m) : r;
    }
    [MethodImpl(256)]
    public static long SafeMod(long x, long m)
    {
        long r = x % m;
        return r < 0 ? r + Math.Abs(m) : r;
    }
    [MethodImpl(256)] public static int Sign(long x) => x == 0 ? 0 : (x < 0 ? -1 : 1);
    [MethodImpl(256)] public static int Sign(double x) => x == 0 ? 0 : (x < 0 ? -1 : 1);
    [MethodImpl(256)] public static int DigitSum(long n, int d = 10) { long s = 0; while (n > 0) { s += n % d; n /= d; } return (int)s; }
    [MethodImpl(256)] public static long Floor(long a, long b) => a >= 0 ? a / b : (a + 1) / b - 1;
    [MethodImpl(256)] public static long Ceil(long a, long b) => a > 0 ? (a - 1) / b + 1 : a / b;
    [MethodImpl(256)] public static int Gcd(int a, int b) => b == 0 ? a : Gcd(b, a % b);
    [MethodImpl(256)] public static long Gcd(long a, long b) => b == 0 ? a : Gcd(b, a % b);
    [MethodImpl(256)] public static (long x, long y, long g) ExtGcd(long a, long b) { if (b == 0) return (Sign(a), 0, Math.Abs(a)); long c = SafeMod(a, b); var (x2, y2, g) = ExtGcd(b, c); long x = SafeMod(y2, b); long y = (g - a * x) / b; return (x, y, g); }
    [MethodImpl(256)] public static void Swap(ref int x, ref int y) { x ^= y; y ^= x; x ^= y; }
    [MethodImpl(256)] public static void Swap(ref long x, ref long y) { x ^= y; y ^= x; x ^= y; }
    [MethodImpl(256)] public static void Swap<T>(ref T x, ref T y) { T t = y; y = x; x = t; }
    [MethodImpl(256)] public static T Clamp<T>(T x, T l, T r) where T : IComparable<T> => x.CompareTo(l) <= 0 ? l : (x.CompareTo(r) <= 0 ? x : r);
    [MethodImpl(256)] public static T Clamp<T>(ref T x, T l, T r) where T : IComparable<T> => x = x.CompareTo(l) <= 0 ? l : (x.CompareTo(r) <= 0 ? x : r);
    [MethodImpl(256)] public static void Chmin<T>(ref T x, T y) where T : IComparable<T> { if (x.CompareTo(y) > 0) x = y; }
    [MethodImpl(256)] public static void Chmax<T>(ref T x, T y) where T : IComparable<T> { if (x.CompareTo(y) < 0) x = y; }
    [MethodImpl(256)] public static int LowerBound(long[] arr, long val, int l = -1, int r = -1) => LowerBound(arr.AsSpan(), t => Sign(t - val), l, r);
    [MethodImpl(256)] public static int LowerBound(int[] arr, int val, int l = -1, int r = -1) => LowerBound(arr.AsSpan(), t => t - val, l, r);
    [MethodImpl(256)] public static int LowerBound<T>(T[] arr, T val, int l = -1, int r = -1) where T : IComparable<T> => LowerBound(arr.AsSpan(), t => t.CompareTo(val), l, r);
    [MethodImpl(256)] public static int LowerBound<T>(T[] arr, Func<T, int> comp, int l = -1, int r = -1) => LowerBound(arr.AsSpan(), comp, l, r);
    [MethodImpl(256)] public static int LowerBound<T>(Span<T> data, Func<T, int> comp, int l = -1, int r = -1) { if (data.Length == 0) return -1; if (l == -1) l = 0; if (r == -1) r = data.Length; while (l < r) { int x = (l + r) / 2; if (comp(data[x]) < 0) l = x + 1; else r = x; } return l; }
    [MethodImpl(256)] public static string ToBase2(long v, int digit = -1) { if (digit == -1) { digit = 0; while ((v >> digit) > 0) digit++; } var c = new string[digit]; for (int i = 0; i < digit; i++) c[digit - 1 - i] = ((v >> i) & 1) == 0 ? "0" : "1"; return string.Join("", c); }
    [MethodImpl(256)] public static string ToBaseN(long v, int n, int digit = -1) { if (digit == -1) { digit = 0; long pow = 1; while (v >= pow) { digit++; pow *= n; } } var c = new int[digit]; for (int i = 0; i < digit; i++, v /= n) c[digit - 1 - i] = (int)(v % n); return string.Join("", c); }
}
 
public class StreamScannerB
{
    public StreamScannerB(Stream stream) { str = stream; }
    private readonly Stream str;
    private readonly byte[] buf = new byte[1024];
    private int len, ptr;
    public bool isEof = false;
    public bool IsEndOfStream { get { return isEof; } }
    [MethodImpl(256)] private byte read() { if (isEof) throw new EndOfStreamException(); if (ptr >= len) { ptr = 0; if ((len = str.Read(buf, 0, 1024)) <= 0) { isEof = true; return 0; } } return buf[ptr++]; }
    [MethodImpl(256)] public char Char() { byte b = 0; do b = read(); while (b < 33 || 126 < b); return (char)b; }
    [MethodImpl(256)] public string Line() { var sb = new StringBuilder(); for (var b = Char(); b != 10 && !isEof; b = (char)read()) sb.Append(b); return sb.ToString(); }
    [MethodImpl(256)] public string Scan() { var sb = new StringBuilder(); for (var b = Char(); b >= 33 && b <= 126; b = (char)read()) sb.Append(b); return sb.ToString(); }
    [MethodImpl(256)] public long Integer() { long ret = 0; byte b = 0; var ng = false; do b = read(); while (b != '-' && (b < '0' || '9' < b)); if (b == '-') { ng = true; b = read(); } for (; true; b = read()) { if (b < '0' || '9' < b) return ng ? -ret : ret; else ret = ret * 10 + b - '0'; } }
    [MethodImpl(256)] public ulong UInteger() { ulong ret = 0; byte b = 0; do b = read(); while (b < '0' || '9' < b); for (; true; b = read()) { if (b < '0' || '9' < b) return ret; else ret = ret * 10 + b - '0'; } }
    [MethodImpl(256)] public double Double() => double.Parse(Scan());
}
 
public static class OutputLib
{
    [MethodImpl(256)] public static void WriteJoin<T>(string s, IEnumerable<T> t) => Console.WriteLine(string.Join(s, t));
    [MethodImpl(256)] public static void WriteMat<T>(T[,] a) { int sz1 = a.GetLength(0); int sz2 = a.GetLength(1); for (int i = 0; i < sz1; i++) { var b = new T[sz2]; for (int j = 0; j < sz2; j++) b[j] = a[i, j]; WriteJoin(" ", b); } }
    [MethodImpl(256)] public static void WriteMat<T>(T[][] a) { for (int i = 0; i < a.Length; i++) WriteJoin(" ", a[i]); }
    [MethodImpl(256)] public static void Write(object t) => Console.WriteLine(t.ToString());
    [MethodImpl(256)] public static void Write(string str) => Console.WriteLine(str);
    [MethodImpl(256)] public static void Write(string str, object arg1) => Console.WriteLine(str, arg1);
    [MethodImpl(256)] public static void Write(string str, object arg1, object arg2) => Console.WriteLine(str, arg1, arg2);
    [MethodImpl(256)] public static void Write(string str, object arg1, object arg2, object arg3) => Console.WriteLine(str, arg1, arg2, arg3);
    [MethodImpl(256)] public static void Write(string str, params object[] arg) => Console.WriteLine(str, arg);
    [MethodImpl(256)] public static void WriteFlush(object t) { Console.WriteLine(t.ToString()); Console.Out.Flush(); }
    [MethodImpl(256)] public static void WriteError(object t) => Console.Error.WriteLine(t.ToString());
    [MethodImpl(256)] public static void Flush() => Console.Out.Flush();
    [MethodImpl(256)] public static void YN(bool t) => Console.WriteLine(t ? "YES" : "NO");
    [MethodImpl(256)] public static void Yn(bool t) => Console.WriteLine(t ? "Yes" : "No");
    [MethodImpl(256)] public static void yn(bool t) => Console.WriteLine(t ? "yes" : "no");
}
 
public interface IStaticMod
{
    uint Mod { get; }
    bool IsPrime { get; }
}
public readonly struct Mod1000000007 : IStaticMod
{
    public uint Mod => 1000000007;
    public bool IsPrime => true;
}
public readonly struct Mod998244353 : IStaticMod
{
    public uint Mod => 998244353;
    public bool IsPrime => true;
}
public readonly struct StaticModInt<T> : IEquatable<StaticModInt<T>>, IFormattable where T : struct, IStaticMod
{
    internal readonly uint _v;
    private static readonly T op = default;
    public int Value => (int)_v;
    public static int Mod => (int)op.Mod;
    public static StaticModInt<T> Zero => default;
    public static StaticModInt<T> One => new StaticModInt<T>(1u);
    [MethodImpl(256)]
    public static StaticModInt<T> Raw(int v)
    {
        var u = unchecked((uint)v);
        return new StaticModInt<T>(u);
    }
    [MethodImpl(256)]
    public StaticModInt(long v) : this(Round(v)) { }
    [MethodImpl(256)]
    public StaticModInt(ulong v) : this((uint)(v % op.Mod)) { }
    [MethodImpl(256)]
    private StaticModInt(uint v) => _v = v;
    [MethodImpl(256)]
    private static uint Round(long v)
    {
        var x = v % op.Mod;
        if (x < 0) x += op.Mod;
        return (uint)x;
    }
    [MethodImpl(256)]
    public static StaticModInt<T> operator ++(StaticModInt<T> v)
    {
        var x = v._v + 1;
        if (x == op.Mod) x = 0;
        return new StaticModInt<T>(x);
    }
    [MethodImpl(256)]
    public static StaticModInt<T> operator --(StaticModInt<T> v)
    {
        var x = v._v;
        if (x == 0) x = op.Mod;
        return new StaticModInt<T>(x - 1);
    }
    [MethodImpl(256)]
    public static StaticModInt<T> operator +(StaticModInt<T> lhs, StaticModInt<T> rhs)
    {
        var v = lhs._v + rhs._v;
        if (v >= op.Mod) v -= op.Mod;
        return new StaticModInt<T>(v);
    }
    [MethodImpl(256)]
    public static StaticModInt<T> operator -(StaticModInt<T> lhs, StaticModInt<T> rhs)
    {
        unchecked
        {
            var v = lhs._v - rhs._v;
            if (v >= op.Mod) v += op.Mod;
            return new StaticModInt<T>(v);
        }
    }
    [MethodImpl(256)]
    public static StaticModInt<T> operator *(StaticModInt<T> lhs, StaticModInt<T> rhs) => new StaticModInt<T>((uint)((ulong)lhs._v * rhs._v % op.Mod));
    [MethodImpl(256)]
    public static StaticModInt<T> operator /(StaticModInt<T> lhs, StaticModInt<T> rhs) => lhs * rhs.Inv();
    [MethodImpl(256)]
    public static StaticModInt<T> operator +(StaticModInt<T> v) => v;
    [MethodImpl(256)]
    public static StaticModInt<T> operator -(StaticModInt<T> v) => new StaticModInt<T>(v._v == 0 ? 0 : op.Mod - v._v);
    [MethodImpl(256)]
    public static bool operator ==(StaticModInt<T> lhs, StaticModInt<T> rhs) => lhs._v == rhs._v;
    [MethodImpl(256)]
    public static bool operator !=(StaticModInt<T> lhs, StaticModInt<T> rhs) => lhs._v != rhs._v;
    [MethodImpl(256)]
    public static implicit operator StaticModInt<T>(int v) => new StaticModInt<T>(v);
    [MethodImpl(256)]
    public static implicit operator StaticModInt<T>(uint v) => new StaticModInt<T>((long)v);
    [MethodImpl(256)]
    public static implicit operator StaticModInt<T>(long v) => new StaticModInt<T>(v);
    [MethodImpl(256)]
    public static implicit operator StaticModInt<T>(ulong v) => new StaticModInt<T>(v);
    [MethodImpl(256)]
    public static implicit operator long(StaticModInt<T> v) => v._v;
    [MethodImpl(256)]
    public static implicit operator ulong(StaticModInt<T> v) => v._v;
    [MethodImpl(256)]
    public StaticModInt<T> Pow(long n)
    {
        var x = this;
        var r = new StaticModInt<T>(1U);
        while (n > 0)
        {
            if ((n & 1) > 0) r *= x;
            x *= x;
            n >>= 1;
        }
        return r;
    }
    [MethodImpl(256)]
    public StaticModInt<T> Inv()
    {
        var (x, y, g) = ExtGcd(_v, op.Mod);
        return new StaticModInt<T>(x);
    }
    [MethodImpl(256)]
    static (long x, long y, long g) ExtGcd(long a, long b)
    {
        if (b == 0) return a >= 0 ? (1, 0, a) : (-1, 0, -a);
        long c = SafeMod(a, b);
        var (x2, y2, g) = ExtGcd(b, c);
        long x = SafeMod(y2, b);
        long y = (g - a * x) / b;
        return (x, y, g);
    }
    [MethodImpl(256)]
    static long SafeMod(long x, long m)
    {
        long r = x % m;
        if (r < 0) r += m;
        return r;
    }
    [MethodImpl(256)]
    public override string ToString() => _v.ToString();
    [MethodImpl(256)]
    public string ToString(string format, IFormatProvider formatProvider) => _v.ToString(format, formatProvider);
    [MethodImpl(256)]
    public override bool Equals(object obj) => obj is StaticModInt<T> m && Equals(m);
    [MethodImpl(256)]
    public bool Equals(StaticModInt<T> other) => _v == other._v;
    [MethodImpl(256)]
    public override int GetHashCode() => _v.GetHashCode();
}
 
public class Map<TKey, TValue> : Dictionary<TKey, TValue>
{
    public new TValue this[TKey key]
    {
        get
        {
            TValue value;
            return TryGetValue(key, out value) ? value : default;
        }
        set
        {
            if (ContainsKey(key)) base[key] = value;
            else Add(key, value);
        }
    }
}