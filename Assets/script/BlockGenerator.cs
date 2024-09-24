using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class BlockGenerator : MonoBehaviour
{
    int nbColonne = 2; // fixe
    public int nbLigne = 4;
    public GameObject Box;
    public Material Black;
    public Material White;
    private UnityEngine.Vector3 StartLinePos;

    public float H;
    public float P;
    public float L;

    public float LSpace;
    //public float HSpace;
    private float PSpace;
    public float LRoad;

    void Start() 
    {
        this.GetComponent<MeshRenderer>().enabled = false;
        StartLinePos = transform.position;
        StartLinePos.y = 0;
        StartLinePos.x -= (LRoad+P+PSpace)/ 2;
        Material currentmat = White;
        for (int i = 0; i < nbLigne; i++)
        {
            for (int j = 0; j < nbColonne; j++)
            {
                UnityEngine.Vector3 Pos = new UnityEngine.Vector3((j * P) + (j * PSpace)+((j % 2)* LRoad), H / 2, (L * i) + (LSpace * i)) + StartLinePos; // -(j/2)*(P*j+PSpace*j)+(1/2 LRoad)
                GameObject GO = Instantiate(Box);
                GO.transform.position = Pos;
                GO.transform.localScale = new UnityEngine.Vector3(P, H, L);
                GO.GetComponent<MeshRenderer>().material = currentmat;
                
            }
            if(currentmat == White)
            {
                currentmat = Black;
            }
            else
            {
                currentmat = White;
            }

        }
    }
    

}
