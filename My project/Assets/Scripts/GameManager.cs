using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public float initialGameSpeed = 5f;
    public float gameSpeedIncrease = 0.1f;
    public float gameSpeed { get; private set; }

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI hiscoreText;

    public AudioSource deathSound;
    public AudioSource music;

    public TextMeshProUGUI gameOverText;
    public Button retryButton;
    public Button menuButton;
    private Player player; 
    private Spawner spawner;

    private float score;
    public float immune = 0f;

    private Shake shake;


private void Awake()
{
    if (Instance == null)
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
    if (Instance == this) {
        Instance = null;
    }
}

private void Start()
{
    player = FindObjectOfType<Player>();
    spawner = FindObjectOfType<Spawner>();
    shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
   
    NewGame();
}

public void NewGame()
{
    Obstacle[] obstacles = FindObjectsOfType<Obstacle>();
    PowerUp[] powerups = FindObjectsOfType<PowerUp>(); 
    PowerUp2[] powerups2 = FindObjectsOfType<PowerUp2>();
    PowerUp3[] powerups3= FindObjectsOfType<PowerUp3>();

        foreach (var obstacle in obstacles){
        Destroy(obstacle.gameObject);
    }
     foreach (var powerup in powerups){
        Destroy(powerup.gameObject);
    }
        foreach (var powerup2 in powerups2)
        {
            Destroy(powerup2.gameObject);
        }
        foreach (var powerup3 in powerups3)
        {
            Destroy(powerup3.gameObject);
        }
        gameSpeed = initialGameSpeed;
    enabled = true;
    score = 0f;

    player.gameObject.SetActive(true);
    spawner.gameObject.SetActive(true);

    gameOverText.gameObject.SetActive(false);
    retryButton.gameObject.SetActive(false);
    menuButton.gameObject.SetActive(false);

    music.Play();
}

public void GameOver(){
   if(immune <= 0f){
        
    deathSound.Play();

            music.Stop();

    shake.CamShake();

    gameSpeed = 0f;
    enabled = false;

    player.gameObject.SetActive(false);
    spawner.gameObject.SetActive(false);

    gameOverText.gameObject.SetActive(true);
    retryButton.gameObject.SetActive(true);
    menuButton.gameObject.SetActive(true);

    UpdateHiscore();
    }
}

public void Ability1(){
    immune = 10.0f;
    
}

public void Ability2(){
    gameSpeed = gameSpeed - 1.5f;
    
}

public void Ability3()
    {
        score += 300f;
    }
public void Ability4(){
    gameSpeed = gameSpeed + 1.5f;
    
}

private void Update()
{
immune -= 1 *  Time.deltaTime;
gameSpeed += gameSpeedIncrease * Time.deltaTime;
  score += gameSpeed * Time.deltaTime;
    scoreText.text = Mathf.FloorToInt(score).ToString("D5");

}
 private void UpdateHiscore()
    {
        float hiscore = PlayerPrefs.GetFloat("hiscore", 0);

        if (score > hiscore)
        {
            hiscore = score;
            PlayerPrefs.SetFloat("hiscore", hiscore);
        }

        hiscoreText.text = Mathf.FloorToInt(hiscore).ToString("D5");
    }


}

  