using System;
using System.Collections.Generic;
using UnityEngine;

namespace main{
    public class Fire : MonoBehaviour{
        public int bulletType = 1;
        private Dictionary<Rigidbody2D, BulletCollection> bulletDictionary = new Dictionary<Rigidbody2D, BulletCollection>();

        public void CalculateStart(){
            BulletCollection _currentBullet = null;
            foreach (var bullet in ImplementedBullet.ImplementedBulletList){
                if (bulletType == bullet.EnumType)
                    _currentBullet = bullet;
            }
            if (_currentBullet != null){
                Vector3 bulletSize = _currentBullet.RBody.gameObject.GetComponent<Renderer>().bounds.size;
                float ang = transform.eulerAngles.z;
                int forX = ang > 180 ? -1 : 1;
                int forY = ang > 90 && ang < 270 ? 1 : -1;
                Vector2 bulletPosition = new Vector2(transform.position.x + bulletSize.x / 2 * forX,
                    transform.position.y + bulletSize.y / 2 * forY);

                Rigidbody2D bulletInstance =
                    Instantiate(_currentBullet.RBody, bulletPosition, transform.rotation);
                /*
                 * transfer bullet information, name destroy force, in GO name
                 */
                bulletInstance.gameObject.name = "bullet " + name;
                bulletInstance.gameObject.AddComponent<UnityBulletInstance>();
                bulletInstance.gameObject.GetComponent<UnityBulletInstance>().DestroyForce = _currentBullet.DestroyForce;
                bulletDictionary.Add(bulletInstance, _currentBullet);
            }
        }

        public void ClearAll(){
            foreach (var k in bulletDictionary){
                if (k.Key != null){
                    Destroy(k.Key.gameObject);
                }
            }
        }

        private void FixedUpdate(){
            if (bulletDictionary.Count > 0){
                foreach (var bullet in bulletDictionary){
                    if (bullet.Key != null){
                        if (Math.Abs(transform.position.x - bullet.Key.transform.position.x) > bullet.Value.Range ||
                            Math.Abs(transform.position.y - bullet.Key.transform.position.y) > bullet.Value.Range){
                            bulletDictionary.Remove(bullet.Key);
                            Destroy(bullet.Key.gameObject);
                            break;
                        } else{
                            if (bullet.Value.DirectionType == "straight"){
                                StaightDirection(bullet);
                            }
                        }
                    } else{
                        bulletDictionary.Remove(bullet.Key);
                        break;
                    }
                }
            }
        }

        
    }
}