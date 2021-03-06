﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour {

	private Animator anim;

	public bool isShadow;

	// Use this for initialization
	void Start () {

		anim = GetComponent<Animator> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		bool moveLeft;
		bool moveRight;
		bool moving;

		if (isShadow) {

            if (Input.GetAxis("LeftJoystickX") < 0 
                || (Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow))){
                moveLeft = true;
                moveRight = false;
            } else if(Input.GetAxis("LeftJoystickX") > 0 
                || (Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow))){
                moveLeft = false;
                moveRight = true;
            } else
            {
                moveLeft = false;
                moveRight = false;
            }

		} else {

            if (Input.GetAxis("LeftJoystickX_P2") < 0
                || (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D)))
            {
                moveLeft = true;
                moveRight = false;
            }
            else if (Input.GetAxis("LeftJoystickX_P2") > 0
              || (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A)))
            {
                moveLeft = false;
                moveRight = true;
            }
            else
            {
                moveLeft = false;
                moveRight = false;
            }

            //moveLeft = Input.GetKey (KeyCode.A) && !Input.GetKey (KeyCode.D);
            //moveRight = Input.GetKey (KeyCode.D) && !Input.GetKey (KeyCode.A);
        }

		moving = moveLeft || moveRight;

		anim.SetBool ("running", moving);

		if (moveLeft)
			anim.SetBool ("faceRight", false);
		else if (moveRight)
			anim.SetBool ("faceRight", true);
		
	}
}
