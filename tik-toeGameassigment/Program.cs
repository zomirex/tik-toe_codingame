//// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
////using System;

//class Program
//{
   
//    static void AIMove()
//    {
//        int bestScore = int.MinValue;
//        int move = -1;
//        int bestRow = -1, bestCol = -1;

//        for (int i = 0; i < 3; i++)
//        {
//            for (int j = 0; j < 3; j++)
//            {
//                if (board[i, j] != 'X' && board[i, j] != 'O')
//                {
//                    board[i, j] = 'O';
//                    int score = Minimax(board, 0, false);
//                    board[i, j] = (char)((i * 3 + j + 1) + '0'); // Undo the move

//                    if (score > bestScore)
//                    {
//                        bestScore = score;
//                        bestRow = i;
//                        bestCol = j;
//                    }
//                }
//            }
//        }

//        board[bestRow, bestCol] = 'O';
//    }

//    // Minimax algorithm
//    static int Minimax(char[,] board, int depth, bool isMaximizing)
//    {
//        int winner = CheckWinner(board);
//        if (winner != 0)
//        {
//            return winner == 1 ? -1 : 1;
//        }

//        if (IsBoardFull(board))
//        {
//            return 0;
//        }

//        if (isMaximizing)
//        {
//            int bestScore = int.MinValue;
//            for (int i = 0; i < 3; i++)
//            {
//                for (int j = 0; j < 3; j++)
//                {
//                    if (board[i, j] =='.')
//                    {
//                        board[i, j] = 'O';// do
//                        int score = Minimax(board, depth + 1, false);
//                        board[i, j] = '.'; // Undo
//                        bestScore = Math.Max(score, bestScore);
//                    }
//                }
//            }
//            return bestScore;
//        }
//        else
//        {
//            int bestScore = int.MaxValue;
//            for (int i = 0; i < 3; i++)
//            {
//                for (int j = 0; j < 3; j++)
//                {
//                    if (board[i,j]=='.')
//                    {
//                        board[i, j] = 'X';// Do 
//                        int score = Minimax(board, depth + 1, true);
//                        board[i, j] = '.'; // Undo 
//                        bestScore = Math.Min(score, bestScore);
//                    }
//                }
//            }
//            return bestScore;
//        }
//    }

//    // Check for winner
//    static int CheckWinner(char[,] board)
//    {
//        // ofoghi
//        for (int i = 0; i < 3; i++)
//        {
//            if (board[i, 0] == board[i, 1] && board[i, 1] == board[i, 2])
//            {
//                return board[i, 0] == 'X' ? 1 : -1;
//            }
//        }

//        // amoodi
//        for (int i = 0; i < 3; i++)
//        {
//            if (board[0, i] == board[1, i] && board[1, i] == board[2, i])
//            {
//                return board[0, i] == 'X' ? 1 : -1;
//            }
//        }

//        // movarab
//        if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2] ||
//            board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
//        {
//            return board[1, 1] == 'X' ? 1 : -1;
//        }

//        return 0;
//    }

//    // kamel boodan board
//    static bool IsBoardFull(char[,] board)
//    {
//        for (int i = 0; i < 3; i++)
//        {
//            for (int j = 0; j < 3; j++)
//            {
//                if (board[i, j] != 'X' && board[i, j] != 'O')
//                {
//                    return false;
//                }
//            }
//        }
//        return true;
//    }
//}

////کد کمکی