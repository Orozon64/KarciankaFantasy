using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "newCard", menuName = "Card")]
public class Card : ScriptableObject
{
    public string cardName;
    public string cardCategory;
    public string cardTag;
    public string cardFaction;
    public int cardAttack;
    public int cardHP;
    public int cardCost;
    public string cardAbility;
}
