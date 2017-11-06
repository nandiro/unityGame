using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonMove : MonoBehaviour {

    private static Vector2 touchStartPos;
    private static Vector2 touchEndPos;

    public static void Flick()
    {

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            touchStartPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);    
        }
        
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            touchEndPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }

        GetDirection();
           
    }

    private static string GetDirection()
    {
        string Direction = "none";
        float directionX = touchEndPos.x - touchStartPos.x;
        float directionY = touchEndPos.y - touchStartPos.y;

        if(Mathf.Abs(directionX) < Mathf.Abs(directionY))
        {
            if(30 < directionX)
            {
                // 右向きにフリック;
                Direction = "right";
            } else if (directionX < -30)
            {
                // 左向きにフリック;
                Direction = "left";
            }
        }


        return Direction;
    }

}
