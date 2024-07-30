using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace GreatDay
{
    public class exitBtn : MonoBehaviour
    {
        public Button button;
        // Start is called before the first frame update
        void Start()
        {
            button.onClick.AddListener(delegate
            {
                SceneManager.LoadScene("GameStart");
            });

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
