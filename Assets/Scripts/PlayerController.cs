using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] Camera PlayerCamera;
    [SerializeField] private GameObject DeadScreen;
    [SerializeField] private GameObject FinishScreen;
    [SerializeField] private GameObject StartArea;
    [SerializeField] private AudioClip[] backgroundMusic;
    [SerializeField] private AudioClip deadMusic;
    [SerializeField] private AudioClip finishMusic;
    
    private Rigidbody2D PlayerRigid;
    private Vector2 speed_vec;
    private bool isStart = false;
    private bool isFinish = false;

    private Animator anim;

    private AudioSource BackgroundMusic;
    private int audioNum;
    

    private float currentTime = 0f;
    private float Playtime = 0f;
    
    void Start()
    {
        PlayerRigid = GetComponent<Rigidbody2D>();
        PlayerCamera.transform.position = new Vector3(transform.position.x, transform.position.y, -1);
        anim = GetComponent<Animator>();
        BackgroundMusic = GetComponent<AudioSource>();
        BackgroundMusicReset();
        
        DeadScreen.SetActive(false);
        FinishScreen.SetActive(false);
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        Playtime += Time.deltaTime;

        if(Playtime > backgroundMusic[audioNum].length)
            {
                BackgroundMusicReset();
                Playtime = 0f;
            }
            

        PlayerCamera.transform.position = new Vector3(transform.position.x, transform.position.y, -1);

        anim.SetBool("Up", false);
        anim.SetBool("Down", false);
        anim.SetBool("Left", false);
        anim.SetBool("Right", false);

        Move();
        
        Collider2D[] col = Physics2D.OverlapCapsuleAll(new Vector2(transform.position.x, transform.position.y + 0.8f),
         new Vector2(1, 0.65f), CapsuleDirection2D.Vertical, 0);
         for (int i = 0; i < col.Length; i++)
         {
             if(col[i].transform.tag == "Start")
             {
                 isStart = true;
             }
             else
             {
                 isStart = false;
             }
         }
         if(Ending.isReset == true)
        {
            anim.SetBool("Disappear", false);
            FinishScreen.SetActive(false);
            Playtime = 0f;
            BackgroundMusicReset();
            Ending.isReset = false;
        }
    }

    private void Move()
    {
        speed_vec = Vector2.zero;
        if(Input.GetKey(KeyCode.UpArrow))
        {
            speed_vec.y += speed;
            anim.SetBool("Up", true);
        }
        if(Input.GetKey(KeyCode.DownArrow))
        {
            speed_vec.y -= speed;
            anim.SetBool("Down", true);
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            speed_vec.x -= speed;
            anim.SetBool("Left", true);
        }
        if(Input.GetKey(KeyCode.RightArrow))
        {
            speed_vec.x += speed;
            anim.SetBool("Right", true);
        }
        PlayerRigid.velocity = speed_vec;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if(other.transform.tag == "Finish")
        {
            isFinish = true;
            Time.timeScale = 0.0f;
            anim.SetBool("Finish", true);
            BackgroundMusic.clip = finishMusic;
            BackgroundMusic.Play();
        }
        if(other.transform.tag == "Enemy" && isFinish == false && isStart == false)
        {
            BackgroundMusic.clip = deadMusic;
            BackgroundMusic.Play();
            Time.timeScale = 0.0f;
            anim.SetBool("Vanish", true);
        }
    }
    
    public void ShowDeadScreen()
    {
        anim.SetBool("Vanish", false);
        anim.SetBool("Disappear", true);
        DeadScreen.SetActive(true);
    }

    public void showFinishScreen()
    {
        FinishScreen.SetActive(true);
    }

    public void BackgroundMusicReset()
    {
        audioNum = Random.Range(0, backgroundMusic.Length);
        BackgroundMusic.clip = backgroundMusic[audioNum];
        BackgroundMusic.Play();   
    }
}
