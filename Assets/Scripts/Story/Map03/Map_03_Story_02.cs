using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_03_Story_02 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        Story.Instance.showMessage("He dodges dangerous traps on his way to find water and civilization.");
    }

    private void OnTriggerExit(Collider other) {
        Story.Instance.unShow();
    }
}
