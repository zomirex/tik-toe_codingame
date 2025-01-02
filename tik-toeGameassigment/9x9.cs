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
                char[,] board = new char[9, 9]; // 9x9 board representation
                Dictionary<int, char> turns = new Dictionary<int, char>();


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
                }
            }
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
            static bool IsEmptyBoard(List<(int,int)> validActions)
            {

                
                return true;
            }

        }
    }
}
