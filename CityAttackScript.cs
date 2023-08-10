using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityAttackScript : MonoBehaviour
{
    public int CityHP;
    public int WallHP;

    public string cityFaction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            Debug.Log("Select Target: B- barbarians, K- kingdom, m-mages, w- whites");
            if(Input.GetKeyDown(KeyCode.B)){
                if(cityFaction == "Barbarians"){
                    //The City takes damage equal to the card's attack
                    Debug.Log("Barbarians attacked!");
                }
            }
            if(Input.GetKeyDown(KeyCode.K)){
                if(cityFaction == "Kingdom"){
                    //The City takes damage equal to the card's attack
                     Debug.Log("Kingdom attacked!");
                }
            }
            if(Input.GetKeyDown(KeyCode.M)){
                if(cityFaction == "Mages"){
                    //The City takes damage equal to the card's attack
                     Debug.Log("Mages attacked!");
                }
            }
            if(Input.GetKeyDown(KeyCode.W)){
                if(cityFaction == "Whites"){
                    //The City takes damage equal to the card's attack
                     Debug.Log("Whites attacked!");
                }
            }

        }
    }
}
