﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flick : MonoBehaviour {

    private static int cancelFlame = 0; // フリック長押し判定  60で1秒
    private static Vector2 touchStartPos;
    private static Vector2 touchEndPos;
    private static string Direction = "none";

    public static string Get()
    {
        CheckInput();
        return Direction;
    }

    private static void CheckInput()
    {
        if (!Input.GetKey(KeyCode.Mouse0)) {
            Direction = "none";
        } else
        {
            cancelFlame++;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            touchStartPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            touchEndPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            GetDirection();
            cancelFlame = 0;
        }
    }

    private static void GetDirection()
    {
        float directionX = touchEndPos.x - touchStartPos.x;
        float directionY = touchEndPos.y - touchStartPos.y;

        //Debug.Log(directionX);
        //Debug.Log(directionY);

        // タッチしている時間が60フレーム以内であれば
        Debug.Log(cancelFlame);
        if (cancelFlame < 60)
        {

            if (Mathf.Abs(directionY) < Mathf.Abs(directionX))
            {
                if (30 < directionX)
                {
                    // 右向きにフリック;
                    Direction = "right";
                }
                else if (directionX < -30)
                {
                    // 左向きにフリック;
                    Direction = "left";
                }
            }
            else if (Mathf.Abs(directionX) < Mathf.Abs(directionY))
            {
                if (30 < directionY)
                {
                    // 右向きにフリック;
                    Direction = "up";
                }
                else if (directionY < -30)
                {
                    // 左向きにフリック;
                    Direction = "down";
                }
            }
            else
            {
                Direction = "touch";
            }
        }else
        {
            Direction = "longTouch";
        }
    }
}
