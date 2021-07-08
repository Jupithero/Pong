﻿using System;
using UnityEngine;

namespace GamePlay {
    public class PlayerController : MonoBehaviour {
        private Rigidbody2D sliderRigidbody2D;
        private const float Speed = 9f;
        private Vector2 Direction;
        public Joystick joystick;

        private void Start() {
            sliderRigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        }
        
        private void Update() {
            Direction = GetNewDirection();
        }
        
        private void FixedUpdate() {
            sliderRigidbody2D.velocity = Speed * Direction;
        }

        private Vector2 GetNewDirection() {
            //return new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
            return new Vector2(joystick.Horizontal, joystick.Vertical).normalized;
        }

        private static Vector2 GetPressedDirection() {
            if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.RightArrow)) return new Vector3(1, 1);
            if (Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.DownArrow)) return new Vector3(1, -1);
            if (Input.GetKey(KeyCode.DownArrow) && Input.GetKey(KeyCode.LeftArrow)) return new Vector3(-1, -1);
            if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.UpArrow)) return new Vector3(-1, 1);

            if (Input.GetKey(KeyCode.UpArrow)) return Vector2.up;
            if (Input.GetKey(KeyCode.DownArrow)) return Vector2.down;
            if (Input.GetKey(KeyCode.RightArrow)) return Vector2.right;
            if (Input.GetKey(KeyCode.LeftArrow)) return Vector2.left;

            return Vector2.zero;
        }
    }
}