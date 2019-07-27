using UnityEngine;
using UnityEngine.SceneManagement;

namespace BootScene
{
    public class BootSceneManager : MonoBehaviour
    {
        [SerializeField]
        private GameObject _dontDestroyObject = null;

        private void Start()
        {
            DontDestroyOnLoad(_dontDestroyObject);

            SceneManager.LoadSceneAsync("TitleScene");
        }
    }
}
