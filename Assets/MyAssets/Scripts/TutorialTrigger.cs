using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTrigger : MonoBehaviour
{
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
        hasPickedUp = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6 && !hasPickedUp)
        {
            tutorialUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 6)
        {
            tutorialUI.SetActive(false);
        }
    }
}
