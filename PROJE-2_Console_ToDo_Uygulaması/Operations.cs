using System;
using System.Collections.Generic;
using System.Text;

namespace PROJE_2_Console_ToDo_Uygulaması
{
    public class Operations
    {


        Dictionary<int, TeamMember> memberDictionary = new Dictionary<int, TeamMember>();
        Dictionary<int, TeamMember> TODO = new Dictionary<int, TeamMember>();
        Dictionary<int, TeamMember> INPROGRESS = new Dictionary<int, TeamMember>();
        Dictionary<int, TeamMember> DONE = new Dictionary<int, TeamMember>();

        public Operations()
        {
            memberDictionary.Add(1, (new TeamMember(Color.RED, "Ronaldo", "Futbolcu", Size.XS)));
            memberDictionary.Add(2, (new TeamMember(Color.ORANGE, "Eminem", "Singer", Size.M)));
            memberDictionary.Add(3, (new TeamMember(Color.YELLOW, "Einstein", "BilimAdamı", Size.XL)));
            memberDictionary.Add(4, (new TeamMember(Color.GREEN, "Messi", "Futbolcu", Size.L)));
            memberDictionary.Add(5, (new TeamMember(Color.BLUE, "Edward", "Vampire", Size.L)));
            memberDictionary.Add(6, (new TeamMember(Color.YELLOW, "Bella", "Vampire", Size.S)));
            memberDictionary.Add(7, (new TeamMember(Color.GREEN, "Suarez", "Futbolcu", Size.M)));
            memberDictionary.Add(8, (new TeamMember(Color.PURPLE, "Tarkan", "Popstar", Size.S)));
            memberDictionary.Add(9, (new TeamMember(Color.GREEN, "Xavi", "Futbolcu", Size.S)));
            memberDictionary.Add(10, (new TeamMember(Color.YELLOW, "Rihanna", "WorldStar", Size.XL)));

            TODO.Add(2, (new TeamMember(Color.ORANGE, "Eminem", "Singer", Size.M)));
            TODO.Add(6, (new TeamMember(Color.YELLOW, "Bella", "Vampire", Size.S)));
            INPROGRESS.Add(10, (new TeamMember(Color.YELLOW, "Rihanna", "WorldStar", Size.XL)));
        }
        public bool Control(int entry)
        {
            if (entry > 0)
                return true;
            else
                return false;
        }
        public void Exit()
        {
            Console.WriteLine("Menüye Dönmek İçin ENTER Tuşuna Basın");
        }

        public void Empty()
        {
            Console.WriteLine("~ BOŞ ~" +
                "\n\n");
        }
        public void IdControl(Dictionary<int, TeamMember> dictionary)
        {
            Console.Write("Lütfen Eklemek İstedğiniz Kartın ID Bilgisini Giriniz:");
            int id = int.Parse(Console.ReadLine());
            if ((memberDictionary.ContainsKey(id)))
            {
                if (!(TODO.ContainsKey(id) || INPROGRESS.ContainsKey(id) || DONE.ContainsKey(id)))
                {
                    foreach (var item in memberDictionary)
                    {
                        if (item.Key == id)
                        {
                            TODO.Add(id, (new TeamMember(item.Value.Title, item.Value.Content, item.Value.Member, item.Value.Size)));
                            Console.WriteLine("Ekleme İşlemi Başarılı");
                            Exit();
                        }
                    }
                }
                else
                {
                    Console.WriteLine(" -{0}- Numaralı ID Zaten Mevcut Bir Board'da Kayıtlı Lütfen Güncelleme İşlemini Kullanın", id);
                }
            }
            else
                Console.WriteLine("Hatalı Bir ID Girdiniz Çıkış Yapılıyor.");

        }

        public void FoundCard(Dictionary<int, TeamMember> dictionary, int id)
        {
            Console.Write(
            "Bulunan Kart Bilgileri:" +
            "\n**************************************" +
            "\n");
            foreach (var item in dictionary)
            {
                if (id == item.Key)
                {
                    Console.Write(
                     "Başlık       :{0}" +
                     "\nİçerik       :{1}" +
                     "\nAtanan Kişi  :{2}" +
                     "\nBüyüklük     :{3}" +
                     "\n-\n", item.Value.Title, item.Value.Content, item.Value.Member, item.Value.Size);
                }
            }
        }
        public void Move(Dictionary<int, TeamMember> dictionary, int id)
        {
            foreach (var item in memberDictionary)
            {
                if (id == item.Key)
                {
                    dictionary.Add(item.Key, new TeamMember(item.Value.Title, item.Value.Content, item.Value.Member, item.Value.Size));
                    break;
                }
            }


        }



        public void WriteALL(Dictionary<int, TeamMember> dictionary)
        {

            foreach (var item in dictionary)
            {
                Console.Write(
                    "Başlık       :{0}" +
                    "\nİçerik       :{1}" +
                    "\nAtanan Kişi  :{2}" +
                    "\nBüyüklük     :{3}" +
                    "\n-\n", item.Value.Title, item.Value.Content, item.Value.Member, item.Value.Size);

            }
        }

