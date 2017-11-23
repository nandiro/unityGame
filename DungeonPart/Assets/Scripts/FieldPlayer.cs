using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FieldPlayer : MonoBehaviour {

    public static FieldStep currentFieldStep;
    public static RectTransform playerRectTrans;
    
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

    private static void UpdatePosition()
    {
        playerRectTrans.localPosition = currentFieldStep.getPosition();
        Debug.Log(currentFieldStep);
    }
    
    private static void UpdateCurrentFieldStep()
    {

    } 

}
