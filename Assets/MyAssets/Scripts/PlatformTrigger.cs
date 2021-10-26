using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTrigger : MonoBehaviour
{
    [SerializeField] Animator animationController;

    private void OnTriggerEnter(Collider other)
    {
        animationController.SetBool("trigger", true);
    }

    private void OnTriggerExit(Collider other)
    {
        animationController.SetBool("trigger", false);
    }

}
