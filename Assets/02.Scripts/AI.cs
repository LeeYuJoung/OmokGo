using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    //    알고리즘
    // 1. 내 돌이 4개인 지점 찾는다.
    // 2. 상대방 돌이 4개인 지점 찾는다.
    // 3. 내 돌이 3개인 지점 첮는다.
    // 4. 상대방 돌이 3개인 지점 찾는다.
    // 5. 내 돌의 연속성을 찾는다. ~> 연속된 개수에 따라 점수부여 (4개 > 3개 > 2개 > 1개) 
    // 공격, 수비 점수 합쳐서 착수

    //    오목 AI 알고리즘
    // 1. 4개가 이어져있을 시 우선순위로 막음
    // 2. 양쪽이 막히지 않은 2+1, 1+2 형태의 돌을 찾아 그 사이를 매꿈
    // 3. 양쪽이 막히지 않은 3개의 돌을 찾음
    // 4. 위 세 항목이 없을 시 돌이 이어진 것의 수를 세 가중치 구해서 착수 위치 정함
    // 4-1) 기본적인 가중치를 구해 제일 높은 것 막음
    // 4-2) 위의 항목에서 여러군대가 나올 경우 내 공격에 유리한 곳 착수
    // 4-3) 또 위의 항목에서 우위가 가려지지 않을 경우 방어에 유리한 곳 찾음
    // 4-4) 그래도 없다면 랜덤으로 돌리기

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
            // AI 차례
            int v = int.MinValue;
            bool pruning = false;

            for(int x = 0; x < Checkerboard.BOARD_SIZE; x++)
            {
                for(int y = 0; y < Checkerboard.BOARD_SIZE; y++)
                {
                    int currentStone = checkerboard.board[x, y];
                    bool flag = false;

                    // 현재 좌표에 돌이 없을 시 &&  주변에 돌이 있을 시 돌을 놓음
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

                            // 가지치기
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
            // 플레이어 차례
            return 0;
        }
    }
}
