using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrizeObject : MonoBehaviour
{
    public PrizeType prizeType;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PrizeDetector"))
        {
            EventManager.instance.InvokeEvent(EventEnums.PRIZE_ON_DROPPED, new Hashtable()
            {
                {"prizeObject", this.gameObject },
                {"prizeType", prizeType }
            });
        }
    }
}
