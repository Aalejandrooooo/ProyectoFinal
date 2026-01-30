using UnityEngine;

[CreateAssetMenu(fileName = "MissionData", menuName = "BlackSignal/Mission")]
public class MissionData : ScriptableObject
{
    public string missionID;
    public string missionName;
    [TextArea(3, 10)] public string description;

    public string sceneName;

    [Header("Mental Impact")]
    public int obedienceImpact;
    public int doubtImpact;
    public int stabilityImpact;
}
