using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using EZInput;

namespace Game
{
    
    internal class Program
    {
           public static char[,] maze = new char[39, 132] {{"##################################################################################################################### Score:       "},
                      {"#                                                                                                                   #             "},
                      {"#                                                                                                                   #             "},
                      {"#                                                                                                                   #     Health  "},
                      {"#                                               #  ####################                               #             #             "},
                      {"#          #                                    #                              ##########             #             #             "},
                      {"#          #                                    #                                                     #             #             "},
                      {"#          #                                    #                                                     #             #             "},
                      {"#          #                #                   #                                                     #             #             "},
                      {"#          #                #                   #                 #   ######################   #                    #             "},
                      {"#          #                #                   #                 #                            #                    #             "},
                      {"#          #                #                                     #                            #                    #             "},
                      {"#          #                #                                     #                            #                    #             "},
                      {"#          #                #                                     #                            #                    #             "},
                      {"#          #                #   ############                                                                        #             "},
                      {"#          #                                                                                                        #             "},
                      {"#          #                                                                                                        #             "},
                      {"#                                                                                                                   #             "},
                      {"#                                 ####################################                      ###############         #             "},
                      {"#                                                                                                                   #             "},
                      {"#                                                                          #                                        #             "},
                      {"#                                                                          #                                        #             "},
                      {"#            #################  #                                          #                                        #             "},
                      {"#                               #                     ###################  #                   #                    #             "},
                      {"#                               #                                                              #                    #             "},
                      {"#                               #                                                              #                    #             "},
                      {"#                               #                                                              #                    #             "},
                      {"#            #                  #                                                              #                    #             "},
                      {"#            #                  #                                                              #                    #             "},
                      {"#            #                  #                                                              #                    #             "},
                      {"#            #                               ######################                                                 #             "},
                      {"#            #                                                                    #                                 #             "},
                      {"#            #                                                                    #                                 #             "},
                      {"#            #                                                                    #                                 #             "},
                      {"#            #                                                                    #                                 #             "},
                      {"#            #  ##################                     #  ######################  #                                 #             "},
                      {"#                                                      #                                                            #             "},
                      {"#                                                      #                                                            #             "},
                      {"#####################################################################################################################             "}};
       public static char player = (char)153;
   public static char[,] demi_maze=new char[39,132];
   public static int bullet_count = 0;
      public static int px = 0;
     public  static int py = 0;
   public static int health = 0;

