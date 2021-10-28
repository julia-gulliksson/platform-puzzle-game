using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTrigger : MonoBehaviour
{
    [SerializeField] Animator tutorialAnimationController;
    [SerializeField] GameObject tutorialUI;
    bool hasPickedUp = false;

    void OnEnable()
    {
        PickUpObjects.objectPickedUp += SetPickedUp;
    }

    void OnDisable()
    {
        PickUpObjects.objectPickedUp -= SetPickedUp;
    }

    void SetPickedUp()
    {
        // Player has picked up an object, deactivate the tutorial text
        hasPickedUp = true;
        tutorialUI.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6 && !hasPickedUp)
        {
            if (!tutorialUI.activeSelf) tutorialUI.SetActive(true);
            tutorialAnimationController.SetBool("fadeIn", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 6 && !hasPickedUp)
        {
            tutorialAnimationController.SetBool("fadeIn", false);
        }
    }
}
