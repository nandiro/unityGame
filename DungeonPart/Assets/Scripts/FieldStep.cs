using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldStep {

    private int? fieldStepID;
    private int? fieldID;    
    private int stepRow;
    private int stepColumn;
    private int? upStepID;
    private int? downStepID;
    private int? leftStepID;
    private int? rightStepID;
    private int? eventID;

    private static Vector3[,] cell = new Vector3[5, 5];
    
    public int? FieldStepID
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
        setCellPosition();
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
        return cell[stepRow, stepColumn];
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

    private static void setCellPosition()
    {
        cell[1,1] = new Vector3(-63, -63);
        cell[1,2] = new Vector3(-21, -63);
        cell[1,3] = new Vector3(21, -63);
        cell[1,4] = new Vector3(63, -63);
        cell[2,1] = new Vector3(-63, -21);
        cell[2,2] = new Vector3(-21, -21);
        cell[2,3] = new Vector3(21, -21);
        cell[2,4] = new Vector3(63, -21);
        cell[3,1] = new Vector3(-63, 21);
        cell[3,2] = new Vector3(-21, 21);
        cell[3,3] = new Vector3(21, 21);
        cell[3,4] = new Vector3(63, 21);
        cell[4,1] = new Vector3(-63, 63);
        cell[4,2] = new Vector3(-21, 63);
        cell[4,3] = new Vector3(21, 63);
        cell[4,4] = new Vector3(63, 63);
    }

    public override string ToString()
    {
        return fieldStepID.ToString();
    }

}
