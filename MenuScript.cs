using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public string playerfaction;
    public Button PlayButton; //To use onClick, we create a button object...
    public Button BarbFactionButton;
    public Button GMKFactionButton;
    public Button MageFactionButton;
    // Start is called before the first frame update
    void Start()
    {
        Button playbtn = PlayButton.GetComponent<Button>();
        Button barbarianbutton = BarbFactionButton.GetComponent<Button>();

        Button gmkbutton = GMKFactionButton.GetComponent<Button>();
        Button magesbutton = MageFactionButton.GetComponent<Button>();
         //...then make another and have it store the Button component of the first object.
        
    }

    public void PlayAsBarbs(){
        
        SceneManager.LoadScene("MainScene");
        playerfaction = "Barbarians";
        Debug.Log("Selected Barbarians");
    }
    public void PlayAsKingdom(){
        
        SceneManager.LoadScene("MainScene");
        playerfaction = "Kingdom";
        Debug.Log("Selected Kingdom");
    }
    public void PlayAsMages(){
        
        SceneManager.LoadScene("MainScene");
        playerfaction = "Mages";
        Debug.Log("Selected Mages");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
