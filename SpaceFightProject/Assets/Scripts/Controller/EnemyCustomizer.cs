using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SpaceFightProject
{
    public class EnemyCustomizer
    {
        private string prefabLink = "Prefabs/Game/Enemys/Enemy";
        private GameObject prefab;

        private float minSpeed;
        private float maxSpeed;
        private int minHp;
        private int maxHp;
        public int Power { set; get; }

        public EnemyCustomizer()
        {
            SetBaseParamerers();
            LoadPrefab();
        }
        public EnemyCustomizer SetSpeed(float min, float max)
        {
            minSpeed = min;
            maxSpeed = max;
            return this;
        }
        public EnemyCustomizer SetHp(int min, int max)
        {
            minHp = min;
            maxHp = max;
            return this;
        }
        public BaseGameObject EnemySpawn(Transform spawn)
        {
            float board = 70;
            float posXRange = ((RectTransform)spawn).rect.width / 2 - board;
            float speed = Random.Range(minSpeed, maxSpeed);

            prefab.GetComponent<Rigidbody2D>().gravityScale = speed;
            GameObject clone = GameObject.Instantiate(prefab, Vector3.zero, 
                Quaternion.identity, spawn) as GameObject;
            clone.transform.localPosition = new Vector3(Random.Range((-1) * posXRange, posXRange), 0, 0); //Change position 
            return new BaseGameObject(clone.GetComponent<GameObjectView>(), 
                RandomNumber(minHp, maxHp), 0, Power, Fractions.Enemy);
        }
        private int RandomNumber(int min, int max)
        {
            System.Random random = new System.Random();
            return random.Next(min, max);
        }
        private void LoadPrefab()
        {
            prefab = Resources.Load(prefabLink, typeof(GameObject)) as GameObject;
        }
        private void SetBaseParamerers()
        {
            minSpeed = 7;
            maxSpeed = 11;
            minHp = 4;
            maxHp = 10;
            Power = 1;
        }
    }
}
