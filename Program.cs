using System;
using System.Threading;

class program
{
    static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.White;
        Random rnd = new Random();

        string p1 = "[1]";
        string p2 = "[2]";
        string p3 = "[3]";
        string p4 = "[4]";
        string p5 = "[5]";
        string p6 = "[6]";
        string p7 = "[7]";
        string p8 = "[8]";
        string p9 = "[9]";

        int choice_x;
        int choice_o;

        bool with_bot = false;
        bool botvsbot = false;
        bool botx2 = false;
        bool botx2forbot2 = false;
        bool botx3 = false;
        int queue = 1;
        int draw = 0;

        void menu()
        {
            while (true)
            {
                with_bot = false;
                botvsbot = false;
                botx2 = false;
                botx2forbot2 = false;
                botx3 = false;
                queue = 1;
                draw = 0;
                Console.Clear();
                Console.WriteLine("Выберите режим\n\nС другом(1)\nПротив бота(2)\nБот против бота(3)");
                Console.Write("\n--> ");
                try
                {
                    int choice_menu = int.Parse(Console.ReadLine());
                    switch(choice_menu)
                    {
                        case 1:
                            with_bot = false;
                            gameplay();
                            break;
                        case 2:
                            with_bot= true;
                            choice_complexity();
                            break;
                        case 3:
                            botvsbot = true;
                            choice_complexity_bots();
                            break;
                        default:
                            Console.WriteLine("Введите от 1 до 3");
                            continue;
                    }
                }
                catch
                {
                    Console.WriteLine("Введите 1 или 2");
                    Console.ReadLine();
                    continue;
                }
            }
        }

