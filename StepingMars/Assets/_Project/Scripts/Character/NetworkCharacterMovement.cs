using System.Diagnostics;
using Mirror;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace StepingMars._Project.Scripts.Character
{
    public class NetworkCharacterMovement: NetworkBehaviour
    {
        [SerializeField] private float _movementSpeed;
        private Rigidbody2D _rigidbody2D;
        
        public void Init(Rigidbody2D rigidbody2D)
        {
            _rigidbody2D = rigidbody2D;
        }

        public void Move(Vector2 movementVector)
        {
            _rigidbody2D.velocity = movementVector.normalized * _movementSpeed;
        }
    }
}