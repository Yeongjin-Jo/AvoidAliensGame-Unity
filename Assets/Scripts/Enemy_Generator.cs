using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Generator : MonoBehaviour
{
    [SerializeField] private GameObject enemy_object;
    [SerializeField] private int EnemySpeed;
    [SerializeField] private float SpeedPeriod;
    [SerializeField] private int enemyNum = 30;
    [SerializeField] public Vector2[] spawnPoint;
    [SerializeField] public Vector2[] reSpawnPoint;
    
    public static GameObject[,] enemy_instance;
    private Rigidbody2D EnemyRigid;
    private Vector2 speedVec;
    private float moveTime = 0f;
    private double previousNum = 0f;
    private double currentNum = 0f;

    public static Vector2[] spawnPoint_static;
    public static int enemyNum_static;

    void Start()
    {
        spawnPoint_static = spawnPoint;
        enemyNum_static = enemyNum;
        enemy_instance = new GameObject[spawnPoint.Length,enemyNum];
        Generator();
    }

    void Update()
    {
        moveTime += Time.deltaTime;

        currentNum = System.Math.Truncate(moveTime);

        if(previousNum != currentNum)
        {   
            previousNum++;
            if(previousNum % SpeedPeriod == 0)
                Move();
        }
    }


    private void Move()
    {
        for (int j = 0; j < spawnPoint.Length; j++)
        {
            for (int i = 0; i < enemyNum; i++)
            {
                speedVec = new Vector2(Random.Range(-EnemySpeed, EnemySpeed+1), Random.Range(-EnemySpeed, EnemySpeed+1));
                enemy_instance[j,i].GetComponent<Rigidbody2D>().velocity = speedVec;
            }    
        }
        
    }


    private void Generator()
    {
        for (int j = 0; j < spawnPoint.Length; j++)
        {
            for (int i = 0; i < enemyNum; i++)
            {        
                enemy_instance[j,i] = Instantiate(enemy_object, new Vector3(spawnPoint[j][0], spawnPoint[j][1], 0), transform.rotation);
                enemy_instance[j,i].transform.tag = "Enemy";
                enemy_instance[j,i].GetComponent<SpriteRenderer>().sortingOrder = 1;
            }    
        }
    }
}
