using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_02_Story_01 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        Tutorial.Instance.showMessage("His journey leads him through a dark Forest.");
    }

    private void OnTriggerExit(Collider other) {
        Tutorial.Instance.unShow();
    }
}
