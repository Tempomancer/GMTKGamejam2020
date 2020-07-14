using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour
{
    public int enemies;
    public Renderer rend;
    private sceneManager manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = GetComponent<sceneManager>();
        // rend.material.SetColor(Color.white);
    }


}
