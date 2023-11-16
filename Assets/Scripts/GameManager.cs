using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject block;
    public float maxX;
    public Transform spawnPoint;
    public float spawnRate;
    public float firstSpawn;


    bool gameStarted = false;

    public GameObject tapToStart;
    public TextMeshProUGUI scoreText;

    int score = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

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
