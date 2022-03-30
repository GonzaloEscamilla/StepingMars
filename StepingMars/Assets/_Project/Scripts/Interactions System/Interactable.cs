using UnityEngine;

namespace StepingMars._Project.Scripts.Interactions_System
{
    public abstract class Interactable : MonoBehaviour
    {
        public abstract void Interact(Transform interactor);
    }
}

