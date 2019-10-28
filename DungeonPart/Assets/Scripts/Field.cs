using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Field : MonoBehaviour {

    // cell
    private static Image c11, c12, c13, c14;
    private static Image c21, c22, c23, c24;
    private static Image c31, c32, c33, c34;
    private static Image c41, c42, c43, c44;
    // wayUD
    private static Image w0111, w1121, w2131, w3141, w4151;
    private static Image w0212, w1222, w2232, w3242, w4252;
    private static Image w0313, w1323, w2333, w3343, w4353;
    private static Image w0414, w1424, w2434, w3444, w4454;
    // wayRL
    private static Image w1011, w1112, w1213, w1314, w1415;
    private static Image w2021, w2122, w2223, w2324, w2425;
    private static Image w3031, w3132, w3233, w3334, w3435;
    private static Image w4041, w4142, w4243, w4344, w4445;

    // ImageDictionariy
    private static Dictionary<int, Image> cellImage;
    private static Dictionary<int, Image> wayImage;

    // cell Position
    public static readonly Dictionary<int, Vector3> cell = new Dictionary<int, Vector3>();

    // Use this for initialization
    void Start () {
        setCellImage();
        setWayImage();
        setCellPosition();
        hide();
    }

    private void setCellImage()
    {
        c11 = GameObject.Find("FieldMap/cell/11").GetComponent<Image>();
        c12 = GameObject.Find("FieldMap/cell/12").GetComponent<Image>();
        c13 = GameObject.Find("FieldMap/cell/13").GetComponent<Image>();
        c14 = GameObject.Find("FieldMap/cell/14").GetComponent<Image>();
        c21 = GameObject.Find("FieldMap/cell/21").GetComponent<Image>();
        c22 = GameObject.Find("FieldMap/cell/22").GetComponent<Image>();
        c23 = GameObject.Find("FieldMap/cell/23").GetComponent<Image>();
        c24 = GameObject.Find("FieldMap/cell/24").GetComponent<Image>();
        c31 = GameObject.Find("FieldMap/cell/31").GetComponent<Image>();
        c32 = GameObject.Find("FieldMap/cell/32").GetComponent<Image>();
        c33 = GameObject.Find("FieldMap/cell/33").GetComponent<Image>();
        c34 = GameObject.Find("FieldMap/cell/34").GetComponent<Image>();
        c41 = GameObject.Find("FieldMap/cell/41").GetComponent<Image>();
        c42 = GameObject.Find("FieldMap/cell/42").GetComponent<Image>();
        c43 = GameObject.Find("FieldMap/cell/43").GetComponent<Image>();
        c44 = GameObject.Find("FieldMap/cell/44").GetComponent<Image>();
        cellImage = new Dictionary<int, Image>()
        {
            { 11,c11 },{ 12,c12 },{ 13,c13 },{ 14,c14 },
            { 21,c21 },{ 22,c22 },{ 23,c23 },{ 24,c24 },
            { 31,c31 },{ 32,c32 },{ 33,c33 },{ 34,c34 },
            { 41,c41 },{ 42,c42 },{ 43,c43 },{ 44,c44 }
        };
    }

    private void setWayImage()
    {

        // Up Down
        w0111 = GameObject.Find("FieldMap/wayUD/0111").GetComponent<Image>();
        w1121 = GameObject.Find("FieldMap/wayUD/1121").GetComponent<Image>();
        w2131 = GameObject.Find("FieldMap/wayUD/2131").GetComponent<Image>();
        w3141 = GameObject.Find("FieldMap/wayUD/3141").GetComponent<Image>();
        w4151 = GameObject.Find("FieldMap/wayUD/4151").GetComponent<Image>();

        w0212 = GameObject.Find("FieldMap/wayUD/0212").GetComponent<Image>();
        w1222 = GameObject.Find("FieldMap/wayUD/1222").GetComponent<Image>();
        w2232 = GameObject.Find("FieldMap/wayUD/2232").GetComponent<Image>();
        w3242 = GameObject.Find("FieldMap/wayUD/3242").GetComponent<Image>();
        w4252 = GameObject.Find("FieldMap/wayUD/4252").GetComponent<Image>();

        w0313 = GameObject.Find("FieldMap/wayUD/0313").GetComponent<Image>();
        w1323 = GameObject.Find("FieldMap/wayUD/1323").GetComponent<Image>();
        w2333 = GameObject.Find("FieldMap/wayUD/2333").GetComponent<Image>();
        w3343 = GameObject.Find("FieldMap/wayUD/3343").GetComponent<Image>();
        w4353 = GameObject.Find("FieldMap/wayUD/4353").GetComponent<Image>();

        w0414 = GameObject.Find("FieldMap/wayUD/0414").GetComponent<Image>();
        w1424 = GameObject.Find("FieldMap/wayUD/1424").GetComponent<Image>();
        w2434 = GameObject.Find("FieldMap/wayUD/2434").GetComponent<Image>();
        w3444 = GameObject.Find("FieldMap/wayUD/3444").GetComponent<Image>();
        w4454 = GameObject.Find("FieldMap/wayUD/4454").GetComponent<Image>();

        // Right Left

        w1011 = GameObject.Find("FieldMap/wayRL/1011").GetComponent<Image>();
        w1112 = GameObject.Find("FieldMap/wayRL/1112").GetComponent<Image>();
        w1213 = GameObject.Find("FieldMap/wayRL/1213").GetComponent<Image>();
        w1314 = GameObject.Find("FieldMap/wayRL/1314").GetComponent<Image>();
        w1415 = GameObject.Find("FieldMap/wayRL/1415").GetComponent<Image>();

        w2021 = GameObject.Find("FieldMap/wayRL/2021").GetComponent<Image>();
        w2122 = GameObject.Find("FieldMap/wayRL/2122").GetComponent<Image>();
        w2223 = GameObject.Find("FieldMap/wayRL/2223").GetComponent<Image>();
        w2324 = GameObject.Find("FieldMap/wayRL/2324").GetComponent<Image>();
        w2425 = GameObject.Find("FieldMap/wayRL/2425").GetComponent<Image>();

        w3031 = GameObject.Find("FieldMap/wayRL/3031").GetComponent<Image>();
        w3132 = GameObject.Find("FieldMap/wayRL/3132").GetComponent<Image>();
        w3233 = GameObject.Find("FieldMap/wayRL/3233").GetComponent<Image>();
        w3334 = GameObject.Find("FieldMap/wayRL/3334").GetComponent<Image>();
        w3435 = GameObject.Find("FieldMap/wayRL/3435").GetComponent<Image>();

        w4041 = GameObject.Find("FieldMap/wayRL/4041").GetComponent<Image>();
        w4142 = GameObject.Find("FieldMap/wayRL/4142").GetComponent<Image>();
        w4243 = GameObject.Find("FieldMap/wayRL/4243").GetComponent<Image>();
        w4344 = GameObject.Find("FieldMap/wayRL/4344").GetComponent<Image>();
        w4445 = GameObject.Find("FieldMap/wayRL/4445").GetComponent<Image>();

        wayImage = new Dictionary<int, Image>()
        {
            { 111,w0111 }, { 1121,w1121 }, { 2131,w2131 }, { 3141,w3141 }, { 4151,w4151 },
            { 212,w0212 }, { 1222,w1222 }, { 2232,w2232 }, { 3242,w3242 }, { 4252,w4252 },
            { 313,w0313 }, { 1323,w1323 }, { 2333,w2333 }, { 3343,w3343 }, { 4353,w4353 },
            { 414,w0414 }, { 1424,w1424 }, { 2434,w2434 }, { 3444,w3444 }, { 4454,w4454 },

            { 1011,w1011 }, { 1112,w1112 }, { 1213,w1213 }, { 1314,w1314 }, { 1415,w1415 },
            { 2021,w2021 }, { 2122,w2122 }, { 2223,w2223 }, { 2324,w2324 }, { 2425,w2425 },
            { 3031,w3031 }, { 3132,w3132 }, { 3233,w3233 }, { 3334,w3334 }, { 3435,w3435 },
            { 4041,w4041 }, { 4142,w4142 }, { 4243,w4243 }, { 4344,w4344 }, { 4445,w4445 },
        };
    }

    private static void setCellPosition()
    {
        cell[11] = new Vector3(-63, -63);
        cell[12] = new Vector3(-21, -63);
        cell[13] = new Vector3(21, -63);
        cell[14] = new Vector3(63, -63);
        cell[21] = new Vector3(-63, -21);
        cell[22] = new Vector3(-21, -21);
        cell[23] = new Vector3(21, -21);
        cell[24] = new Vector3(63, -21);
        cell[31] = new Vector3(-63, 21);
        cell[32] = new Vector3(-21, 21);
        cell[33] = new Vector3(21, 21);
        cell[34] = new Vector3(63, 21);
        cell[41] = new Vector3(-63, 63);
        cell[42] = new Vector3(-21, 63);
        cell[43] = new Vector3(21, 63);
        cell[44] = new Vector3(63, 63);
    }

    // Field Map の Image を全て非表示にする
    public static void hide()
    {
        // cell を非表示にする
        c11.enabled = false;
        c12.enabled = false;
        c13.enabled = false;
        c14.enabled = false;
        c24.enabled = false;
        c21.enabled = false;
        c22.enabled = false;
        c23.enabled = false;
        c34.enabled = false;
        c31.enabled = false;
        c32.enabled = false;
        c33.enabled = false;
        c34.enabled = false;
        c41.enabled = false;
        c42.enabled = false;
        c43.enabled = false;
        c44.enabled = false;
        // 上下をつなぐ道を非表示にする
        w0111.enabled = false;
        w1121.enabled = false;
        w2131.enabled = false;
        w3141.enabled = false;
        w4151.enabled = false;

        w0212.enabled = false;
        w1222.enabled = false;
        w2232.enabled = false;
        w3242.enabled = false;
        w4252.enabled = false;

        w0313.enabled = false;
        w1323.enabled = false;
        w2333.enabled = false;
        w3343.enabled = false;
        w4353.enabled = false;

        w0414.enabled = false;
        w1424.enabled = false;
        w2434.enabled = false;
        w3444.enabled = false;
        w4454.enabled = false;
        // 左右をつなぐ道を非表示にする。
        w1011.enabled = false;
        w1112.enabled = false;
        w1213.enabled = false;
        w1314.enabled = false;
        w1415.enabled = false;

        w2021.enabled = false;
        w2122.enabled = false;
        w2223.enabled = false;
        w2324.enabled = false;
        w2425.enabled = false;

        w3031.enabled = false;
        w3132.enabled = false;
        w3233.enabled = false;
        w3334.enabled = false;
        w3435.enabled = false;

        w4041.enabled = false;
        w4142.enabled = false;
        w4243.enabled = false;
        w4344.enabled = false;
        w4445.enabled = false;
    }

    // 今いるフィールドステップを表示する
    public static void showCurrentFieldStep(FieldStep currentFieldStep)
    {
        cellImage[currentFieldStep.Cell].enabled = true;
        
        if (currentFieldStep.Up != null)
        {
            Debug.Log(currentFieldStep.Cell * 100 + currentFieldStep.Cell + 10);
            wayImage[currentFieldStep.Cell * 100 + currentFieldStep.Cell + 10].enabled = true;
        }
        if (currentFieldStep.Down != null)
        {
            Debug.Log((currentFieldStep.Cell - 10) * 100 + currentFieldStep.Cell);
            wayImage[(currentFieldStep.Cell - 10) * 100 + currentFieldStep.Cell].enabled = true;
        }
        if (currentFieldStep.Right != null)
        {
            Debug.Log(currentFieldStep.Cell * 100 + currentFieldStep.Cell + 1);
            wayImage[currentFieldStep.Cell * 100 + currentFieldStep.Cell + 1].enabled = true;            
        }
        if (currentFieldStep.Left != null)
        {
            Debug.Log((currentFieldStep.Cell - 1) * 100 + currentFieldStep.Cell);
            wayImage[(currentFieldStep.Cell - 1) * 100 + currentFieldStep.Cell].enabled = true;
        }
    }

    // フィールドに入った時行ったことのあるステップなら表示する
    public static void show(int currentFieldID)
    {
        foreach(FieldStep currentFieldStep in FieldPlayer.beenFieldStep)
        {
            if (currentFieldStep.FieldID == currentFieldID)
            {
                showCurrentFieldStep(currentFieldStep);
            }
        }           
    }
}
