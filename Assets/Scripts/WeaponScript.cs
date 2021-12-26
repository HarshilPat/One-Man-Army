using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class WeaponScript : MonoBehaviour
{
    private bool swing = false;

    private int degree = 0;

    private float weaponY = -0.4f;

    private float weaponX = -0.3f;

    private Vector3 pos;

    [SerializeField]
    public GameObject player;
    
    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerMovement>().turnedRight)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            weaponX = 0.3f;
        }

        else
        {
            GetComponent<SpriteRenderer>().flipX = false;
            weaponX = -0.3f;
        }

        pos = player.transform.position;
        pos.x += weaponX;
        pos.y += weaponY;
        transform.position = pos;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<SpriteRenderer>().enabled = true;
            transform.GetChild(0).gameObject.SetActive(true);
            Attack();
        }
    }

    private void FixedUpdate()
    {
        if (swing)
        {
            degree -= 7;
            if (degree < -65)
            {
                degree = 0;
                swing = false;
                //GetComponent<SpriteRenderer>().enabled = false;
                transform.GetChild(0).gameObject.SetActive(false);
            }
            transform.eulerAngles = Vector3.forward * degree;
            pos = player.transform.position;
            pos.x += weaponX;
            pos.y += weaponY;
            transform.position = pos;
        }
    }

    void Attack()
    {
        if (player.GetComponent<PlayerMovement>().turnedRight)
        {
            GetComponent<SpriteRenderer>().flipX = true;
            weaponX = 0.3f;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = false;
            weaponX = -0.3f;
        }
        pos = player.transform.position;
        pos.x += weaponX;
        pos.y += weaponY;
        transform.position = pos;

        swing = true;
    }
}