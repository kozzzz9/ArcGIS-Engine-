using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Snake
{
    /// <summary>
    /// 方向向量：X 为列（水平方向），Y 为行（垂直方向）。
    /// </summary>
    public class Direction
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Direction(int x = 0, int y = 0)
        {
            X = x;
            Y = y;
        }
    }

    /// <summary>
    /// 蛇身链表节点：Prev 指向更靠头部的一节，Next 指向更靠尾部的一节。
    /// </summary>
    public class Snake
    {
        public Direction Pos { get; set; }   // 当前所在格子
        public Snake? Prev { get; set; }      // 前一节（更靠头）
        public Snake? Next { get; set; }      // 后一节（更靠尾）

        public Snake(Direction pos)
        {
            Pos = pos;
        }
    }

    /// <summary>
    /// 控制台贪吃蛇游戏主逻辑。
    /// </summary>
    class Game
    {
        private const int Width = 40;   // 地图列数（含左右外墙）
        private const int Height = 20;  // 地图行数（含上下外墙）
        private const int Food = 6;     // 地图中代表食物的标记

        private readonly int[,] map = new int[Height, Width];
        private Snake? head;
        private Direction dir = new(1, 0);   // 当前移动方向，初始向右
        private int score;
        private int length;
        private bool quit;
        private readonly Random rnd = new();

        private static void Main()
        {
            Console.CursorVisible = false;
            if (OperatingSystem.IsWindows())
            {
                try
                {
                    Console.SetWindowSize(Width, Height + 3);
                    Console.SetBufferSize(Width, Height + 3);
                }
                catch
                {
                    // 某些环境不允许调整窗口大小，忽略即可
                }
            }
            new Game().Run();
        }

        private void Run()
        {
            while (true)
            {
                Reset();
                Console.Clear();

                bool died = PlayRound();
                if (quit)
                    break;

                if (died)
                {
                    DrawGameOver();
                    Console.WriteLine("  按 R 重新开始，按其它键退出...");
                    if (Console.ReadKey(true).Key != ConsoleKey.R)
                        break;
                }
            }
            Console.CursorVisible = true;
        }

        // 初始化一局游戏状态
        private void Reset()
        {
            Array.Clear(map);
            score = 0;
            length = 4;
            quit = false;
            dir = new Direction(1, 0);
            head = CreateSnake();
            PlaceFood();
        }

        // 创建长度为 4 的蛇，蛇头朝右
        private Snake CreateSnake()
        {
            Snake? prev = null;
            Snake? headNode = null;
            int startX = 10, startY = 10;
            for (int i = 0; i < 4; i++)
            {
                var node = new Snake(new Direction(startX - i, startY));
                node.Prev = prev;
                if (prev != null)
                    prev.Next = node;
                else
                    headNode = node;
                prev = node;
            }
            return headNode!;
        }

        // 主循环：返回 true 表示撞死，返回 false 表示玩家主动退出
        private bool PlayRound()
        {
            while (true)
            {
                HandleInput();
                if (quit)
                    return false;

                if (!Step())
                    return true;   // 撞墙或撞到自己

                Draw();
                Thread.Sleep(CurrentDelay());
            }
        }

        // 非阻塞读取键盘输入，支持 WASD 与方向键
        private void HandleInput()
        {
            while (Console.KeyAvailable)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:
                        if (dir.Y != 1) dir = new Direction(0, -1);
                        break;
                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                        if (dir.Y != -1) dir = new Direction(0, 1);
                        break;
                    case ConsoleKey.A:
                    case ConsoleKey.LeftArrow:
                        if (dir.X != 1) dir = new Direction(-1, 0);
                        break;
                    case ConsoleKey.D:
                    case ConsoleKey.RightArrow:
                        if (dir.X != -1) dir = new Direction(1, 0);
                        break;
                    case ConsoleKey.Escape:
                        quit = true;
                        break;
                }
            }
        }

        // 推进一帧：返回 false 表示游戏结束
        private bool Step()
        {
            var nodes = Body();
            int n = nodes.Count;

            int[] oldX = new int[n];
            int[] oldY = new int[n];
            for (int i = 0; i < n; i++)
            {
                oldX[i] = nodes[i].Pos.X;
                oldY[i] = nodes[i].Pos.Y;
            }

            int newHeadX = oldX[0] + dir.X;
            int newHeadY = oldY[0] + dir.Y;

            // 撞墙
            if (newHeadX <= 0 || newHeadX >= Width - 1 || newHeadY <= 0 || newHeadY >= Height - 1)
                return false;

            // 撞到自己（尾巴这一帧会移开，故不计入尾部）
            for (int i = 1; i < n - 1; i++)
                if (oldX[i] == newHeadX && oldY[i] == newHeadY)
                    return false;

            bool ate = map[newHeadY, newHeadX] == Food;

            // 更新头部
            nodes[0].Pos = new Direction(newHeadX, newHeadY);
            // 身体每一节移动到前一节原来的位置
            for (int i = 1; i < n; i++)
                nodes[i].Pos = new Direction(oldX[i - 1], oldY[i - 1]);

            if (ate)
            {
                map[newHeadY, newHeadX] = 0;
                score++;
                length++;
                // 在尾部补上一节，位置为原尾部的坐标，保证形状连贯
                Snake tail = nodes[^1];
                Snake grow = new Snake(new Direction(oldX[^1], oldY[^1]));
                grow.Prev = tail;
                tail.Next = grow;
                PlaceFood();
            }
            return true;
        }

        // 在空地随机放置食物
        private void PlaceFood()
        {
            var free = new List<(int x, int y)>();
            for (int y = 1; y < Height - 1; y++)
                for (int x = 1; x < Width - 1; x++)
                    if (map[y, x] == 0 && !OnSnake(x, y))
                        free.Add((x, y));

            if (free.Count == 0)
                return; // 蛇占满全屏

            var p = free[rnd.Next(free.Count)];
            map[p.y, p.x] = Food;
        }

        private bool OnSnake(int x, int y)
        {
            for (var s = head; s != null; s = s.Next)
                if (s.Pos.X == x && s.Pos.Y == y)
                    return true;
            return false;
        }

        // 从头到尾收集所有蛇身节点
        private List<Snake> Body()
        {
            var list = new List<Snake>();
            for (var s = head; s != null; s = s.Next)
                list.Add(s);
            return list;
        }

        // 帧间隔随分数逐渐加快
        private int CurrentDelay()
        {
            int delay = 180 - score * 4;
            return delay < 60 ? 60 : delay;
        }

        private void Draw()
        {
            var sb = new StringBuilder();
            sb.Append("贪吃蛇   分数: ").Append(score)
              .Append("   长度: ").Append(length)
              .Append("   (WASD/方向键移动, ESC 退出)").Append('\n');

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    bool border = x == 0 || x == Width - 1 || y == 0 || y == Height - 1;
                    if (border)
                    {
                        sb.Append('#');
                    }
                    else if (map[y, x] == Food)
                    {
                        sb.Append('o');
                    }
                    else
                    {
                        char c = ' ';
                        for (var s = head; s != null; s = s.Next)
                        {
                            if (s.Pos.X == x && s.Pos.Y == y)
                            {
                                c = ReferenceEquals(s, head) ? '@' : '*';
                                break;
                            }
                        }
                        sb.Append(c);
                    }
                }
                sb.Append('\n');
            }

            Console.SetCursorPosition(0, 0);
            Console.Write(sb.ToString());
        }

        private void DrawGameOver()
        {
            Console.Clear();
            Console.WriteLine("=====================");
            Console.WriteLine("       游戏结束！");
            Console.WriteLine($"  最终分数: {score}");
            Console.WriteLine($"  最终长度: {length}");
            Console.WriteLine("=====================");
        }
    }
}
