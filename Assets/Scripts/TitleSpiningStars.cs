using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSpiningStars : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    void Update()
    {
        this.gameObject.transform.RotateAround(this.gameObject.transform.position, Vector3.forward, moveSpeed * Time.deltaTime);
    }
}
