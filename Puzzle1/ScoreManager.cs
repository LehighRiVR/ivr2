using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private ElementH elementH; // reference to the element class
    private ElementV elementV;
    public Text scoreText;
    public float score;
    public Image scoreBar;

    void Start()
    {
        elementH = FindObjectOfType<ElementH>();
        elementV = FindObjectOfType<ElementV>();
    }

    // This method is constantly updating the score value in text
    void Update()
    {
       scoreText.text = "Score: " + score;
    }

    // This method passes how much we are increasing the score by
    public void IncreaseScore(float amountToIncrease)
    {
        score += amountToIncrease;
        UpdateBar();
    }

    private void UpdateBar()
    {
        scoreBar.fillAmount = score/10;

        //if (element != null && scoreBar != null)
        //{
        //    int length = element.scoreGoals.Length;
        //    scoreBar.fillAmount = (float)score / (float)element.scoreGoals[length - 1];
        //}
    }
}
