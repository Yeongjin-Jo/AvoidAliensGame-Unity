using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyPrefabScript : MonoBehaviour
{
    [SerializeField] GameObject respawnPoint_Main;
    [SerializeField] GameObject respawnPoint_Map01;

    private Vector2[] respawnPoint;
    void Start()
    {
        if(SceneManager.GetActiveScene().name == "Main")
        {
            respawnPoint = respawnPoint_Main.GetComponent<RespawnPoint>().respawnPoints;

        }
        else if(SceneManager.GetActiveScene().name == "Map01")
        {
            respawnPoint = respawnPoint_Map01.GetComponent<RespawnPoint>().respawnPoints;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.tag == "Boundary")
        {
            int respawnNum = Random.Range(0, respawnPoint.Length);
            this.gameObject.transform.position = respawnPoint[respawnNum];
        }
    }
}
