using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour {

    //Self-explanatory
    private void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}
