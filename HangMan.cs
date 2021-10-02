using System;
using System.Linq;

namespace HangMan
{
    class Program
    { 
        enum Menu // อีนัมเมนูปกติ 
        {
            PlayGame = 1,
            Exit
        }
        
        static void Main(string[] args)
        {
            PrintHead(1); // ปริ้นทุกอย่างแยกเป็นฟังก์ชั่น 
            PrintMenuList();
            PrintInputMenu();
        }

        static void PrintHead(int menu)
        {
            if (menu == 1)  // อันนี้คงไม่ต้องอธิบาย แต่ถ้าอยากให้ผมอธิบายก็แค่ขกทำฟังก์ชั่นปริ้นเฮดหล่ยอันก็จับอันเดียวหละก็ใส่อีฟเอา
            {
                Console.WriteLine("Welcome to Hangman Game");

                Console.WriteLine("-------------------------");
            }
            
            if (menu == 2)
            {
                Console.WriteLine("Play Game Hangman");
                Console.WriteLine("-------------------------");
            }

            
                                   
        }

        static void PrintMenuList() // ปริ้นโง่ๆเลยครับ
        {
            Console.WriteLine("1. Play game");

            Console.WriteLine("2. Exit");


        }
         
        static void PrintInputMenu() // อินพุทค่าเมนู และแปลงเป็นของอีนัมหละก็เรียกใช้
        {
            Console.Write("Please Select Menu : ");

            Menu menu = (Menu)int.Parse(Console.ReadLine());

            SelectMenu(menu); //ส่งฮอนคูลไป


        }

        static void SelectMenu(Menu menu) // ได้รับฮอนคูล
        {
            if (menu == Menu.PlayGame) // เลือกเมนูตามค่าอีนัมครับผ้ม
            {
                PrintHead(2);
                Random random = new Random(); // ฟงัก์ชั่นแรนด้อมที่อาจารย์กำหนดให้

                string[] Word = new string[] { "Tennis", "Football", "Badminton" }; // อาเรย์คำที่จะใช้เล่น มากกว่า 3 ก็ได้นะจารย์ ชิล

                int RandomResult = random.Next(0, 2); // สุ่มค่าตามอินเดกซ์อาเรย์

                string randomword = Word[RandomResult]; // เรียกอินเดกซ์ของค่าที่สุ่มได้

                string word = randomword.ToLower(); // แปลงเป็นพิมเล็กให้หมด

                int x = word.Length; // ความยาวของคำ

               
                char[] GuessWord = word.ToCharArray(); // แปลงคำที่สุ่มได้เป็นอาเรย์แบบ คา

                int score = 0; // ตั้งไว้ให้เดา หยอกๆครับจารย์ คะแนนที่เดาผิด

                Console.WriteLine(""); // เอิ่ม เว้นให้มันดูสวยเฉยๆ

                char[] Answer = new char[x]; // สร้างอาเรย์อันที่ 2 รองไว้ รอดูต่อไป

                for (int z = 0; z < x; z++) // อ่าใส่ค่าในอาเรย์เป็นขีดตามคำให้หมด
                {
                    Answer[z] = '_'; 

                }

                int win = 0;  // ตั้งไว้ให้งงอีกแล้ว เดะบอกต่อว่าทำอะไรได้ อยากรู้หละซี่ 

                while (score != 6) // อ่ารันเกมปกติถ้าคะแนนตายไม่เท่ากับ 6 ก็รันไปเรื่อยๆ
                {

                    Console.WriteLine("Incorrect Score : {0}", score); // ปริ้นโง่ๆ

                    for (int q = 0; q < Answer.Length; q++) // พิมพ์ขีดตามจำนวนตัวอักษร
                    {
                        Console.Write(Answer[q] + " ");
                    }
                    
                    

                    Console.WriteLine(""); // เอิ่ม เว้นให้มันดูสวยเฉยๆ2

                    Console.Write("Input alphabet : "); // ใส่คำให้เดา

                    char alphabet = char.Parse(Console.ReadLine()); // อ่านค่าที่เดา

                    Console.WriteLine(""); // เอิ่ม เว้นให้มันดูสวยเฉยๆ3

                    /* if (GuessWord.Contains(alphabet))
                     {
                         int wordposition  = Array.IndexOf(GuessWord, alphabet) + 1;
                         Console.WriteLine(wordposition); 
                     } */

                    int i = 0; // ตั้งไว้เป็นเคาเตอร์เพื่อนับอินเดกของอาเรย์ 2

                    int check = 0; // ตั้งไว้ก่อน
                    foreach (char k in GuessWord)  // ฟอร์อีชสำหรับการเดาคำ 
                    {
                        if (k == alphabet) // ถ้าอารฟาเบทมีก็ไป
                        {                         
                            Answer[i] = alphabet; // ถ้ามีตัวอะไรชนก็จะแปลงขีดเป็นตัวอักษรที่ถูก
                            check = 1; // เปลี่ยนเช็คเป็น 0 
                            win++; // อ่ามาแล้วๆ ที่ตั้งไว้โง่ๆตอนแรก เอามาใช้นับว่าคำที่ถูกไปแล้วมีกี่อันยังไงหละ
                            Console.Clear();
                        }
                        i++; // รันอาเรย์ตัวต่อไป
                    }
                    
                    if(check == 0) // ถ้าสมมตุจบฟอร์อีชมาหละไม่เปลี่ยนค่า ก็แสดงว่าอะไร ก็แสดงว่ามันไม่ได้เข้าลูป และหมายความว่าไง มันก็หมายความว่าทายผิดนั้นเองนะพี่น้อง เพิ่มไป 1 คะแนน
                    {
                        score++;
                        Console.Clear();
                    }

               /*     char value = '_';

                    int checkwordpos = Array.IndexOf(Answer, value);

                    if(checkwordpos <= 0) 
                    {                                               
                        Console.WriteLine("You win!!");

                        break;  
                    } */
                    
                    if(win == Answer.Length) // เหมือนที่บอกไปแต้มชนะยังไงหละ ถ้าหมดก็จบ หวะฮ่าฮ่า
                    {
                        Console.WriteLine("Incorrect score : {0} ",score); // ตั้งแต่บรรทัดนี้ไปให้ดูสวยงาม ไม่เชื่อก็ลองไล่ดู ไม่มีไรหละครับ
                        
                        for (int d = 0; d < Answer.Length; d++)
                        {
                            Console.Write(Answer[d] + " ");
                        }
                        Console.WriteLine(" ");

                        Console.WriteLine("You win!!");

                        Console.ReadLine();

                        break;                         // จบลูป
                    }
                }
                if (score == 6) // อันนี้ก็เดามั่วเกิ๊น มีแค่ 3 คำยังผิดอีกเรอะ
                {
                    Console.WriteLine("Game over!");

                    Console.ReadLine();
                }                
            }
            else if (menu == Menu.Exit)  // อีนัมตัวที่สองมีหน้าที่แค่นี้จริงๆ
            {
                Console.WriteLine("Bye! ");
                Environment.Exit(0); // ก็อป stackoverflow มาครับเอามาให้ออกจาก console ปล.กันเพื่อนลอกโค้ดด้วยครับ
            }

            
        }
    }
}
