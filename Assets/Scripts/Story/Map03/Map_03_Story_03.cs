using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_03_Story_03 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        Story.Instance.showMessage("And finally, after he avoided all traps and enemies he finds a harbour. So his next task is to find a way over the sea.");
    }

    private void OnTriggerExit(Collider other) {
        Story.Instance.unShow();
    }
}
