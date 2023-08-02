using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            PlayGame();
        }

        static void Welcome()
        {
            Console.WriteLine("\n============================");
            Console.WriteLine("===== TIC TAC TOE Game =====");
            Console.WriteLine("============================\n");
        }

        static void ShowBoard(char[] board)
        {
            Console.WriteLine($"{board[0]}|{board[1]}|{board[2]}");
            Console.WriteLine($"{board[3]}|{board[4]}|{board[5]}");
            Console.WriteLine($"{board[6]}|{board[7]}|{board[8]}");
        }

        static bool CheckWin(char[] board, char current_player, ref int x_points, ref int o_points)
        {
            int[][] winningCombos = new int[][]
            {
                new int[] { 0, 1, 2 }, new int[] { 3, 4, 5 }, new int[] { 6, 7, 8 }, // Rows
                new int[] { 0, 3, 6 }, new int[] { 1, 4, 7 }, new int[] { 2, 5, 8 }, // Columns
                new int[] { 0, 4, 8 }, new int[] { 2, 4, 6 } // Diagonals
            };

            foreach (var combo in winningCombos)
            {
                if (board[combo[0]] == current_player && board[combo[1]] == current_player && board[combo[2]] == current_player)
                {
                    if (current_player == 'X')
                    {
                        x_points++;
                    }
                    else
                    {
                        o_points++;
                    }
                    return true;
                }
            }
            return false;
        }

        static void PlayGame()
        {
            bool names = true;
            bool game;
            int cell;
            int x_points = 0;
            int o_points = 0;
            int turn;
            string player_x = "";
            string player_o = "";

            Welcome();

            do
            {
                Console.Write("Player X, write your name: ");
                player_x = Console.ReadLine();

                Console.Write("Player O, write your name: ");
                player_o = Console.ReadLine();

            } while (string.IsNullOrEmpty(player_x) || string.IsNullOrEmpty(player_o));

            while (true)
            {
                turn = 1;
                char current_player = 'X';
                char[] board = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

                Console.Write("\nStart the game? (press 'y' to play, any else to quit)\n");
                char play = char.ToUpper(Console.ReadKey().KeyChar);
                Console.WriteLine();

                if (play == 'Y')
                {
                    game = true;
                }
                else
                {
                    return;
                }

                bool single_game = true;

                while (single_game)
                {
                    ShowBoard(board);

                    Console.Write($"\nPlayer {current_player}. Choose a cell by entering a number (1-9): ");
                    cell = int.Parse(Console.ReadLine()) - 1;

                    if (board[cell] == 'X' || board[cell] == 'O')
                    {
                        Console.WriteLine("The cell is already taken. Choose another one!");
                        continue;
                    }

                    board[cell] = current_player;

                    if (CheckWin(board, current_player, ref x_points, ref o_points))
                    {
                        ShowBoard(board);
                        Console.WriteLine($"\nPlayer {current_player} Won!\n");
                        single_game = false;
                    }
                    else if (turn == 9)
                    {
                        Console.WriteLine("\nThe game is a tie!\n");
                        single_game = false;
                    }
                    else
                    {
                        current_player = current_player == 'X' ? 'O' : 'X';
                        turn++;
                    }
                }

                Console.WriteLine($"Player X: {player_x} points: {x_points}\t\tPlayer O: {player_o} points: {o_points}\n");
            }

            Console.WriteLine("Thank you for playing!\n");
        }
    }
}

