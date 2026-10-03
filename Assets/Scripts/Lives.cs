using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LivesManager : MonoBehaviour
{
    // image array to hold each heart
    [SerializeField] private Image[] hearts;

    private int lives = 3;

    public void LoseLife()
    {
        // decrement lives
        lives--;

        Debug.Log("Lives remaining: " + lives);

        UpdateHearts();

        if (lives <= 0)
        {
            PlayerDied();
        }
    }

    void UpdateHearts()
    {
        // control the visibility of each heart
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < lives)
            {
                hearts[i].gameObject.SetActive(true);
            }
            else
            {
                hearts[i].gameObject.SetActive(false);
            }
        }
    }

    void PlayerDied()
    {
        Debug.Log("YOU DIED!");

        SceneManager.LoadScene("YouDied");
    }
}