using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NovelFront : UtilUI {

    private static float fadeSpeed = 0.0f;
    private static float alpha = 0.0f;

    public static void Display(string[] currentData)
    {
        // 指定時間、開始を遅らせる
        Wait(currentData[CSV_WAIT]);
       
        if (IsDelayTime)
        {
            FrontManager(currentData);    
        }
            
    }

    private static void FrontManager(string[] currentData)
    {
        // fadeにかかる時間を設定
        if(float.Parse(currentData[CSV_FADE_TIME]) != 0)
        {
            fadeSpeed = 1.0f / (float.Parse(currentData[CSV_FADE_TIME]) * 60f);

        } else
        {
            fadeSpeed = 1.0f;
            Debug.Log("fade speed 1.0");
        }

        switch (currentData[CSV_COMMAND]+currentData[CSV_FADE_TYPE])
        {
            case "FadeOut":
            case "FadeOutBlack":
                FadeOut(1.0f, 0.0f);
                break;
            case "FadeOutWhite":
                FadeOut(1.0f, 1.0f);
                break;
            case "FadeOutGray":
                fadeSpeed /= 2.0f;
                FadeOut(0.5f, 0.0f);
                break;
            case "FadeIn":
            case "FadeInBlack":
                FadeIn(0.0f, 0.0f);
                break;
            case "FadeInWhite":
                FadeIn(0.0f, 1.0f);
                break;
            case "FadeInGray":
                fadeSpeed /= 2.0f;
                FadeIn(0.0f, 0.0f);
                break;
            case "FadeInBtoG":
                fadeSpeed /= 4.0f;
                FadeIn(0.5f, 0.0f);
                break;
            default:
                Debug.Log(currentData[CSV_COMMAND] + currentData[CSV_FADE_TYPE] + " FadeType Command miss");
                break;
        }

    }

    //フェードアウトorグレースケールorホワイトアウト
    public static void FadeOut(float alphaKey, float colorFloat)
    {
        if (alpha < alphaKey)
        {
            alpha += fadeSpeed;
            NovelManager.frontPanel.color = new Color(colorFloat, colorFloat, colorFloat, alpha);            
        }
        else
        {
            currentLine++;
        }

    }

    //フェードアウトorグレースケールから戻るorホワイトアウトから戻る
    public static void FadeIn(float alphaKey, float colorFloat)
    {

        if (alphaKey < alpha)
        {
            alpha -= fadeSpeed;
            NovelManager.frontPanel.color = new Color(colorFloat, colorFloat, colorFloat, alpha);
        }
        else
        {
            currentLine++;
        }

    }
}
