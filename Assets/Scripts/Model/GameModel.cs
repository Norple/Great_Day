using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModel : MonoBehaviour
{
    //时间分为1+3天，新手指引+三天游玩，一天分为3份，上午下午和晚上
    //在1/3天的时间内又可能发生三种事件：触发事件，必然事件，交谈
    //所以命名方式为event_03a1->新手指引阶段晚上触发事件1
    //本脚本用于记录各个事件的发生情况。
}
