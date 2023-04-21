using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bar : MonoBehaviour
{
    [field:SerializeField]
    public int MaxValue { get; private set; }
    [field:SerializeField]
    public int Value { get; private set; }

    [SerializeField] private Image topBar;
    [SerializeField] private Image bottomBar;

    [SerializeField] private float animationSpeed = 10f;

    private Coroutine adjustBarFillCoroutine;
    
    private float _targetFill => (float)Value / MaxValue;

    public void Change(int amount)
    {
        Value = Mathf.Clamp(Value + amount, 0, MaxValue);
        if (adjustBarFillCoroutine != null)
        {
            StopCoroutine(adjustBarFillCoroutine);
        }

        adjustBarFillCoroutine = StartCoroutine(AdjustBarFill(amount));

        if (Value == 0)
        {
            Debug.Log($"{name} is 0");
        }

        if (Value == MaxValue)
        {
            Debug.Log($"{name} is {MaxValue}");
        }
    }

    private IEnumerator AdjustBarFill(int amount)
    {
        var suddenChangeBar = amount >= 0 ? bottomBar : topBar;
        var slowChangeBar = amount >= 0 ? topBar : bottomBar;

        suddenChangeBar.fillAmount = _targetFill;
        while (Mathf.Abs(suddenChangeBar.fillAmount - slowChangeBar.fillAmount) > 0.05f)
        {
            slowChangeBar.fillAmount = Mathf.Lerp(slowChangeBar.fillAmount, _targetFill, Time.deltaTime * animationSpeed);
            yield return null;
        }

        slowChangeBar.fillAmount = _targetFill;
    }

   /*
    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Change(20);
        }
        else if (Input.GetMouseButtonDown(1))
        {
            Change(-20);
        }
    }
    */
}
