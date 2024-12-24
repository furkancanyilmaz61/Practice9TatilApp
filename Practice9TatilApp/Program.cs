using System;

class Program
{
    static void Main(string[] args)
    {
        // Lokasyon bilgileri
        string[] lokasyonlar = { "Bodrum", "Marmaris", "Çeşme" };
        int[] lokasyonFiyatlari = { 4000, 3000, 5000 };

        // Ulaşım bilgileri
        int karaYoluFiyati = 1500;
        int havaYoluFiyati = 4000;

        while (true)
        {
            Console.WriteLine("Lütfen tatil yapmak istediğiniz lokasyonu seçiniz: (Bodrum, Marmaris, Çeşme)");
            string lokasyon = Console.ReadLine()?.Trim().ToLower();

            int lokasyonIndex = Array.FindIndex(lokasyonlar, l => l.ToLower() == lokasyon);
            if (lokasyonIndex == -1)
            {
                Console.WriteLine("Geçersiz bir lokasyon girdiniz. Lütfen tekrar deneyiniz.");
                continue;
            }

            Console.WriteLine("Kaç kişi tatil planlıyorsunuz?");
            if (!int.TryParse(Console.ReadLine(), out int kisiSayisi) || kisiSayisi <= 0)
            {
                Console.WriteLine("Geçerli bir kişi sayısı giriniz.");
                continue;
            }

            Console.WriteLine("Tatilinize kara yolu ile mi hava yolu ile mi gitmek istersiniz? (1 = Kara Yolu, 2 = Hava Yolu)");
            if (!int.TryParse(Console.ReadLine(), out int ulasimSecimi) || (ulasimSecimi != 1 && ulasimSecimi != 2))
            {
                Console.WriteLine("Geçerli bir ulaşım seçeneği giriniz.");
                continue;
            }

            int ulasimFiyati = ulasimSecimi == 1 ? karaYoluFiyati : havaYoluFiyati;
            int toplamFiyat = kisiSayisi * (lokasyonFiyatlari[lokasyonIndex] + ulasimFiyati);

            Console.WriteLine($"\nSeçiminiz: {lokasyonlar[lokasyonIndex]}");
            Console.WriteLine($"Tatil Bilgisi: Bu lokasyonda keyifli bir tatil yapabilir, tarihi ve doğal güzellikleri keşfedebilirsiniz.");
            Console.WriteLine($"Kişi başı toplam maliyet: {lokasyonFiyatlari[lokasyonIndex] + ulasimFiyati} TL");
            Console.WriteLine($"Toplam maliyet ({kisiSayisi} kişi): {toplamFiyat} TL");

            Console.WriteLine("\nBaşka bir tatil planı yapmak ister misiniz? (Evet/Hayır)");
            string devam = Console.ReadLine()?.Trim().ToLower();
            if (devam == "hayır")
            {
                Console.WriteLine("İyi günler dileriz! Çıkış yapılıyor...");
                break; // Döngüyü sonlandırır ve programdan çıkar
            }
            else if (devam != "evet")
            {
                Console.WriteLine("Geçersiz giriş. Program sonlandırılıyor.");
                break; // Geçersiz girişlerde de çıkış yapılıyor
            }
        }
    }
}
