using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FieldPlayer : MonoBehaviour {

    public static FieldStep currentFieldStep;
    public static Transform playerRectTrans;
    
	// Use this for initialization
	void Start () {
        currentFieldStep = FieldManager.fieldStep[0];
        Debug.Log(currentFieldStep);
        Debug.Log(currentFieldStep.getPosition());
        playerRectTrans = GetComponent<Transform>();
        //GetComponent<Image>().enabled = false;
        Debug.Log(playerRectTrans.position);
        //playerRectTrans.position = new Vector3(-63,-21);
        UpdatePosition();
    }
	
    public static void MoveUp()
    {
        if(currentFieldStep.Up != null)
        {
            currentFieldStep = FieldManager.fieldStep.Find(x => x.FieldStepID == currentFieldStep.Up);
            //UpdatePosition();
        }    
    }
    public static void MoveDown()
    {
        if (currentFieldStep.Down != null)
        {
            currentFieldStep = FieldManager.fieldStep.Find(x => x.FieldStepID == currentFieldStep.Down);
            //UpdatePosition();
        }
    }
    public static void MoveRight()
    {
        if (currentFieldStep.Right != null)
        {
            currentFieldStep = FieldManager.fieldStep.Find(x => x.FieldStepID == currentFieldStep.Right);
            //UpdatePosition();
        }
    }
    public static void MoveLeft()
    {
        if (currentFieldStep.Left != null)
        {
            currentFieldStep = FieldManager.fieldStep.Find(x => x.FieldStepID == currentFieldStep.Left);
            //UpdatePosition();
        }
    }

    private static void UpdatePosition()
    {
        Debug.Log("player" + playerRectTrans.position);
        Debug.Log("current " + currentFieldStep.getPosition());
        playerRectTrans.position = currentFieldStep.getPosition();
        Debug.Log("player" + playerRectTrans.position);
        //position = currentFieldStep.getPosition();
    }
    
    private static void UpdateCurrentFieldStep()
    {

    } 

}
