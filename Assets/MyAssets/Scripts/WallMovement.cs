using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMovement : MonoBehaviour
{
    Animator animationController;
    // The platform trigger that this wall belongs to
    [SerializeField] int triggerId;
    void OnEnable()
    {
        animationController = GetComponent<Animator>();
        PlatformTrigger.platformTriggered += MovePlatform;
    }

    void OnDisable()
    {
        PlatformTrigger.platformTriggered -= MovePlatform;
    }

    void MovePlatform(bool entered, int id)
    {
        if (id == triggerId)
        {
            // Depending on if the correct platform has been triggered or not, the wall will move up or down
            animationController.SetBool("platformTriggered", entered);
        }
    }
}
