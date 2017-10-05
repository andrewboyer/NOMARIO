﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCollider : MonoBehaviour
{
    public bool shadowDrop = false;
    public bool playerDrop = false;
    public GameObject human;
    public GameObject shadow;

    private Collider2D coll;

    // Use this for initialization.
    void Start()
    {
        coll = GetComponent<Collider2D>();
    }

    // At the start of every physics frame, check whether the players collide
    private void FixedUpdate()
    {
        CheckCollisions(human, false);
        CheckCollisions(shadow, true);
    }

    private void CheckCollisions(GameObject player, bool isShadow)
    {
        Rigidbody2D playerRigidbody = player.GetComponent<Rigidbody2D>();
        Collider2D playerColl = player.GetComponent<Collider2D>();

        // Calculate the top of the player and the bottom of the platform.
        float playerHeight = playerColl.bounds.size.y;
        float playerTop = player.transform.position.y + playerHeight / 2 + 0.01f;
        float playerBot = player.transform.position.y - playerHeight / 2 - 0.01f;

        float platformHeight = coll.bounds.size.y;
        float platformTop = transform.position.y + platformHeight / 2 + 0.01f;
        float platformBot = transform.position.y - platformHeight / 2 - 0.01f;

                
        // If the player is moving upwards, don't collide
        if (playerRigidbody.velocity.y > 0.1f)
        {
            if (isShadow) shadowDrop = true;
            else playerDrop = true;
        }

        // If the player is at the midpoint of the platform
        if (playerTop > platformTop && platformBot > playerBot)
        {
            if (isShadow) shadowDrop = true;
            else playerDrop = true;
        }



        if (shadowDrop && isShadow)
        {
            // If player drops all the way through platform, stop dropping.
            if ((playerTop < platformBot || platformTop < playerBot))
            {
                shadowDrop = false;
            }

            Physics2D.IgnoreCollision(coll, playerColl, shadowDrop);
        }
        else if (playerDrop && !isShadow)
        {
            // If player drops all the way through platform, stop dropping.
            if ((playerTop < platformBot || platformTop < playerBot))
            {
                playerDrop = false;
            }

            Physics2D.IgnoreCollision(coll, playerColl, playerDrop);
        }            
    }
}
