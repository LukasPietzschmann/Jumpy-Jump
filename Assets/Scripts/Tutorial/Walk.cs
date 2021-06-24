using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        Tutorial.Instance.showMessage("Press <A> and <D> or <Arrow-Left> and <Arrow-Right> to walk");
    }

    private void OnTriggerExit(Collider other) {
        Tutorial.Instance.unShow();
    }
}
