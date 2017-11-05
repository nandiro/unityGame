using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NovelManager : UtilUI {

    public static Text baloonText;
    public static Image baloonImage;
    public static Image leftActor;
    public static Image rightActor;
    public static Image centerActor;
    public static Text frontText;
    public static Image frontPanel;
    public static Image backImage;
    public string CSVPath;

    private List<string[]> csvDatas;

    //UI初期化メソッド
    private void InitUI()
    {
        baloonText = GameObject.Find("Canvas/Baloon/BaloonText").GetComponent<Text>();
        baloonImage = GameObject.Find("Canvas/Baloon/BaloonImage").GetComponent<Image>();
        leftActor = GameObject.Find("Canvas/Actor/LeftActor").GetComponent<Image>();
        rightActor = GameObject.Find("Canvas/Actor/RightActor").GetComponent<Image>();
        centerActor = GameObject.Find("Canvas/Actor/CenterActor").GetComponent<Image>();
        frontPanel = GameObject.Find("Canvas/Front/FrontPanel").GetComponent<Image>();
        frontText = GameObject.Find("Canvas/Front/FrontText").GetComponent<Text>();
        backImage = GameObject.Find("Canvas/Back/BackImage").GetComponent<Image>();
        frontPanel.enabled = true;
        frontText.enabled = false;
        baloonImage.enabled = false;
        baloonText.enabled = false;
        rightActor.enabled = false;
        leftActor.enabled = false;
        centerActor.enabled = false;
        isClicked = true;
    }

    // Use this for initialization
    void Start () {
        InitUI();
        csvDatas = CSV.Read(CSVPath);
        currentLine = 1;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            isClicked = true;
        }

        if (isClicked && currentLine < csvDatas.Count )
        {
            NovelCommandManager(csvDatas);
            //Debug.Log(currentLine);
            //Debug.Log(csvDatas[currentLine][CSV_COMMAND] + " " + csvDatas[currentLine][CSV_TEXT]);       
        }

        // 文字を一文字ずつ表示するメソッド   
        NovelBaloon.DisplayLine();
        NovelFrontText.DisplayLine();

    }

    private void NovelCommandManager(List<string[]> csvDatas)
    {
        switch (csvDatas[currentLine][CSV_COMMAND])
        {

            case "SetCharacter":
                NovelActor.Display(csvDatas[currentLine]);
                break;
            case "SetBackGraund":
                NovelBack.Display(csvDatas[currentLine]);
                break;
            case "Message":
                NovelBaloon.Display(csvDatas[currentLine]);            
                break;
            case "HideMessage":
                NovelBaloon.Hide(csvDatas[currentLine]);
                break;
            case "FadeIn":
            case "FadeOut":
                NovelFront.Display(csvDatas[currentLine]);
                break;
            case "WindowMessage":
                frontText.enabled = true;
                NovelFrontText.Display(csvDatas[currentLine]);
                break;
            case "HideWindowMessage":
                NovelFrontText.Hide(csvDatas[currentLine]);
                break;
            default:
                Debug.Log(currentLine + csvDatas[currentLine][CSV_COMMAND] +" command miss");
                break;
        }
    }
    
                                                   
}
