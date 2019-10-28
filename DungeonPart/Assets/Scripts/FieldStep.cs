using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldStep {

    private int fieldStepID;
    private int fieldID;    
    private int stepRow;
    private int stepColumn;
    private int? upStepID;
    private int? downStepID;
    private int? leftStepID;
    private int? rightStepID;
    private int? eventID;
 
    public int FieldID
    {
        get { return fieldID; }
    }

    public int FieldStepID
    {
        get { return fieldStepID; }
    }    
    public int? Up
    {
        get { return upStepID; }
    }
    public int? Down
    {
        get { return downStepID; }
    }
    public int? Right
    {
        get { return rightStepID; }
    }
    public int? Left
    {
        get { return leftStepID; }
    }

    public int Cell
    {
        get { return stepRow * 10 + stepColumn; }
    }


    private FieldStep(string[] csvData)
    {
        fieldStepID = StringConvertInt(csvData[0]);
        fieldID = StringConvertInt(csvData[1]);
        stepRow = StringConvertInt(csvData[2]);
        stepColumn = StringConvertInt(csvData[3]);
        upStepID = StringConvertNullInt(csvData[4]);
        downStepID = StringConvertNullInt(csvData[5]);
        leftStepID = StringConvertNullInt(csvData[6]);
        rightStepID = StringConvertNullInt(csvData[7]);
        eventID = StringConvertNullInt(csvData[8]);     
    }

    public static List<FieldStep> MakeFieldStep()
    {

        List<FieldStep> fieldStepList = new List<FieldStep>();
        List<string[]> csvData = CSV.Read("FieldStep");

        for (int i = 1; i < csvData.Count; i++){
            fieldStepList.Add(new FieldStep(csvData[i]));
            Debug.Log("i = " + i + " : " + new FieldStep(csvData[i]));
        }
        return fieldStepList;
    }

    // FieldStepのある位置を返します
    public Vector3 getPosition()
    {
        return Field.cell[Cell];
    }

    private string TestPrint()
    {

        return ("ID:" + fieldStepID + " ID " + fieldID + " position " +stepRow + 
            stepColumn + " upID "+ upStepID + " downID " + downStepID + " leftID " + leftStepID +
             " rightID " + rightStepID + " eventID " + eventID);
    }

    // CSVから引っ張て来たデータが空白かどうか判定してIntで返す
    private int StringConvertInt(string numberString)
    {
        int number;
        number = int.Parse(numberString);
        return number;
    }

    private int? StringConvertNullInt(string numberString)
    {
        int? number = null;
        if (!string.IsNullOrEmpty(numberString))
        {
            number = int.Parse(numberString);
        }
       return number;
    }

    

    public override string ToString()
    {
        return fieldStepID.ToString();
    }

}
