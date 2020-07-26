using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI restartText;
    public GameObject titleScreen;
    public GameObject endScreen;
    public GameObject tutorialScreen;
    public GameObject coinPrefab;
    public GameObject enemyPrefab;
    public GameObject coinTut;
    public GameObject enemyTut;
    public MoveDown moveDownScript;

    public int normalMaxObjects = 3;
    public int hardMaxCoins = 2;
    public int hardMaxEnemies = 4;
    public float normalGameSpeed = 4.5f;
    public float hardGameSpeed = 7.0f;
    public float normalPlayerSpeed = 10.0f;

    public bool isGameRunning;
    public bool inTutorial;
    public int coinCount;
    public int enemyCount;
    public int score;
    public float gameSpeed;
    public float playerSpeed;

    private float xBounds = 4.5f;
    private float yBoundsTop = 12.0f;
    private float yBoundsBottom = 7.5f;
    private float zPos = -0.8f;
    private float xPos;
    private float yPos;
    private int maxCoins;
    private int maxEnemies;

    void Start() {
        titleScreen.gameObject.SetActive(true);
        endScreen.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);
    }

    void Update() {
        if (isGameRunning) {
            if (coinCount < maxCoins) {
                SpawnObject(coinPrefab);
                coinCount++;
            }

            if (enemyCount < maxEnemies) {
                SpawnObject(enemyPrefab);
                enemyCount++;
            }
        }

        if (!isGameRunning) {  
            if (Input.GetKeyDown(KeyCode.R)) {
                Restart();
            }
        }

        if (inTutorial) {
            if (Input.GetKeyDown(KeyCode.M)) {
                Restart();
			}
		}
    }
    Vector3 SpawnPosition() {
        xPos = Random.Range(-xBounds, xBounds);
        yPos = Random.Range(yBoundsBottom, yBoundsTop);

        return new Vector3(xPos, yPos, zPos);
    }

    public void UpdateScore(int scoreToAdd) {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }

    public void Restart() {
        isGameRunning = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GameOver() {
        endScreen.gameObject.SetActive(true);
        isGameRunning = false;
    }

    void InitialInstantiation(GameObject item, int difficulty) {
        if (difficulty != 1) {
            if (item.name == "Coin") {
                for (int i = 0; i < 2; i++) {
                    Instantiate(item, SpawnPosition(), item.transform.rotation);
                    coinCount++;
				}
			}

            if (item.name == "Enemy") {
                for (int i = 0; i < 4; i++) {
                    Instantiate(item, SpawnPosition(), item.transform.rotation);
                    enemyCount++;
                }
            }

            return;
        }

        if (item.name == "Coin") {
            for (int i = 0; i < 3; i++) {
                Instantiate(item, SpawnPosition(), item.transform.rotation);
                coinCount++;
            }
        }

        if (item.name == "Enemy") {
            for (int i = 0; i < 3; i++) {
                Instantiate(item, SpawnPosition(), item.transform.rotation);
                coinCount++;
            }
        }
    }

    void SpawnObject(GameObject item) {
        Instantiate(item, SpawnPosition(), item.transform.rotation);
    }

    public void StartGame(int difficulty) {
        isGameRunning = true;
		score = 0;

        titleScreen.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(true);

        if (difficulty == 2) {
            gameSpeed = hardGameSpeed;
            playerSpeed = hardGameSpeed;
            maxEnemies = hardMaxEnemies;
            maxCoins = hardMaxCoins;

            InitialInstantiation(coinPrefab, difficulty);
            InitialInstantiation(enemyPrefab, difficulty);

            coinCount = maxCoins;
            enemyCount = maxEnemies;

            return;
        }

        gameSpeed = normalGameSpeed;
        playerSpeed = normalPlayerSpeed;
        maxCoins = normalMaxObjects;
        maxEnemies = normalMaxObjects;

        InitialInstantiation(coinPrefab, difficulty);
        InitialInstantiation(enemyPrefab, difficulty);

        coinCount = maxCoins;
        enemyCount = maxEnemies;
    }

    public void StartTutorial() {
        inTutorial = true;
        isGameRunning = true;

        titleScreen.gameObject.SetActive(false);
        endScreen.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(false);
        tutorialScreen.gameObject.SetActive(true);
        coinTut.gameObject.SetActive(true);
        enemyTut.gameObject.SetActive(true);
	}
}