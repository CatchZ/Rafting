using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System;

public class MaterialColourChange : MonoBehaviour
{
    public Material materialToChange;
    public Color color = Color.red;
    public int amountOfTimeInMiliseconds = 500;
    private Color defaultColor = Color.black;
    public float amountOfTimeInSeconds = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        

    }
    
    void Update()
    {
        
    }
    public void ChangeColorForAmountOfTime()
    {
        StartCoroutine(ChangeColorCoroutine());
        //changeColorBack();
    }
    private IEnumerator ChangeColorCoroutine()
    {

        Debug.Log("ChangeColorForAmountOfTime() called");

        // Change the color to the specified color
        materialToChange.SetColor("_EmissionColor", color);
        materialToChange.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;

        // Wait for the specified amount of time
        Debug.Log("start waiting");
        yield return new WaitForSeconds(amountOfTimeInSeconds);
        Debug.Log("stop waiting");
        // Change the color back to the default color
        materialToChange.SetColor("_EmissionColor", defaultColor);
        materialToChange.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
    }
    private void changeColorBack() {
        materialToChange.SetColor("_EmissionColor", defaultColor);
        materialToChange.globalIlluminationFlags = MaterialGlobalIlluminationFlags.RealtimeEmissive;
    }
    /*
    public void changeCoulourforAmountofTime() {
        Debug.Log("changeCoulourforAmountofTime() called");
        materialToChange.SetColor("BaseMap", color);
        Thread.Sleep(amountOfTimeInMiliseconds);
        materialToChange.SetColor("BaseMap", defaultColor);
    }*/
}
