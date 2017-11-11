using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame        
	void Update () {
        FlickAction();    	
	}

    private static void FlickAction()
    {
        switch (Flick.Get())
        {
            case "up":
                // 上フリックされた時の処理
                Debug.Log("up");
                ScreenShift.In();
                ScreenShift.Out();
                break;
            case "down":
                // 下フリックされた時の処理
                Debug.Log("down");
                break;
            case "right":
                // 右フリックされた時の処理
                Debug.Log("right");
                break;
            case "left":
                // 左フリックされた時の処理
                Debug.Log("left");
                break;
            case "touch":
                // タッチされた時の処理
                Debug.Log("touch");
                break;
            case "none":
                // 何もしていない状態
                break;
        }
    }
}
