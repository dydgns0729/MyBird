using UnityEngine;
using UnityEngine.SceneManagement;

namespace MyBird
{
    public class TitleUI : MonoBehaviour
    {
        #region Variables
        [SerializeField] private string loadToScene = "PlayScene";
        #endregion

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                ResetGameDate();
            }
        }

        public void Play()
        {
            SceneManager.LoadScene(loadToScene);
        }

        void ResetGameDate()
        {
            PlayerPrefs.DeleteAll();
        }
    }
}