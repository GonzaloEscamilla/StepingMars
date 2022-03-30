using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

namespace StepingMars
{
    public abstract class Interactable : MonoBehaviour
    {
        public abstract void Interact(Transform interactor);
    }
}
