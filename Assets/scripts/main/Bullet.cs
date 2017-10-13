using UnityEngine;
using System.Collections;

namespace main{
    public class Bullet : MonoBehaviour{
        // private GameObject _bullet;
        public static Color Color;

        private static string spriteNames = "source/index_2.1";
        private static Sprite _sprite;
        private static Texture2D _texture;

        public static void BulletInit(){
            var sprites = Resources.LoadAll<Sprite>("source/index_2.1");
            foreach (var val in sprites){
                if (val.name == "index_2.1_bullet"){
                    _sprite = val;
                }
            }
        }

        public static void Create(float shuttleAnglesZ, Transform transform){
            GameObject bullet = new GameObject("bullet");
            bullet.AddComponent<CircleCollider2D>();
            bullet.AddComponent<SpriteRenderer>();
            bullet.GetComponent<SpriteRenderer>().sprite =
                Sprite.Create(_sprite.texture, _sprite.textureRect, _sprite.textureRectOffset);
            bullet.GetComponent<CircleCollider2D>().radius = 0.1f; //_sprite.textureRect.height/2;
            BulletVector(bullet, shuttleAnglesZ, transform);
            // bullet.transform.position = new Vector3(0, 0, 1);
        }

        private static void BulletVector(GameObject bullet, float angle, Transform transform){
            var ang = Mathf.MoveTowardsAngle(transform.eulerAngles.z, 5f, 0.5f * Time.deltaTime);
            bullet.transform.eulerAngles = new Vector3(1, ang, 1);
        }
    }
}