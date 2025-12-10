using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int score = 0;
    public TMP_Text scoreText_tmp;
    public int totalBalloons = 0;
    public static int staticScore = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Start()
    {
        totalBalloons = GameObject.FindGameObjectsWithTag("Balloon").Length;
        UpdateScoreUI();

        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void FindScoreTextInScene()
    {
        GameObject scoreObj = GameObject.FindGameObjectWithTag("ScoreText");
        if (scoreObj != null)
        {
            scoreText_tmp = scoreObj.GetComponent<TMP_Text>();
        }
        else
        {
            scoreText_tmp = null;
        }
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        FindScoreTextInScene();
        totalBalloons = GameObject.FindGameObjectsWithTag("Balloon").Length;
        UpdateScoreUI();
    }

    public void AddScore(int amount)
    {
        score += amount;
        staticScore = score;
        UpdateScoreUI();
        totalBalloons--;

        if (totalBalloons <= 0)
        {
            GoToNextScene();
        }
    }

    private void UpdateScoreUI()
    {
        if (scoreText_tmp != null)
            scoreText_tmp.text = "Score: " + score;
    }

    private void GoToNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
