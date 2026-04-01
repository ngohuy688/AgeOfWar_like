using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EntityBaseData : ScriptableObject
{
    public int damage;
    public int healthPoint;
    public float movementSpeed;
    public float moveDirection;
    public float attackInterval;
    public float attackSpeed;
    public Vector2 attackRange;
    public int knockBack;
    public bool AOE;
    public bool pushBack;
    public int pushBackRate;
}
