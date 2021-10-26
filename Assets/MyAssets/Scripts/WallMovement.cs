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
        Debug.Log("Moved!" + entered);
        animationController.SetBool("platformTriggered", entered);
    }
}
