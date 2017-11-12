using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScreenShift : MonoBehaviour {

    private static Animator screenShift;
    
    // Use this for initialization
    void Start () {
        screenShift = GetComponent<Animator>();
    }
		
	public static void In(string flick)
    {

        switch (flick)
        {
            case "up":
                // 上フリックされた時の処理
                screenShift.SetBool("isFunctioned", false);
                screenShift.Play("bottom_in");
                break;
            case "down":
                // 下フリックされた時の処理
                screenShift.SetBool("isFunctioned", false);
                screenShift.Play("top_in");
                break;
            case "right":
                // 右フリックされた時の処理
                screenShift.SetBool("isFunctioned", false);
                screenShift.Play("left_in");
                break;
            case "left":
                // 左フリックされた時の処理
                screenShift.SetBool("isFunctioned", false);
                screenShift.Play("right_in");
                break;
            case "touch":
                // タッチされた時の処理
                break;
            case "none":
                // 何もしていない状態
                break;
        }
    }

    public static void Out(string flick)
    {
        switch (flick)
        {
            case "up":
                // 上フリックされた時の処理
                screenShift.SetBool("isFunctioned", true);
                screenShift.Play("bottom_out");
                break;
            case "down":
                // 下フリックされた時の処理
                screenShift.Play("top_out");
                screenShift.SetBool("isFunctioned", true);
                break;
            case "right":
                // 右フリックされた時の処理
                screenShift.Play("left_out");
                screenShift.SetBool("isFunctioned", true);
                break;
            case "left":
                // 左フリックされた時の処理
                screenShift.Play("right_out");
                screenShift.SetBool("isFunctioned", true);
                break;
            case "touch":
                // タッチされた時の処理
                break;
            case "none":
                // 何もしていない状態
                break;
        }
    }

    private static void isPlayedScreenShift()
    {
        // ベースレイヤーのアニメーションの再生が終わっていたら
        if (1 < screenShift.GetCurrentAnimatorStateInfo(0).normalizedTime)
        {
            // setに戻る
            screenShift.SetBool("isPlayed", true);
        }
    }

    private static void isFunctionedScreenShift()
    {
        // ベースレイヤーのアニメーションの再生が終わっていたら
        if (1 < screenShift.GetCurrentAnimatorStateInfo(0).normalizedTime)
        {
            // setに戻る
            screenShift.SetBool("isFunctioned", true);
            Debug.Log(screenShift.GetCurrentAnimatorStateInfo(0).normalizedTime);
        }
    }
}
