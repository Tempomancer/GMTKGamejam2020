using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletSpawner : MonoBehaviour
{

    objectPuller objectPooler;

    private void Start()
    {
        objectPooler = objectPuller.Instance;
    }
    private void FixedUpdate()
    {
        objectPooler.SpawnFromPool("Bullet", transform.position, Quaternion.identity);
    }
}
