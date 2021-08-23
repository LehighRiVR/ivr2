using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class anthraciteGain : MonoBehaviour
{
    private ElementV elementV; // reference to the element class
    private ElementH elementH;
    public Text gainText;
    public int gain;

    void Start()
    {
        elementV = FindObjectOfType<ElementV>();
        elementH = FindObjectOfType<ElementH>();
    }

    // This method is constantly updating the score value in text
    void Update()
    {
        gainText.text = "" + gain;
    }

    // This method passes how much we are increasing the score by
    public void IncreaseScore(int amountToIncrease)
    {
        gain += amountToIncrease;

    }
}
