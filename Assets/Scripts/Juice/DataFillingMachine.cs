using Scripts.Juice;
using UnityEngine;

[CreateAssetMenu(fileName = "FillingMachine", menuName = "FillingMachine/FillingMachineLevel")]
public class DataFillingMachine : ScriptableObject
{
    public FillingMachine PrefabSugar;
    public float Price;
    public float MaxCountJuicePack;
    public float MaxCountPool;
    public int LevelMachine =0;
    public DataJuice DataJuice;
}
