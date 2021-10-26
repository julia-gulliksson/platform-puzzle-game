using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMovement : MonoBehaviour
{
    void OnEnable()
    {
        PlatformTrigger.platformTriggered += MovePlatform;
    }

    void OnDisable()
    {
        PlatformTrigger.platformTriggered -= MovePlatform;
    }

    void MovePlatform(bool entered)
    {
        Debug.Log("Moved!" + entered);
    }
}
