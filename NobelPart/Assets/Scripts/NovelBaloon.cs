using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NovelBaloon : UtilUI {

    public static string currentBaloonText = string.Empty;      // 現在の文字列
    public static float baloonTimeUnitilDisplay = 0;  // 表示にかかる時間
    public static float baloonTimeElapsed = 0.1f;   // 文字列の表示を開始した時間
    public static int baloonLastUpdateCharacter = -1;   // 表示中の文字数

    //文字を一文字ずつ表示する
    public static float intervalForCharacterDisplay = 0.05f;

    // 文字が最後まで表示されているかどうかの判定式
    public static bool IsCompleteDisplayText
    {
        get { return Time.time > baloonTimeElapsed + baloonTimeUnitilDisplay; }
    }

    // 吹き出し表示
    public static void Display(string[] currentData)
    {
        Wait(currentData[CSV_WAIT]);
        if (IsDelayTime)
        {
            DisplayBaloonText(currentData);
        }
        isClicked = false;
    }

    // 吹き出し非表示
    public static void Hide(string[] currentData)
    {
        Wait(currentData[CSV_WAIT]);
        if (IsDelayTime)
        {
            NovelManager.baloonText.enabled = false;
            NovelManager.baloonImage.enabled = false;
            currentLine++;
        }
    }

    // 吹き出し文字表示
    private static void DisplayBaloonText(string[] currentData)
    {
        if (IsCompleteDisplayText)
        {
            SetNextLine(currentData[CSV_TEXT]);
            DisplayBaloonImage(currentData);           
        }
        else
        {
            baloonTimeUnitilDisplay = 0;
        }       
    }

    // 文字の表示
    private static void SetNextLine(string text)
    {
        currentBaloonText = text;
        NovelManager.baloonText.enabled = true;
        currentLine++;
        // 想定表示時間と現在の時刻をキャッシュ
        baloonTimeUnitilDisplay = currentBaloonText.Length * intervalForCharacterDisplay;
        baloonTimeElapsed = Time.time;

        // 文字カウントを初期化
        baloonLastUpdateCharacter = -1;
    }

    // 文字を一文字ずつ表示する(Update内に置く)
    public static void DisplayLine()
    {
        // クリックから経過した時間が想定表示時間の何％か確認し、表示文字を出す
        int displayCharacterCount = (int)(Mathf.Clamp01((Time.time - baloonTimeElapsed) / baloonTimeUnitilDisplay) * currentBaloonText.Length);

        // 表示文字数が前回の表示文字数と異なるならテキストを更新する
        if (displayCharacterCount != baloonLastUpdateCharacter && currentBaloonText != "")
        {
            NovelManager.baloonText.text = hideTag(currentBaloonText.Substring(0, displayCharacterCount));
            
            baloonLastUpdateCharacter = displayCharacterCount;
        }
    }

    // タグを表示させないようにする
    public static string hideTag(string text)
    {
        if (text.Contains("<"))
        {
            if(countChar(text,'>') % 2 == 0 && countChar(text, '>') != 0)
            {
                return text;
            } else if(countChar(text,'<') % 2 == 1)
            {
                return text.Remove(text.LastIndexOf("<"));    
            } else if(countChar(text,'<') % 2 == 0)
            {
                return text.Remove(text.LastIndexOf("<", (text.LastIndexOf("<")-1)));
            }      
        }
        return text;    
    }
    
    // 文字列の中に指定した文字がいくつあるのか数える
    public static int countChar(string text,char c)
    {
        return text.Length - text.Replace(c.ToString(), "").Length; 
    } 

    // 吹き出しの表示とキャラクターのグレースケール制御
    private static void DisplayBaloonImage(string[] currentData)
    {
        switch (currentData[CSV_POSITION]+currentData[CSV_BALOON_TYPE])
        {
            case "LeftNormal":
                //左側を通常表示、右側をグレースケール
                NovelManager.centerActor.enabled = false;
                NovelManager.leftActor.enabled = true;
                NovelManager.leftActor.color = originalColor;
                NovelManager.rightActor.color = grayScale;

                NovelManager.baloonImage.enabled = true;
                NovelManager.baloonImage.sprite = GetResourcesSprite("baloon/left_normal");
                break;
            case "RightNormal":
                //右側を通常表示、左側をグレースケール
                NovelManager.centerActor.enabled = false;
                NovelManager.rightActor.enabled = true;
                NovelManager.rightActor.color = originalColor;
                NovelManager.leftActor.color = grayScale;

                NovelManager.baloonImage.enabled = true;
                NovelManager.baloonImage.sprite = GetResourcesSprite("baloon/right_normal");
                break;
            case "CenterNormal":
                NovelManager.baloonImage.enabled = true;
                NovelManager.baloonImage.sprite = GetResourcesSprite("baloon/center_normal");
                break;
            case "LeftAccent":
                //左側を通常表示、右側をグレースケール
                NovelManager.centerActor.enabled = false;
                NovelManager.leftActor.enabled = true;
                NovelManager.leftActor.color = originalColor;
                NovelManager.rightActor.color = grayScale;

                NovelManager.baloonImage.enabled = true;
                NovelManager.baloonImage.sprite = GetResourcesSprite("baloon/left_accent");
                break;
            case "RightAccent":
                //右側を通常表示、左側をグレースケール
                NovelManager.centerActor.enabled = false;
                NovelManager.rightActor.enabled = true;
                NovelManager.rightActor.color = originalColor;
                NovelManager.leftActor.color = grayScale;

                NovelManager.baloonImage.enabled = true;
                NovelManager.baloonImage.sprite = GetResourcesSprite("baloon/right_accent");
                break;
            case "CenterAccent":
                NovelManager.baloonImage.enabled = true;
                NovelManager.baloonImage.sprite = GetResourcesSprite("baloon/center_accent");
                break;
            case "Delete":
                NovelManager.baloonImage.enabled = false;
                break;
            default:
                Debug.Log("position or baloon type miss");
                break;
        }

    }

}
