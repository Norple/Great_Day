using PixelCrushers.DialogueSystem;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GreatDay
{
    public class UPanel : MonoBehaviour
    {
        public GameObject upanel;
        public GameObject upanel1;
        public GameObject upanel2;
        public GameObject upanel3;
        public GameObject panel2_detail;

        //����Ƿ���ʾ
        private bool isShow;
        //��ɫ��Ϣҳ�Ƿ��
        private bool isDetailShow;

        //��ȡ�����ݿ�
        //private DialogueDatabase DB;

        private int currentPanel = 3; // �����ʼʱ��ʾ����panel1

        //����button���
        public List<Button> buttons; // �洢���а�ť���б�
        public Color selectedColor; // ѡ��ʱ����ɫ
        public Color unselectedColor; // δѡ��ʱ����ɫ
        private int currentSelectedIndex = 0; // ��ǰѡ�еİ�ť����

        public Sprite img_wolf;
        public Sprite img_lizard;
        public Sprite img_penguin;
        public Sprite img_mouse;

        //��ɫ����ҳ������
        public Text nameDText;
        public Image picDImg;

        //�����Ϣҳ������
        public Text dark_t;
        public Text wolf_t;
        public Text lizard_t;
        public Text penguin_t;
        public Text mouse_t;

        // Start is called before the first frame update
        void Start()
        {
            isShow = false;
            isDetailShow = false;
            SetButtonColor(buttons[currentSelectedIndex], selectedColor);
            //DB = FindAnyObjectByType<DialogueDatabase>();
        }
        // Update is called once per frame
        void Update()
        {
            //currentPanel�У�1�����ã�2��NPC��Ϣ��3���û���Ϣ
            //����escʱ�������ɫ����ҳ�Ǵ򿪵ģ��رգ�������ǣ��͹ر��ܲ˵���
            if (Input.GetKeyDown(KeyCode.Escape) && isDetailShow == false)
            {
                upanel.SetActive(isShow = !isShow);
                if (isShow)
                {
                    Time.timeScale = 0;
                }
                else
                {
                    Time.timeScale = 1;
                }
                Debug.Log(isShow);
            }
            else if (Input.GetKeyDown(KeyCode.Escape) && isDetailShow == true)
            {
                isDetailShow = false;
                panel2_detail.SetActive(false);
                Debug.Log("��ɫ����ҳ����ʾΪ���ɼ�");
            }
            //������¼������л����
            else if (Input.GetKeyDown(KeyCode.DownArrow) && isDetailShow == false)
            {
                // �л�����һ�����
                currentPanel = (currentPanel % 3) + 1; // ѭ���л�1, 2, 3  
                SetPanelActive(currentPanel, true);
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow) && isDetailShow == false)
            {
                // �л�����һ�����  
                Debug.Log("�����ѱ����");
                currentPanel = (currentPanel + 1) % 3 + 1;// ѭ���л�3, 2, 1
                SetPanelActive(currentPanel, true);
            }
            //������Ҽ�����ѡ���ɫ
            else if (Input.GetKeyDown(KeyCode.LeftArrow) && currentSelectedIndex > 0 && currentPanel == 2 && isDetailShow == false)
            {
                // ѡ��ǰһ����ť
                currentSelectedIndex--;
                //UpdateButtonColors();
                SelectButtonAtIndex(currentSelectedIndex);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) && currentSelectedIndex < buttons.Count - 1 && currentPanel == 2 && isDetailShow == false)
            {
                // ѡ����һ����ť  
                currentSelectedIndex++;
                //UpdateButtonColors();
                SelectButtonAtIndex(currentSelectedIndex);
            }
            //��һ�λص�npc��Ϣҳ��ʱ��ѡ��λ�û����»ص���һ��
            if (currentPanel != 2)
            {
                currentSelectedIndex = 0;
                SelectButtonAtIndex(currentSelectedIndex);
            }
            //�ڵڶ������ѡ��ý�ɫ����enter���Խ����ɫ����ҳ��
            if (currentPanel == 2 && Input.GetKeyDown(KeyCode.Return) && isDetailShow == false)
            {
                Debug.Log("�س��Ѱ���");
                isDetailShow = true;
                panel2_detail.SetActive(true);
                resetDPanel(currentSelectedIndex);
            }
            if (currentPanel == 3 && isShow == true)
            {
                //ÿ�ζ�Ҫ����һ�����ݿ�
                //DB = FindAnyObjectByType<DialogueDatabase>();
                setPanel1();
            }
        }
        private void TogglePanelGroup()
        {
            upanel1.SetActive(!upanel1.activeSelf);
            upanel2.SetActive(!upanel2.activeSelf);
            upanel3.SetActive(!upanel3.activeSelf);
        }
        /// <summary>
        /// ����ָ�����ļ���״̬����ͬʱ�����������  
        /// </summary>
        /// <param name="panelNumber"></param>
        /// <param name="isActive"></param> 
        private void SetPanelActive(int panelNumber, bool isActive)
        {
            switch (panelNumber)
            {
                case 1:
                    upanel1.SetActive(isActive);
                    upanel2.SetActive(!isActive);
                    upanel3.SetActive(!isActive);
                    break;
                case 2:
                    upanel1.SetActive(!isActive);
                    upanel2.SetActive(isActive);
                    upanel3.SetActive(!isActive);
                    break;
                case 3:
                    upanel1.SetActive(!isActive);
                    upanel2.SetActive(!isActive);
                    upanel3.SetActive(isActive);
                    break;
                default:
                    // ��Ӧ�÷����������ȷ�����򲻻����  
                    Debug.LogError("Invalid panel number: " + panelNumber);
                    break;
            }
        }
        /// <summary>
        /// ���ð�ť��ɫ
        /// </summary>
        /// <param name="button"></param>
        /// <param name="color"></param>
        void SetButtonColor(Button button, Color color)
        {
            // ��ȡ��ť�µ�Image�������������ɫ  
            Image img = button.transform.Find("Image").GetComponentInChildren<Image>();
            if (img != null)
            {
                img.color = color;
            }
        }
        void UpdateButtonColors()
        {
            // ȡ����ǰѡ�а�ť��ѡ��״̬
            SetButtonColor(buttons[currentSelectedIndex - 1], unselectedColor);
            // �����µ�ѡ�а�ťΪѡ��״̬
            SetButtonColor(buttons[currentSelectedIndex], selectedColor);
        }
        private void SelectButtonAtIndex(int index)
        {
            // �Ƚ����а�ť����Ϊδѡ����ɫ  
            foreach (var button in buttons)
            {
                SetButtonColor(button, unselectedColor);
                Debug.Log("���а�ť�ѱ�����Ϊδѡ����ɫ " + selectedColor);
            }

            // Ȼ��ָ�������İ�ť����Ϊѡ����ɫ  
            if (index >= 0 && index < buttons.Count)
            {
                SetButtonColor(buttons[index], selectedColor);
                Debug.Log("ָ�������İ�ť�ѱ�����Ϊѡ����ɫ " + selectedColor);
            }
        }
        /// <summary>
        /// �ҵ���ǰѡ�еĽ�ɫ���Ҵ�dialogDB�л�ȡ���������Լ���picture�����ȡ����ͼƬ
        /// </summary>
        private void resetDPanel(int selectIndex)
        {
            //��ʾ����
            string name = buttons[selectIndex].name;
            nameDText.text = name;
            //��ʾͷ��
            switch (name)
            {
                case "�ɶ�":
                    picDImg.sprite = img_wolf;
                    break;
                case "����":
                    picDImg.sprite = img_penguin;
                    break;
                case "Lizard":
                    picDImg.sprite = img_lizard;
                    break;
                case "С��":
                    picDImg.sprite = img_mouse;
                    break;
                default:
                    break;
            }
            //��ʾӡ��
        }
        private void setPanel1()
        {
            //��ȡ��ǰ�ڰ�ֵ�ͺøж�
            //��ȡtext
            string dark_data;
            string wolf_data;
            string lizard_data;
            string penguin_data;
            string mouse_data;
            dark_data = DialogueLua.GetVariable("darkness_value").asString;
            wolf_data = DialogueLua.GetVariable("wolf_likeness").asString;
            lizard_data = DialogueLua.GetVariable("lizard_likeness").asString;
            penguin_data = DialogueLua.GetVariable("penguin_likeness").asString;
            mouse_data = DialogueLua.GetVariable("mouse_likeness").asString;
            dark_t.text = dark_data;
            wolf_t.text = wolf_data;
            lizard_t.text = lizard_data;
            penguin_t.text = penguin_data;
            mouse_t.text = mouse_data;
            Debug.Log("�û������Ѹ���");
        }
    }
}
