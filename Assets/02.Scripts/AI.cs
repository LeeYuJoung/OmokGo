using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    //    �˰���
    // 1. �� ���� 4���� ���� ã�´�.
    // 2. ���� ���� 4���� ���� ã�´�.
    // 3. �� ���� 3���� ���� �R�´�.
    // 4. ���� ���� 3���� ���� ã�´�.
    // 5. �� ���� ���Ӽ��� ã�´�. ~> ���ӵ� ������ ���� �����ο� (4�� > 3�� > 2�� > 1��) 
    // ����, ���� ���� ���ļ� ����

    //    ���� AI �˰���
    // 1. 4���� �̾������� �� �켱������ ����
    // 2. ������ ������ ���� 2+1, 1+2 ������ ���� ã�� �� ���̸� �Ų�
    // 3. ������ ������ ���� 3���� ���� ã��
    // 4. �� �� �׸��� ���� �� ���� �̾��� ���� ���� �� ����ġ ���ؼ� ���� ��ġ ����
    // 4-1) �⺻���� ����ġ�� ���� ���� ���� �� ����
    // 4-2) ���� �׸񿡼� �������밡 ���� ��� �� ���ݿ� ������ �� ����
    // 4-3) �� ���� �׸񿡼� ������ �������� ���� ��� �� ������ �� ã��
    // 4-4) �׷��� ���ٸ� �������� ������

    public Checkerboard checkerboard;

    void Start()
    {
        checkerboard = GameObject.Find("Checkerboard").GetComponent<Checkerboard>();
    }

    public int AlphaBetaPruning(int depth, int alpha, int beta)
    {
        if (depth == 4)
        {
            return 0;
        }

        if(depth % 2 == 0)
        {
            // AI ����
            int v = int.MinValue;
            bool pruning = false;

            for(int x = 0; x < Checkerboard.BOARD_SIZE; x++)
            {
                for(int y = 0; y < Checkerboard.BOARD_SIZE; y++)
                {
                    int currentStone = checkerboard.board[x, y];
                    bool flag = false;

                    // ���� ��ǥ�� ���� ���� �� &&  �ֺ��� ���� ���� �� ���� ����
                    if(currentStone == 0)
                    {
                        for(int k = 0; k < 8; k++)
                        {

                        }

                        if (flag)
                        {
                            checkerboard.board[x, y] = Checkerboard.WHITE;
                            int temp = AlphaBetaPruning(depth + 1, alpha, beta);

                            if(v < temp)
                            {
                                v = temp;

                                if(depth == 0)
                                {

                                }
                            }
                            checkerboard.board[x, y] = 0;
                            alpha = Mathf.Max(alpha, v);

                            // ����ġ��
                            if(beta <= alpha)
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
}
