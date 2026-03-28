using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", 
menuName = "Data/Enemy", order = 1)]
public class EnemyData : EntityBaseData
{
    public int goldDrop;
    public float timeApearance;
}
