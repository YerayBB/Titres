using UnityEngine;
using UnityEngine.SceneManagement;

namespace Titres
{
    public class MainMenuManager : MonoBehaviour
    {
        public void Play()
        {
            SceneManager.LoadScene(1);
        }

        public void Quit()
        {
            Application.Quit();
        }
    }
}
