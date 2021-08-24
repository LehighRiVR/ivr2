using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pebbleGain : MonoBehaviour
{
    private ElementH elementH; // reference to the element class
    private ElementV elementV;
    public Text gainText;
    public int gain;

    void Start()
    {
        elementH = FindObjectOfType<ElementH>();
        elementV = FindObjectOfType<ElementV>();
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
