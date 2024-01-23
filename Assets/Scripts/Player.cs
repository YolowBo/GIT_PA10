using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Animation thisAnimation;
    private Rigidbody rb;
    [SerializeField]private GameManager GM;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            thisAnimation.Play();
            rb.velocity = Vector3.up * 3.5f;
        }
           
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Points")
        {
            GM.UpdateScore(1);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Object")
        {
            GM.GameOver();
        }
    }
}
