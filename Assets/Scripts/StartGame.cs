using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // 引入UI命名空间  

namespace GreatDay
{
    public class StartGame : MonoBehaviour
    {
        public Button btnGameStart;
        public AudioSource audioSource;

        // Start is called before the first frame update  
        void Start()
        {
            audioSource.Play(); // 在游戏开始时播放背景音乐  

            if (btnGameStart != null) // 确保btnGameStart和btnVoice都已经被分配了  
            {
                Debug.Log("开始游戏了哦！");
                // 添加点击事件监听器，当按钮被点击时播放音效并加载场景  
                btnGameStart.onClick.AddListener(delegate
                {
                    StopGameMusicAndLoadScene(); // 停止背景音乐并加载场景  
                });
            }
            else
            {
                Debug.LogError("BtnGameStart或btnVoice未被分配！");
            }
        }

        // 加载场景，停止播放音乐  
        void StopGameMusicAndLoadScene()
        {
            // 停止音频源播放  
            if (audioSource != null && audioSource.isPlaying)
            {
                audioSource.Stop();
            }
            // 加载Game场景  
            SceneManager.LoadScene("Building");
        }
    }
}
