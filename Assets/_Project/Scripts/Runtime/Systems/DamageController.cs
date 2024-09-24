using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageController : MonoBehaviour
{
    public int HP;
    public Transform hitPoint;

    public void TakeDamage(int amount)
    {
        HP -= amount;
        print("tomei " + amount + " de dano " + name);
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }

}