        void choice_complexity()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Выберите сложность бота: \n");
                Console.WriteLine("Легко(1) Бот ставит значения наугад");
                Console.WriteLine("Средне(2) Бот чуть умнее Золо");
                Console.Write("\n--> ");
                try
                {
                    int choice_complex = int.Parse(Console.ReadLine());
                    switch (choice_complex)
                    {
                        case 1:
                            botx2 = false;
                            who_first();
                            break;
                        case 2:
                            botx2 = true;
                            who_first();
                            break;
                        //case 3:
                        //    botx3 = true;
                        //    who_first();
                        //    break;
                        default:
                            Console.WriteLine("Выберите от 1 до 2");
                            Console.ReadLine();
                            continue;
                    }
                }
                catch
                {
                    Console.WriteLine("Выберите от 1 до 3");
                    Console.ReadLine();
                    continue;
                }
            }
        }
        void choice_complexity_bots()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Выберите сложность первого бота: \n");
                Console.WriteLine("Легко(1) Бот ставит значения наугад");
                Console.WriteLine("Средне(2) Бот чуть умнее Золо");
                Console.Write("\n--> ");
                try
                {
                    int choice_complex_bot1 = int.Parse(Console.ReadLine());
                    switch (choice_complex_bot1)
                    {
                        case 1:
                            botx2 = false;
                            break;
                        case 2:
                            botx2 = true;
                            break;
                        //case 3:
                        //    botx3 = true;
                        //    who_first();
                        //    break;
                        default:
                            Console.WriteLine("Выберите от 1 до 2");
                            Console.ReadLine();
                            continue;
                    }
                }
                catch
                {
                    Console.WriteLine("Выберите от 1 до 3");
                    Console.ReadLine();
                    continue;
                }

                Console.Clear();
                Console.WriteLine("Выберите сложность второго бота: \n");
                Console.WriteLine("Легко(1) Бот ставит значения наугад");
                Console.WriteLine("Средне(2) Бот чуть умнее Золо");
                Console.Write("\n--> ");
                try
                {
                    int choice_complex_bot1 = int.Parse(Console.ReadLine());
                    switch (choice_complex_bot1)
                    {
                        case 1:
                            gameplay();
                            break;
                        case 2:
                            botx2forbot2 = true;
                            gameplay();
                            break;
                        //case 3:
                        //    botx3 = true;
                        //    who_first();
                        //    break;
                        default:
                            Console.WriteLine("Выберите от 1 до 2");
                            Console.ReadLine();
                            continue;
                    }
                }
                catch
                {
                    Console.WriteLine("Выберите от 1 до 3");
                    Console.ReadLine();
                    continue;
                }

            }
        }

        void reset_board()
        {
            p1 = "[1]";
            p2 = "[2]";
            p3 = "[3]";
            p4 = "[4]";
            p5 = "[5]";
            p6 = "[6]";
            p7 = "[7]";
            p8 = "[8]";
            p9 = "[9]";
            queue = 1;
            draw = 0;
            botx2 = false;
            botx3 = false;
        }
        void who_first()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Кто ходит первым?");
                Console.WriteLine("\nЯ(1)");
                Console.WriteLine("Бот(2)");
                Console.Write("\n--> ");
                try
                {
                    int first_player = int.Parse(Console.ReadLine());
                    switch (first_player)
                    {
                        case 1:
                            queue = 1;
                            break;
                        case 2:
                            queue = -1;
                            break;
                        default:
                            Console.WriteLine("Введите 1 или 2");
                            Console.ReadLine();
                            continue;
                    }
                }
                catch
                {
                    Console.WriteLine("Введите 1 или 2");
                    Console.ReadLine();
                    continue;
                }
                gameplay();
            }
        }

        void checking_win_X()
        {
            if ((p1 == "[X]" & p2 == "[X]" & p3 == "[X]") || (p4 == "[X]" & p5 == "[X]" & p6 == "[X]") || (p7 == "[X]" & p8 == "[X]" & p9 == "[X]") || (p1 == "[X]" & p4 == "[X]" & p7 == "[X]") || (p2 == "[X]" & p5 == "[X]" & p8 == "[X]") || (p3 == "[X]" & p6 == "[X]" & p9 == "[X]") || (p1 == "[X]" & p5 == "[X]" & p9 == "[X]") || (p3 == "[X]" & p5 == "[X]" & p7 == "[X]"))
            {
                Thread.Sleep(789);
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("Крестики победили!\n");
                    Console.WriteLine($" {p1} {p2} {p3}\n {p4} {p5} {p6}\n {p7} {p8} {p9}");
                    Console.Write("\nВернуться в меню--> ");
                    Console.ReadLine();
                    reset_board();
                    menu();
                }
            }
            draw++;
        }
        void checking_win_O()
        {
            if ((p1 == "[O]" & p2 == "[O]" & p3 == "[O]") || (p4 == "[O]" & p5 == "[O]" & p6 == "[O]") || (p7 == "[O]" & p8 == "[O]" & p9 == "[O]") || (p1 == "[O]" & p4 == "[O]" & p7 == "[O]") || (p2 == "[O]" & p5 == "[O]" & p8 == "[O]") || (p3 == "[O]" & p6 == "[O]" & p9 == "[O]") || (p1 == "[O]" & p5 == "[O]" & p9 == "[O]") || (p3 == "[O]" & p5 == "[O]" & p7 == "[O]"))
            {
                Thread.Sleep(789);
                Console.Clear();
                Console.WriteLine("Нолики победили!\n");
                Console.WriteLine($" {p1} {p2} {p3}\n {p4} {p5} {p6}\n {p7} {p8} {p9}");
                Console.Write("\nВернуться в меню--> ");
                Console.ReadLine();
                reset_board();
                menu();
            }
            draw++;
        }
        void draw_check()
        {
            if(draw == 10)
            {
                Thread.Sleep(789);
                Console.Clear();
                Console.WriteLine("Ничья!\n");
                Console.WriteLine($" {p1} {p2} {p3}\n {p4} {p5} {p6}\n {p7} {p8} {p9}");
                Console.Write("\nВернуться в меню--> ");
                Console.ReadLine();
                reset_board();
                menu();
            }
        }

        void bot_defending(string XorO)
        {
            if (p1 == "[1]")
            {
                if ((p2 == XorO & p3 == XorO) || (p4 == XorO & p7 == XorO) || (p5 == XorO & p9 == XorO))
                {
                    if (XorO == "[O]")
                    {
                        choice_x = 1;
                    }
                    else
                    {
                        choice_o = 1;
                    }
                }
            }

            if (p2 == "[2]")
            {
                if ((p1 == XorO & p3 == XorO) || (p5 == XorO & p8 == XorO))
                {
                    if (XorO == "[O]")
                    {
                        choice_x = 2;
                    }
                    else
                    {
                        choice_o = 2;
                    }
                }
            }

            if (p3 == "[3]")
            {
                if ((p1 == XorO & p2 == XorO) || (p5 == XorO & p7 == XorO) || (p6 == XorO & p9 == XorO))
                {
                    if (XorO == "[O]")
                    {
                        choice_x = 3;
                    }
                    else
                    {
                        choice_o = 3;
                    }
                }
            }

            if (p4 == "[4]")
            {
                if ((p1 == XorO & p7 == XorO) || (p5 == XorO & p6 == XorO))
                {
                    if (XorO == "[O]")
                    {
                        choice_x = 4;
                    }
                    else
                    {
                        choice_o = 4;
                    }
                }
            }

            if (p5 == "[5]")
            {
                if ((p2 == XorO & p8 == XorO) || (p4 == XorO & p6 == XorO) || (p1 == XorO & p9 == XorO) || (p7 == XorO & p3 == XorO))
                {
                    if (XorO == "[O]")
                    {
                        choice_x = 5;
                    }
                    else
                    {
                        choice_o = 5;
                    }
                }
            }

            if (p6 == "[6]")
            {
                if ((p9 == XorO & p3 == XorO) || (p4 == XorO & p5 == XorO))
                {
                    if (XorO == "[O]")
                    {
                        choice_x = 6;
                    }
                    else
                    {
                        choice_o = 6;
                    }
                }
            }

            if (p7 == "[7]")
            {
                if ((p1 == XorO & p4 == XorO) || (p8 == XorO & p9 == XorO) || (p5 == XorO & p3 == XorO))
                {
                    if (XorO == "[O]")
                    {
                        choice_x = 7;
                    }
                    else
                    {
                        choice_o = 7;
                    }
                }
            }

            if (p8 == "[8]")
            {
                if ((p7 == XorO & p9 == XorO) || (p2 == XorO & p5 == XorO))
                {
                    if (XorO == "[O]")
                    {
                        choice_x = 8;
                    }
                    else
                    {
                        choice_o = 8;
                    }
                }
            }

            if (p9 == "[9]")
            {
                if ((p7 == XorO & p8 == XorO) || (p1 == XorO & p5 == XorO) || (p3 == XorO & p6 == XorO))
                {
                    if (XorO == "[O]")
                    {
                        choice_x = 9;
                    }
                    else
                    {
                        choice_o = 9;
                    }
                }
            }
        }
        void bot_attack(string XorO)
        {
            if (p1 == "[1]")
            {
                if ((p2 == XorO & p3 == XorO) || (p4 == XorO & p7 == XorO) || (p5 == XorO & p9 == XorO))
                {
                    if(XorO == "[X]")
                    {
                        choice_x = 1;
                    }
                    else
                    {
                        choice_o = 1;
                    }
                }
            }

            if (p2 == "[2]")
            {
                if ((p1 == XorO & p3 == XorO) || (p5 == XorO & p8 == XorO))
                {
                    if (XorO == "[X]")
                    {
                        choice_x = 2;
                    }
                    else
                    {
                        choice_o = 2;
                    }
                }
            }

            if (p3 == "[3]")
            {
                if ((p1 == XorO & p2 == XorO) || (p5 == XorO & p7 == XorO) || (p6 == XorO & p9 == XorO))
                {
                    if (XorO == "[X]")
                    {
                        choice_x = 3;
                    }
                    else
                    {
                        choice_o = 3;
                    }
                }
            }

            if (p4 == "[4]")
            {
                if ((p1 == XorO & p7 == XorO) || (p5 == XorO & p6 == XorO))
                {
                    if (XorO == "[X]")
                    {
                        choice_x = 4;
                    }
                    else
                    {
                        choice_o = 4;
                    }
                }
            }

            if (p5 == "[5]")
            {
                if ((p2 == XorO & p8 == XorO) || (p4 == XorO & p6 == XorO) || (p1 == XorO & p9 == XorO) || (p7 == XorO & p3 == XorO))
                {
                    if (XorO == "[X]")
                    {
                        choice_x = 5;
                    }
                    else
                    {
                        choice_o = 5;
                    }
                }
            }

            if (p6 == "[6]")
            {
                if ((p9 == XorO & p3 == XorO) || (p4 == XorO & p5 == XorO))
                {
                    if (XorO == "[X]")
                    {
                        choice_x = 6;
                    }
                    else
                    {
                        choice_o = 6;
                    }
                }
            }

            if (p7 == "[7]")
            {
                if ((p1 == XorO & p4 == XorO) || (p8 == XorO & p9 == XorO) || (p5 == XorO & p3 == XorO))
                {
                    if (XorO == "[X]")
                    {
                        choice_x = 7;
                    }
                    else
                    {
                        choice_o = 7;
                    }
                }
            }

            if (p8 == "[8]")
            {
                if ((p7 == XorO & p9 == XorO) || (p2 == XorO & p5 == XorO))
                {
                    if (XorO == "[X]")
                    {
                        choice_x = 8;
                    }
                    else
                    {
                        choice_o = 8;
                    }
                }
            }

            if (p9 == "[9]")
            {
                if ((p7 == XorO & p8 == XorO) || (p1 == XorO & p5 == XorO) || (p3 == XorO & p6 == XorO))
                {
                    if (XorO == "[X]")
                    {
                        choice_x = 9;
                    }
                    else
                    {
                        choice_o = 9;
                    }
                }
            }
        }

        void gameplay()
        {
            if (botvsbot)
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine($" {p1} {p2} {p3}\n {p4} {p5} {p6}\n {p7} {p8} {p9}");
                    checking_win_O();
                    draw_check();
                    Console.Write("\nПервый бот думает куда поставить X");
                    Thread.Sleep(470);
                    Console.Write(".");
                    Thread.Sleep(470);
                    Console.Write(".");
                    Thread.Sleep(470);
                    Console.WriteLine(".\n");
                    while (true)
                    {
                        choice_x = rnd.Next(1, 10);
                        if (botx2)
                        {
                            bot_defending("[O]");
                            bot_attack("[X]");
                        }
                        if (botx3)
                        {

                        }

                        //if(p5 == "[5]")
                        //{
                        //    if ((bot_first_choice & botx2))
                        //    {
                        //        choice_o = 5;
                        //    }
                        //}

                        switch (choice_x)
                        {
                            case 1:
                                if (p1 == "[X]" || p1 == "[O]")
                                {
                                    continue;
                                }
                                p1 = "[X]";
                                break;
                            case 2:
                                if (p2 == "[X]" || p2 == "[O]")
                                {
                                    continue;
                                }
                                p2 = "[X]";
                                break;
                            case 3:
                                if (p3 == "[X]" || p3 == "[O]")
                                {
                                    continue;
                                }
                                p3 = "[X]";
                                break;
                            case 4:
                                if (p4 == "[X]" || p4 == "[O]")
                                {
                                    continue;
                                }
                                p4 = "[X]";
                                break;
                            case 5:
                                if (p5 == "[X]" || p5 == "[O]")
                                {
                                    continue;
                                }
                                p5 = "[X]";
                                break;
                            case 6:
                                if (p6 == "[X]" || p6 == "[O]")
                                {
                                    continue;
                                }
                                p6 = "[X]";
                                break;
                            case 7:
                                if (p7 == "[X]" || p7 == "[O]")
                                {
                                    continue;
                                }
                                p7 = "[X]";
                                break;
                            case 8:
                                if (p8 == "[X]" || p8 == "[O]")
                                {
                                    continue;
                                }
                                p8 = "[X]";
                                break;
                            case 9:
                                if (p9 == "[X]" || p9 == "[O]")
                                {
                                    continue;
                                }
                                p9 = "[X]";
                                break;
                        }
                        queue *= -1;
                        break;
                    }
                    Console.Clear();
                    Console.WriteLine($" {p1} {p2} {p3}\n {p4} {p5} {p6}\n {p7} {p8} {p9}");
                    checking_win_X();
                    draw_check();
                    Console.Write("\nВторой бот думает куда поставить O");
                    Thread.Sleep(470);
                    Console.Write(".");
                    Thread.Sleep(470);
                    Console.Write(".");
                    Thread.Sleep(470);
                    Console.WriteLine(".\n");
                    while (true)
                    {
                        choice_o = rnd.Next(1, 10);
                        if (botx2forbot2)
                        {
                            bot_defending("[X]");
                            bot_attack("[O]");
                        }
                        if (botx3)
                        {

                        }

                        //if(p5 == "[5]")
                        //{
                        //    if ((bot_first_choice & botx2))
                        //    {
                        //        choice_o = 5;
                        //    }
                        //}

                        switch (choice_o)
                        {
                            case 1:
                                if (p1 == "[X]" || p1 == "[O]")
                                {
                                    continue;
                                }
                                p1 = "[O]";
                                break;
                            case 2:
                                if (p2 == "[X]" || p2 == "[O]")
                                {
                                    continue;
                                }
                                p2 = "[O]";
                                break;
                            case 3:
                                if (p3 == "[X]" || p3 == "[O]")
                                {
                                    continue;
                                }
                                p3 = "[O]";
                                break;
                            case 4:
                                if (p4 == "[X]" || p4 == "[O]")
                                {
                                    continue;
                                }
                                p4 = "[O]";
                                break;
                            case 5:
                                if (p5 == "[X]" || p5 == "[O]")
                                {
                                    continue;
                                }
                                p5 = "[O]";
                                break;
                            case 6:
                                if (p6 == "[X]" || p6 == "[O]")
                                {
                                    continue;
                                }
                                p6 = "[O]";
                                break;
                            case 7:
                                if (p7 == "[X]" || p7 == "[O]")
                                {
                                    continue;
                                }
                                p7 = "[O]";
                                break;
                            case 8:
                                if (p8 == "[X]" || p8 == "[O]")
                                {
                                    continue;
                                }
                                p8 = "[O]";
                                break;
                            case 9:
                                if (p9 == "[X]" || p9 == "[O]")
                                {
                                    continue;
                                }
                                p9 = "[O]";
                                break;
                        }
                        queue *= -1;
                        break;
                    }
                }
            }
            while (true)
            {
                while (true)
                {
                    if (queue == 1)
                    {
                        Console.Clear();
                        Console.WriteLine($" {p1} {p2} {p3}\n {p4} {p5} {p6}\n {p7} {p8} {p9}");
                        checking_win_O();
                        draw_check();
                        Console.WriteLine("\nВыберите, куда поставите X\n");
                        Console.Write("--> ");
                        try
                        {
                            choice_x = int.Parse(Console.ReadLine());

                            switch (choice_x)
                            {
                                case 1:
                                    if (p1 == "[X]" || p1 == "[O]")
                                    {
                                        draw--;
                                        Console.WriteLine("Это поле уже занято");
                                        Console.ReadLine();
                                        continue;
                                    }
                                    p1 = "[X]";
                                    break;
                                case 2:
                                    if (p2 == "[X]" || p2 == "[O]")
                                    {
                                        draw--;
                                        Console.WriteLine("Это поле уже занято");
                                        Console.ReadLine();
                                        continue;
                                    }
                                    p2 = "[X]";
                                    break;
                                case 3:
                                    if (p3 == "[X]" || p3 == "[O]")
                                    {
                                        draw--;
                                        Console.WriteLine("Это поле уже занято");
                                        Console.ReadLine();
                                        continue;
                                    }
                                    p3 = "[X]";
                                    break;
                                case 4:
                                    if (p4 == "[X]" || p4 == "[O]")
                                    {
                                        draw--;
                                        Console.WriteLine("Это поле уже занято");
                                        Console.ReadLine();
                                        continue;
                                    }
                                    p4 = "[X]";
                                    break;
                                case 5:
                                    if (p5 == "[X]" || p5 == "[O]")
                                    {
                                        draw--;
                                        Console.WriteLine("Это поле уже занято");
                                        Console.ReadLine();
                                        continue;
                                    }
                                    p5 = "[X]";
                                    break;
                                case 6:
                                    if (p6 == "[X]" || p6 == "[O]")
                                    {
                                        draw--;
                                        Console.WriteLine("Это поле уже занято");
                                        Console.ReadLine();
                                        continue;
                                    }
                                    p6 = "[X]";
                                    break;
                                case 7:
                                    if (p7 == "[X]" || p7 == "[O]")
                                    {
                                        draw--;
                                        Console.WriteLine("Это поле уже занято");
                                        Console.ReadLine();
                                        continue;
                                    }
                                    p7 = "[X]";
                                    break;
                                case 8:
                                    if (p8 == "[X]" || p8 == "[O]")
                                    {
                                        draw--;
                                        Console.WriteLine("Это поле уже занято");
                                        Console.ReadLine();
                                        continue;
                                    }
                                    p8 = "[X]";
                                    break;
                                case 9:
                                    if (p9 == "[X]" || p9 == "[O]")
                                    {
                                        draw--;
                                        Console.WriteLine("Это поле уже занято");
                                        Console.ReadLine();
                                        continue;
                                    }
                                    p9 = "[X]";
                                    break;
                                default:
                                    draw--;
                                    Console.WriteLine("Выберите от 1 до 9");
                                    Console.ReadLine();
                                    continue;
                            }
                            queue *= -1;
                        }
                        catch
                        {
                            draw--;
                            Console.WriteLine("Выберите от 1 до 9");
                            Console.ReadLine();
                            continue;
                        }
                    }
                    break;
                }// player

                if (with_bot)
                {
                    Console.Clear();
                    Console.WriteLine($" {p1} {p2} {p3}\n {p4} {p5} {p6}\n {p7} {p8} {p9}");
                    checking_win_X();
                    draw_check();
                    Console.Write("\nБот думает куда поставить О");
                    Thread.Sleep(470);
                    Console.Write(".");
                    Thread.Sleep(470);
                    Console.Write(".");
                    Thread.Sleep(470);
                    Console.WriteLine(".\n");
                }

                while (true)
                {
                    if (with_bot)
                    {
                        if (queue == -1)
                        {
                            choice_o = rnd.Next(1, 10);
                            if (botx2)
                            {
                                bot_defending("[X]");
                                bot_attack("[O]");
                            }
                            if (botx3)
                            {
                                
                            }

                            //if(p5 == "[5]")
                            //{
                            //    if ((bot_first_choice & botx2))
                            //    {
                            //        choice_o = 5;
                            //    }
                            //}

                            switch (choice_o)
                            {
                                case 1:
                                    if (p1 == "[X]" || p1 == "[O]")
                                    {
                                        continue;
                                    }
                                    p1 = "[O]";
                                    break;
                                case 2:
                                    if (p2 == "[X]" || p2 == "[O]")
                                    {
                                        continue;
                                    }
                                    p2 = "[O]";
                                    break;
                                case 3:
                                    if (p3 == "[X]" || p3 == "[O]")
                                    {
                                        continue;
                                    }
                                    p3 = "[O]";
                                    break;
                                case 4:
                                    if (p4 == "[X]" || p4 == "[O]")
                                    {
                                        continue;
                                    }
                                    p4 = "[O]";
                                    break;
                                case 5:
                                    if (p5 == "[X]" || p5 == "[O]")
                                    {
                                        continue;
                                    }
                                    p5 = "[O]";
                                    break;
                                case 6:
                                    if (p6 == "[X]" || p6 == "[O]")
                                    {
                                        continue;
                                    }
                                    p6 = "[O]";
                                    break;
                                case 7:
                                    if (p7 == "[X]" || p7 == "[O]")
                                    {
                                        continue;
                                    }
                                    p7 = "[O]";
                                    break;
                                case 8:
                                    if (p8 == "[X]" || p8 == "[O]")
                                    {
                                        continue;
                                    }
                                    p8 = "[O]";
                                    break;
                                case 9:
                                    if (p9 == "[X]" || p9 == "[O]")
                                    {
                                        continue;
                                    }
                                    p9 = "[O]";
                                    break;
                            }
                            queue *= -1;
                            break;
                        }
                    }// bot

                    else
                    {
                        if (queue == -1)
                        {
                            Console.Clear();
                            Console.WriteLine($" {p1} {p2} {p3}\n {p4} {p5} {p6}\n {p7} {p8} {p9}");
                            checking_win_X();
                            draw_check();
                            Console.WriteLine("\nВыберите, куда поставите O\n");
                            Console.Write("--> ");
                            try
                            {
                                choice_o = int.Parse(Console.ReadLine());

                                switch (choice_o)
                                {
                                    case 1:
                                        if (p1 == "[X]" || p1 == "[O]")
                                        {
                                            draw--;
                                            Console.WriteLine("Это поле уже занято");
                                            Console.ReadLine();
                                            continue;
                                        }
                                        p1 = "[O]";
                                        break;
                                    case 2:
                                        if (p2 == "[X]" || p2 == "[O]")
                                        {
                                            draw--;
                                            Console.WriteLine("Это поле уже занято");
                                            Console.ReadLine();
                                            continue;
                                        }
                                        p2 = "[O]";
                                        break;
                                    case 3:
                                        if (p3 == "[X]" || p3 == "[O]")
                                        {
                                            draw--;
                                            Console.WriteLine("Это поле уже занято");
                                            Console.ReadLine();
                                            continue;
                                        }
                                        p3 = "[O]";
                                        break;
                                    case 4:
                                        if (p4 == "[X]" || p4 == "[O]")
                                        {
                                            draw--;
                                            Console.WriteLine("Это поле уже занято");
                                            Console.ReadLine();
                                            continue;
                                        }
                                        p4 = "[O]";
                                        break;
                                    case 5:
                                        if (p5 == "[X]" || p5 == "[O]")
                                        {
                                            draw--;
                                            Console.WriteLine("Это поле уже занято");
                                            Console.ReadLine();
                                            continue;
                                        }
                                        p5 = "[O]";
                                        break;
                                    case 6:
                                        if (p6 == "[X]" || p6 == "[O]")
                                        {
                                            draw--;
                                            Console.WriteLine("Это поле уже занято");
                                            Console.ReadLine();
                                            continue;
                                        }
                                        p6 = "[O]";
                                        break;
                                    case 7:
                                        if (p7 == "[X]" || p7 == "[O]")
                                        {
                                            draw--;
                                            Console.WriteLine("Это поле уже занято");
                                            Console.ReadLine();
                                            continue;
                                        }
                                        p7 = "[O]";
                                        break;
                                    case 8:
                                        if (p8 == "[X]" || p8 == "[O]")
                                        {
                                            draw--;
                                            Console.WriteLine("Это поле уже занято");
                                            Console.ReadLine();
                                            continue;
                                        }
                                        p8 = "[O]";
                                        break;
                                    case 9:
                                        if (p9 == "[X]" || p9 == "[O]")
                                        {
                                            draw--;
                                            Console.WriteLine("Это поле уже занято");
                                            Console.ReadLine();
                                            continue;
                                        }
                                        p9 = "[O]";
                                        break;
                                    default:
                                        draw--;
                                        Console.WriteLine("Выберите от 1 до 9");
                                        Console.ReadLine();
                                        continue;
                                }
                                queue *= -1;
                            }
                            catch
                            {
                                draw--;
                                Console.WriteLine("Выберите от 1 до 9");
                                Console.ReadLine();
                                continue;
                            }
                        }
                        break;
                    }// player2
                }// vs bot or player2
            }// пиздилка
        }
        menu();
    }
}
