using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceFightProject
{
    public class PlayerMoveController : MonoBehaviour
    {
        public float speed = 1;
        private Rigidbody2D rb;
        protected void Start()
        {
            rb = gameObject.GetComponent<Rigidbody2D>();
        }
        protected void FixedUpdate()
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector2 movement = new Vector2(moveHorizontal, moveVertical);

            rb.AddForce(movement * speed);
        }
    }


}
