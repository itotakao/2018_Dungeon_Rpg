using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : Base.Skill
{
    public override void Use()
    {
        base.Use();
        PlayerManager.Heal(20);
    }
}