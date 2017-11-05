using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

    public string[] scenarios; // シナリオを格納する
    public Text uiText; // uiTextへの参照を保つ

    private string textName;
    private TextAsset csvFile; // CSVファイル
    private List<string[]> csvDatas;// CSVの中身を入れるリスト
    private const int CSV_TEXT = 3;
    private const int CSV_START = 1;
    
    //文字を一文字ずつ表示する
    float intervalForCharacterDisplay = 0.05f;

    private int currentLine = CSV_START;        // 表示している文字数
    private string currentText = string.Empty;      // 現在の文字列
    private float timeUnitilDisplay = 0;  // 表示にかかる時間
    private float timeElapsed = 0.1f;   // 文字列の表示を開始した時間
    private int lastUpdateCharacter = -1;   // 表示中の文字数

    // Use this for initialization
    void Start () {
        csvDatas = CSV.Read("aaaa");
        uiText = this.GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
 
    }

    // 文字が最後まで表示されているかどうかの判定式
    public bool IsCompleteDisplayText
    {
        get { return Time.time > timeElapsed + timeUnitilDisplay; }
    }

    // 文字の表示を行う 
    void DisplayLine()
    {
        if (IsCompleteDisplayText)
        {
            if (currentLine < csvDatas.Count && Input.GetMouseButtonDown(0))
            {
                if (Wait(3))
                {
                    SetNextLineRandam();
                }
                
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
            {
                timeUnitilDisplay = 0;
            }
        }
        // クリックから経過した時間が想定表示時間の何％か確認し、表示文字を出す
        int displayCharacterCount = (int)(Mathf.Clamp01((Time.time - timeElapsed) / timeUnitilDisplay) * currentText.Length);

        // 表示文字数が前回の表示文字数と異なるならテキストを更新する
        if (displayCharacterCount != lastUpdateCharacter)
        {
            uiText.text = currentText.Substring(0, displayCharacterCount);
            lastUpdateCharacter = displayCharacterCount;
        }
    }
    // 最初の文字を表示
    void SetNextLine()
    {
        int nextCurrentText = 1;
        currentText = (csvDatas[currentLine][CSV_TEXT]);
        while (CSV_TEXT + nextCurrentText < csvDatas[currentLine].Length)
        {
            currentText += ("\n" + csvDatas[currentLine][CSV_TEXT + nextCurrentText]);
            nextCurrentText++;
        }
        currentLine++;

        // 想定表示時間と現在の時刻をキャッシュ
        timeUnitilDisplay = currentText.Length * intervalForCharacterDisplay;
        timeElapsed = Time.time;

        // 文字カウントを初期化
        lastUpdateCharacter = -1;
    }


    // 文字をセット
    void SetNextLineRandam ()
    {
        int nextCurrentText = 1;
        currentLine = Random.Range(2, csvDatas.Count);
        currentText = (csvDatas[currentLine][CSV_TEXT]);
        while (CSV_TEXT + nextCurrentText < csvDatas[currentLine].Length)
        {
            currentText += ("\n" + csvDatas[currentLine][CSV_TEXT+ nextCurrentText]);
            nextCurrentText++;
        }

        // 想定表示時間と現在の時刻をキャッシュ
        timeUnitilDisplay = currentText.Length * intervalForCharacterDisplay;
        timeElapsed = Time.time;

        // 文字カウントを初期化
        lastUpdateCharacter = -1;
    }

    private bool Wait(float seconds)
    {
        float timeMax = seconds + Time.time;
        
        if (timeMax <= Time.time)
        {
            return true;    
        }
        return false;
    }

    private IEnumerable DelayMethod(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
    }
    
}
