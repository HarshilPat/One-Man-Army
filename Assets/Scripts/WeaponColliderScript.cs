using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class WeaponColliderScript : MonoBehaviour
{
    public GameObject player;

    private bool isColliding = false;

    float time = 0.1f;
    float timer = 0f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) {
            if (isColliding == false){
                isColliding = true;
                collision.gameObject.GetComponent<EnemyScript>().TakeDamage(1);
            }
        }

        if (collision.gameObject.CompareTag("Spawner"))
        {
            collision.gameObject.GetComponent<SpawnerScript>().takeDamage(1);
        }
    }

    void Update() {
        timer += Time.deltaTime;
        if (timer > time) {
        isColliding = false;
        timer = 0f;
        }
    }
}