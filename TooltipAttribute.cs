using UnityEngine;

public class BPTooltipAttribute : PropertyAttribute
{
    public readonly string text;

    public BPTooltipAttribute(string text)
    {
        this.text = text;
    }
}