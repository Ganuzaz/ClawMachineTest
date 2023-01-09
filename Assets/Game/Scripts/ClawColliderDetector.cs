using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawColliderDetector : MonoBehaviour
{

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("Prize") || collision.gameObject.CompareTag("BaseCabinet"))
        {
            EventManager.instance.InvokeEvent(EventEnums.CLAW_COLLIDER_COLLISION_ENTER);
        }
    }
}
