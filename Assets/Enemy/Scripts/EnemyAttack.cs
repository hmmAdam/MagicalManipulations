using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Transform playerTransform;
    Transform wandTransform;
    float maxDistanceToTarget = 6f;
    float distanceToTarget;

    [SerializeField]
    float rawDamage = 10f;

    [SerializeField]
    float delayTimer = 2f;
    float tick;
    bool attackReady = true;

    void Start()
    {
        tick = delayTimer;
        wandTransform = gameObject.transform.Find("Gun");
    }

    void Update()
    {
        Attack();
    }

    bool IsReadyToAttack()
    {
        if (tick < delayTimer)
        {
            tick += Time.deltaTime;
            return false;
        }

        return true;
    }

    void LookAtTarget()
    {
        //this.transform.LookAt(playerTransform.position);
        Vector3 lookVector = playerTransform.position - transform.position;
        lookVector.y = transform.position.y;
        Quaternion rotation = Quaternion.LookRotation(lookVector);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0.01f);
    }

    void Attack()
    {
        distanceToTarget = Vector3.Distance(playerTransform.position, wandTransform.position);
        attackReady = IsReadyToAttack();

        if (distanceToTarget <= maxDistanceToTarget)
        {
            LookAtTarget();

            if (attackReady)
            {
                tick = 0f;
                Ray ray = new Ray(wandTransform.position, wandTransform.forward);
                RaycastHit raycastHit;

                if (Physics.Raycast(ray, out raycastHit, maxDistanceToTarget))
                {
                    Debug.Log("Enemy Shoots");
                    if (raycastHit.transform != null)
                    {
                        raycastHit.collider.SendMessageUpwards("Hit", rawDamage, SendMessageOptions.DontRequireReceiver);
                    }
                }
                else
                {
                    Debug.Log("ENEMY: FAILED RAYCAST");
                }
            }
        }
    }
}
