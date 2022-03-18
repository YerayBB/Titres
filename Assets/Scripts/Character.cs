using UnityEngine;

namespace Titres
{
    [RequireComponent(typeof(Animator), typeof(Rigidbody2D))]
    public class Character : MonoBehaviour
    {
        public event System.Action<Character> OnDeath;

        [SerializeField]
        private float _jumpForce = 10;
        [SerializeField]
        private float _speedForce = 5;
        [SerializeField]
        [Range(0,100)]
        private int _activeChance = 50;

        private Rigidbody2D _rigidBody;
        private Animator _animator;
        private bool _grounded;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _rigidBody = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            Board.Instance.OnFullDrop += Interact;
        }

        private void Interact(int rows)
        {
            if(Random.Range(10,100) <= (_activeChance + rows))
            {
                Move();
            }
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
            _rigidBody.velocity += (Vector2.right * Random.Range(Mathf.Min(0f, maxpush), Mathf.Max(0f, maxpush)));
        }

        public void Move()
        {
            if(Random.Range(0,2) == 0)
            {
                _rigidBody.velocity += Vector2.left * _speedForce;
            }
            else
            {
                _rigidBody.velocity += Vector2.right * _speedForce;
            }
        }

        public void Jump()
        {
            _rigidBody.velocity += (Vector2.up * _jumpForce);
        }

        public void Jump(float force)
        {
            _rigidBody.velocity += (Vector2.up * force);
        }

        private void OnDestroy()
        {
            Board.Instance.OnFullDrop -= Interact;
            OnDeath?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
