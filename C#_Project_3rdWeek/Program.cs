using System;
using System.Collections.Generic;

class Program
{
    static void Main() // 3 uygulamadan birini seçmek için metot tanımladık.
    {
        while (true) // kullanıcı 0 çıkış seçeneğini basana kadar sonsuz döngü şeklinde uygulama seçimi devam eder.
        {
            Console.WriteLine("Uygulama Menüsü:");
            Console.WriteLine("1- Rastgele Sayı Bulma Oyunu");
            Console.WriteLine("2- Hesap Makinesi");
            Console.WriteLine("3- Ortalama Hesaplama");
            Console.WriteLine("0- Çıkış");
            Console.Write("Uygulamalar arasında bir seçim yapınız (1-3, 0): ");
            string appChoice = Console.ReadLine(); // kullanıcıdan uygulama seçimi istiyoruz.

            switch (appChoice) // seçtiği uygulamaya göre switch ile seçenekleri oluşturuyoruz ve metotları çağırıyoruz. Metotları aşağıda uygulamalarda tanımlayacağız.
            {
                case "1":
                    randomNumberApp();
                    break;

                case "2":
                    calculator();
                    break;

                case "3":
                    averageGrade();
                    break;

                case "0":
                    Console.WriteLine("Programdan çıkıldı.");
                    return; // return ile programı sonlandırıyoruz.

                default:
                    Console.WriteLine("Geçersiz seçim. Devam etmek için Enter'a basınız."); // farklı bir seçim girilmesi halinde enterdan sonra tekrar menü gelecek.
                    Console.ReadLine();
                    break;
            }
        }
    }

    static void randomNumberApp()
    {

        int getEstimations() //yanlış bir karakter, boş ya da sadece enter'a basması halinde hakkı gitmemesi için metot oluşturuyoruz.
        {
            while (true)
            {
                string data = Console.ReadLine();
                if (string.IsNullOrEmpty(data)) //giriş eğer boş ya da geçersizse.
                {
                    Console.WriteLine("Boş giriş yapamazsınız. Lütfen geçerli bir sayı giriniz: ");
                    continue;
                }
                if (int.TryParse(data, out int estimate)) // eğer giriş başarılı bir şekilde sayıya çevrildiyse.
                {
                    return estimate; //çıkış yapıyoruz.
                }
                else
                {
                    Console.WriteLine("1 ile 100 arasında geçerli bir sayı girin: ");
                }
            }
        }

        Random rand = new Random();

        int target = rand.Next(1, 101);
        int attempts = 5; //Kullanıcının toplam 5 hakkı var.

        Console.WriteLine("1 ile 100 arasında bir sayı tuttum. Tahmin etmek için 5 hakkın var! Haydi başlayalım.");

        while (attempts > 0) //Kullanıcının hakkı kaldığı sürece döngü çalışacak.
        {
            Console.WriteLine($"{attempts} hakkınız var.");
            Console.Write("Bir sayı tahmin edin: ");
            int estimate = getEstimations(); //Giriş için metodu çağırdık. Tahminlerimizi bu değişkende tutacağız.

            //aşağıdaki yöntemle son hakkını da kaybettiğinde daha büyük ya da daha küçük bir sayı girmelisin diye öneride bulunmayacak.
            if (estimate == target) //tutulan sayıd doğruysa
            {
                Console.WriteLine("Tebrikler, doğru bildiniz!");
                return; // bu şekilde program sona eriyor.
            }

            else if (estimate < target && attempts > 1) //tutulan sayıdan daha küçükse ve 1'den fazla hakkı varsa yani son hakkı değilse.
            {
                Console.WriteLine("Daha büyük bir sayı girmelisin.");
            }

            else if (estimate > target && attempts > 1) // tutulan sayıdan daha büyükse ve 1'den fazla hakkı varsa, yani son hakkı değilse.
            {
                Console.WriteLine("Daha küçük bir sayı girmelisin.");
            }
            attempts--; //5'ten geriye her denemede hakkı düşüyor.
        }

        Console.WriteLine($"Hakkınız bitti. Doğru sayı {target}.");

    }

    static void calculator() //hesap makinesi uygulaması tanımlıyoruz.
    {

        Console.WriteLine("Hesap Makinesi Uygulaması.");
        //kullanıcıdan bilgileri alıyoruz.
        Console.Write("1. sayıyı girin: ");
        double number1 = Convert.ToDouble(Console.ReadLine());

        Console.Write("2. sayıyı girin: ");
        double number2 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Yapmak istediğiniz işlemi seçin: ");
        Console.WriteLine("Toplama --> +");
        Console.WriteLine("Çıkarma --> -");
        Console.WriteLine("Çarpma --> *");
        Console.WriteLine("Bölme --> /");

        char arithmetics = Convert.ToChar(Console.ReadLine()); // karakter gireceğimiz için char kullandık.

        switch (arithmetics) // işleme göre sonuçları yazıdırıyoruz.
        {
            case '+':
                Console.WriteLine($"Sonuç: {number1 + number2}");
                break;

            case '-':
                Console.WriteLine($"Sonuç: {number1 - number2}");
                break;

            case '*':
                Console.WriteLine($"Sonuç: {number1 * number2}");
                break;
            case '/':
                if (number2 != 0)
                    Console.WriteLine($"Sonuç: {number1 / number2}");
                else
                    Console.WriteLine("Sıfıra bölme yapamazsınız. İkinci sayı sıfırdan farklı olmalı.");
                break;

            default:
                Console.WriteLine("Geçersiz bir sayı girdiniz. Lütfen tekrar deneyiniz.");
                break;

        }
    }

    static void averageGrade() // ortalama hesaplama uygulamasını tanımlıyoruz.
    {
        Console.WriteLine("Ortalama Hesaplama Uygulaması.");

        //kullanıcı bilgilerini alıyoruz.
        Console.WriteLine("Birinci notunuzu giriniz: ");
        double grade1 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("İkinci notunuzu giriniz: ");
        double grade2 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Üçüncü notunuzu giriniz: ");
        double grade3 = Convert.ToDouble(Console.ReadLine());

        //geçersiz bir sayı halinde uyarı vermesi için;
        if (grade1 < 0 || grade1 > 100 || grade2 < 0 || grade2 > 100 || grade3 < 0 || grade3 > 100)
        {
            Console.WriteLine("Hata! Lütfen tüm notlarınızı 0 ile 100 arasında giriniz");
            return; // programı sonlandırdık.
        }

        //ortalamayı hesapladığımız bir değişken tanımlıyoruz.
        double avg = (grade1 + grade2 + grade3) / 3;
        Console.WriteLine($"Not ortalamanız: {avg}");

        //bu değişkendeki sayıyı harf notu olarak göstereceğiz;
        if (avg >= 90 && avg <= 100)
        {
            Console.WriteLine("Harf notunuz AA.");
        }
        else if (avg >= 85)
        {
            Console.WriteLine("Harf notunuz BA.");
        }
        else if (avg >= 80)
        {
            Console.WriteLine("Harf notunuz BB.");
        }
        else if (avg >= 75)
        {
            Console.WriteLine("Harf notunuz CB.");
        }
        else if (avg >= 70)
        {
            Console.WriteLine("Harf notunuz CC.");
        }
        else if (avg >= 65)
        {
            Console.WriteLine("Harf notunuz DC.");
        }
        else if (avg >= 60)
        {
            Console.WriteLine("Harf notunuz DD.");
        }
        else if (avg >= 55)
        {
            Console.WriteLine("Harf notunuz FD.");
        }
        else
        {
            Console.WriteLine("Harf notunuz FF.");
        }
    }
}