
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static readonly string Samogloski = "aąeęiouóy";
    static readonly List<string> Historia = new List<string>();

    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.Title = "LINGUA // Ultimate Translator";

        while (true)
        {
            Console.Clear();
            Naglowek();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("  [1]  POLSKI  ->  JĘZYMPYK");
            Console.WriteLine("  [2]  JĘZYMPYK  ->  POLSKI");
            Console.WriteLine("  [3]  HISTORIA TŁUMACZEŃ");
            Console.WriteLine("  [4]  INFORMACJE");
            Console.WriteLine("  [0]  WYJŚCIE");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\n  ─────────────────────────────────────");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\n  Wybierz opcję » ");
            Console.ResetColor();

            string opcja = Console.ReadLine() ?? "";

            switch (opcja)
            {
                case "1":
                    Tlumacz(true);
                    break;
                case "2":
                    Tlumacz(false);
                    break;
                case "3":
                    PokazHistorie();
                    break;
                case "4":
                    Informacje();
                    break;
                case "0":
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("\n  Wympypiemperdampalampaj!");
                    Console.ResetColor();
                    return;
                default:
                    Blad("Nieznana opcja!");
                    break;
            }
        }
    }

    static void Naglowek()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(
            "  ╔══════════════════════════════════════════════════════════════╗");
        Console.WriteLine(
            "  ║          J Ę M P Ę Z Y M P Y K   A M P A A M P A A M P A     ║");
        Console.WriteLine(
            "  ╚══════════════════════════════════════════════════════════════╝");

        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("       ULTIMATE LANGUAGE TRANSLATOR");
        Console.ResetColor();
        Console.WriteLine();
    }

    static bool CzySamogloska(char znak)
    {
        return Samogloski.Contains(
            char.ToLowerInvariant(znak));
    }

    static string TlumaczNaLingua(string tekst)
    {
        StringBuilder wynik = new StringBuilder();

        foreach (char znak in tekst)
        {
            wynik.Append(znak);

            if (CzySamogloska(znak))
            {
                wynik.Append("mp");
                wynik.Append(znak);
            }
        }

        return wynik.ToString();
    }

    static string TlumaczNaPolski(string tekst)
    {
        StringBuilder wynik = new StringBuilder();

        for (int i = 0; i < tekst.Length; i++)
        {
            char znak = tekst[i];
            wynik.Append(znak);

            // Samogłoska + mp + powtórzona samogłoska
            if (CzySamogloska(znak)
                && i + 3 < tekst.Length
                && tekst[i + 1] == 'm'
                && tekst[i + 2] == 'p'
                && char.ToLowerInvariant(tekst[i + 3])
                    == char.ToLowerInvariant(znak))
            {
                i += 3;
            }
        }

        return wynik.ToString();
    }

    static void Tlumacz(bool naLingua)
    {
        Console.Clear();
        Naglowek();

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(naLingua
            ? "  TRYB: POLSKI -> LINGUA"
            : "  TRYB: LINGUA -> POLSKI");

        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("  Wpisz tekst i naciśnij ENTER.");
        Console.WriteLine("  Wpisz /back, aby wrócić do menu.\n");
        Console.ResetColor();

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write("  Tekst » ");
        Console.ResetColor();

        string tekst = Console.ReadLine() ?? "";

        if (tekst == "/back")
            return;

        string wynik = naLingua
            ? TlumaczNaLingua(tekst)
            : TlumaczNaPolski(tekst);

        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("  ───────────── WYNIK ─────────────");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\n  " + wynik);
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("\n  ─────────────────────────────────");
        Console.ResetColor();

        Historia.Add(
            (naLingua ? "PL > LINGUA: " : "LINGUA > PL: ")
            + tekst + " => " + wynik);

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("\n  [ENTER] Powrót do menu");
        Console.ResetColor();
        Console.ReadLine();
    }

    static void PokazHistorie()
    {
        Console.Clear();
        Naglowek();

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("  HISTORIA TŁUMACZEŃ\n");
        Console.ResetColor();

        if (Historia.Count == 0)
        {
            Console.WriteLine("  Brak tłumaczeń.");
        }
        else
        {
            foreach (string wpis in Historia)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("  > " + wpis);
                Console.ResetColor();
            }
        }

        Console.WriteLine("\n  Naciśnij ENTER, aby wrócić.");
        Console.ReadLine();
    }

    static void Informacje()
    {
        Console.Clear();
        Naglowek();

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("  O PROJEKCIE\n");
        Console.ResetColor();

        Console.WriteLine("  Nazwa:       LINGUA AAA");
        Console.WriteLine("  Wersja:      1.0");
        Console.WriteLine("  Technologia: C#");
        Console.WriteLine("  Biblioteki:  Systemowe");
        Console.WriteLine();
        Console.WriteLine("  Reguła języka:");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("  a -> ampa");
        Console.WriteLine("  e -> empe");
        Console.WriteLine("  o -> ompo");
        Console.ResetColor();

        Console.WriteLine("\n  Naciśnij ENTER, aby wrócić.");
        Console.ReadLine();
    }

    static void Blad(string komunikat)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\n  [BŁĄD] " + komunikat);
        Console.ResetColor();
        Console.WriteLine("  Naciśnij ENTER...");
        Console.ReadLine();
    }
}
