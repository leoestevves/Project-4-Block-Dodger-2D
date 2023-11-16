using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject block;
    [SerializeField] float maxX;
    [SerializeField] Transform spawnPoint;
    [SerializeField] float spawnRate;
    [SerializeField] float firstSpawn;

    bool gameStarted = false;

    [SerializeField] GameObject tapToStart;
    [SerializeField] TextMeshProUGUI scoreText;

    int score = 0;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0) && !gameStarted)
        {
            StartSpawning();
            gameStarted = true;
            tapToStart.SetActive(false);
        }        
    }


    void StartSpawning()
    {
        InvokeRepeating("SpawnBlock", firstSpawn, spawnRate);
    }

    void SpawnBlock()
    {
        Vector3 spawnPos = spawnPoint.position;

        spawnPos.x = Random.Range(-maxX, maxX);

        Instantiate(block, spawnPos, Quaternion.identity);

        score++;
        scoreText.text = score.ToString();
    }

}
