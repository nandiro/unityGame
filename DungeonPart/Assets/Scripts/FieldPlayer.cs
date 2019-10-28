using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FieldPlayer : MonoBehaviour {

    private static int currentFieldID; 
    public static FieldStep currentFieldStep;
    public static RectTransform playerRectTrans;
    public static List<FieldStep> beenFieldStep = new List<FieldStep>();

    // Use this for initialization
    void Start () {
        currentFieldStep = FieldManager.fieldStep[0];
        playerRectTrans = GetComponent<RectTransform>();
        UpdatePosition();
    }
	
    public static void MoveUp()
    {
        if(currentFieldStep.Up != null)
        {
            currentFieldStep = FieldManager.fieldStep.Find(x => x.FieldStepID == currentFieldStep.Up);
            UpdatePosition();
        }    
    }
    public static void MoveDown()
    {
        if (currentFieldStep.Down != null)
        {
            currentFieldStep = FieldManager.fieldStep.Find(x => x.FieldStepID == currentFieldStep.Down);
            UpdatePosition();
        }
    }
    public static void MoveRight()
    {
        if (currentFieldStep.Right != null)
        {
            currentFieldStep = FieldManager.fieldStep.Find(x => x.FieldStepID == currentFieldStep.Right);
            UpdatePosition();
        }
    }
    public static void MoveLeft()
    {
        if (currentFieldStep.Left != null)
        {
            currentFieldStep = FieldManager.fieldStep.Find(x => x.FieldStepID == currentFieldStep.Left);
            UpdatePosition();
        }
    }

    // プレイヤーが移動したときの位置を更新する
    private static void UpdatePosition()
    {
        playerRectTrans.localPosition = currentFieldStep.getPosition();
        UpdateFieldID();
        UpdateBeenFieldStep(currentFieldStep);
        Field.showCurrentFieldStep(currentFieldStep);
    }
    
    // FieldのIDが変わったらFieldを更新する
    private static void UpdateFieldID()
    {
        if( currentFieldID != currentFieldStep.FieldID )
        {
            Field.hide();
            currentFieldID = currentFieldStep.FieldID;
            Field.show(currentFieldID);
        }
    }
 
    // 行ったことのあるfieldStepを保存する
    private static void UpdateBeenFieldStep(FieldStep currentFieldStep)
    {
        if (!beenFieldStep.Contains(currentFieldStep))
        {
            beenFieldStep.Add(currentFieldStep);
        }     
    } 

}
