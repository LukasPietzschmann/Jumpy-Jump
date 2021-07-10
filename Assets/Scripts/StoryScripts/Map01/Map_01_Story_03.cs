using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_01_Story_03 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        Tutorial.Instance.showMessage("He avoids evil Spiders and Traps to travel from World to World.");
    }

    private void OnTriggerExit(Collider other) {
        Tutorial.Instance.unShow();
    }
}
