using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkerboard : MonoBehaviour
{
    public const int BOARD_SIZE = 17;
    public const int BLACK = 1;
    public const int WHITE = 2;

    public int[,] board = new int[BOARD_SIZE, BOARD_SIZE]
    {
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
        {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 }
    };

    public int gameStatus = 0;

    public void Init_Board()
    {
        for(int i = 0; i < BOARD_SIZE; i++)
        {

        }
    }

    public void CheckFiveInRange()
    {

    }

    public void DrawScreen(GameObject _stone)
    {
        RaycastHit hit;

        if (Physics.Raycast(_stone.transform.position, Vector3.up, out hit, 0.5f))
        {
            Debug.Log(":: 위에 바둑돌 있음 ::");
        }
        else if (Physics.Raycast(_stone.transform.position, Vector3.down, out hit, 0.5f))
        {
            Debug.Log(":: 아래 바둑돌 있음 ::");
        }
        else if (Physics.Raycast(_stone.transform.position, Vector3.right, 0.5f))
        {
            Debug.Log(":: 오른쪽에 바둑돌 있음 ::");
        }
        else if (Physics.Raycast(_stone.transform.position, Vector3.left, out hit, 0.5f))
        {
            Debug.Log(":: 왼쪽에 바둑돌 있음 ::");
        }
        else if (Physics.Raycast(_stone.transform.position, (Vector3.up + Vector3.right).normalized, out hit, 0.5f))
        {
            Debug.Log(":: 오른쪽 위 대각선에 바둑돌 있음 ::");
        }
        else if (Physics.Raycast(_stone.transform.position, (Vector3.left + Vector3.up).normalized, out hit, 0.5f))
        {
            Debug.Log(":: 왼쪽 위 대각선에 바둑돌 있음 ::");
        }
        else if (Physics.Raycast(_stone.transform.position, (Vector3.down + Vector3.right).normalized, out hit, 0.5f))
        {
            Debug.Log(":: 오른쪽 아래 대각선에 바둑돌 있음 ::");
        }
        else if (Physics.Raycast(_stone.transform.position, (Vector3.down + Vector3.left).normalized, out hit, 0.5f))
        {
            Debug.Log(":: 왼쪽 아래 대각선에 바둑돌 있음 ::");
        }
    }
}
