using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class JobData : MonoBehaviour
{

    public enum JobEnum
    {
        Warrior,
        Caster
    }

    public void LoadJob(JobEnum job)
    {
        try
        {
            switch (job)
            {
                case JobEnum.Warrior:

                    break;

                case JobEnum.Caster:

                    break;

                default:
                    throw new ArgumentException();
            }
        }
        catch (ArgumentException)
        {
#if UNITY_EDITOR
            Debug.LogError("エラー:想定外の数値が入っています");
#endif
        }
    }
}
