using System;

namespace PROJE_2_Console_ToDo_Uygulaması
{
    class Program
    {
        static void Main(string[] args)
        {

            Operations operation = new Operations();
            operation.getMenu();
            try
            {
                int entry = int.Parse(Console.ReadLine());
                while (operation.Control(entry))
                {

                    switch (entry)
                    {
                        case 1:
                            operation.ListBoard();
                            break;
                        case 2:
                            operation.AddCard();
                            break;
                        case 3:
                            operation.DeleteCard();
                            break;
                        case 4:
                            operation.MoveCard();
                            break;                                                
                    }
                    Console.ReadLine();
                    Console.Clear();
                    operation.getMenu();
                    entry = int.Parse(Console.ReadLine());

                }
            }
            catch (Exception)
            {
                Console.WriteLine("Hatalı Tuşlama Yaptınız Çıkış Yapılıyooor.");
                Console.Read();
                
            }
           
        }
    }
}
