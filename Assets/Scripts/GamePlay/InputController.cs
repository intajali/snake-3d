using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameConstants;

public class InputController : MonoBehaviour
{
    PlayerController playerController;
    public enum Axis
    {
        Horizontal,
        Vertical
    };

    int horizontal = 0, vertical = 0;

    void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    void Update()
    {
        horizontal = 0;
        vertical = 0;
        GetKeyboardInput();
    }


    private void GetKeyboardInput()
    {
        horizontal = GetAxis(Axis.Horizontal);
        vertical = GetAxis(Axis.Vertical);

        if (horizontal != 0)
            vertical = 0;

        if(horizontal != 0)
        {
            playerController.SetDirection(horizontal == 1 ? Direction.RIGHT : Direction.LEFT);
        }else if(vertical != 0)
        {
            playerController.SetDirection(vertical == 1 ? Direction.UP : Direction.DOWN);
        }
    }

    int GetAxis(Axis axis)
    {
        if(axis == Axis.Horizontal)
        {
            bool left = Input.GetKeyDown(KeyCode.LeftArrow);
            bool right = Input.GetKeyDown(KeyCode.RightArrow);

            if (left)
                return -1;
            if (right)
                return 1;

            return 0;
        }else if(axis == Axis.Vertical)
        {
            bool up = Input.GetKeyDown(KeyCode.UpArrow); 
            bool down = Input.GetKeyDown(KeyCode.DownArrow);

            if (up)
                return 1;
            if (down)
                return -1;

            return 0;
        }
        return 0;
    }
}
