using UnityEngine;
using UnityEngine.UI;

public class GemeManager : MonoBehaviour
{
    private int score;
    public Player player;
    public Text scoreText;
    public GameObject playButton;
    public GameObject gameOver;
    public int FRAME_RATE = 60;

    private void Awake()
    {
        Application.targetFrameRate = this.FRAME_RATE;
        Pause();
    }

    public void Play() {
        score = 0;
        scoreText.text = score.ToString();
        playButton.SetActive(false);
        gameOver.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

        Pipes[] pipes = FindObjectsByType<Pipes>(FindObjectsSortMode.None);

        //Pipes[] pipes = FindObjectsOfType<Pipes>();

        //Pipes[] pipes = FindFirstObjectsByType<Pipes>();

        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }

    }

    public void Pause() {
        Time.timeScale = 0f;
        player.enabled = false;
    }

    public void IncreaseScore() {
        score++;
        this.scoreText.text = score.ToString();
    }

    public void GameOver() {
        gameOver.SetActive(true);
        playButton.SetActive(true);

        Pause();
    }
}
