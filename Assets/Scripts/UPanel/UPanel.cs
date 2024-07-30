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

        //面板是否显示
        private bool isShow;
        //角色信息页是否打开
        private bool isDetailShow;

        //获取到数据库
        //private DialogueDatabase DB;

        private int currentPanel = 3; // 假设初始时显示的是panel1

        //管理button组件
        public List<Button> buttons; // 存储所有按钮的列表
        public Color selectedColor; // 选中时的颜色
        public Color unselectedColor; // 未选中时的颜色
        private int currentSelectedIndex = 0; // 当前选中的按钮索引

        public Sprite img_wolf;
        public Sprite img_lizard;
        public Sprite img_penguin;
        public Sprite img_mouse;

        //角色详情页相关组件
        public Text nameDText;
        public Image picDImg;

        //玩家信息页相关组件
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
            //currentPanel中，1是设置，2是NPC信息，3是用户信息
            //按下esc时，如果角色详情页是打开的，关闭，如果不是，就关闭总菜单。
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
                Debug.Log("角色详情页已显示为不可见");
            }
            //点击上下键可以切换面板
            else if (Input.GetKeyDown(KeyCode.DownArrow) && isDetailShow == false)
            {
                // 切换到下一个面板
                currentPanel = (currentPanel % 3) + 1; // 循环切换1, 2, 3  
                SetPanelActive(currentPanel, true);
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow) && isDetailShow == false)
            {
                // 切换到上一个面板  
                Debug.Log("向上已被点击");
                currentPanel = (currentPanel + 1) % 3 + 1;// 循环切换3, 2, 1
                SetPanelActive(currentPanel, true);
            }
            //点击左右键可以选择角色
            else if (Input.GetKeyDown(KeyCode.LeftArrow) && currentSelectedIndex > 0 && currentPanel == 2 && isDetailShow == false)
            {
                // 选中前一个按钮
                currentSelectedIndex--;
                //UpdateButtonColors();
                SelectButtonAtIndex(currentSelectedIndex);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) && currentSelectedIndex < buttons.Count - 1 && currentPanel == 2 && isDetailShow == false)
            {
                // 选中下一个按钮  
                currentSelectedIndex++;
                //UpdateButtonColors();
                SelectButtonAtIndex(currentSelectedIndex);
            }
            //再一次回到npc信息页面时，选中位置会重新回到第一个
            if (currentPanel != 2)
            {
                currentSelectedIndex = 0;
                SelectButtonAtIndex(currentSelectedIndex);
            }
            //在第二面板中选择好角色后点击enter可以进入角色详情页面
            if (currentPanel == 2 && Input.GetKeyDown(KeyCode.Return) && isDetailShow == false)
            {
                Debug.Log("回车已按下");
                isDetailShow = true;
                panel2_detail.SetActive(true);
                resetDPanel(currentSelectedIndex);
            }
            if (currentPanel == 3 && isShow == true)
            {
                //每次都要更新一次数据库
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
        /// 设置指定面板的激活状态，并同时禁用其他面板  
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
                    // 不应该发生的情况，确保程序不会崩溃  
                    Debug.LogError("Invalid panel number: " + panelNumber);
                    break;
            }
        }
        /// <summary>
        /// 设置按钮颜色
        /// </summary>
        /// <param name="button"></param>
        /// <param name="color"></param>
        void SetButtonColor(Button button, Color color)
        {
            // 获取按钮下的Image组件并设置其颜色  
            Image img = button.transform.Find("Image").GetComponentInChildren<Image>();
            if (img != null)
            {
                img.color = color;
            }
        }
        void UpdateButtonColors()
        {
            // 取消当前选中按钮的选中状态
            SetButtonColor(buttons[currentSelectedIndex - 1], unselectedColor);
            // 设置新的选中按钮为选中状态
            SetButtonColor(buttons[currentSelectedIndex], selectedColor);
        }
        private void SelectButtonAtIndex(int index)
        {
            // 先将所有按钮设置为未选中颜色  
            foreach (var button in buttons)
            {
                SetButtonColor(button, unselectedColor);
                Debug.Log("所有按钮已被设置为未选中颜色 " + selectedColor);
            }

            // 然后将指定索引的按钮设置为选中颜色  
            if (index >= 0 && index < buttons.Count)
            {
                SetButtonColor(buttons[index], selectedColor);
                Debug.Log("指定索引的按钮已被设置为选中颜色 " + selectedColor);
            }
        }
        /// <summary>
        /// 找到当前选中的角色并且从dialogDB中获取它的描述以及从picture里面获取它的图片
        /// </summary>
        private void resetDPanel(int selectIndex)
        {
            //显示姓名
            string name = buttons[selectIndex].name;
            nameDText.text = name;
            //显示头像
            switch (name)
            {
                case "成都":
                    picDImg.sprite = img_wolf;
                    break;
                case "丘丘":
                    picDImg.sprite = img_penguin;
                    break;
                case "Lizard":
                    picDImg.sprite = img_lizard;
                    break;
                case "小黍":
                    picDImg.sprite = img_mouse;
                    break;
                default:
                    break;
            }
            //显示印象
        }
        private void setPanel1()
        {
            //获取当前黑暗值和好感度
            //获取text
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
            Debug.Log("用户数据已更新");
        }
    }
}
