using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NovelBack : UtilUI {

	public static void Display(string[] currentData)
    {
        // 指定時間、開始を遅らせる
        Wait(currentData[CSV_WAIT]);
        if (IsDelayTime)
        {
            DisplayBackImage(currentData[CSV_PATH]);
            currentLine++;
        }
    }
    
    private static void DisplayBackImage(string imagePath)
    {
        NovelManager.backImage.sprite = GetResourcesSprite(imagePath);
    }

}