        public void getMenu()
        {

            Console.Write(

                "Lütfen yapmak istediğiniz işlemi seçiniz :)" +
                "\n*******************************************" +
                "\n(1) Board Listelemek" +
                "\n(2) Board'a Kart Eklemek" +
                "\n(3) Board'dan Kart Silmek" +
                "\n(4) Kart Taşımak" +
                "\nÇıkmak için herhangi bir tuşa basabilirsiniz" +
                "\n" +
                "\n");
        }
        public void ListBoard()
        {
            Console.WriteLine(
                "TODO Line" +
                "\n************************");
            if (TODO.Count > 0)
            {
                WriteALL(TODO);
            }
            else
                Empty();

            Console.WriteLine(
                "IN PROGRESS Line" +
                "\n************************");

            if (INPROGRESS.Count > 0)
            {
                WriteALL(INPROGRESS);
            }
            else
                Empty();

            Console.WriteLine(
               "DONE Line" +
               "\n************************");
            if (DONE.Count > 0)
            {
                WriteALL(DONE);
            }
            else
                Empty();

            Exit();
        }
        public void AddCard()
        {

            int answer;
            Console.WriteLine(
                "Lütfen Eklemek İstediğiniz Line'ı Seçiniz:" +
                "\n(1) TODO" +
                "\n(2) IN PROGRESS" +
                "\n(3) DONE" +
                "\n");
            answer = int.Parse(Console.ReadLine());
            switch (answer)
            {
                case 1:
                    IdControl(TODO);                  
                    break;

                case 2:
                    IdControl(INPROGRESS);                    
                    break;
                case 3:
                    IdControl(DONE);
                    
                    break;
                default:
                    Console.WriteLine("Hatalı Tuşlama Yaptınız Menüye Geri Dönülüyor");
                    break;
            }
           
        }
        public void DeleteCard()
        {
            int id;
            Console.Write("Lütfen Silmek İstediğiniz Kartın ID Bilgisini Giriniz :");
            id = int.Parse(Console.ReadLine());

            if (TODO.ContainsKey(id) || INPROGRESS.ContainsKey(id) || DONE.ContainsKey(id))
            {
                if (TODO.ContainsKey(id))
                    TODO.Remove(id);
                else if (INPROGRESS.ContainsKey(id))
                    INPROGRESS.Remove(id);
                else
                    DONE.Remove(id);
                Console.WriteLine("Kart Silme işlemi Başarılı :))");
            }
            else
            {
                Console.Write(
                 "Aradığınız krtiterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız:" +
                 "\n*Silme işlemini sonlandırmak için : (1)" +
                 "\n*Yeniden denemek için : (2)" +
                 "\nSeçiminiz  : ");
                int answer = int.Parse(Console.ReadLine());
                if (answer == 2)               
                    DeleteCard();
                else
                    Exit();
            }          
        }

        public void MoveCard()
        {
            int id;
            Console.Write(
                " Öncelikle taşımak istediğiniz kartı seçmeniz gerekiyor." +
                "\nLütfen kart ID bilgisini yazınız :");
            id = int.Parse(Console.ReadLine());

            if (TODO.ContainsKey(id) || INPROGRESS.ContainsKey(id) || DONE.ContainsKey(id))
            {
                if (TODO.ContainsKey(id))
                {
                    FoundCard(TODO, id);
                    TODO.Remove(id);
                }

                else if (INPROGRESS.ContainsKey(id))
                {
                    FoundCard(INPROGRESS, id);
                    INPROGRESS.Remove(id);
                }

                else
                {
                    FoundCard(DONE, id);
                    DONE.Remove(id);
                }

                Console.WriteLine(
                    "Lütfen taşımak istediğiniz Line'ı seçiniz:" +
                    "\n(1) TODO" +
                    "\n(2) IN PROGRESS" +
                    "\n(3) DONE");
                int chosen = int.Parse(Console.ReadLine());
                switch (chosen)
                {
                    case 1:
                        Move(TODO, id);
                        Console.WriteLine("Taşıma İşlemi Başarılı :))");
                        break;
                    case 2:
                        Move(INPROGRESS, id);
                        Console.WriteLine("Taşıma İşlemi Başarılı :))");
                        break;
                    case 3:
                        Move(DONE, id);
                        Console.WriteLine("Taşıma İşlemi Başarılı :))");
                        break;
                    default:
                        Console.WriteLine("Hatalı tuşlama yaptınız çıkış yapılıyor.");
                        break;
                }
            }
            else
            {
                Console.Write(
           "Aradığınız krtiterlere uygun kart board'da bulunamadı. Lütfen bir seçim yapınız:" +
           "\n*Güncelleme işlemini sonlandırmak için : (1)" +
           "\n*Yeniden denemek için : (2)" +
           "\nSeçiminiz  : ");
                int answer = int.Parse(Console.ReadLine());
                if (answer == 2)
                    MoveCard();
                else
                    Exit();
            }
        }
    }
}
