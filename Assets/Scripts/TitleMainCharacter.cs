using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleMainCharacter : MonoBehaviour
{
    private float Playtime;
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        Playtime = 0f;
        anim = GetComponent<Animator>();
        anim.SetBool("Idle", true);
        anim.SetBool("Hold", false);
        anim.SetBool("Slide", false);
        
        

    }

    // Update is called once per frame
    void Update()
    {
        Playtime += Time.deltaTime;
    }

    void AnimationHold()
    {
        anim.SetBool("Idle", false);
        anim.SetBool("Hold", true);
        anim.SetBool("Slide", false);
    }

    void AnimationSlide()
    {
        anim.SetBool("Idle", false);
        anim.SetBool("Hold", false);
        anim.SetBool("Slide", true);
    }
    void AnimationIdle()
    {
        anim.SetBool("Idle", true);
        anim.SetBool("Hold", false);
        anim.SetBool("Slide", false);
    }
}
