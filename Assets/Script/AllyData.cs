using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", 
menuName = "Data/Ally", order =2)]
public class AllyData : EntityBaseData
{
    public int summonCost;
    public float summonCoolDown;
}
