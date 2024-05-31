using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkerboard : MonoBehaviour
{
    public const int BOARD_SIZE = 19;
    public const int WHITE = 1;
    public const int BLACK = 2;

    public int[,] board = new int[BOARD_SIZE, BOARD_SIZE];
    //public List<int> omok_dirX;
    //public List<int> omok_dirY;

    public int countStone;

    private void Start()
    {
        for(int i = 0; i < BOARD_SIZE; i++)
        {
            for(int j = 0; j < BOARD_SIZE; j++)
            {
                board[i, j] = 0;
            }
        }
    }

    public bool CheckRange(int x, int y)
    {
        return (x >= 0 && y >= 0 && x < 19 && y < 19) ? true : false;
    }

    public bool ChangeBoard(int x, int y, int value)
    {
        if(CheckRange(x, y))
        {
            board[x, y] = value;
        }
        else
        {
            return false;
        }

        return true;
    }

    public bool CheckWin(int _stone)
    {
        for(int i = 0; i < BOARD_SIZE; i++)
        {
            for(int j = 0; j < BOARD_SIZE; j++)
            {
                int buff = board[i, j];

                if(buff == _stone && buff != 0)
                {
                    countStone = 1;

                    // 오른쪽 방향 확인
                    if(CheckRange(i+1,j) && board[i + 1, j] == buff)
                    {
                        countStone++;

                        for(int k = 2; k < 5; k++)
                        {
                            if(CheckRange(i + k, j) && board[i + 1, j] == buff)
                            {
                                countStone++;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }

                    if (countStone == 5)
                        return true;
                    else
                        countStone = 1;

                    // 아래쪽 방향 확인
                    if(CheckRange(i, j + 1) && board[i, j + 1] == buff)
                    {
                        countStone++;

                        for(int k = 2; k < 5; k++)
                        {
                            if(CheckRange(i, j+k) && board[i, j + k] == buff)
                            {
                                countStone++;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }

                    if (countStone == 5)
                        return true;
                    else
                        countStone = 1;

                    // 오른쪽 아래 대각선 방향 확인
                   if(CheckRange(i+1, j+1) && board[i + 1, j + 1] == buff)
                    {
                        countStone++;

                        for(int k = 2; k < 5; k++)
                        {
                            if(CheckRange(i+k, j+k) && board[i + k, j + k] == buff)
                            {
                                countStone++;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }

                    if (countStone == 5)
                        return true;
                    else
                        countStone = 1;

                    // 오른쪽 위 대각선 방향 확인
                    if(CheckRange(i+1, j-1) && board[i + 1, j - 1] == buff)
                    {
                        countStone++;

                        for(int k = 2; k < 5; k++)
                        {
                            if(CheckRange(i+k, j- k) && board[i + k, j - k] == buff)
                            {
                                countStone++;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }

                    if(countStone == 5) 
                        return true;
                }
            }
        }
        return false;
    }
}
