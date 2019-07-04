using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceFightProject
{
    public class PlayerFireController : MonoBehaviour
    {
        public System.Action strike;

        private void FixedUpdate()
        {
            float fire = Input.GetAxis("Fire1");

            if (fire != 0)
                strike();
        }

        public void RemoveFireContoller()
        {
            GameObject.Destroy(this);
        }

    }
}