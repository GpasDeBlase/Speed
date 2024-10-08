using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Train : MonoBehaviour
{
    public int speed = 1;
    public bool move = false;



    void Start()
    {
        
    }


    void Update()
    {
        if (move) transform.position += transform.forward * speed * Time.deltaTime;
    }
}
