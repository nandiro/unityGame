using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NovelFrontText : UtilUI
{
    public static string currentFrontText = string.Empty;      // 現在の文字列
    public static float frontTimeUnitilDisplay = 0;  // 表示にかかる時間
    public static float frontTimeElapsed = 0.1f;   // 文字列の表示を開始した時間
    public static int frontLastUpdateCharacter = -1;   // 表示中の文字数

    //文字を一文字ずつ表示する
    public static float intervalForCharacterDisplay = 0.05f;

    // 文字が最後まで表示されているかどうかの判定式
    private static bool IsCompleteDisplayText
    {
        get { return Time.time > frontTimeElapsed + frontTimeUnitilDisplay; }
    }

    public static void Display(string[] currentData)
    {
        Wait(currentData[CSV_WAIT]);
        if (IsDelayTime)
        {
            DisplayFrontText(currentData);
        }
        isClicked = false;
    }

    public static void Hide(string[] currentData)
    {
        Wait(currentData[CSV_WAIT]);
        if (IsDelayTime)
        {
            NovelManager.frontText.enabled = false;
            currentLine++;
        }       
    }

    private static void DisplayFrontText(string[] currentData)
    {
        if (IsCompleteDisplayText)
        {
            SetColor(currentData[CSV_FADE_TYPE]);
            SetNextLine(currentData[CSV_TEXT]);
        }
        else
        {
            frontTimeUnitilDisplay = 0;
        }
    }

    // 文字色の変更
    private static void SetColor(string color)
    {
        switch (color)
        {
            case "":
            case "Black":
                NovelManager.frontText.color = new Color(0.0f, 0.0f, 0.0f);
                break;
            case "White":
                NovelManager.frontText.color = new Color(1.0f, 1.0f, 1.0f);
                break;
            default :
                Debug.Log("Not Color");
                break;
        }
    }
    
    // 文字の表示
    private static void SetNextLine(string text)
    {
        currentFrontText = text;
        NovelManager.frontText.enabled = true;
        currentLine++;
        // 想定表示時間と現在の時刻をキャッシュ
        frontTimeUnitilDisplay = currentFrontText.Length * intervalForCharacterDisplay;
        frontTimeElapsed = Time.time;

        // 文字カウントを初期化
        frontLastUpdateCharacter = -1;
    }

    // 文字を一文字ずつ表示する(Update内に置く)
    public static void DisplayLine()
    {

        NovelManager.frontText.text = currentFrontText;
        /*

        // クリックから経過した時間が想定表示時間の何％か確認し、表示文字を出す
        int displayCharacterCount = (int)(Mathf.Clamp01((Time.time - frontTimeElapsed) / frontTimeUnitilDisplay) * currentFrontText.Length);

        // 表示文字数が前回の表示文字数と異なるならテキストを更新する
        if (displayCharacterCount != frontLastUpdateCharacter && currentFrontText != "")
        {
            NovelManager.frontText.text = hideTag(currentFrontText.Substring(0, displayCharacterCount));
            frontLastUpdateCharacter = displayCharacterCount;
        }
        */
    }

    // タグを表示させないようにする
    public static string hideTag(string text)
    {
        if (text.Contains("<"))
        {
            if (countChar(text, '>') % 2 == 0 && countChar(text, '>') != 0)
            {
                return text;
            }
            else if (countChar(text, '<') % 2 == 1)
            {
                return text.Remove(text.LastIndexOf("<"));
            }
            else if (countChar(text, '<') % 2 == 0)
            {
                return text.Remove(text.LastIndexOf("<", (text.LastIndexOf("<") - 1)));
            }
        }
        return text;
    }
 
    // 文字列の中に指定した文字がいくつあるのか数える
    public static int countChar(string text, char c)
    {
        return text.Length - text.Replace(c.ToString(), "").Length;
    }
}
