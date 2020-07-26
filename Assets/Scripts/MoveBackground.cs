using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MoveBackground : MonoBehaviour
{
    private GameManager gameManagerScript;

    private Vector3 startPos;
    private float repeatHeight;

    void Start()
    {
        startPos = transform.position;
        repeatHeight = GetComponent<BoxCollider>().size.y / 2;
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    void Update()
    {
        if (gameManagerScript.isGameRunning) {
            if (transform.position.y < repeatHeight) {
                transform.position = startPos;
            }

            transform.Translate(Vector3.down * gameManagerScript.gameSpeed * Time.deltaTime);
        }
    }
}