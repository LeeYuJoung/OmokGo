using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Checkerboard checkerboard;
    public GameObject stonePrefab;
    public GameObject cuser;

    public const int WHITE = 1;
    public const int BLACK = 2;
    public int playerStone = WHITE;
    
    void Start()
    {
        checkerboard = GameObject.Find("Checkerboard").GetComponent<Checkerboard>();
    }

    void Update()
    {
        if(!GameManager.Instance().isMyTurn || GameManager.Instance().isGameOver)
        {
            cuser.SetActive(false);
            return;
        }

        cuser.SetActive(true);
        MovePosition();
    }

    public void MovePosition()
    {
        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(transform.position.x < 8)
            {
                transform.position += new Vector3(0.5f, 0, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(transform.position.x > 0)
            {
                transform.position += new Vector3(-0.5f, 0, 0);
            }
        }
        else if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(transform.position.y  < 0)
            {
                transform.position += new Vector3(0, 0.5f, 0);
            }
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(transform.position.y > -8)
            {
                transform.position += new Vector3(0, -0.5f, 0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            int _x = Mathf.Abs((int)(transform.position.x / 0.5f));
            int _y = Mathf.Abs((int)(transform.position.y / 0.5f));
            Debug.Log("X : " + _x + " , " + "Y : " + _y);

            if (GameManager.Instance().isMyTurn && checkerboard.ChangeBoard(_x, _y, playerStone))
            {
                GameObject _stone = Instantiate(stonePrefab, transform.position, Quaternion.identity);
                _stone.transform.parent = checkerboard.transform;

                if (checkerboard.CheckWin(playerStone))
                {
                    Debug.Log("::: 오목 완성 :::");
                }
            }
        }
    }
}
