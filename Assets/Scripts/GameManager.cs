using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Player player;
    public Text score_text;
    public GameObject play_button;
    public GameObject game_over;
    private int score;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        Pause();
    }

    public void Play()
    {
        score = 0;
        score_text.text = score.ToString();

        play_button.SetActive(false);
        game_over.SetActive(false);

        Time.timeScale = 1f;
        player.enabled = true;

        Pipes[] pipes = FindObjectsOfType<Pipes>();
        for(int i = 0; i < pipes.Length; ++i)
            Destroy(pipes[i].gameObject);
    }

    public void Pause()
    {
        Time.timeScale = 0f; // this "freezes" the game since the other files utilize time
        player.enabled = false;
    }

    public void GameOver()
    {
        game_over.SetActive(true);
        play_button.SetActive(true);
        Pause();
    }
    public void IncreaseScore()
    {
        ++score;
        score_text.text = score.ToString();
    }
}
