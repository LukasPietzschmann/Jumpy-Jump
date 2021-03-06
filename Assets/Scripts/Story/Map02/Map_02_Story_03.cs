using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_02_Story_03 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        Story.Instance.showMessage("The shape of the landscape changed. The sun burns on his head and he runs faster to find a house.");
    }

    private void OnTriggerExit(Collider other) {
        Story.Instance.unShow();
    }
}
