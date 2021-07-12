using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_01_Story_01 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        Debug.Log(Story.Instance);
        Story.Instance.showMessage("To escape his boring homelife and to explore the world,\n he walks over cliffs in the sea.");
    }

    private void OnTriggerExit(Collider other) {
        Story.Instance.unShow();
    }
}
