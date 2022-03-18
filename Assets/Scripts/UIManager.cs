using UnityEngine;
using UnityEngine.SceneManagement;

namespace Titres
{
    public class UIManager : MonoBehaviour
    {
        private Controls _inputs;
        private Animator _animator;

        #region MonoBehaviorCalls

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _inputs = new Controls();
            _inputs.GameOverActions.Retry.performed += (a) => Retry();
            _inputs.GameOverActions.Quit.performed += (a) => Close();
        }

        void Start()
        {
            Board.Instance.OnGameOver += () =>
            {
                _animator.SetTrigger("Switch");
                _inputs.GameOverActions.Enable();
            };
        }

        #endregion

        public void Retry()
        {
            _inputs.GameOverActions.Disable();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void Close()
        {
            _inputs.GameOverActions.Disable();
            SceneManager.LoadScene(0);
        }

        
    }
}