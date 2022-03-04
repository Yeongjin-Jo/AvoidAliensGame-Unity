using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private Vector3 resetPosition;
    public static bool isReset;

    void Start()
    {
        isReset = false;
    }


    public void Reset()
    {
        isReset = true;
        Player.SetActive(true);
        Player.transform.position = resetPosition;
        gameObject.SetActive(false);
        Time.timeScale = 1.0f;


        GameObject[] enemy_instances = GameObject.FindGameObjectsWithTag("Enemy");

        for (int i = 0; i < Enemy_Generator.spawnPoint_static.Length; i++)
        {
            for (int j = 0; j < Enemy_Generator.enemyNum_static; j++)
            {
                enemy_instances[i*Enemy_Generator.enemyNum_static+j].transform.position = Enemy_Generator.spawnPoint_static[i];
            }
        }

        // for (int i = 0; i < enemy_instances.Length; i++)    
        // {
        //     Destroy(enemy_instances[i], 0.5f);
        // }
    }

    public void ExitToTitle()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Title");
    }

    public void Quit()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }
}
