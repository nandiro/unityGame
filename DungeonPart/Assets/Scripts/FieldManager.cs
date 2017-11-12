using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FieldManager : MonoBehaviour {

    public static Image backImage;
    private static bool isRunning = false;
    private float waitAnimeTime = 0.15f;

    // Use this for initialization
    void Start () {
        backImage = GameObject.Find("BackCanvas/Back/BackImage").GetComponent<Image>();
    }

    // Update is called once per frame        
    void Update () {
        FlickAction();    	
	}

    private void FlickAction()
    {
        string flick = Flick.Get();
        switch (flick)
        {
            case "up":
                // 上フリックされた時の処理
                Debug.Log("up");
                StartCoroutine(FlickUpAction(flick));
                break;
            case "down":
                // 下フリックされた時の処理
                Debug.Log("down");
                StartCoroutine(FlickDownAction(flick));
                break;
            case "right":
                // 右フリックされた時の処理
                Debug.Log("right");
                StartCoroutine(FlickRightAction(flick));
                break;
            case "left":
                // 左フリックされた時の処理
                Debug.Log("left");
                StartCoroutine(FlickLeftAction(flick));
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

    // 上フリック
    private IEnumerator FlickUpAction(string flick)
    {
        // 他のコルーチンが動いているならば　このコルーチンを終了
        if (isRunning) yield break;
        // コルーチン開始
        isRunning = true;

        ScreenShift.In(flick);
        // ScreenShiftIn待機時間。あとでAnimationの終了まで待機するコルーチンか何かを作る
        yield return new WaitForSeconds(waitAnimeTime);

        DisplayBackImage("3");

        ScreenShift.Out(flick);
        
        // コルーチン終了
        isRunning = false;
        yield break;
    }

    // 下フリック
    private IEnumerator FlickDownAction(string flick)
    {
        // 他のコルーチンが動いているならば　このコルーチンを終了
        if (isRunning) yield break;
        // コルーチン開始
        isRunning = true;

        ScreenShift.In(flick);
        // ScreenShiftIn待機時間。あとでAnimationの終了まで待機するコルーチンか何かを作る
        yield return new WaitForSeconds(waitAnimeTime);

        DisplayBackImage("9");

        ScreenShift.Out(flick);

        // コルーチン終了
        isRunning = false;
        yield break;
    }

    // 右フリック
    private IEnumerator FlickRightAction(string flick)
    {
        // 他のコルーチンが動いているならば　このコルーチンを終了
        if (isRunning) yield break;
        // コルーチン開始
        isRunning = true;

        ScreenShift.In(flick);
        // ScreenShiftIn待機時間。あとでAnimationの終了まで待機するコルーチンか何かを作る
        yield return new WaitForSeconds(waitAnimeTime);

        DisplayBackImage("1254");

        ScreenShift.Out(flick);

        // コルーチン終了
        isRunning = false;
        yield break;
    }

    // 左フリック
    private IEnumerator FlickLeftAction(string flick)
    {
        // 他のコルーチンが動いているならば　このコルーチンを終了
        if (isRunning) yield break;
        // コルーチン開始
        isRunning = true;

        ScreenShift.In(flick);
        // ScreenShiftIn待機時間。あとでAnimationの終了まで待機するコルーチンか何かを作る
        yield return new WaitForSeconds(waitAnimeTime);

        DisplayBackImage("7");

        ScreenShift.Out(flick);

        // コルーチン終了
        isRunning = false;
        yield break;
    }

    private static void DisplayBackImage(string imagePath)
    {
        backImage.sprite = Resources.Load<Sprite>("Sprites/BackGraund/" + imagePath);
    }

}
