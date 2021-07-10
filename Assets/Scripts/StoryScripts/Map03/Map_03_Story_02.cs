using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_03_Story_02 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        Tutorial.Instance.showMessage("He dodges dangerous Traps on his way to find Water.");
    }

    private void OnTriggerExit(Collider other) {
        Tutorial.Instance.unShow();
    }
}
