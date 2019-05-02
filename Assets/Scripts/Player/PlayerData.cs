using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    [SerializeField] float movementSpeed;
    [HideInInspector] public float Speed { get { return movementSpeed * Time.deltaTime; } }
    public float JumpForce;
}
