using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkerboard : MonoBehaviour
{
    public enum STONE
    {
        WHITE,
        BLACK
    }
    public STONE[,] board = new STONE[19, 19];
    public List<int> omok_dirX;
    public List<int> omok_dirY;

    public bool isCorrectRange(int x, int y)
    {
        return (x >= 0 && y >= 0 && x < 19 && y < 19) ? true : false;
    }

    public bool fourWaySearch(int x, int y, bool flag)
    {
        STONE currentStone = flag ? STONE.WHITE : STONE.BLACK;

        for(int i = 0; i < 4; i++)
        {
            int nx = x;
            int ny = y;
            bool s = true;

            for(int k = 0; k < 4; k++)
            {
                nx += omok_dirX[i];
                ny += omok_dirY[i];

                Debug.Log(nx + " " + ny);

                if(!isCorrectRange(nx, ny) || currentStone != board[nx, ny])
                {
                    s= false;
                }
            }

            if(s == true)
            {
                return true;
            }
        }

        return false;
    }

    public bool isOmok(bool flag)
    {
        STONE currentStone = flag ? STONE.WHITE : STONE.BLACK;

        for(int i = 0; i < 19; i++)
        {
            for(int k = 0; k < 19; k++)
            {
                if(fourWaySearch(i, k , flag))
                {
                    Debug.Log(currentStone + "이(가) 이겼습니다.");
                    return true;
                }
            }
        }

        return false;
    }
}
