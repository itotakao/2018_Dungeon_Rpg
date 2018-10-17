using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Base
{
    public class Skill : MonoBehaviour
    {
        public PlayerManager PlayerManager{ get { return PlayerManager.Current; }}

        public TextManager TextManager { get { return TextManager.Current; } }

        [SerializeField]
        string skillName = "";

        public virtual string GetSkillName()
        {
            return skillName;
        }

        public virtual void Use()
        {
            TextManager.PushLog("スキルを使用しました");
        }
    }
}