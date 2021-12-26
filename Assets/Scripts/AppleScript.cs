using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleScript : MonoBehaviour
{
    private GameObject player;

    void Start() 
        {
         player = GameObject.FindWithTag("Player"); 
         }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerMovement>().Heal(1);
        }
        Destroy(gameObject);
    }
}
