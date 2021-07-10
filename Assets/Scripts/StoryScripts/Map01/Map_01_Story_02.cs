using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_01_Story_02 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        Tutorial.Instance.showMessage("He jumps over abysses with the roaring sea under his feet.");
    }

    private void OnTriggerExit(Collider other) {
        Tutorial.Instance.unShow();
    }
}
