using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSystemsScipt : MonoBehaviour
{
    public int currentturn;
    public int energy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void newturn(){
        ++currentturn;
        energy = currentturn;
        
    }
}
