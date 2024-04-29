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
            Debug.Log(":: ���� �ٵϵ� ���� ::");
        }
        else if (Physics.Raycast(_stone.transform.position, Vector3.down, out hit, 0.5f))
        {
            Debug.Log(":: �Ʒ� �ٵϵ� ���� ::");
        }
        else if (Physics.Raycast(_stone.transform.position, Vector3.right, 0.5f))
        {
            Debug.Log(":: �����ʿ� �ٵϵ� ���� ::");
        }
        else if (Physics.Raycast(_stone.transform.position, Vector3.left, out hit, 0.5f))
        {
            Debug.Log(":: ���ʿ� �ٵϵ� ���� ::");
        }
        else if (Physics.Raycast(_stone.transform.position, (Vector3.up + Vector3.right).normalized, out hit, 0.5f))
        {
            Debug.Log(":: ������ �� �밢���� �ٵϵ� ���� ::");
        }
        else if (Physics.Raycast(_stone.transform.position, (Vector3.left + Vector3.up).normalized, out hit, 0.5f))
        {
            Debug.Log(":: ���� �� �밢���� �ٵϵ� ���� ::");
        }
        else if (Physics.Raycast(_stone.transform.position, (Vector3.down + Vector3.right).normalized, out hit, 0.5f))
        {
            Debug.Log(":: ������ �Ʒ� �밢���� �ٵϵ� ���� ::");
        }
        else if (Physics.Raycast(_stone.transform.position, (Vector3.down + Vector3.left).normalized, out hit, 0.5f))
        {
            Debug.Log(":: ���� �Ʒ� �밢���� �ٵϵ� ���� ::");
        }
    }
}
