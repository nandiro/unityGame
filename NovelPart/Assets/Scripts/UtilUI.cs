using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UtilUI : MonoBehaviour {

    public const int CSV_COMMAND = 0;
    public const int CSV_WAIT = 1;
    public const int CSV_POSITION = 2;
    public const int CSV_TEXT = 3;
    public const int CSV_FADE_TYPE = 4;
    public const int CSV_FADE_TIME = 5;
    public const int CSV_BALOON_TYPE = 6;
    public const int CSV_PATH = 7; 

    protected static float delayTime = 1.0f; //Waitの開始時刻
    protected static int doneLine = 0;    // Waitを実行したコマンド行

    protected static bool isClicked = false;

    protected static int currentLine = 0; // 実行しているコマンド行

    public static Color originalColor = new Color(1.0f, 1.0f, 1.0f);
    public static Color grayScale = new Color(0.3f, 0.3f, 0.4f);

    // 待機時間を越えたかどうかの判定式
    public static bool IsDelayTime
    {
        get { return Time.time >= delayTime; }
    }

    // 待機時間を設定する
    public static void Wait(string waitTime)
    {
        // その行がWaitを実行したかどうか
        if (doneLine != currentLine)
        {
            if(waitTime == "")
            {
                waitTime = "0";
            }
            delayTime = Time.time + float.Parse(waitTime);
            doneLine = currentLine;
        }
        
    }

    //Resources/Spriteから画像をSpriteとして読み込み
    public static Sprite GetResourcesSprite(string path)
    {
        Sprite sprite = null;
        sprite = Resources.Load<Sprite>("Sprites/" + path);
        return sprite;
    }
}
