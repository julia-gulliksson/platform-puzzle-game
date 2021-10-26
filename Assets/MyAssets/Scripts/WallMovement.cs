using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMovement : MonoBehaviour
{
    //[SerializeField] Animator animationController;
    Animator animationController;
    void OnEnable()
    {
        animationController = gameObject.GetComponent<Animator>();
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
