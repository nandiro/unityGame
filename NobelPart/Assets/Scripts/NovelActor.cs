using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NovelActor : UtilUI {

    public static void Display(string[] currentData)
    {
        // 指定時間、開始を遅らせる
        Wait(currentData[CSV_WAIT]);
        if (IsDelayTime)
        {
            DisplayActor(currentData[CSV_POSITION], currentData[CSV_PATH]);
            currentLine++;
        }    
    }

    private static void DisplayActor(string position, string image)
    {
        switch (position)
        {
            case "Left":
                NovelManager.centerActor.enabled = false;
                NovelManager.leftActor.enabled = true;
                NovelManager.leftActor.sprite = GetResourcesSprite(image);
                break;
            case "Right":
                NovelManager.centerActor.enabled = false;
                NovelManager.rightActor.enabled = true;
                NovelManager.rightActor.sprite = GetResourcesSprite(image);
                break;
            case "Center":
                NovelManager.leftActor.enabled = false;
                NovelManager.rightActor.enabled = false;
                NovelManager.centerActor.enabled = true;
                NovelManager.centerActor.sprite = GetResourcesSprite(image);
                break;
            case "LeftDelete":
                NovelManager.leftActor.enabled = false;
                break;
            case "RightDelete":
                NovelManager.rightActor.enabled = false;
                break;
            case "CenterDelete":
                NovelManager.centerActor.enabled = false;
                break;
            default:
                Debug.Log("miss mach position");
                break;
        }
    }
}
