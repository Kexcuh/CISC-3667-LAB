using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{

    public int coinCounter; // How many coins the player has
    public Text scoreText; // Display text for player coin amount
    public int goalCounter; // The amount of points player has obtained towards level complete
    public int level = 0; // Current level that the player is on
    public int levelComplete = 0; // Number of goal points required to moveon to the next leve

    [ContextMenu("Increase Score")]
    public void addScore()
    {
        coinCounter++;
        scoreText.text = coinCounter.ToString();
    }

    public void addGoal()
    {
        goalCounter++;
    }

    // Start is called before the first frame update
    void Start()
    {   
        coinCounter = 0;
        goalCounter = 0;
        //SceneManager.LoadScene(level);
    }

    // Update is called once per frame
    void Update()
    {
        
        if(goalCounter >= levelComplete)
        {
            level++;
            SceneManager.LoadScene(level);
        }
    }

    public void restartLevel()
    {
        SceneManager.LoadScene(level);
    }

    [ContextMenu("Next Level")]
    public void nextLevel()
    {
        level++;
        SceneManager.LoadScene(level);
    }
}
