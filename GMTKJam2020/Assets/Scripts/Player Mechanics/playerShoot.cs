using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShoot : MonoBehaviour
{
    public Transform firePos;
    public GameObject bulletPrefab;
    objectPuller objectPooler;

    [SerializeField] private float shootCD;//cooldown for shooting
    [SerializeField] private float timeSinceLastShot;

    private void Start()
    {
        objectPooler = objectPuller.Instance;

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && timeSinceLastShot <= 0f)
        {
            Shoot();
            timeSinceLastShot = shootCD;
        }else if(timeSinceLastShot > 0f){
            timeSinceLastShot -= Time.deltaTime;
        }
    }

    private void Shoot()
    {
        GameObject daBullet = objectPooler.SpawnFromPool("Bullet", firePos.position, firePos.rotation);
        //GameObject daBullet = Instantiate(bulletPrefab, firePos.position, firePos.rotation);
        daBullet.GetComponent<Bullet>().moveDir = firePos.up;
       
        daBullet.GetComponent<Bullet>().launch();
    }

}
