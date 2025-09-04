using UnityEngine;

[CreateAssetMenu(fileName = "NewDialog", menuName = "Dialog")]
public class DialogLines : ScriptableObject
{
    [TextArea(2, 5)]
    public string[] lines;
}