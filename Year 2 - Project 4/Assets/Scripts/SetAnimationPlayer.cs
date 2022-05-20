using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAnimationPlayer : MonoBehaviour
{
    [SerializeField] private AnimatorOverrideController[] overrideControllers;
    [SerializeField] private AnimatorOverrider overrider;

    public void Set(int index)
    {
        overrider.SetAnimations(overrideControllers[index]);
    }
}
