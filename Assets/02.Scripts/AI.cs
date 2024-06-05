using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public Checkerboard checkerboard;
    public PlayerController playerController;
    public int currentState;

    void Start()
    {
        checkerboard = GameObject.Find("Checkerboard").GetComponent<Checkerboard>();
    }

    #region AlphaBetaPruning_Algorithm
    public int AlphaBetaPruning(int depth, int alpha, int beta)
    {
        if (depth == 4)
        {
            return 0;
        }

        if (depth % 2 == 0)
        {
            // AI 차례
            int v = int.MinValue;
            bool pruning = false;

            for (int x = 0; x < Checkerboard.BOARD_SIZE; x++)
            {
                for (int y = 0; y < Checkerboard.BOARD_SIZE; y++)
                {
                    int currentStone = checkerboard.board[x, y];
                    bool flag = false;

                    // 현재 좌표에 돌이 없을 시 주변에 돌이 있을 시 돌을 놓음
                    if (currentStone == 0)
                    {
                        int nx, ny;

                        for (int k = 0; k < 8; k++)
                        {
                            nx = x;
                            ny = y;

                            if (!checkerboard.CheckRange(nx, ny)) continue;

                            if (checkerboard.board[nx, ny] != 0)
                            {
                                flag = true;
                                break;
                            }
                        }

                        if (flag)
                        {
                            checkerboard.board[x, y] = Checkerboard.WHITE;
                            int temp = AlphaBetaPruning(depth + 1, alpha, beta);

                            if (v < temp)
                            {
                                v = temp;

                                if (depth == 0)
                                {

                                }
                            }
                            checkerboard.board[x, y] = 0;
                            alpha = Mathf.Max(alpha, v);

                            // 가지치기
                            if (beta <= alpha)
                            {
                                pruning = true;
                                break;
                            }
                        }
                    }
                    if (pruning)
                        break;
                }
                if (pruning)
                    break;
            }
            return v;
        }
        else
        {
            // 플레이어 차례
            return 0;
        }
    }
    #endregion

    // 가중치 계산
    public void GetStatus()
    {
        for(int x = 0; x < Checkerboard.BOARD_SIZE; x++)
        {
            for(int y = 0; y < Checkerboard.BOARD_SIZE; y++)
            {
                // 현재 위치에 돌이 없으면 무시
                if (checkerboard.board[x, y] == 0) continue;

                // 만약 양방향으로 오목이 들어가지 않는다면 무시
                // 01. 돌의 개수 확인
                // 02. 한 칸 띄워져 있는지 확인
                // 03. 한 쪽이 막혀 있는지 확인
            }
        }
    }

    // 터미널 노드의 가중치(상태 값)를 구하는 함수
    public void SetWeight()
    {
        int buff;

        if (currentState == playerController.playerStone)
        {
            buff = -1;
        }
        else
        {
            buff = 1;
        }

        for(int i = 0; i < Checkerboard.BOARD_SIZE; i++)
        {

        }
    }

    // 가중치를 바탕으로 AI가 착수할 위치 판별하는 함수
    public void SetAI()
    {
         
    }
}
