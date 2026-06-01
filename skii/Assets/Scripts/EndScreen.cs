using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class EndScreen : MonoBehaviour
{
    [SerializeField] private GameObject endScreenPanel;
    [SerializeField] private TextMeshProUGUI finalTimeText;
    [SerializeField] private Button restartButton;
    [SerializeField] private Button nextLevelButton;
    [SerializeField] private Button quitButton;

    public static EndScreen Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        restartButton.onClick.AddListener(Restart);
        nextLevelButton.onClick.AddListener(NextLevel);
        quitButton.onClick.AddListener(Quit);
    }

    public void ShowEndScreen(string time, float timeFloat)
    {
        endScreenPanel.SetActive(true);
        finalTimeText.text = "Time: " + time;
        Leaderboard.Instance.AddTime(timeFloat);
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void NextLevel()
    {
        SceneManager.LoadScene("Level2");
    }

    void Quit()
    {
        Application.Quit();
    }
}