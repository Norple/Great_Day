using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; // ����UI�����ռ�  

namespace GreatDay
{
    public class StartGame : MonoBehaviour
    {
        public Button btnGameStart;
        public AudioSource audioSource;

        // Start is called before the first frame update  
        void Start()
        {
            audioSource.Play(); // ����Ϸ��ʼʱ���ű�������  

            if (btnGameStart != null) // ȷ��btnGameStart��btnVoice���Ѿ���������  
            {
                Debug.Log("��ʼ��Ϸ��Ŷ��");
                // ��ӵ���¼�������������ť�����ʱ������Ч�����س���  
                btnGameStart.onClick.AddListener(delegate
                {
                    StopGameMusicAndLoadScene(); // ֹͣ�������ֲ����س���  
                });
            }
            else
            {
                Debug.LogError("BtnGameStart��btnVoiceδ�����䣡");
            }
        }

        // ���س�����ֹͣ��������  
        void StopGameMusicAndLoadScene()
        {
            // ֹͣ��ƵԴ����  
            if (audioSource != null && audioSource.isPlaying)
            {
                audioSource.Stop();
            }
            // ����Game����  
            SceneManager.LoadScene("Building");
        }
    }
}
