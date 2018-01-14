using System;
using System.Collections;
using System.Collections.Generic;
using main;
using UnityEngine;
using Random = UnityEngine.Random;

public class ShotgunBullet : MonoBehaviour{
    public class BulletShotgunSimple : BulletCollection{
        // class must generate and save all own clones
        public float Speed = 5f;

        public float Range = 200;
        public float DestroyForce = 7;
        private Rigidbody2D rBody;
        private List<Rigidbody2D> bulletList = new List<Rigidbody2D>();

        private void Start(){
            rBody = RBody("SimpleShotgun");
        }

        public override void CreateClone(Transform targetTrasnform, int counter){
            Transform copiedTransform = targetTrasnform;
            if (counter == 0){
                Debug.Log("COPIED");
                copiedTransform = Instantiate(targetTrasnform);
                copiedTransform.gameObject.SetActive(false);
            }
            Vector3 bulletSize = rBody.gameObject.GetComponent<Renderer>().bounds.size;
            float ang = copiedTransform.eulerAngles.z * Random.Range(17.8f, -17.8f);
            int forX = ang > 180 ? -1 : 1;
            int forY = ang > 90 && ang < 270 ? 1 : -1;
            Vector2 bulletPosition = new Vector2(copiedTransform.position.x + bulletSize.x / 2 * forX,
                copiedTransform.position.y + bulletSize.y / 2 * forY);
            Rigidbody2D bulletInstance =
                Instantiate(rBody, bulletPosition, copiedTransform.rotation);
            bulletInstance.gameObject.AddComponent<BulletOwner>().Owner = copiedTransform.gameObject;
            bulletList.Add(bulletInstance);
            if (counter < 8){
                counter++;
                StartCoroutine(CreateCloneIteration(copiedTransform, counter));
            } else{
                // Destroy(copiedTransform.gameObject);
            }
        }

        IEnumerator CreateCloneIteration(Transform targetTrasnform, int counter){
            yield return new WaitForSeconds(0.01f);
            CreateClone(targetTrasnform, counter);
        }

        public override void Fly(){
            if (bulletList.Count > 0){
                foreach (var bullet in bulletList){
                    GameObject owner = bullet?.gameObject.GetComponent<BulletOwner>().Owner;
                    if (bullet != null && owner != null){
                        if (Math.Abs(owner.transform.position.x - bullet.transform.position.x) > Range ||
                            Math.Abs(owner.transform.position.y - bullet.transform.position.y) > Range){
                            bulletList.Remove(bullet);
                            Destroy(owner);
                            Destroy(bullet.gameObject);
                            break;
                        } else{
                            Transform vt = bullet.transform;
                            //var l = 0.1 / Math.Cos(vt.eulerAngles.z); // length gipotenyza from katet and angle
                            double x = vt.position.x + Math.Cos(vt.eulerAngles.z * Mathf.Deg2Rad) * Speed;
                            double y = vt.position.y + Math.Sin(vt.eulerAngles.z * Mathf.Deg2Rad) * Speed;
                            vt.position = new Vector3((float) x, (float) y, 0);
                        }
                    } else{
                        bulletList.Remove(bullet);
                        break;
                    }
                }
            }
        }
    }
}