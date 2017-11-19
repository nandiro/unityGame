using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldStep : MonoBehaviour {

    private int fieldStepID;
    private int fieldID;    
    private int stepRow;
    private int stepColumn;
    private int upStepID;
    private int downStepID;
    private int leftStepID;
    private int rightStepID;
    private int eventID;

    private FieldStep(string[] csvData)
    {
        fieldStepID = int.Parse(csvData[0] ?? null);
        fieldID = int.Parse(csvData[1] ?? null);
        stepRow = int.Parse(csvData[2] ?? null);
        stepColumn = int.Parse(csvData[3] ?? null);
        upStepID = int.Parse(csvData[4] ?? null);
        downStepID = int.Parse(csvData[5] ?? null);
        leftStepID = int.Parse(csvData[6] ?? null);
        rightStepID = int.Parse(csvData[7] ?? null);
        eventID = int.Parse(csvData[8] ?? null);
    }

    public List<FieldStep> MakeFieldStep()
    {
        List<FieldStep> fieldStepList = new List<FieldStep>();
        List<string[]> csvData = CSV.Read("FieldStep");

        for(int i = 1; i < csvData.Count; i++){
            fieldStepList.Add(new FieldStep(csvData[i]));
        }

        return fieldStepList;
    }

    public override string ToString()
    {
        return fieldStepID.ToString();
    }

}
