using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    public Collider2D collAtack;

    public void AttackTrue()
    {
        collAtack.enabled = true;   
    }

    public void AttackFalse()
    {
        collAtack.enabled = false;
    }
}
