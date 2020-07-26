using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameManager gameManagerScript;

    private float xBounds = 4.5f;
    private float input;

    void Start()
    {
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void Update()
    {
        if (gameManagerScript.isGameRunning) {
            input = Input.GetAxis("Horizontal");

            if (transform.position.x > xBounds) {
                transform.position = new Vector3(xBounds, transform.position.y, transform.position.z);
            }

            if (transform.position.x < -xBounds) {
                transform.position = new Vector3(-xBounds, transform.position.y, transform.position.z);
            }

            transform.Translate(Vector3.right * input * gameManagerScript.playerSpeed * Time.deltaTime);
        }
    }

	private void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Coin")) {
            gameManagerScript.coinCount--;
            gameManagerScript.UpdateScore(1);

            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Enemy")) {
            gameManagerScript.GameOver();
		}
	}
}