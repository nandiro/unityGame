using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSV : MonoBehaviour {

    public static List<string[]> Read(string textName)
    {
        int column = 0;
        List<string[]> csvDatas = new List<string[]>(); // CSVの中身を入れるリスト   
        TextAsset csvFile = Resources.Load("CSV/" + textName) as TextAsset;// Resouces/CSV/のCSVファイルを読み込む
        StringReader reader = new StringReader(csvFile.text);

        while (reader.Peek() > -1)
        {
            string line = reader.ReadLine();
            if (column < countChar(line, ','))
            {
                // CSVの最大カラム数を保存する
                column = countChar(line, ',');
            } else if(countChar(line, ',') < column)
            {
                // 行が最大カラム数に達していない場合、もう一行読み込んで追加する
                line = line + "\n" + reader.ReadLine();
            }
            csvDatas.Add(line.Split(','));
        }
        return csvDatas;
    }

    // 文字列の中に指定した文字がいくつあるのか数える
    public static int countChar(string text, char c)
    {
        return text.Length - text.Replace(c.ToString(), "").Length;
    }
}
