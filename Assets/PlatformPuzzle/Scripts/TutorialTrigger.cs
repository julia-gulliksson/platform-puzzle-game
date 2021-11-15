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
        GameEventsManager.current.onObjectPickedUp += SetPickedUp;
    }

    void OnDisable()
    {
        GameEventsManager.current.onObjectPickedUp -= SetPickedUp;
    }

    void SetPickedUp()
    {
        // Player has picked up an object, deactivate the tutorial text
        hasPickedUp = true;
        tutorialUI.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasPickedUp)
        {
            // TODO: Make into an event
            if (!tutorialUI.activeSelf) tutorialUI.SetActive(true);
            tutorialAnimationController.SetBool("fadeIn", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && !hasPickedUp)
        {
            tutorialAnimationController.SetBool("fadeIn", false);
        }
    }
}
