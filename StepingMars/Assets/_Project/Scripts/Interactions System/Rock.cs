using UnityEngine;

namespace StepingMars
{
    public class Rock : Interactable
    {
        public override void Interact(Transform interactor)
        {
            Debug.Log("Im being interacted");
            this.gameObject.SetActive(false);
        }
    }
}