using System;
using System.Collections.Generic;
using SzamonkeresLINQ;

internal class Program
{
    private static void Main(string[] args)
    {
     
        List<Szorny> szornyek = SzornyAdatbazis.Feltolt(new List<Szorny>());

        SzornyElemzo szornyekElemzo = new SzornyElemzo(szornyek);

        Console.WriteLine($"Összes szörny száma: {szornyekElemzo.OsszesSzornySzama()}");

        Console.WriteLine("Veszélyes szörnyek nevei:");
        foreach (var nev in szornyekElemzo.VeszelyesSzornyekNevei())
        {
            Console.WriteLine(nev);
        }

        Console.WriteLine("Egyedi élőhelyek:");
        foreach (var elohely in szornyekElemzo.EgyediElohelyek())
        {
            Console.WriteLine(elohely);
        }

        Console.WriteLine($"Átlagos veszélyességi szint: {szornyekElemzo.AtlagosVeszelyesseg():F2}");

        Console.WriteLine("Legveszélyesebb szörnyek:");
        foreach (var szorny in szornyekElemzo.LegveszelyesebbSzornyek())
        {
            Console.WriteLine($"{szorny.Nev} - Veszélyességi szint: {szorny.VeszelyessegiSzint}");
        }

        Console.WriteLine("Mocsári veszélyes szörnyek:");
        foreach (var szorny in szornyekElemzo.MocsariVeszelyesSzornyek())
        {
            Console.WriteLine($"{szorny.Nev} - Élőhely: {szorny.Elohely} - Veszélyességi szint: {szorny.VeszelyessegiSzint}");
        }

        Console.WriteLine($"Van-e extrém tűz gyenge szörny? {(szornyekElemzo.VanExtremTuzGyengeSzorny() ? "Igen" : "Nem")}");

        Console.WriteLine("Szörnyek száma élőhelyenként:");
        foreach (var elohelyCount in szornyekElemzo.SzornyekSzamaElohelyenkent())
        {
            Console.WriteLine(elohelyCount);
        }

        Console.WriteLine("A program véget ért. Nyomj meg egy gombot a kilépéshez.");
        Console.ReadKey();
    }
}
