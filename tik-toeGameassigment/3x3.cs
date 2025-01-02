using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tik_toeGameassigment
{
    public class _3x3
    {
        class Player
        {
            static void Main(string[] args)
            {
                char[,] board = new char[3, 3]; // 9x9 board representation
                //Dictionary<int, char> turns = new Dictionary<int, char>();


                while (true)
                {
                    int bestScore = int.MinValue;
                    // Read opponent's move
                    string[] inputs = Console.ReadLine().Split(' ');
                    int opponentRow = int.Parse(inputs[0]);
                    int opponentCol = int.Parse(inputs[1]);
                    (int row, int col) bestmove = (-1, -1);
                    // Update the board with opponent's move
                    if (opponentRow != -1 && opponentCol != -1) // -1 means no move yet
                    {
                        board[opponentRow, opponentCol] = 'O';
                    }

                    int validActionCount = int.Parse(Console.ReadLine());
                    List<(int row, int col)> validActions = new List<(int, int)>();
                    //khoondan valid action ha
                    for (int i = 0; i < validActionCount; i++)
                    {
                        inputs = Console.ReadLine().Split(' ');
                        int row = int.Parse(inputs[0]);
                        int col = int.Parse(inputs[1]);
                        board[row, col] = '.';// rikhtan valid action ha
                        validActions.Add((row, col));
                    }
                    // impliment minimax
                    foreach (var action in validActions)
                    {

                        board[action.row, action.col] = 'X';//do move
                        int Score = Minimax(board, 0, false);
                        if (bestScore < Score) // save move if it gonna win
                        {
                            bestScore = Score;
                            bestmove = (action.row, action.col);

                        }
                        board[action.row, action.col] = '.';//undo move 

                    }
                    Console.WriteLine($"{bestmove.row} {bestmove.col}");
                    board[bestmove.row, bestmove.col] = 'X';//do move
                }
            }
            //minimax algorythem 
            static int Minimax(char[,] board, int depth, bool isMaxturn)
            {
                int winner = CheckWinner(board);
                if (winner != 0)
                {
                    return winner == 1 ? -1 : 1;
                }

                if (IsBoardFull(board))
                {
                    return 0;
                }

                if (isMaxturn)//my turn
                {
                    int bestScore = int.MinValue;
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            if (board[i, j] == '.')
                            {
                                board[i, j] = 'X';// do
                                int score = Minimax(board, depth + 1, false);
                                board[i, j] = '.'; // Undo
                                bestScore = Math.Max(score, bestScore);
                            }
                        }
                    }
                    return bestScore;
                }
                else//opp turn 
                {
                    int bestScore = int.MaxValue;
                    for (int i = 0; i < 3; i++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            if (board[i, j] == '.')
                            {
                                board[i, j] = 'O';// Do 
                                int score = Minimax(board, depth + 1, true);
                                board[i, j] = '.'; // Undo 
                                bestScore = Math.Min(score, bestScore);
                            }
                        }
                    }
                    return bestScore;
                }
            }

            // Check baray barande
            static int CheckWinner(char[,] board)
            {
                // ofoghi
                for (int i = 0; i < 3; i++)
                {
                    if (board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
                    {
                        return board[i, 0] == 'X' ? 1 : -1;
                    }
                }

                // amoodi
                for (int i = 0; i < 3; i++)
                {
                    if (board[0, i] == board[1, i] && board[1, i] == board[2, i])
                    {
                        return board[0, i] == 'X' ? 1 : -1;
                    }
                }

                // movarab
                if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2] ||
                    board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
                {
                    return board[1, 1] == 'X' ? 1 : -1;
                }

                return 0;
            }

            // kamel boodan board
            static bool IsBoardFull(char[,] board)
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (board[i, j] != 'X' && board[i, j] != 'O')
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            
            

        }
    }
}
