using strange.extensions.mediation.impl;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SpaceFightProject
{
    public class GameObjectView : View, IMyView
    {
        public delegate bool SetDamageDelegate(float damage);
        public SetDamageDelegate setDamage;

        public delegate void DestroyIt();
        public DestroyIt destroyIt;

        public delegate float DamagePover();
        public DamagePover damagePover;

        public void LoadView()
        {
            destroyIt += DestoryObject;
        }
        public void RemoveView() { }

        private void DestoryObject()
        {
            GameObject.Destroy(gameObject);
        }

        public void SetDamage(float damage)
        {
            if (setDamage(damage))
                destroyIt();
        }

    }
}
