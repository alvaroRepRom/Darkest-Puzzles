using System;
using UnityEngine;

[CreateAssetMenu(fileName = "OnAlertSO", menuName = "Events/OnAlertSO")]
public class OnAlertSO : ScriptableObject
{
    public Action<bool> onAlert;
    public void OnAlert(bool isAlert)
    {
        onAlert?.Invoke(isAlert);
    }
}
