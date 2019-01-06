using System;
using System.Collections.Generic;
using System.Threading;



namespace FPSGame
{
    class Program
    {
        static Thread t;
        static bool hmm = true;
        static void Main(string[] args)
        {

            Console.CursorVisible = false;

            GameRoom.init();

            alt();

            //foreach (ColumnInfo item in GameRoom.castrays())
            //{
            //    Console.WriteLine(item.distance);
            //}
            //Console.ReadLine();
            //startcontrolling();
        }

        static void alt()
        {

            GameRoom.startshowing();

            GameRoom.startupdating();

            startcontrolling();

        }


        static void startcontrolling()
        {
            Thread t = new Thread(new ThreadStart(Controllermove)); t.Start();
            
        }


        static void Controllermove()
        {
            long prev = 0;
            long deltatime = DateTime.Now.Ticks - prev;
            while (true)
            {
                prev = DateTime.Now.Ticks;
                ConsoleKey k = Console.ReadKey(true).Key;
                switch (k)
                {
                    case ConsoleKey.W:
                        GameRoom.playerxpos += GameRoom.playermovespeed * Math.Cos(convert(GameRoom.playerrot));
                        GameRoom.playerypos += GameRoom.playermovespeed * Math.Sin(convert(GameRoom.playerrot));
                        //Console.WriteLine("X: {0}, Y: {1}", GameRoom.playerxpos, GameRoom.playerypos);
                        break;
                    case ConsoleKey.S:
                        GameRoom.playerxpos -= GameRoom.playermovespeed * Math.Cos(convert(GameRoom.playerrot));
                        GameRoom.playerypos -= GameRoom.playermovespeed * Math.Sin(convert(GameRoom.playerrot));
                        //Console.WriteLine("X: {0}, Y: {1}", GameRoom.playerxpos, GameRoom.playerypos);
                        break;
                    case ConsoleKey.A:
                        GameRoom.playerrot -= GameRoom.playermovespeed;
                        break;
                    case ConsoleKey.D:
                        GameRoom.playerrot += GameRoom.playermovespeed;
                        break;
                    case ConsoleKey.Spacebar:
                        if (hmm)
                        {
                            GameRoom.stopshowing(); hmm = false;
                        }
                        else
                        {
                            GameRoom.startshowing(); hmm = true;
                        }
                        Console.WriteLine("X {0} Y {1} Rot {2}", GameRoom.playerxpos, GameRoom.playerypos, GameRoom.playerrot);
                        break;
                }
            }

        }



        




        public static double convert(double degs)
        {
            return (3.141592 / 180) * degs;
        }

        static double distance(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
        }

        


    }
}
