using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSpiningStars : MonoBehaviour
{
    void Update()
    {
        this.gameObject.transform.RotateAround(this.gameObject.transform.position, Vector3.forward, Time.deltaTime);
    }
}
