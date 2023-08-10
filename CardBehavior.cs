using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardBehavior : MonoBehaviour
{
    public Card card;
    public TMP_Text nameText;
    //public TMP_Text categoryText;
    public TMP_Text factionText;
    public TMP_Text AttackText;
    public TMP_Text HPText;
    public TMP_Text costText;
    // Start is called before the first frame update
    void Start()
    {
        nameText.text = card.cardName;
        factionText.text = card.cardFaction;
        AttackText.text = card.cardAttack.ToString();
        HPText.text = card.cardHP.ToString();
        costText.text = card.cardCost.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
