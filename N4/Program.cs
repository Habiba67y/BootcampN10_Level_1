//#1
//using static System.Net.Mime.MediaTypeNames;

//string[] Names = new string[]
//    {
//        "Abdulxayev Jasurbek Anvar O'g'li",
//        "Abdumannonov Botirjon Davlat O'g'li",
//        "Abdurahmonov Azizbek Alisher O'g'li",
//        "Anvarjonov Ozodbek Avazxon O'g'li",
//        "Asadov Firdavs Asqarbek O'g'li",
//        "Eshmurodov Umarali Abduhalim O'g'li",
//        "Ibrohimjonov Shodiyor Ziyodali O'g'li",
//        "Jo'raboyev Boburjon Murodjon O'g'li",
//        "Kamolov Bunyod Maruf O'g'li",
//        "Karimjonov Ilhom Ramzjon O'g'li",
//        "Komiljonov Muhammadaziz Abduraximovich",
//        "Rashidov Asadbek",
//        "Sadriddinov Abdurahmon Jurabek O'g'li",
//        "Sattorova Habiba Shuxrat Qizi",
//        "Tolibov Firdavs Odil O'g'li",
//        "To'rayev Dinur Alisher O'g'li",
//        "Vositov Muhammadrizo Muhammadtolib O'g'li",
//        "Xaybullayev Mexroj Mansurjonovich",
//        "Xolmuratov Qurbonali Suxrob O'g'li"
//    };
//string search = Console.ReadLine();
//for (int i = 0; i < Names.Length; i++)
//{
//    if (Names[i].Contains(search, StringComparison.OrdinalIgnoreCase))
//    {
//        Console.WriteLine(Names[i]);
//    }
//}

//#2
//var s1 = "{{ApplicationDate}}";
//var s2 = "{{ApplicationNumber}}";
//var s3 = "{{OrganizationName}}";
//var s4 = "{{rektor}}";
//var s5 = "{{StudentName}}";
//var s6 = "{{StudentNumber}}";
//var s16 = "{{Code}}";
//var s7 = "{{EduSpeciality}}";
//var s8 = "{{EduForm}}";
//var s9 = "{{EduLanguage}}";
//var s10 = "{{OrderId}}";
//var s11 = "{{Ball}}";
//var s12= "{{DifferenceBall}}";
//var s13 = "{{EduContractSumType}}";
//var s14 = "{{Abiturient}}";
//var s15 = "{{AbiturientId}}";

//string application = "{{ApplicationDate}} {{ApplicationNumber}}\n{{OrganizationName}}rektori {{rektor}} Rektorga Abituriyent {{StudentName}}" +
//    " dan Tel.: {{StudentNumber}}\n\nARIZA\n  Men joriy yilda {{OrganizationName}}ning {{Code}} - {{EduSpeciality}}ta 'lim yo'nalishini" +
//    " {{EduForm}}ta 'lim shakli, {{EduLanguage}} ta'lim tili bo'yicha {{OrderId}} - OTM sifatida tanlab, davlat test sinovida ishtirok" +
//    " etdim.Davlat test markazi tomonidan e'lon qilingan test natijasiga ko'ra {{Ball}} ball to'pladim va to'lov-kontrakt asosidagi qabul " +
//    "chegarasiga {{DifferenceBall}} ball yetmay qoldi .Shu munosabat bilan, meni qo'shimcha tarzda {{EduContractSumType}} tabaqalashtirilgan" +
//    " to'lov-kontrakt asosida talabalikka qabul qilishingizni hamda menga to`lov shartnomasini taqdim etishingizni so'rayman.Men Oliy ta'lim" +
//    " muassasasining ichki tartib qoidalari va kontraktni barcha shartlari bilan tanishib chiqdim hamda tasdiqlangan o'quv rejasi bo'yicha belgilangan" +
//    " vaqtlarda darslarga qatnashishga, belgilangan muddatlarda to'lov-kontrakt pulini to'lashga va to'lov hujjatlarini topshirishga shaxsan o`zim " +
//    "mas'ulligimni tasdiqlayman.\nAbituriyent: {{Abiturient}} ID raqami: {{AbiturientId}}";
//string f = application
//    .Replace(s1, "14.07.2023")
//    .Replace(s2, "852-52-526")
//    .Replace(s3, "Najot ta'lim")
//    .Replace(s4, "Falonchi falonchiyevga")
//    .Replace(s5, "Sattorova Habiba")
//    .Replace(s6, "74-185-296")
//    .Replace(s7, "fghj52")
//    .Replace(s8, "5")
//    .Replace(s9, "6")
//    .Replace(s10, "c#")
//    .Replace(s11, "4545")
//    .Replace(s12, "5")
//    .Replace(s13, "100 000 so'm")
//    .Replace(s14, "Sattorova Habiba")
//    .Replace(s15, "8606")
//    .Replace(s16, "8956");
//Console.WriteLine(f);