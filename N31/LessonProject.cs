//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Runtime.CompilerServices;
//using System.Text;
//using System.Threading.Tasks;
//using System.Xml.Linq;

//namespace N31
//{
//    public class LessonProject
//    {
//        public async Task Main(string[] args)
//        {
//            while (true)
//            {
//                Console.Write("1.Content download\n2.File translate\n3.Game\n4.Exit\n\n=> ");
//                var choise = Console.ReadLine();
//                if (choise == "1")
//                {
//                    await Task.Run(() =>
//                    {
//                        DownloadVideoAsync("https://m.muzuz.net/mp3/shohruhxon-oq-libos-video-klip.mp4");
//                    });
//                }
//                else if (choise == "2") 
//                {
//                    await TranslateTextAsync("method");
//                }
//            }
//        }
//        private async Task DownloadVideoAsync(string url)
//        {
//            var folderName = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.ToString());
//            var filePath = Path.Combine(folderName, $"{Guid.NewGuid().ToString().Substring(0, 10)}.mp4");
//            Console.WriteLine("video yuklanyapti...");
            
//            Console.WriteLine("Video yuklandi");
//        }
//        private async Task<string> TranslateTextAsync(string text)
//        {
//            string api = "http://translate.google.com/?hl=ru&sl=en&tl=uz&text=method&op=translate";
//            using (var httpClient = new HttpClient())
//            {
//                var responce = await httpClient.GetAsync(api);
//                if (responce.IsSuccessStatusCode)
//                {
//                    var jsonResponse = await responce.Content.ReadAsStringAsync();
//                    Console.WriteLine(jsonResponse);
//                    return jsonResponse;
//                }
//                return "--";
//            }
//        }

//    }
//}
