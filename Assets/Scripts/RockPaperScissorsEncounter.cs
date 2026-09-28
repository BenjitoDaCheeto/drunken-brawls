using UnityEngine;
using UnityEngine.SceneManagement;

public class RockPaperScissorsEncounter : MonoBehaviour
{
    public enum Choice
    {
        Rock,
        Paper,
        Scissors
    }

    private Choice enemyChoice;

    [SerializeField] private GameObject choiceCanvas;
    [SerializeField] private WorldMovement worldMovement;

    void Start()
    {
        // hide choice buttons for now
        choiceCanvas.SetActive(false);
    }

    public void StartEncounter()
    {
        // enemy randomly chooses rock, paper, or scissors
        enemyChoice = (Choice)Random.Range(0, 3);

        Debug.Log("Enemy chose: " + enemyChoice);

        // show choice buttons
        choiceCanvas.SetActive(true);
    }

    // called by rock button
    public void ChooseRock()
    {
        CheckResult(Choice.Rock);
        Debug.Log("Player chose: Rock");
    }

    // called by paper button  
    public void ChoosePaper()
    {
        CheckResult(Choice.Paper);
        Debug.Log("Player chose: Paper");
    }

    // called by scissors button
    public void ChooseScissors()
    {
        CheckResult(Choice.Scissors);
        Debug.Log("Player chose: Scissors");
    }

    void CheckResult(Choice playerChoice)
    {
        // hide ui once the choice has been selected
        choiceCanvas.SetActive(false);

        Debug.Log("Player chose: " + playerChoice);
        Debug.Log("Enemy chose: " + enemyChoice);

        // if draw, restart
        if (playerChoice == enemyChoice)
        {
            Debug.Log("DRAW!");

            StartEncounter();
            return;
        }

        // rock paper scissors logic
        bool playerWon =
            (playerChoice == Choice.Rock && enemyChoice == Choice.Scissors) ||
            (playerChoice == Choice.Paper && enemyChoice == Choice.Rock) ||
            (playerChoice == Choice.Scissors && enemyChoice == Choice.Paper);

        if (playerWon)
        {
            PlayerWins();
        }
        else
        {
            PlayerLoses();
        }
    }

    void PlayerWins()
    {
        Debug.Log("YOU WIN!");

        worldMovement.StartWorld();

        Destroy(gameObject);
    }

    void PlayerLoses()
    {
        Debug.Log("YOU DIED!");

        SceneManager.LoadScene("YouDied");
    }
}