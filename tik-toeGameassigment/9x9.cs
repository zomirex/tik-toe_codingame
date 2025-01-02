using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    // Read opponent's move
                    string[] inputs = Console.ReadLine().Split(' ');
                    int opponentRow = int.Parse(inputs[0]);
                    int opponentCol = int.Parse(inputs[1]);

                    // Update the board with opponent's move
                    if (opponentRow != -1 && opponentCol != -1) // -1 means no move yet
                    {
                        board[opponentRow, opponentCol] = 'O';
                    }

                    // Read the number of valid moves
                    int validActionCount = int.Parse(Console.ReadLine());
                    List<(int row, int col)> validActions = new List<(int, int)>();
                    for (int i = 0; i < validActionCount; i++)
                    {
                        inputs = Console.ReadLine().Split(' ');
                        int row = int.Parse(inputs[0]);
                        int col = int.Parse(inputs[1]);
                        board[row, col] = '.';
                    }
                    for (int i = 0;i < 9;i++)
                    {
                        if (IsBoardFull(board, i)==false)
                        {

                        }
                    }
                }
            }
            //tagsim kardan board 
            static (int,int) dividedBoard(int num)
            {
                
                switch(num)
                {
                    case 0:
                        return (0, 0);
                    case 1:
                        return (0, 3);
                    case 2:
                        return (0, 6);
                    case 3:
                        return (3, 0);
                    case 4 :
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
            static int CheckWinner(char[,] board,(int row,int col)map)
            {
                // ofoghi
                for (int i = map.row; i < 3+map.row; i++)
                {
                    if (board[i, map.col] == board[i, map.col+1] && board[i, map.col+1] == board[i, map.col+2])
                    {
                        return board[i, map.col + 0] == 'X' ? 1 : -1;
                    }
                }

                // amoodi
                for (int i = map.col; i < 3+ map.col; i++)
                {
                    if (board[map.row, i] == board[map.row + 1, i] && board[map.row + 1, i] == board[map.row + 2, i])
                    {
                        return board[map.row + 0, i] == 'X' ? 1 : -1;
                    }
                }

                // movarab
                if (board[map.row+0, map.col + 0] == board[map.row + 1, map.col + 1] && board[map.row + 1, map.col + 1] == board[map.row + 2, map.col+2] ||
                    board[map.row + 0, map.col + 2] == board[map.row + 1, map.col + 1] && board[map.row + 1, map.col + 1] == board[map.row + 2, map.col + 0])
                {
                    return board[map.row + 1, map.col + 1] == 'X' ? 1 : -1;
                }

                return 0;
            }
            // dorost kardan ye map as main board ?* camel nist
            static char[,]? MainBoardState(int mapnum,bool iswin, char[,] map)
            {
                return null;
            }
            // kamel boodan board
            static bool IsBoardFull(char[,] board,int num)
            {
                (int row, int col) = dividedBoard(num);
                for (int i = row; i < 3+row; i++)
                {
                    for (int j = col; j < col+3; j++)
                    {
                        if (board[i,j]=='.')
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            //algorythem mini max
            static int Minimax(char[,] board, int depth, bool isMaxturn,int num)
            {

                int winner = CheckWinner(board,dividedBoard(num));
                if (winner != 0)
                {
                    return winner == 1 ? -1 : 1;
                }

                if (IsBoardFull(board,num))
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
                                int score = Minimax(board, depth + 1, false,num);
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

        }
    }
}
