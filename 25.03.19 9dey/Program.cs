namespace _25._03._19_9dey
{
    internal class Program
    {
        struct Position                                                        //플레이어 초기 설정 함수
        {
            public int x;
            public int y;
        }
        static void Main(string[] args)
        {
            bool gameOver = false;
            Position player;
            char[,] map;
            int Money = 0;


            Start(out player, out map);                                         //시작
            while (gameOver == false)
            {
                Render(player, map,ref Money);                                   //출력
                ConsoleKey key = Input();                                       //입력
                Update(key, ref player, ref map, ref gameOver, ref Money);                    //업데이트
            }
            end(Money);                                                                //끝

        }
        static void Start(out Position player, out char[,] map)
        {
            Console.CursorVisible = false;
            player.x = 5;                                                       //플래이어 위치
            player.y = 6;

            map = new char[20, 20]                                              //초기 맵
            {
                {'▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒'},
                {'▒', 'M', '▒', ' ', ' ', '▒', ' ', 'M', '▒', ' ', ' ', '▒', ' ', '▒', ' ', ' ', ' ', ' ', ' ', '▒'},
                {'▒', ' ', '▒', ' ', 'M', '▒', ' ', ' ', '▒', ' ', ' ', '▒', ' ', '▒', ' ', '▒', 'M', ' ', ' ', '▒'},
                {'▒', ' ', '▒', ' ', '▒', '▒', ' ', '▒', '▒', ' ', '▒', '▒', ' ', 'M', ' ', '▒', ' ', ' ', ' ', '▒'},
                {'▒', ' ', '▒', ' ', ' ', ' ', ' ', ' ', ' ', 'M', ' ', ' ', ' ', '▒', ' ', '▒', ' ', ' ', ' ', '▒'},
                {'▒', ' ', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', ' ', '▒', ' ', '▒', ' ', 'M', ' ', '▒'},
                {'▒', ' ', '▒', 'M', ' ', ' ', ' ', ' ', ' ', 'M', ' ', ' ', ' ', ' ', ' ', '▒', '▒', '▒', '▒', '▒'},
                {'▒', ' ', '▒', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'M', ' ', '▒', ' ', ' ', ' ', '▒'},
                {'▒', ' ', '▒', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', 'M', ' ', ' ', '▒', ' ', '▒', ' ', '▒'},
                {'▒', ' ', '▒', ' ', 'M', ' ', ' ', ' ', 'M', ' ', ' ', ' ', ' ', ' ', ' ', '▒', 'M', '▒', ' ', '▒'},
                {'▒', ' ', '▒', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '▒', '▒', '▒', ' ', '▒'},
                {'▒', ' ', '▒', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', '▒', 'M', '▒', ' ', '▒'},
                {'▒', ' ', '▒', ' ', '▒', '▒', ' ', '▒', '▒', ' ', ' ', ' ', '▒', '▒', ' ', 'M', ' ', '▒', ' ', '▒'},
                {'▒', ' ', '▒', ' ', '▒', ' ', ' ', ' ', '▒', ' ', ' ', ' ', '▒', ' ', ' ', '▒', ' ', '▒', ' ', '▒'},
                {'▒', ' ', '▒', ' ', '▒', ' ', ' ', ' ', '▒', ' ', ' ', 'M', '▒', ' ', ' ', '▒', ' ', '▒', ' ', '▒'},
                {'▒', ' ', '▒', 'M', '▒', ' ', 'M', ' ', '▒', ' ', ' ', ' ', '▒', ' ', ' ', '▒', ' ', '▒', ' ', '▒'},
                {'▒', ' ', '▒', ' ', '▒', '▒', '▒', '▒', '▒', ' ', ' ', ' ', '▒', ' ', 'M', '▒', ' ', '▒', ' ', '▒'},
                {'▒', ' ', '▒', ' ', ' ', ' ', ' ', ' ', 'M', ' ', ' ', ' ', '▒', '▒', '▒', '▒', ' ', '▒', 'M', '▒'},
                {'▒', ' ', 'M', ' ', ' ', ' ', 'M', ' ', ' ', ' ', ' ', ' ', '▒', 'M', ' ', ' ', ' ', ' ', ' ', '▒'},
                {'▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒', '▒'},
            };

        }
        static void Render(Position player, char[,] map,ref int Money)                                      //출력 함수 제작
        {
            Console.SetCursorPosition(0, 0);                                                   //셋팅 커서 포지션[커서 원위치]
            Printmay(map,ref Money);                                                                    //맵 출력 함수 가저오기
            PrintPlayer(player);                                                              //플레이어 출력 함수 가저오기

        }
        static void Printmay(char[,] map,ref int Money)
        {
            for (int y = 0; y < map.GetLength(0); y++)                                        //y축
            {
                for (int x = 0; x < map.GetLength(1); x++)                                    //x축
                {
                    Console.Write(map[y, x]);                                                  //y,x축 갑 출력

                }
                Console.WriteLine();                                                          //y축 이동
            }
            Console.WriteLine($"내가주은 돈{Money}");
        }
        static void PrintPlayer(Position player)
        {
            Console.SetCursorPosition(player.x, player.y);                       //플레이어 위치
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("▼");                                                  //플레이어 캐릭터 설정
            Console.ResetColor();
        }
        static ConsoleKey Input()                                                //입력 함수
        {
            return Console.ReadKey(true).Key;                                    //키 입력 설정
        }
        static void Update(ConsoleKey key, ref Position player, ref char[,] map, ref bool gameOver,ref int Money)//업데이트 설정 함수
        {
            move(key, ref player, ref map, ref Money);                                              //무브 설정
            bool clear = Clear(map);                                                                //클리어 함수 가저오기
            if (clear)                                                                              
            {
                gameOver = true;                                                           //클리어 되면 게임오버 참으로 바꾸기
            }

        }
        static void move(ConsoleKey key, ref Position player, ref char[,] map,ref int Money)           //무브 설정 함수
        {
            Position target;
            Position Overtarget;
            switch (key)
            {
                case ConsoleKey.A:
                case ConsoleKey.LeftArrow:
                    target.x = player.x - 1;
                    target.y = player.y;
                    break;
                case ConsoleKey.D:
                case ConsoleKey.RightArrow:
                    target.x = player.x + 1;
                    target.y = player.y;
                    break;
                case ConsoleKey.W:
                case ConsoleKey.UpArrow:
                    target.x = player.x;
                    target.y = player.y - 1;
                    break;
                case ConsoleKey.S:
                case ConsoleKey.DownArrow:
                    target.x = player.x;
                    target.y = player.y + 1;
                    break;
                default:
                    return;

            }
            if (map[target.y, target.x] == ' ')          //움직이는 방향이 빈칸 일경우
            {
                player.x = target.x;                     //움직이는 방향의 플레이어 이동
                player.y = target.y;
            }
            else if (map[target.y, target.x] == 'M')     //움직이는 방향에 머니가 있으면
            {
                map[target.y, target.x] = ' ';           //머니 줍기
                Money = Money + 100;                     //머니 + 해주기
                player.x = target.x;                     //움직이는 방향의 플레이어 이동
                player.y = target.y;
            }
        }
        static bool Clear(char[,] map)                   //클리어 함수 제작 
        {
            int money = 0;
            foreach (char item in map)                  
            {
                if (item == 'M')
                {
                    money++;
                    break;
                }
            }
            if (money == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static void end(int Money)
        {
           Console.Clear();
            Console.WriteLine("모든 돈을 다 주웠습니다");
            Console.WriteLine($"당신이 주은 돈은{Money}");
        }
    }
}
