using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskTracker : MonoBehaviour
{
    [SerializeField]
    float targetRate = 0.0f;

    [SerializeField]
    float secondsUntilNextCheck = 60.0f;

    public float TargetRate
    {
        get
        {
            return targetRate;
        }
        set
        {
            targetRate = value;
            OnNewTargetSet.Invoke(targetRate);
        }
    }

    public float SecondsUntilNextCheck
    {
        get
        {
            return secondsUntilNextCheck;
        }
        set
        {
            secondsUntilNextCheck = value;
            OnNewCheckTimeSet.Invoke(secondsUntilNextCheck);
        }
    }

    public FloatEvent OnNewCheckTimeSet = new FloatEvent();

    public FloatEvent OnNewTargetSet = new FloatEvent();

    public EmptyEvent OnCheckPlayerRate = new EmptyEvent();

    public BoolEvent OnCheckPassed = new BoolEvent();

    private void Start()
    {
        OnCheckPassed.AddListener((passed) =>
        {
            if (passed)
            {
                TargetRate += 0.25f;
                SecondsUntilNextCheck = Mathf.Max(10, secondsUntilNextCheck - 1);
            }
            else
            {
                TargetRate = TargetRate;
                SecondsUntilNextCheck = Mathf.Max(10, secondsUntilNextCheck - 5);
            }
        });
    }
}
