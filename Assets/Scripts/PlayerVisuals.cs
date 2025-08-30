using Fusion;
using UnityEngine;

public class PlayerVisuals : NetworkBehaviour
{
    [Networked]
    public Color PlayerColor { get; set; }

    private SpriteRenderer sr;

    public override void Spawned()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
        sr.color = PlayerColor; // apply initial color
    }

    public override void Render()
    {
        // Keeps renderer updated if color changes later
        if (sr != null)
        {
            sr.color = PlayerColor;
        }
    }
}
