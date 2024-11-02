using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public float GameSpeed { get; private set; }

    [SerializeField]
    private float initialGameSpeed;
    [SerializeField]
    private float gameSpeedIncrease;
    [SerializeField]
    private Vector3 startPosition;

    [SerializeField]
    private Player player;
    [SerializeField]
    private Spawner spawner;

    [SerializeField]
    private TextMeshProUGUI gameOverText;
    [SerializeField]
    private Button retryButton;

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

    private void Start()
    {
        NewGame();
    }

    private void Update()
    {
        GameSpeed += gameSpeedIncrease * Time.deltaTime;
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
        }
    }

    public void NewGame()
    {
        player.gameObject.transform.position = startPosition;

        Obstacle[] obstacles = FindObjectsOfType<Obstacle>();
        foreach (Obstacle obstacle in obstacles)
        {
            Destroy(obstacle.gameObject);
        }

        GameSpeed = initialGameSpeed;
        enabled = true;

        player.gameObject.SetActive(true);
        spawner.gameObject.SetActive(true);

        gameOverText.gameObject.SetActive(false);
        retryButton.gameObject.SetActive(false);
    }

    public void GameOver()
    {
        GameSpeed = 0f;
        enabled = false;

        player.gameObject.SetActive(false);
        spawner.gameObject.SetActive(false);

        gameOverText.gameObject.SetActive(true);
        retryButton.gameObject.SetActive(true);
    }
}
