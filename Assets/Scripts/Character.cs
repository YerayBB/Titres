using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Titres
{
    [RequireComponent(typeof(Animator), typeof(Rigidbody2D))]
    public class Character : MonoBehaviour
    {
        public event System.Action<Character> OnDeath;

        private Rigidbody2D _rigidBody;
        private Animator _animator;
        private bool _grounded;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _rigidBody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            _animator.SetBool("grounded", _grounded);
            _animator.SetFloat("speedx", _rigidBody.velocity.x);
            _animator.SetFloat("speedy", _rigidBody.velocity.y);

        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            _grounded = true;
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            _grounded = false;
        }

        public void Move(float maxpush)
        {
            _rigidBody.AddForce(Vector2.right * Random.Range(Mathf.Min(0f, maxpush), Mathf.Max(0f, maxpush)));
        }

        public void Jump(float force)
        {
            _rigidBody.AddForce(Vector2.up * force);
        }

        private void OnDestroy()
        {
            OnDeath?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
