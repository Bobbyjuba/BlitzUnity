using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    private GameManager gameManagerScript;

    private float bottom = -5.0f;

    void Start()
    {
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void Update()
    {
        if (gameManagerScript.isGameRunning) {
            if (transform.position.y < bottom) {
                if (gameObject.CompareTag("Enemy")) {
                    gameManagerScript.enemyCount--;
                }

                if (gameObject.CompareTag("Coin")) {
                    gameManagerScript.coinCount--;
                }

                Destroy(gameObject);
            }

            transform.Translate(Vector3.down * gameManagerScript.gameSpeed * Time.deltaTime);
        }
    }
}