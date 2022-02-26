using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ending : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private Button ResetButton;
    [SerializeField] private Button QuitButton;
    public static bool isReset;

    void Start()
    {
        isReset = false;
    }

    public void Reset()
    {
        isReset = true;
        Player.SetActive(true);
        Player.transform.position = new Vector3(-41, -31, 0);
        gameObject.SetActive(false);
        Time.timeScale = 1.0f;

        GameObject[] enemy_instances = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i < enemy_instances.Length; i++)    
        {
            Destroy(enemy_instances[i], 0.5f);
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
