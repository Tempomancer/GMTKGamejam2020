using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectPuller : MonoBehaviour {

    [System.Serializable]
    public class Pool {
        public string tag;
        public GameObject prefab;
        public int size;
    }


    #region Singleton
    public static objectPuller Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;


    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionary.Add(pool.tag, objectPool);
        }
    }




        public GameObject SpawnFromPool (string tag, Vector2 position, Quaternion rotation)
        {
            if (!poolDictionary.ContainsKey(tag))
            {
                Debug.LogWarning("Pool with tag" + tag + "doesn't exist.");
                return null;
            }


            GameObject objectToSpawn = poolDictionary[tag].Dequeue();

            objectToSpawn.SetActive(true);
            objectToSpawn.transform.position = position;

            // objectToSpawn.transform.rotation = rotation;

            poolDictionary[tag].Enqueue(objectToSpawn);

            return objectToSpawn;
        }

//    public void ReturnObjectToPool(string poolName, GameObject poolObject)
//    {
//        if (poolDictionary.ContainsKey(poolName))
//        {
//            objectPoolDictionary[poolName].Enqueue(poolObject);
//            poolObject.SetActive(false);
//        }
//        else
//        {
//            Debug.Log(poolName + " object pool is not available");
//        }
//    }
//}
   

}



