using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElementH : MonoBehaviour
{
    [Header("Board Variables")]
    public int column;
    public int row;
    private Board board;

    public int targetX;
    public int targetY;
    GameObject leftElement1;
    GameObject rightElement1;
    GameObject upElement1;
    GameObject downElement1;

    public static GameObject tempH;
    public static GameObject tempV;


    public int anthraciteScore = 0;
    public int pebbleScore = 0;
    public int emptyScore = 0;
    public int nothingScore = 0;
    int randNum;

    public Text text;
    public GameObject ElementScoredDisplay;
    public GameObject ElementVisual;
    public GameObject plus;
    public bool isHighlighted = false;

    void Start()
    {
        board = FindObjectOfType<Board>();
        targetX = (int)transform.position.x;
        targetY = (int)transform.position.y;
        row = targetY;
        column = targetX;
    }

    void Update()
    {
        FindMatchesThree();
        board.changeCursor();
        //RaycastShower();
    }

    public void OnMouseEnter()
    {
        if (this.gameObject.GetComponent<SpriteRenderer>().enabled)
        {
            tempH = GameObject.Find(this.gameObject.name);
            tempH.GetComponent<ElementH>().enabled = true;
        }
    }
    /*
        public void temp()
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

                    if (hit.collider != null)
                    {
                        string colliderName = hit.collider.name;
                        char x = colliderName[2];
                        char y = colliderName[5];
                        int xCoord = int.Parse(x.ToString());
                        int yCoord = int.Parse(y.ToString());

                        GameObject temp = GameObject.Find(colliderName);
                        temp.GetComponent<Element>().enabled = true;
                    }

        }
    */
    #region 3 Elements RECIPE
    void highlight3(GameObject neighborA1, GameObject neighborB1, GameObject clicked)
    {
        neighborA1.gameObject.GetComponent<SpriteRenderer>().color = new Color32(55, 55, 55, 255);
        neighborB1.gameObject.GetComponent<SpriteRenderer>().color = new Color32(55, 55, 55, 255);
        clicked.gameObject.GetComponent<SpriteRenderer>().color = new Color32(55, 55, 55, 255);

        neighborA1.gameObject.GetComponent<ElementH>().isHighlighted = true;
        neighborB1.gameObject.GetComponent<ElementH>().isHighlighted = true;
        clicked.gameObject.GetComponent<ElementH>().isHighlighted = true;

        board.cursorChanged = true;
        //board.changeCursor();
    }

    void destroy3(GameObject neighborA1, GameObject neighborB1, GameObject clicked)
    {
        neighborA1.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        neighborB1.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        clicked.gameObject.GetComponent<SpriteRenderer>().enabled = false;

        neighborA1.tag = "Untagged";
        neighborB1.tag = "Untagged";
        clicked.tag = "Untagged";

        board.cursorChanged = false;
        //board.changeCursor(); 
    }

    void reward()
    {
        Random random = new Random();
        for (int i = 0; i < 3; i++)
        {
            randNum = Random.Range(0, 4);
            switch (randNum)
            {
                case 0:
                    emptyScore++;
                    Debug.Log("You got " + emptyScore + " EMPTY!");
                    break;

                case 1:
                    nothingScore++;
                    Debug.Log("You got " + nothingScore + " NOTHING!");
                    break;

                case 2:
                    anthraciteScore++;
                    Debug.Log("You got " + anthraciteScore + " ANTHRACITE!");
                    Instantiate(plus, new Vector3(-8, 5, 0), Quaternion.identity);
                    plus.transform.parent = ElementScoredDisplay.transform;
                    Instantiate(ElementVisual, new Vector3(-6, 5, 0), Quaternion.identity);
                    GameObject.Find("ElementVisual").transform.parent= ElementScoredDisplay.transform; 
                    text.text = anthraciteScore.ToString();
                    break;

                case 3:
                    pebbleScore++;
                    Debug.Log("You got " + pebbleScore + " PEBBLE!");
                    Instantiate(plus, new Vector3(-8, 5, 0), Quaternion.identity);
                    plus.transform.parent = ElementScoredDisplay.transform;
                    Instantiate(ElementVisual, new Vector3(-6, 5, 0), Quaternion.identity);
                    GameObject.Find("ElementVisual").transform.parent = ElementScoredDisplay.transform;
                    text.text = pebbleScore.ToString();
                    break;
            }
        }
    }

    void unhighligthALL()
    {
        for (int i = 0; i < board.width; i++)
        {
            for (int j = 0; j < board.height; j++)
            {
                board.allElements[i, j].GetComponent<ElementH>().isHighlighted = false;
                board.allElements[i, j].GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255);
                board.allElements[i, j].GetComponent<ElementH>().enabled = false;
            }
        }
        board.cursorChanged = false;
    }

   

    //HORIZONTAL - 3 COMMON TILES 
    void FindMatchesThree()
    {
        if (column > 0 && column < board.width - 1)
        {
            leftElement1 = board.allElements[column - 1, row];
            tempH = board.allElements[column, row];
            rightElement1 = board.allElements[column + 1, row];

            if (leftElement1.tag == tempH.tag && rightElement1.tag == tempH.tag)
            {
                highlight3(leftElement1, rightElement1, tempH);

                this.isHighlighted = true;
                leftElement1.gameObject.GetComponent<ElementH>().isHighlighted = true;
                rightElement1.gameObject.GetComponent<ElementH>().isHighlighted = true;

                if (Input.GetMouseButtonUp(0)) // DESTROYS 3 VERTICAL BLOCKS IN A ROW
                {
                    destroy3(leftElement1, rightElement1, tempH);
                    reward();
                  
                }
            }
            else
            {
                this.unhighligthALL();
            }
        }
}
}



/*
public void addScore()
{
Score++;
ScoreText.text = Score.ToString();
}
*/

/*
public void RaycastShower()
{
    if (Input.GetMouseButtonUp(0))
    {
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                Vector2 worldPoint = new Vector2(i, j); //Camera.main.ScreenToWorldPoint(Input.mousePosition); // replace with i / j
                RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero); // replace with i / j
                if (hit.collider != null)
                {
                    if (hit.collider.tag.Equals("Anthracite"))
                    {
                        anthraciteScore++;
                    }

                    if (hit.collider.tag.Equals("Pebble"))
                    {
                        pebbleScore++;
                    }

                }

            }

        }
        //Debug.Log("Anthracite score" + anthraciteScore);
       // Debug.Log("Pebble score" + pebbleScore);
    }
}
*/



#endregion