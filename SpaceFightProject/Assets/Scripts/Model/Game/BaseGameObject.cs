using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceFightProject
{
    public class BaseGameObject
    {
        public GameObject Object;
        public float MaxHp { get; set; }
        public float CurrentHp { get; set; }

        public bool SetDamageOrDestroy(float damage)
        {
            CurrentHp -= damage;
            if (CurrentHp <= 0)
            {
                GameObject.Destroy(Object);
                return true;
            }
            return false;
        }
        public BaseGameObject() { }
        public BaseGameObject(ref GameObject obj)
        {
            Object = obj;
        }
        public BaseGameObject(ref GameObject obj, float maxHp)
        {
            Object = obj;
            CurrentHp = MaxHp = maxHp;
        }

    }
}
