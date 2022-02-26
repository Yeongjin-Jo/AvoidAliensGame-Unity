using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPrefabScript : MonoBehaviour
{
    [SerializeField] private Vector2[] respawnPoint;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.transform.tag == "Boundary")
        {
            int respawnNum = Random.Range(0, respawnPoint.Length);
            this.gameObject.transform.position = respawnPoint[respawnNum];
        }
    }
}
