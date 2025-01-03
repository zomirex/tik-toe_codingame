using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace tik_toeGameassigment
{
    public class _9x9
    {
        class Player
        {

            static void Main(string[] args)
            {
                char[,] board = new char[9, 9]; // 9x9 board 
                //Dictionary<int, char> turns = new Dictionary<int, char>();


                while (true)
                {
                    // decler int variables
                    int bestScore = int.MinValue;
                    (int row, int col) bestmove = (-1, -1);
                    // Read opponent's move
                    string[] inputs = Console.ReadLine().Split(' ');
                    int opponentRow = int.Parse(inputs[0]);
                    int opponentCol = int.Parse(inputs[1]);
                    int currentboardnum = 0;
                    // Update the board with opponent's move
                    if (opponentRow != -1 && opponentCol != -1) // -1 means no move yet
                    {
                        board[opponentRow, opponentCol] = 'O';
                    }

                    // Read the number of valid moves
                    int validActionCount = int.Parse(Console.ReadLine());
                    List<(int row, int col)> validActions = new List<(int, int)>();
                    List<int> validBoards = new List<int>();
                    for (int i = 0; i < validActionCount; i++)
                    {
                        inputs = Console.ReadLine().Split(' ');
                        int row = int.Parse(inputs[0]);
                        int col = int.Parse(inputs[1]);
                        board[row, col] = '.';
                        validActions.Add((row, col));


                    }

                    for (int i = 0; i < validActions.Count; i++)
                    {
                        if (i == 0)
                        {
                            validBoards.Add(CurrentBoard(validActions[i].row, validActions[i].col));

                        }
                        else
                        {
                            if (validBoards[i - 1] != CurrentBoard(validActions[i].row, validActions[i].col))
                                validBoards.Add(CurrentBoard(validActions[i].row, validActions[i].col));
                        }
                    }
                    currentboardnum = CurrentBoard(validActions[0].row, validActions[0].col);
                    // first implement 
                    foreach (var action in validActions)
                    {

                        board[action.row, action.col] = 'X';//do move
                        int Score = Minimax(board, 0, false, currentboardnum);
                        if (bestScore < Score) // save move if it gonna win
                        {
                            bestScore = Score;
                            bestmove = (action.row, action.col);

                        }
                        board[action.row, action.col] = '.';//undo move 

                    }

                    // second implement is'nt work to now
                    (int row, int col) rowcol = dividedBoard(currentboardnum);
                    for (int i = rowcol.row; i < 3 + rowcol.row; i++)
                    {
                        for (int j = rowcol.col; j < 3 + rowcol.col; j++)
                        {
                            if (board[i, j] == '.')
                            {
                                board[i, j] = 'X';//do move
                                int Score = Minimax(board, 0, false, currentboardnum);
                                if (bestScore < Score) // save move if it gonna win
                                {
                                    bestScore = Score;
                                    bestmove = (i, j);

                                }
                                board[i, j] = '.';//undo move 
                            }

                        }
                    }
                    //third and finall implement which is the best one

                    for (int i = rowcol.row; i < 3 + rowcol.row; i++)
                    {
                        for (int j = rowcol.col; j < 3 + rowcol.col; j++)
                        {
                            if (board[i, j] == '.')
                            {
                                board[i, j] = 'X';//do move
                                int Score = Minimax2(board, 0, false, currentboardnum);
                                if (bestScore < Score) // save move if it gonna win
                                {
                                    bestScore = Score;
                                    bestmove = (i, j);
                                    continue;
                                }
                                board[i, j] = '.';//undo move 
                                continue;
                            }

                        }
                    }
                    (int row, int col) resistingmove = bestMove(board, currentboardnum, 'O');
                    (int row, int col) winingmove = bestMove(board, currentboardnum, 'X');
                    if (winingmove.row != -1 || resistingmove.row != -1)
                    {
                        if (winingmove.row != -1)
                        {
                            Console.WriteLine($"{winingmove.row} {winingmove.col}");
                            board[bestmove.row, bestmove.col] = 'X';//do move
                        }


                        if (resistingmove.row != -1)
                        {
                            Console.WriteLine($"{resistingmove.row} {resistingmove.col}");
                            board[bestmove.row, bestmove.col] = 'X';//do move
                        }

                    }
                    else
                    {
                        Console.WriteLine($"{bestmove.row} {bestmove.col}");
                        board[bestmove.row, bestmove.col] = 'X';//do move
                    }

                }
            }
            //check best move 
            static (int, int) bestMove(char[,] board, int num, char player)
            {
                (int row, int col) map = dividedBoard(num);
                // ofoghi
                for (int i = map.row; i < 3 + map.row; i++)
                {
                    if ((board[i, map.col] == board[i, map.col + 1]) && (board[i, map.col] == player) && board[i, map.col + 2] == '.')
                    {
                        return (i, map.col + 2);
                    }
                    else if ((board[i, map.col + 1] == board[i, map.col + 2]) && (board[i, map.col + 1] == player) && board[i, map.col] == '.')
                    {
                        return (i, map.col + 1);
                    }
                    else if ((board[i, map.col] == board[i, map.col + 2]) && (board[i, map.col] == player) && board[i, map.col + 1] == '.')
                    {
                        return (i, map.col + 2);
                    }
                }

                // amoodi
                for (int i = map.col; i < 3 + map.col; i++)
                {
                    if ((board[map.row, i] == board[map.row + 1, i]) && (board[map.row, i] == player) && board[map.row + 2, i] == '.')
                    {
                        return (map.row + 2, i);
                    }
                    else if ((board[map.row, i] == board[map.row + 2, i]) && (board[map.row, i] == player) && board[map.row + 1, i] == '.')
                    {
                        return (map.row + 1, i);
                    }
                    else if ((board[map.row + 1, i] == board[map.row + 2, i]) && (board[map.row + 1, i] == player) && board[map.row + 0, i] == '.')
                    {
                        return (map.row + 0, i);
                    }
                }

                // movarab
                if (board[map.row + 0, map.col + 0] == board[map.row + 1, map.col + 1] && board[map.row + 1, map.col + 1] == player && board[map.row + 2, map.col + 2] == '.')
                {
                    return (map.row + 2, map.col + 2);
                }
                if (board[map.row + 0, map.col + 0] == board[map.row + 2, map.col + 2] && board[map.row, map.col] == player && board[map.row + 1, map.col + 1] == '.')
                {
                    return (map.row + 1, map.col + 1);
                }
                if (board[map.row + 1, map.col + 1] == board[map.row + 2, map.col + 2] && board[map.row + 1, map.col + 1] == player && board[map.row, map.col] == '.')
                {
                    return (map.row, map.col);
                }
                // movarab bar acs
                if (board[map.row + 0, map.col + 2] == board[map.row + 1, map.col + 1] && board[map.row + 1, map.col + 1] == player && board[map.row + 2, map.col + 0] == '.')
                {
                    return (map.row + 2, map.col + 0);
                }
                if (board[map.row + 0, map.col + 2] == board[map.row + 2, map.col + 0] && board[map.row + 2, map.col + 0] == player && board[map.row + 1, map.col + 1] == '.')
                {
                    return (map.row + 1, map.col + 1);
                }
                if (board[map.row + 1, map.col + 1] == board[map.row + 2, map.col + 0] && board[map.row + 1, map.col + 1] == player && board[map.row + 0, map.col + 2] == '.')
                {
                    return (map.row + 0, map.col + 2);
                }
                return (-1, -1);
            }
            //peyda board e darhall bazi
            static int CurrentBoard(int row, int col)
            {
                //(int row, int col) board=(row, col);
                if (row < 3)
                {
                    if (col < 3)
                        return 0;
                    else if (col >= 3 && col < 6)
                        return 1;
                    else
                        return 2;
                }
                else if (row >= 3 && row < 6)
                {
                    if (col < 3)
                        return 3;
                    else if (col >= 3 && col < 6)
                        return 4;
                    else
                        return 5;
                }
                else
                {

                    if (col < 3)
                        return 6;
                    else if (col >= 3 && col < 6)
                        return 7;
                    else
                        return 8;

                }

            }
            //tagsim kardan board 
            static (int, int) dividedBoard(int num)
            {

                switch (num)
                {
                    case 0:
                        return (0, 0);
                    case 1:
                        return (0, 3);
                    case 2:
                        return (0, 6);
                    case 3:
                        return (3, 0);
                    case 4:
                        return (3, 3);
                    case 5:
                        return (3, 6);
                    case 6:
                        return (6, 0);
                    case 7:
                        return (6, 3);
                    case 8:
                        return (6, 6);
                    default:
                        return (0, 0);

                }

            }
            // chek kardan barande baray mini bardaha
            static int CheckWinner(char[,] board, (int row, int col) map)
            {
                // ofoghi
                for (int i = map.row; i < 3 + map.row; i++)
                {
                    if (board[i, map.col] == board[i, map.col + 1] && board[i, map.col + 1] == board[i, map.col + 2])
                    {
                        return board[i, map.col + 0] == 'X' ? 1 : -1;
                    }
                }

                // amoodi
                for (int i = map.col; i < 3 + map.col; i++)
                {
                    if (board[map.row, i] == board[map.row + 1, i] && board[map.row + 1, i] == board[map.row + 2, i])
                    {
                        return board[map.row + 0, i] == 'X' ? 1 : -1;
                    }
                }

                // movarab
                if (board[map.row + 0, map.col + 0] == board[map.row + 1, map.col + 1] && board[map.row + 1, map.col + 1] == board[map.row + 2, map.col + 2] ||
                    board[map.row + 0, map.col + 2] == board[map.row + 1, map.col + 1] && board[map.row + 1, map.col + 1] == board[map.row + 2, map.col + 0])
                {
                    return board[map.row + 1, map.col + 1] == 'X' ? 1 : -1;
                }

                return 0;
            }
            // dorost kardan ye map as main board ?* camel nist
            static char[,]? MainBoardState(int mapnum, bool iswin, char[,] map)
            {
                return null;
            }
            // kamel boodan board
            static bool IsBoardFull(char[,] board, int num)
            {
                (int row, int col) = dividedBoard(num);
                for (int i = row; i < 3 + row; i++)
                {
                    for (int j = col; j < col + 3; j++)
                    {
                        if (board[i, j] == '.')
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            //algorythem mini max this i think have bug in it
            static int Minimax(char[,] board, int depth, bool isMaxturn, int num)
            {

                int winner = CheckWinner(board, dividedBoard(num));
                if (winner != 0)
                {
                    return winner == 1 ? -1 : 1;
                }

                if (IsBoardFull(board, num))
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
                                int score = Minimax(board, depth + 1, false, num);
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
                                int score = Minimax(board, depth + 1, true, num);
                                board[i, j] = '.'; // Undo 
                                bestScore = Math.Min(score, bestScore);
                            }
                        }
                    }
                    return bestScore;
                }
            }
            //algorythem mini max second edition
            static int Minimax2(char[,] board, int depth, bool isMaxturn, int num)
            {
                //decler needed variables
                (int row, int col) = dividedBoard(num);
                int winner = CheckWinner(board, dividedBoard(num));
                if (winner != 0)
                {
                    return winner == 1 ? 1 : -1;
                }

                if (IsBoardFull(board, num))
                {
                    return 0;
                }

                if (isMaxturn)//my turn
                {
                    int bestScore = int.MinValue;
                    for (int i = row; i < 3 + row; i++)
                    {
                        for (int j = col; j < 3 + col; j++)
                        {
                            if (board[i, j] == '.')
                            {
                                board[i, j] = 'X';// do
                                int score = Minimax2(board, depth + 1, false, num);
                                board[i, j] = '.'; // Undo
                                bestScore = Math.Max(score, bestScore);
                                continue;
                            }
                        }
                    }
                    return bestScore;
                }
                else//opp turn 
                {
                    int bestScore = int.MaxValue;
                    for (int i = row; i < 3 + row; i++)
                    {
                        for (int j = col; j < 3 + col; j++)
                        {
                            if (board[i, j] == '.')
                            {
                                board[i, j] = 'O';// Do 
                                int score = Minimax2(board, depth + 1, true, num);
                                board[i, j] = '.'; // Undo 
                                bestScore = Math.Min(score, bestScore);
                                continue;
                            }
                        }
                    }
                    return bestScore;
                }
            }
        }
    }
}
