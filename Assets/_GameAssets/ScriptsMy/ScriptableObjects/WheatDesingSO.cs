using System.IO.Enumeration;
using UnityEngine;

[CreateAssetMenu(fileName = "WheatDesingSO", menuName = "ScriptableObjects/WheatDesingSO")]


public class WheatDesingSO : ScriptableObject
{
    [SerializeField] private float _increasedDecreaseMltiplier;
    [SerializeField] private float _resetBoostDuration;


    public float IncreasedDecreaseMultiplier => _increasedDecreaseMltiplier;
    public float ResetBoostDuration => _resetBoostDuration;

}
