using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMovement : MonoBehaviour
{
    [SerializeField] Animator animationController;
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
        // Depending on if the platform has been triggered or not, the wall will move up or down
        animationController.SetBool("platformTriggered", entered);
    }
}
