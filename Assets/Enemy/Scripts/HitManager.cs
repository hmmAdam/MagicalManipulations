using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    float hitPoints = 50;

    void Hit(float rawDamage)
    {
        hitPoints -= rawDamage;
        if (hitPoints <= 0)
        {
            Invoke("SelfTerminate", 0f);
        }
    }

    void SelfTerminate()
    {
        Destroy(gameObject);
    }
}
