using UnityEngine;
using System.Collections;

namespace main{
    public class Bullet : MonoBehaviour{
        // private GameObject _bullet;
        public static Color Color;

        public void Start(){
            Color = new Color(0.2F, 0.3F, 0.4F, 0.5F);
        }

        public static void Create(){
            GameObject bullet = new GameObject("bullet");
            bullet.AddComponent<CircleCollider2D>();
            bullet.AddComponent<Renderer>();
            bullet.GetComponent<CircleCollider2D>().radius = 3;
            bullet.GetComponent<Renderer>().material.SetColor(1, Color);
        }

        private void BulletStartPosition(){
        }
    }
}