        static void Main(string[] args)
        {

            char key;
            string direction_1 = "right";
            string direction_2 = "up";
            string direction_3 = "left";
            int option = 1;
            int health_count = 0;
            int score = 0;
            int x = 0, y = 0;
            int num = 0;
            int count = 0;
            int loop = 0;
            int loop_count = 0;
            int enemy_speed = 0;
            hide_cursor();
            demi();
            Console.Clear() ;
            while (true)
            {

                clear_all();
                header();
                menu(option);
                key = Console.ReadKey().KeyChar;
                if (key == 13)
                {
                    if (option == 1)
                    {
                        Console.Clear();
                        // read_maze(maze);
                        // read_data(direction_1, direction_2, direction_3, health_count, health, score, count, loop, loop_count, num, x, y);
                        full_health();
                        print_maze();
                        while (true)
                        {
                            if (Keyboard.IsKeyPressed(Key.LeftArrow))
                            {
                                move_left();
                            }
                            if (Keyboard.IsKeyPressed(Key.RightArrow))
                            {
                                move_right();
                            }
                            if (Keyboard.IsKeyPressed(Key.UpArrow))
                            {
                                move_up();
                            }
                            if (Keyboard.IsKeyPressed(Key.DownArrow))
                            {
                                move_down();
                            }
                            if (Keyboard.IsKeyPressed(Key.Space))
                            {
                                fire();
                            }
                            if (Keyboard.IsKeyPressed(Key.Escape))
                            {
                                break;
                            }
                            player_coordinates(ref px,ref py);
                            print_score(score);
                            health_variation(ref health_count);
                            move_bullet_up();
                            move_bullet_down();
                            move_bullet_left();
                            move_bullet_right();
                            set_direction_1(ref direction_1);
                            set_direction_2(ref direction_2);
                            set_direction_3(ref direction_3);
                            score_increase(ref score);
                            move_enemy_1(direction_1);
                            move_enemy_2(direction_2);
                            if (enemy_speed == 2)
                            {
                                if (py > 2 && px < 115)
                                    move_enemy_3(direction_3);
                                enemy_speed = 0;
                            }
                            health_bar(ref health, ref health_count);
                            x++;
                            y++;
                            if (x == 39)
                                x = 0;
                            if (y == 115)
                                y = 0;
                            if (num == 0)
                            {
                                if (score % 3 == 0 && score > 0 && loop_count == 0)
                                {
                                    count = 1;
                                    num = 1;
                                }
                            }
                            if (count == 1)
                            {
                                health_pill(x, y);
                                count = 0;
                                loop_count = 1;
                            }
                            if (score % 3 != 0)
                                num = 0;
                            if (loop == 30)
                            {
                                erase_health_pill();
                                loop_count = 0;
                                loop = 0;
                            }
                            if (loop_count == 1)
                                loop++;
                            full_health();
                            enemy_speed++;
                            clear_all();
                            print_maze();
                            collision();
                            if (health == 5)
                            { 
                                Console.Clear();
                                print_maze();
                                Thread.Sleep(1000);
                                Console.Clear();
                                loss();
                                Thread.Sleep(5000);
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                            if (score == 15)
                            {
                                Thread.Sleep(1000);
                                Console.Clear();
                                win();
                                Thread.Sleep(5000);
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                        }
                    }
                    else if (option == 2)
                    {
                        direction_1 = "right";
                        direction_2 = "up";
                        direction_3 = "left";
                        health_count = 0;
                        health = 0;
                        score = 0;
                        count = 0;
                        loop = 0;
                        loop_count = 0;
                        num = 0;
                        x = 0;
                        y = 0;
                        enemy_speed = 0;
                        restart();
                        Console.Clear();
                        print_maze();
                        full_health();
                        print_player();
                        print_enemy_1();
                        print_enemy_2();
                        print_enemy_3();
                        clear_all();
                        print_maze();
                        while (true)
                        {
                            if (Keyboard.IsKeyPressed(Key.LeftArrow))
                            {
                                move_left();
                            }
                            if (Keyboard.IsKeyPressed(Key.RightArrow))
                            {
                                move_right();
                            }
                            if (Keyboard.IsKeyPressed(Key.UpArrow))
                            {
                                move_up();
                            }
                            if (Keyboard.IsKeyPressed(Key.DownArrow))
                            {
                                move_down();
                            }
                            if (Keyboard.IsKeyPressed(Key.Space))
                            {
                                fire();
                            }
                            if (Keyboard.IsKeyPressed(Key.Escape))
                            {
                                break;
                            }
                            player_coordinates(ref px,ref  py);
                            print_score(score);
                            health_variation(ref health_count);
                            move_bullet_up();
                            move_bullet_down();
                            move_bullet_left();
                            move_bullet_right();
                            set_direction_1(ref direction_1);
                            set_direction_2(ref direction_2);
                            set_direction_3(ref direction_3);
                            score_increase(ref score);
                            move_enemy_1(direction_1);
                            move_enemy_2(direction_2);
                            if (enemy_speed == 2)
                            {
                                if (py > 2 && px < 115)
                                    move_enemy_3(direction_3);
                                enemy_speed = 0;
                            }
                            health_bar(ref health,ref health_count);
                            x++;
                            y++;
                            if (x == 39)
                                x = 0;
                            if (y == 115)
                                y = 0;
                            if (num == 0)
                            {
                                if (score % 3 == 0 && score > 0 && loop_count == 0)
                                {
                                    count = 1;
                                    num = 1;
                                }
                            }
                            if (count == 1)
                            {
                                health_pill(ref x,ref y);
                                count = 0;
                                loop_count = 1;
                            }
                            if (score % 3 != 0)
                                num = 0;
                            if (loop == 30)
                            {
                                erase_health_pill();
                                loop_count = 0;
                                loop = 0;
                            }
                            if (loop_count == 1)
                                loop++;
                            full_health();
                            enemy_speed++;
                            clear_all();
                            print_maze();
                            collision();
                            if (health == 5)
                            {
                                Console.Clear();
                                print_maze();
                                Thread.Sleep(1000);
                                Console.Clear();
                                loss();
                                Thread.Sleep(5000);

                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                            if (score == 15)
                            {
                                Thread.Sleep(1000);
                                Console.Clear();
                                win();
                                Thread.Sleep(5000);
                                Console.ReadKey();
                                Console.Clear();
                                break;
                            }
                        }
                    }
                    else if (option == 3)
                    {
                        Console.Clear();
                        header();
                        instructions();
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else if (option == 4)
                    {
                        Console.Clear();
                        break;
                    }
                }
                else if (key == 72 && option > 1)
                {
                    option--;
                }
                else if (key == 80 && option < 4)
                {
                    option++;
                }
            }
        }
        static void header()
        {
            Console.WriteLine("\t\t\t:::::::::: :::    ::: ::::::::::: :::::::::      :::      :::::::: ::::::::::: ::::::::::: ::::::::  ::::    :::" );
            Console.WriteLine("\t\t\t:+:        :+:    :+:     :+:     :+:    :+:   :+: :+:   :+:    :+:    :+:         :+:    :+:    :+: :+:+:   :+:" );
            Console.WriteLine("\t\t\t+:+         +:+  +:+      +:+     +:+    +:+  +:+   +:+  +:+           +:+         +:+    +:+    +:+ :+:+:+  +:+" );
            Console.WriteLine("\t\t\t+#++:++#     +#++:+       +#+     +#++:++#:  +#++:++#++: +#+           +#+         +#+    +#+    +:+ +#+ +:+ +#+" );
            Console.WriteLine("\t\t\t+#+         +#+  +#+      +#+     +#+    +#+ +#+     +#+ +#+           +#+         +#+    +#+    +#+ +#+  +#+#+#" );
            Console.WriteLine("\t\t\t#+#        #+#    #+#     #+#     #+#    #+# #+#     #+# #+#    #+#    #+#         #+#    #+#    #+# #+#   #+#+#" );
            Console.WriteLine("\t\t\t########## ###    ###     ###     ###    ### ###     ###  ########     ###     ########### ########  ###    ####" );
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }
        static void menu(int option)
        {
            Console.WriteLine("\t\t\t\t\t\t 1.Continue              " );
            if (option == 1)
            {   Console.WriteLine("\t\t\t\t\t\t--------------" );
             }
            Console.WriteLine("\t\t\t\t\t\t 2.New Game               " );
            if (option == 2)
            {   Console.WriteLine("\t\t\t\t\t\t--------------" );
             }
            Console.WriteLine("\t\t\t\t\t\t 3.Instructions          " );
            if (option == 3)
            {   Console.WriteLine("\t\t\t\t\t\t--------------" );
             }
            Console.WriteLine("\t\t\t\t\t\t 4.Exit           " );
            if (option == 4)
            {   Console.WriteLine("\t\t\t\t\t\t--------------" );
             }
        }
        static void win()
        {
            Console.WriteLine("" );
            Console.WriteLine("" );
            Console.WriteLine("" );
            Console.WriteLine("" );
            Console.WriteLine("" );
            Console.WriteLine("" );
            Console.WriteLine("\t\t\t\t\t\t\t     )   )                    (       ) " );
            Console.WriteLine("\t\t\t\t\t\t\t  ( /(( /(          (  (      )\\ ) ( /( " );
            Console.WriteLine("\t\t\t\t\t\t\t  )\\())\\())    (    )\\))(   '(()/( )\\())" );
            Console.WriteLine("\t\t\t\t\t\t\t ((_)((_)\\     )\\  ((_)()\\ )  /(_)|(_)\\ " );
            Console.WriteLine("\t\t\t\t\t\t\t__ ((_)((_) _ ((_) _(())\\_)()(_))  _((_)" );
            Console.WriteLine("\t\t\t\t\t\t\t\\ \\ / / _ \\| | | | \\ \\((_)/ /|_ _|| \\| |" );
            Console.WriteLine("\t\t\t\t\t\t\t \\ V / (_) | |_| |  \\ \\/\\/ /  | | | .` |" );
            Console.WriteLine("\t\t\t\t\t\t\t  |_| \\___/ \\___/    \\_/\\_/  |___||_|\\_|" );
        }
        static void loss()
        {
            Console.WriteLine("" );
            Console.WriteLine("" );
            Console.WriteLine("" );
            Console.WriteLine("" );
            Console.WriteLine("" );
            Console.WriteLine("" );
            Console.WriteLine("\t\t\t\t\t:::   :::  ::::::::  :::    :::      :::        ::::::::   ::::::::   :::::::: " );
            Console.WriteLine("\t\t\t\t\t:+:   :+: :+:    :+: :+:    :+:      :+:       :+:    :+: :+:    :+: :+:    :+:" );
            Console.WriteLine("\t\t\t\t\t +:+ +:+  +:+    +:+ +:+    +:+      +:+       +:+    +:+ +:+        +:+       " );
            Console.WriteLine("\t\t\t\t\t  +#++:   +#+    +:+ +#+    +:+      +#+       +#+    +:+ +#++:++#++ +#++:++#++" );
            Console.WriteLine("\t\t\t\t\t   +#+    +#+    +#+ +#+    +#+      +#+       +#+    +#+        +#+        +#+" );
            Console.WriteLine("\t\t\t\t\t   #+#    #+#    #+# #+#    #+#      #+#       #+#    #+# #+#    #+# #+#    #+#" );
            Console.WriteLine("\t\t\t\t\t   ###     ########   ########       ########## ########   ########   ######## " );
        }
        public static void print_maze()
        {
            for (int row = 0; row < 39; row++)
            {
                for (int col = 0; col < 132; col++)
                {
                    Console.WriteLine(maze[row,col]);
                }
                Console.WriteLine();
            }
        }
      public  static  void demi()
        {
            for (int row = 0; row < 39; row++)
            {
                for (int col = 0; col < 132; col++)
                {
                    demi_maze[row,col] = maze[row,col];
                }
                Console.WriteLine();
            }
        }
        static void restart()
        {
            for (int row = 0; row < 39; row++)
            {
                for (int col = 0; col < 132; col++)
                {
                    maze[row,col] = demi_maze[row,col];
                }
                Console.WriteLine();
            }
        }
        static void instructions()
        {
            
            Console.WriteLine("\t\t\t\tInstructions" );
            Console.WriteLine();
            
            Console.WriteLine("\t\t\t\t\t1. ");
           
            Console.WriteLine("'UP' key to move upward." );
            
            Console.WriteLine("\t\t\t\t\t2. ");
           
            Console.WriteLine("'DOWN' key to move downward." );
           
            Console.WriteLine("\t\t\t\t\t3. ");
           
            Console.WriteLine("'RIGHT' key to move forward." );
           
            Console.WriteLine("\t\t\t\t\t4. ");
           
            Console.WriteLine("'LEFT' key to move backward." );
            
            Console.WriteLine("\t\t\t\t\t5. ");
           
            Console.WriteLine("'SPACE'key to generate fire." );
            
            Console.WriteLine("\t\t\t\t\t6. ");
           
            Console.WriteLine("'ESP' key to quit." );
            
            Console.WriteLine("\t\t\t\t\t7. ");
           
            Console.WriteLine(" One enemy is chasing enemy." );
            
            Console.WriteLine("\t\t\t\t\t8. ");
           
            Console.WriteLine(" One enemy with vertical movement." );
            
            Console.WriteLine("\t\t\t\t\t9. ");
           
            Console.WriteLine(" One enemy with horizontal movement." );
            
            Console.WriteLine("\t\t\t\t\t10.");
           
           Console.WriteLine("One health pill for short time interval." );
            
            Console.WriteLine("\t\t\t\t\t11.");
           
            Console.WriteLine("Two enemies generate fire when player comes in front of thwm." );
            
            Console.WriteLine("\t\t\t\t\t12.");
           
            Console.WriteLine(" To win, you must score 15." );
            
            Console.WriteLine("\t\t\t\t\t13.");
           
            Console.WriteLine("You will loss if health is zero or chased by enenmy." );
            Console.WriteLine();
            
            Console.WriteLine("\t\t\t\t\tPress any key to continue..." );
           
        }

        static void print_player()
        {
            maze[36,1] = 153;
            maze[37,1] = 206;
            maze[37,2] = '>';
        }
        static void print_enemy_1()
        {
            maze[1,1] = 233;
            maze[2,1] = 206;
        }
        static void print_enemy_2()
        {
            maze[36,115] = 233;
            maze[37,115] = 206;
        }
        static void print_enemy_3()
        {
            maze[20,65] = 232;
            maze[21,65] = 215;
        }

        static void move_left()
        {
            char a = (char)235;
            for (int row = 0; row < 39; row++)
            {
                for (int col = 0; col < 132; col++)
                {
                    if (maze[row,col] == player)
                    {
                        if (maze[row,col - 1] == a)
                        {
                            maze[row,col - 1] = ' ';
                            health--;
                        }
                        if (maze[row + 1,col - 1] == a)
                        {
                            maze[row + 1,col - 1] = ' ';
                            health--;
                        }
                    }
                    if (maze[row,col] == player && maze[row,col - 1] == ' ' && (maze[row + 1,col - 1] == ' ' || (maze[row + 1,col - 1] == '<' && maze[row + 1,col - 2] == ' ')))
                    {
                        if (maze[row + 1,col - 1] != '<')
                        {
                            maze[row,col] = 153;
                            maze[row + 1,col] = 206;
                            maze[row + 1,col - 1] = '<';
                            if (maze[row + 1,col + 1] == '>')
                            {
                                maze[row + 1,col + 1] = ' ';
                            }
                            else if (maze[row - 1,col] == '^')
                                maze[row - 1,col] = ' ';
                        }
                        else
                        {
                            maze[row,col - 1] = 153;
                            maze[row + 1,col - 1] = 206;
                            maze[row + 1,col - 2] = '<';
                            maze[row,col] = ' ';
                            maze[row + 1,col] = ' ';
                            if (maze[row + 1,col + 1] == '>')
                            {
                                maze[row + 1,col + 1] = ' ';
                            }
                            else if (maze[row - 1,col] == '^')
                                maze[row - 1,col] = ' ';
                        }
                    }
                    else if (maze[row,col] == player && maze[row,col - 1] == ' ' && (maze[row + 1,col - 1] == ' ' || (maze[row + 1,col - 1] == '<' && maze[row + 1,col - 2] == ' ')))
                    {
                        if (maze[row + 1,col - 1] != '<')
                        {
                            maze[row,col] = 153;
                            maze[row + 1,col] = 206;
                            maze[row + 1,col - 1] = '<';
                            if (maze[row + 1,col + 1] == '>')
                            {
                                maze[row + 1,col + 1] = ' ';
                            }
                            else if (maze[row - 1,col] == '^')
                                maze[row - 1,col] = ' ';
                        }
                    }
                    else if (maze[row + 1,col - 1] == '<' && maze[row + 1,col - 2] == '#')
                    {
                        maze[row,col - 1] = 153;
                        maze[row + 1,col - 1] = 206;
                        maze[row + 1,col] = ' ';
                        maze[row,col] = ' ';
                    }
                }
            }
        }
        static void move_right()
        {
            char a = (char)235;
            for (int row = 0; row < 39; row++)
            {
                for (int col = 0; col < 132; col++)
                {
                    if (maze[row,col] == player)
                    {
                        if (maze[row,col + 1] == a)
                        {
                            maze[row,col + 1] = ' ';
                            health--;
                        }
                        if (maze[row + 1,col + 1] == a)
                        {
                            maze[row + 1,col + 1] = ' ';
                            health--;
                        }
                    }
                    if (maze[row,col] == player && maze[row,col + 1] == ' ' && (maze[row + 1,col + 1] == ' ' || (maze[row + 1,col + 1] == '>' && maze[row + 1,col + 2] == ' ')))
                    {
                        if (maze[row + 1,col + 1] != '>')
                        {
                            maze[row,col] = 153;
                            maze[row + 1,col] = 206;
                            maze[row + 1,col + 1] = '>';
                            if (maze[row + 1,col - 1] == '<')
                            {
                                maze[row + 1,col - 1] = ' ';
                            }
                            else if (maze[row - 1,col] == '^')
                                maze[row - 1,col] = ' ';

                            break;
                        }
                        else
                        {
                            maze[row,col + 1] = 153;
                            maze[row + 1,col + 1] = 206;
                            maze[row + 1,col + 2] = '>';
                            maze[row,col] = ' ';
                            maze[row + 1,col] = ' ';
                            if (maze[row + 1,col - 1] == '<')
                            {
                                maze[row + 1,col - 1] = ' ';
                            }
                            else if (maze[row - 1,col] == '^')
                                maze[row - 1,col] = ' ';
                            break;
                        }
                    }
                    else if (maze[row + 1,col + 1] == '>' && maze[row + 1,col + 2] == '#')
                    {
                        maze[row,col + 1] = 153;
                        maze[row + 1,col + 1] = 206;
                        maze[row + 1,col] = ' ';
                        maze[row,col] = ' ';
                    }
                }
            }
        }
        static void move_up()
        {
            char a = (char)235;
            for (int row = 0; row < 39; row++)
            {
                for (int col = 0; col < 132; col++)
                {
                    if (maze[row,col] == player)
                    {
                        if (maze[row - 1,col] == a)
                        {
                            maze[row - 1,col] = ' ';
                            health--;
                        }
                    }
                    if (maze[row,col] == player && (maze[row - 1,col] == ' ' || (maze[row - 1,col] == '^' && maze[row - 2,col] == ' ')))
                    {
                        if (maze[row - 1,col] != '^')
                        {
                            maze[row,col] = 153;
                            maze[row + 1,col] = 206;
                            maze[row - 1,col] = '^';
                            if (maze[row + 1,col + 1] == '>')
                            {
                                maze[row + 1,col + 1] = ' ';
                            }
                            else if (maze[row + 1,col - 1] == '<')
                                maze[row + 1,col - 1] = ' ';
                        }
                        else
                        {
                            maze[row - 1,col] = 153;
                            maze[row,col] = 206;
                            maze[row - 2,col] = '^';
                            maze[row + 1,col] = ' ';
                            if (maze[row + 1,col + 1] == '>')
                            {
                                maze[row + 1,col + 1] = ' ';
                            }
                            else if (maze[row + 1,col - 1] == '<')
                                maze[row + 1,col - 1] = ' ';
                        }
                    }
                    else if (maze[row - 1,col] == '^' && maze[row - 2,col] == '#')
                    {
                        maze[row - 1,col] = 153;
                        maze[row,col] = 206;
                        maze[row + 1,col] = ' ';
                    }
                }
            }
        }
        static void move_down()
        {
            char a = (char)235;
            for (int row = 0; row < 39; row++)
            {
                for (int col = 0; col < 132; col++)
                {
                    if (maze[row,col] == player)
                    {
                        if (maze[row + 2,col] == a)
                        {
                            maze[row + 2,col] = ' ';
                            health--;
                        }
                    }
                    if (maze[row,col] == player && maze[row + 2,col] == ' ')
                    {
                        if (maze[row + 1,col + 1] == '>')
                            maze[row + 1,col + 1] = ' ';
                        else if (maze[row + 1,col - 1] == '<')
                            maze[row + 1,col - 1] = ' ';
                        else if (maze[row - 1,col] == '^')
                            maze[row - 1,col] = ' ';
                        else
                        {
                            maze[row + 1,col] = 153;
                            maze[row + 2,col] = 206;
                            maze[row,col] = ' ';
                            return;
                        }
                    }
                }
            }
        }

        static void set_direction_1( ref string direction)
        {
            char a = 233;
            for (int row = 0; row < 2; row++)
            {
                for (int col = 0; col < 132; col++)
                {
                    if (maze[row,col] == a && maze[row,col + 1] == '#')
                    {
                        direction = "left";
                    }
                    else if (maze[row,col] == a && maze[row,col - 1] == '#')
                    {
                        direction = "right";
                    }
                }
            }
        }
        static void move_enemy_1(string direction)
        {
            char a = (char)233;
            char c = (char)153;
            char b = (char)206;
            char down = 'o';
            char left = (char)174;
            char right = (char)175;
            if (direction == "left")
            {
                for (int row = 0; row < 2; row++)
                {
                    for (int col = 0; col < 132; col++)
                    {
                        if (maze[row,col] == a && maze[row,col - 1] != '#')
                        {
                            if (bullet_count == 3)
                                bullet_count = 0;
                            bullet_count++;
                            if (px == col)
                            {
                                bullet_count = 0;
                                if (maze[row + 2,col] == ' ')
                                    maze[row + 2,col] = down;
                            }
                            if ((py == row + 1 || py == row) && px < col && bullet_count == 3)
                            {
                                bullet_count = 0;
                                if (maze[row + 1,col - 4] == ' ')
                                    maze[row + 1,col - 4] = left;
                            }
                            if ((py == row + 1 || py == row) && px > col && bullet_count == 3)
                            {
                                bullet_count = 0;
                                if (maze[row + 1,col + 1] == ' ')
                                    maze[row + 1,col + 1] = right;
                            }
                            if (maze[row,col - 1] == c || maze[row,col - 1] == '<' || maze[row,col - 1] == '>' || maze[row,col - 1] == '^' || maze[row + 1,col - 1] == c || maze[row + 1,col - 1] == '<' || maze[row + 1,col - 1] == '>' || maze[row + 1,col - 1] == '^')
                                health = 5;
                            maze[row,col - 1] = 233;
                            maze[row + 1,col - 1] = 206;
                            maze[row + 1,col] = ' ';
                            maze[row,col] = ' ';
                        }
                    }
                }
            }
            else if (direction == "right")
            {
                for (int row = 0; row < 2; row++)
                {
                    for (int col = 0; col < 132; col++)
                    {
                        if (maze[row,col] == a && maze[row,col + 1] != '#')
                        {
                            if (bullet_count == 3)
                                bullet_count = 0;
                            bullet_count++;
                            if (px == col)
                            {
                                bullet_count = 0;
                                if (maze[row + 2,col] == ' ')
                                    maze[row + 2,col] = down;
                            }
                            if ((py == row + 1 || py == row) && px < col && bullet_count == 3)
                            {
                                bullet_count = 0;
                                if (maze[row + 1,col - 1] == ' ')
                                    maze[row + 1,col - 1] = left;
                            }
                            if ((py == row + 1 || py == row) && px > col && bullet_count == 3)
                            {
                                bullet_count = 0;
                                if (maze[row + 1,col + 4] == ' ')
                                    maze[row + 1,col + 4] = right;
                            }
                            if (maze[row,col + 1] == c || maze[row,col + 1] == '<' || maze[row,col + 1] == '>' || maze[row,col + 1] == '^' || maze[row + 1,col + 1] == c || maze[row + 1,col + 1] == '<' || maze[row + 1,col + 1] == '>' || maze[row + 1,col + 1] == '^')
                                health = 5;
                            maze[row,col + 1] = 233;
                            maze[row + 1,col + 1] = 206;
                            maze[row,col] = ' ';
                            maze[row + 1,col] = ' ';

                            break;
                        }
                    }
                }
            }
        }

        static void set_direction_2(ref string direction)
        {
            char a = (char)233;
            for (int row = 0; row < 39; row++)
            {
                for (int col = 0; col < 132; col++)
                {
                    if (maze[row,col] == a && maze[row - 4,col] == '#')
                    {
                        direction = "down";
                    }
                    else if (maze[row,col] == a && maze[row + 2,col] == '#')
                    {
                        direction = "up";
                    }
                }
            }
        }
        static void move_enemy_2(string direction)
        {
            char a = (char)233;
            char b = (char)153;
            char c = (char)206;
            char up = (char)239;
            char down = 'o';
            char left = (char)174;
            char right = (char)175;
            if (direction == "up")
            {
                for (int row = 4; row < 39; row++)
                {
                    for (int col = 0; col < 132; col++)
                    {
                        if (maze[row,col] == a && maze[row - 1,col] != '#')
                        {
                            if (bullet_count == 3)
                                bullet_count = 0;
                            bullet_count++;
                            if (px == col && py > row && bullet_count == 3)
                            {
                                bullet_count = 0;
                                if (maze[row + 2,col] == ' ')
                                    maze[row + 2,col] = down;
                            }
                            if ((px == col && py < row) && bullet_count == 3)
                            {
                                bullet_count = 0;
                                if (maze[row - 2,col] == ' ')
                                    maze[row - 2,col] = up;
                            }
                            if ((py == row + 1 || py == row || py == row - 1) && bullet_count == 3)
                            {
                                bullet_count = 0;
                                if (maze[row + 1,col - 1] == ' ')
                                    maze[row + 1,col - 1] = left;
                            }
                            if (maze[row - 1,col] == c || maze[row - 1,col] == '>')
                                health = 5;
                            maze[row - 1,col] = 233;
                            maze[row,col] = 206;
                            maze[row + 1,col] = ' ';
                        }
                    }
                }
            }
            else if (direction == "down")
            {
                for (int row = 4; row < 39; row++)
                {
                    for (int col = 0; col < 132; col++)
                    {
                        if (maze[row,col] == a && maze[row + 2,col] != '#')
                        {
                            if (bullet_count == 3)
                                bullet_count = 0;
                            bullet_count++;
                            if (px == col && py > row && bullet_count == 3)
                            {
                                bullet_count = 0;
                                if (maze[row + 2,col] == ' ')
                                    maze[row + 2,col] = down;
                            }
                            if ((px == col && py < row) && bullet_count == 3)
                            {
                                bullet_count = 0;
                                if (maze[row - 2,col] == ' ')
                                    maze[row - 2,col] = up;
                            }
                            if ((py == row + 1 || py == row || py == row - 1) && bullet_count == 3)
                            {
                                bullet_count = 0;
                                if (maze[row + 1,col - 1] == ' ')
                                    maze[row + 1,col - 1] = left;
                            }
                            if (maze[row + 2,col] == b || maze[row + 2,col] == '^' || maze[row + 2,col] == '>')
                                health = 5;
                            maze[row + 1,col] = 233;
                            maze[row + 2,col] = 206;
                            maze[row,col] = ' ';
                            return;
                        }
                    }
                }
            }
        }

        static void set_direction_3(ref string direction)
        {
            char a = (char)232;
            for (int row = 0; row < 39; row++)
            {
                for (int col = 0; col < 132; col++)
                {
                    if (maze[row,col] == a)
                    {
                        if (px < col && maze[row,col - 1] == ' ' && maze[row + 1,col - 1] == ' ')
                            direction = "left";
                        else if (px > col && maze[row,col + 1] == ' ' && maze[row + 1,col + 1] == ' ')
                            direction = "right";
                        else if (py < row && maze[row - 1,col] == ' ')
                            direction = "up";
                        else if (py > row && maze[row + 2,col] == ' ')
                            direction = "down";
                    }
                }
            }
        }
        static void move_enemy_3(string direction)
        {
            if (direction == "left")
            {
                move_enemy_left();
            }
            if (direction == "right")
            {
                move_enemy_right();
            }
            if (direction == "up")
            {
                move_enemy_up();
            }
            if (direction == "down")
            {
                move_enemy_down();
            }
        }

        static void move_enemy_left()
        {
            char a = (char)232;
            char b = (char)153;
            char c = (char)206;
            char left = (char)174;
            for (int row = 0; row < 39; row++)
            {
                for (int col = 0; col < 132; col++)
                {
                    if (maze[row,col] == a)
                    {
                        if (maze[row + 1,col - 1] != '#' && maze[row,col - 1] != '#')
                        {
                            if (maze[row,col - 1] == b || maze[row,col - 1] == c || maze[row,col - 1] == '^' || maze[row,col - 1] == '<' || maze[row,col - 1] == '>' || maze[row + 1,col - 1] == b || maze[row + 1,col - 1] == c || maze[row + 1,col - 1] == '^' || maze[row + 1,col - 1] == '<' || maze[row + 1,col - 1] == '>')
                                health = 5;
                            maze[row,col - 1] = 232;
                            maze[row + 1,col - 1] = 215;
                            maze[row + 1,col] = ' ';
                            maze[row,col] = ' ';
                        }
                    }
                }
            }
        }
        static void move_enemy_right()
        {
            char a = (char)232;
            char b = (char)153;
            char c = (char)206;
            char right = (char)175;
            for (int row = 0; row < 39; row++)
            {
                for (int col = 0; col < 132; col++)
                {
                    if (maze[row,col] == a)
                    {
                        if (maze[row + 1,col + 1] != '#' && maze[row,col + 1] != '#')
                        {
                            if (maze[row,col + 1] == b || maze[row,col + 1] == c || maze[row,col + 1] == '^' || maze[row,col + 1] == '<' || maze[row,col + 1] == '>' || maze[row + 1,col + 1] == b || maze[row + 1,col + 1] == c || maze[row + 1,col + 1] == '^' || maze[row + 1,col + 1] == '<' || maze[row + 1,col + 1] == '>')
                                health = 5;
                            maze[row,col + 1] = 232;
                            maze[row + 1,col + 1] = 215;
                            maze[row + 1,col] = ' ';
                            maze[row,col] = ' ';
                            return;
                        }
                    }
                }
            }
        }
        static void move_enemy_up()
        {
            char a = (char)232;
            char b = (char)153;
            char c = (char)206;
            char up = (char)239;
            for (int row = 0; row < 39; row++)
            {
                for (int col = 0; col < 132; col++)
                {
                    if (maze[row,col] == a)
                    {
                        if (maze[row - 1,col] != '#')
                        {
                            if (maze[row - 1,col] == c || maze[row - 1,col] == '>' || maze[row - 1,col] == '<')
                                health = 5;
                            maze[row - 1,col] = 232;
                            maze[row,col] = 215;
                            maze[row + 1,col] = ' ';
                        }
                    }
                }
            }
        }
        static void move_enemy_down()
        {
            char a = (char)232;
            char b = (char)153;
            char c = (char)206;
            char down = '0';
            for (int row = 0; row < 39; row++)
            {
                for (int col = 0; col < 132; col++)
                {
                    if (maze[row,col] == a)
                    {
                        if (maze[row + 2,col] != '#')
                        {
                            if (maze[row + 2,col] == b || maze[row + 2,col] == '^' || maze[row + 2,col] == '>' || maze[row + 2,col] == '<')
                                health = 5;
                            maze[row + 1,col] = 232;
                            maze[row + 2,col] = 215;
                            maze[row,col] = ' ';
                            return;
                        }
                    }
                }
            }
        }

        static void health_pill(ref int x,ref int y)
        {
            char a = (char)235;
            while (true)
            {
                if (maze[x,y] != ' ')
                    x++;
                if (maze[x,y] != ' ')
                    y++;
                if (maze[x,y] == ' ')
                {
                    maze[x,y] = a;
                    x = 0;
                    y = 0;
                    Console.ReadKey();
                    break;
                }
            }
        }
        static void erase_health_pill()
        {
            char a = (char)235;
            for (int row = 0; row < 39; row++)
            {
                for (int col = 0; col < 132; col++)
                {
                    if (maze[row,col] == a)
                        maze[row,col] = ' ';
                }
            }
        }

        static void fire()
        {
            char a = (char)153;
            char up = (char)239;
            char down = 'o';
            char left = (char)174;
            char right = (char)175;
            for (int row = 0; row < 39; row++)
            {
                for (int col = 0; col < 132; col++)
                {
                    if (maze[row,col] == '^' && maze[row - 1,col] == ' ')
                    {
                        maze[row - 1,col] = up;
                        return;
                    }
                    if (maze[row,col] == '>' && maze[row,col + 1] == ' ')
                    {
                        maze[row,col + 1] = right;
                        return;
                    }
                    if (maze[row,col] == '<' && maze[row,col - 1] == ' ')
                    {
                        maze[row,col - 1] = left;
                        return;
                    }
                }
            }
            for (int row = 0; row < 39; row++)
            {
                for (int col = 0; col < 132; col++)
                {
                    if (maze[row,col] == a && maze[row + 2,col] == ' ' && maze[row - 1,col] != '^' && maze[row + 1,col + 1] != '>' && maze[row + 1,col - 1] != '<')
                    {
                        maze[row + 2,col] = down;
                        return;
                    }
                }
            }
        }
        static void move_bullet_up()
        {
            char up = (char)239;
            for (int row = 0; row < 39; row++)
            {
                for (int col = 0; col < 132; col++)
                {
                    if (maze[row,col] == up && maze[row - 1,col] == ' ')
                    {
                        maze[row - 1,col] = up;
                        maze[row,col] = ' ';
                    }
                    else if (maze[row,col] == up && maze[row - 1,col] != ' ')
                    {
                        maze[row,col] = ' ';
                    }
                }
            }
        }
        static void move_bullet_down()
        {
            char down = 'o';
            for (int row = 39; row >= 0; row--)
            {
                for (int col = 0; col < 118; col++)
                {
                    if (maze[row,col] == down && maze[row + 1,col] == ' ')
                    {
                        maze[row + 1,col] = down;
                        maze[row,col] = ' ';
                    }
                    else if (maze[row,col] == down && maze[row + 1,col] != ' ')
                    {
                        maze[row,col] = ' ';
                    }
                }
            }
        }
        static void move_bullet_left()
        {
            char left = (char)174;
            for (int row = 0; row < 39; row++)
            {
                for (int col = 0; col < 132; col++)
                {
                    if (maze[row,col] == left && maze[row,col - 1] == ' ')
                    {
                        maze[row,col - 1] = left;
                        maze[row,col] = ' ';
                    }
                    else if (maze[row,col] == left && maze[row,col - 1] != ' ')
                    {
                        maze[row,col] = ' ';
                    }
                }
            }
        }
        static void move_bullet_right()
        {
            char right = (char)175;
            for (int row = 0; row < 39; row++)
            {
                for (int col = 132; col >= 0; col--)
                {
                    if (maze[row,col] == right && maze[row,col + 1] == ' ')
                    {
                        maze[row,col + 1] = right;
                        maze[row,col] = ' ';
                    }
                    else if (maze[row,col] == right && maze[row,col + 1] != ' ')
                    {
                        maze[row,col] = ' ';
                    }
                }
            }
        }

        static void health_bar(ref int health,ref int health_count)
        {
            if (health_count == 2)
            {
                health_count = 0;
                health++;
                int b = (health * 3);
                for (int i = 0; i < b; i++)
                {
                    if (i == 0)
                        i = 1;
                    maze[2,132 - i] = ' ';
                }
            }
        }
        static void full_health()
        {
            char a = (char)223;
            for (int i = 0; i < ((5 - health) * 3) - 1; i++)
                maze[2,118 + i] = a;
        }
        static void health_variation(ref int health_count)
        {
            char a = (char)153;
            char up = (char)239;
            char down = 'o';
            char left =(char) 174;
            char right = (char)175;
            for (int row = 0; row < 39; row++)
            {
                for (int col = 0; col < 132; col++)
                {
                    if (maze[row,col] == a)
                    {
                        if (maze[row - 2,col] == down || maze[row + 2,col] == up || maze[row,col - 1] == right || maze[row + 1,col - 2] == right || maze[row,col + 1] == left || maze[row + 1,col + 2] == left)
                            health_count++;
                    }
                }
            }
        }

        static void print_score(int score)
        {
            string a = score.ToString();
            for (int row = 0; row < 39; row++)
            {
                for (int col = 0; col < 132; col++)
                {
                    if (maze[row,col] == ':')
                    {
                        maze[row,col + 1] = a[0];
                        maze[row,col + 2] = a[1];
                    }
                }
            }
        }
        static void score_increase(ref int score)
        {
            char a = (char)233;
            char b = (char)232;
            char up = (char)239;
            char down = 'o';
            char left = (char)174;
            char right = (char)175;
            for (int row = 0; row < 39; row++)
            {
                for (int col = 0; col < 132; col++)
                {
                    if (maze[row,col] == a)
                    {
                        if (maze[row - 1,col] == down || maze[row + 2,col] == up || maze[row,col - 1] == right || maze[row + 1,col - 1] == right || maze[row,col + 1] == left || maze[row + 1,col + 1] == left)
                        {
                            score++;
                        }
                    }
                    if (maze[row,col] == b)
                    {
                        if (maze[row - 1,col] == down || maze[row + 2,col] == up || maze[row,col - 1] == right || maze[row + 1,col - 1] == right || maze[row,col + 1] == left || maze[row + 1,col + 1] == left)
                        {
                            score++;
                        }
                    }
                }
            }
        }

        static void collision()
        {
            char up = (char)239;
            char down = 'o';
            char left = (char)174;
            char right = (char)175;
            for (int row = 0; row < 39; row++)
            {
                for (int col = 0; col < 118; col++)
                {
                    if (maze[row,col] == up)
                    {
                        if (maze[row - 1,col] == down)
                        {
                            maze[row - 1,col] = ' ';
                            maze[row,col] = ' ';
                        }
                        if (maze[row - 1,col + 1] == left)
                        {
                            maze[row - 1,col + 1] = ' ';
                            maze[row,col] = ' ';
                        }
                        if (maze[row - 1,col - 1] == right)
                        {
                            maze[row - 1,col - 1] = ' ';
                            maze[row,col] = ' ';
                        }
                        if (maze[row - 2,col] == down)
                        {
                            maze[row - 2,col] = ' ';
                            maze[row,col] = ' ';
                        }
                        if (maze[row - 2,col + 2] == left)
                        {
                            maze[row - 2,col + 2] = ' ';
                            maze[row,col] = ' ';
                        }
                        if (maze[row - 2,col - 2] == right)
                        {
                            maze[row - 2,col - 2] = ' ';
                            maze[row,col] = ' ';
                        }
                        break;
                    }
                    else if (maze[row,col] == down)
                    {
                        if (maze[row + 1,col] == up)
                        {
                            maze[row + 1,col] = ' ';
                            maze[row,col] = ' ';
                        }
                        if (maze[row + 1,col + 1] == left)
                        {
                            maze[row + 1,col + 1] = ' ';
                            maze[row,col] = ' ';
                        }
                        if (maze[row + 1,col - 1] == right)
                        {
                            maze[row + 1,col - 1] = ' ';
                            maze[row,col] = ' ';
                        }
                        if (maze[row + 2,col] == up)
                        {
                            maze[row + 2,col] = ' ';
                            maze[row,col] = ' ';
                        }
                        if (maze[row + 2,col + 2] == left)
                        {
                            maze[row + 2,col + 2] = ' ';
                            maze[row,col] = ' ';
                        }
                        if (maze[row + 2,col - 2] == right)
                        {
                            maze[row + 2,col - 2] = ' ';
                            maze[row,col] = ' ';
                        }
                        break;
                    }
                    else if (maze[row,col] == left)
                    {
                        if (maze[row,col - 1] == right)
                        {
                            maze[row,col - 1] = ' ';
                            maze[row,col] = ' ';
                        }
                        if (maze[row + 1,col - 1] == up)
                        {
                            maze[row + 1,col - 1] = ' ';
                            maze[row,col] = ' ';
                        }
                        if (maze[row - 1,col - 1] == down)
                        {
                            maze[row - 1,col - 1] = ' ';
                            maze[row,col] = ' ';
                        }
                        if (maze[row,col - 2] == right)
                        {
                            maze[row,col - 2] = ' ';
                            maze[row,col] = ' ';
                        }
                        if (maze[row + 2,col - 2] == up)
                        {
                            maze[row + 2,col - 2] = ' ';
                            maze[row,col] = ' ';
                        }
                        if (maze[row - 2,col - 2] == down)
                        {
                            maze[row - 2,col - 2] = ' ';
                            maze[row,col] = ' ';
                        }
                        break;
                    }
                    else if (maze[row,col] == right)
                    {
                        if (maze[row,col + 1] == left)
                        {
                            maze[row,col + 1] = ' ';
                            maze[row,col] = ' ';
                        }
                        if (maze[row + 1,col + 1] == up)
                        {
                            maze[row + 1,col + 1] = ' ';
                            maze[row,col] = ' ';
                        }
                        if (maze[row - 1,col + 1] == down)
                        {
                            maze[row - 1,col + 1] = ' ';
                            maze[row,col] = ' ';
                        }
                        if (maze[row,col + 2] == left)
                        {
                            maze[row,col + 2] = ' ';
                            maze[row,col] = ' ';
                        }
                        if (maze[row + 2,col + 2] == up)
                        {
                            maze[row + 2,col + 2] = ' ';
                            maze[row,col] = ' ';
                        }
                        if (maze[row - 2,col + 2] == down)
                        {
                            maze[row - 2,col + 2] = ' ';
                            maze[row,col] = ' ';
                        }
                        break;
                    }
                }
            }
        }

        static void player_coordinates(ref int px,ref int py)
        {
            char p = (char)153;
            for (int row = 0; row < 39; row++)
            {
                for (int col = 0; col < 132; col++)
                {
                    if (maze[row,col] == p)
                    {
                        px = col;
                        py = row;
                    }
                }
            }
        }
        static void hide_cursor()
        {
            Console.CursorVisible = false;
        }
        static extern IntPtr GetStdHandle(int nStdHandle);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool SetConsoleCursorPosition(IntPtr hConsoleOutput, COORD cursorPosition);

      
        [StructLayout(LayoutKind.Sequential)]
        public struct COORD
        {
            public short X;
            public short Y;
        }
        static void clear_all()
        {
            IntPtr hConsole = GetStdHandle(-11);
            COORD cursorPos;
            cursorPos.X = 0;
            cursorPos.Y = 0;
            SetConsoleCursorPosition(hConsole, cursorPos);
        }
    }
}
