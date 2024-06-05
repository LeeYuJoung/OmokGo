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
            // AI ����
            int v = int.MinValue;
            bool pruning = false;

            for (int x = 0; x < Checkerboard.BOARD_SIZE; x++)
            {
                for (int y = 0; y < Checkerboard.BOARD_SIZE; y++)
                {
                    int currentStone = checkerboard.board[x, y];
                    bool flag = false;

                    // ���� ��ǥ�� ���� ���� �� �ֺ��� ���� ���� �� ���� ����
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

                            // ����ġ��
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
            // �÷��̾� ����
            return 0;
        }
    }
    #endregion

    // ����ġ ���
    public void GetStatus()
    {
        for(int x = 0; x < Checkerboard.BOARD_SIZE; x++)
        {
            for(int y = 0; y < Checkerboard.BOARD_SIZE; y++)
            {
                // ���� ��ġ�� ���� ������ ����
                if (checkerboard.board[x, y] == 0) continue;

                // ���� ��������� ������ ���� �ʴ´ٸ� ����
                // 01. ���� ���� Ȯ��
                // 02. �� ĭ ����� �ִ��� Ȯ��
                // 03. �� ���� ���� �ִ��� Ȯ��
            }
        }
    }

    // �͹̳� ����� ����ġ(���� ��)�� ���ϴ� �Լ�
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

    // ����ġ�� �������� AI�� ������ ��ġ �Ǻ��ϴ� �Լ�
    public void SetAI()
    {
         
    }
}
