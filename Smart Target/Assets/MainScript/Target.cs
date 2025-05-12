using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour

{
    public DoubleTapMode doubleTapMode;

    void OnMouseDown()
    {
        doubleTapMode.HitTarget();
    }
}