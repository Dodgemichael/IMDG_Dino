using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class GameManager1 : MonoBehaviour
{
    public static GameManager1 Instance { get; private set; }

    public float initialGameSpeed1 = 5f;
    public float gameSpeedIncrease1 = 0.1f;
    public float gameSpeed1 { get; private set; }

    public TextMeshProUGUI gameOverText1;
    public TextMeshProUGUI scoreText1;
    public TextMeshProUGUI hiscoreText1;
    public Button retryButton1;

    private Player player1;
    private Spawner spawner1;

    private float score1;


    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }

    private void OnDestroy()
    {
        if(Instance == this)
        {
            Instance = null;
        }
    }

    private void Start()
    {
        player1 = FindObjectOfType<Player>();
        spawner1 = FindObjectOfType<Spawner>();

        NewGame();
    }

    public void NewGame()
    {
        Obstacle[] obstacles = FindObjectsOfType<Obstacle>();

        foreach(var obstacle in obstacles)
        {
            Destroy(obstacle.gameObject);
        }

      

        gameSpeed1 = initialGameSpeed1;
        score1 = 0f;
        enabled = true;

        player1.gameObject.SetActive(true);
        spawner1.gameObject.SetActive(true);
        gameOverText1.gameObject.SetActive(false);
        retryButton1.gameObject.SetActive(false);

        UpdateHiscore();
    }

    public void GameOver()
    {
        gameSpeed1 = 0f;
        enabled = false;

        player1.gameObject.SetActive(false);
        spawner1.gameObject.SetActive(false);
        gameOverText1.gameObject.SetActive(true);
        retryButton1.gameObject.SetActive(true);
        UpdateHiscore();
    }

    private void Update()
    {
        gameSpeed1 += gameSpeedIncrease1 * Time.deltaTime;
        score1 += gameSpeed1 * Time.deltaTime;
        scoreText1.text = Mathf.FloorToInt(score1).ToString("D5");
    }

    private void UpdateHiscore()
    {
        float hiscore1 = PlayerPrefs.GetFloat("hiscore", 0);
        if (score1 > hiscore1)
        {
            hiscore1 = score1;
            PlayerPrefs.SetFloat("hiscore", hiscore1);
        }

        hiscoreText1.text = Mathf.FloorToInt(hiscore1).ToString("D5");
    }

}
