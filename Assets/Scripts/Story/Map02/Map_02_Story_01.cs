using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_02_Story_01 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        Story.Instance.showMessage("His journey leads him through a dark and mystic forest with weird creatures.");
    }

    private void OnTriggerExit(Collider other) {
        Story.Instance.unShow();
    }
}
