using UnityEngine;
using System.Collections;

namespace main{
    public class Bullet : MonoBehaviour{
        public string BulletOwner;
        private Sprite _sprite;
        public Rigidbody2D CreateBullet(){
            getSprite();
            GameObject bullet = new GameObject("bullet");
            bullet.AddComponent<SpriteRenderer>();
            bullet.GetComponent<SpriteRenderer>().sprite =
                Sprite.Create(_sprite.texture, _sprite.textureRect, _sprite.textureRectOffset);
            bullet.AddComponent<CircleCollider2D>();
            bullet.AddComponent<Rigidbody2D>();
            bullet.GetComponent<CircleCollider2D>().isTrigger = true;
            bullet.GetComponent<Rigidbody2D>().gravityScale = 0;
            bullet.transform.position = new Vector3(-100000, 0, 0);
            return bullet.GetComponent<Rigidbody2D>();
        }

        private void getSprite(){
            var sprites = Resources.LoadAll<Sprite>("source/index_2.1");
            foreach (var val in sprites){
                if (val.name == "index_2.1_bullet"){
                    _sprite = val;
                }
            }
        }        
    }
}