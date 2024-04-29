using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OmokAI : MonoBehaviour
{
    public const int BOARD_SIZE = 19;
    public const int WHITE = 1;
    public const int BLACK = 2;

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


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public int AI_Init(int[] bestPosition)
    {

        return 0;
    }
}
