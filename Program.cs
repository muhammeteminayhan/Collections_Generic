using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main()
    {
        // Dosyadan veri okuma
        string filePath = "rehber.txt"; // Metin dosyasının adını kontrol edin.

        if (!File.Exists(filePath))
        {
            Console.WriteLine("Dosya bulunamadı. Lütfen 'rehber.txt' dosyasını uygulama dizinine yerleştirin.");
            return;
        }

        var cityDictionary = new SortedDictionary<string, SortedDictionary<string, string>>();

        foreach (var line in File.ReadAllLines(filePath))
        {
            // Satırı ayırma
            var parts = line.Split('|');
            if (parts.Length != 3) continue;

            string name = parts[0].Trim();
            string city = parts[1].Trim();
            string phone = parts[2].Trim();

            // Şehir için kontrol
            if (!cityDictionary.ContainsKey(city))
            {
                cityDictionary[city] = new SortedDictionary<string, string>();
            }

            // Şehir altına kişi ekleme
            cityDictionary[city][name] = phone;
        }

        // Çıktıyı ekrana yazdırma
        foreach (var cityEntry in cityDictionary)
        {
            Console.WriteLine($"{cityEntry.Key} :");
            foreach (var personEntry in cityEntry.Value)
            {
                Console.WriteLine($"  {personEntry.Key} - {personEntry.Value}");
            }
        }
    }
}