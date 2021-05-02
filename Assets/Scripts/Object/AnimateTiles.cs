using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// Permite animar um tile, para usar basta ir no menu Create -> Tile -> Animated Tile
/// Depois, defina no inspector os tiles e a velocidade
/// Por fim, coloca essa animação na TilePalet e usa normalmente
/// </summary>

[CreateAssetMenu(menuName = "Tile.../Animated Tile", fileName = "New Animated Tile")]
public class AnimateTiles : TileBase
{
    [SerializeField]
    private Sprite[] sprites;

    [SerializeField]
    private float velocidade;

    public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
    {
        if(sprites != null && sprites.Length > 0)
        {
            tileData.sprite = sprites[0];
        }
    }

    public override bool GetTileAnimationData(Vector3Int position, ITilemap tilemap, ref TileAnimationData tileAnimationData)
    {
        if(sprites.Length > 0)
        {
            tileAnimationData.animatedSprites = sprites;
            tileAnimationData.animationSpeed = velocidade;
            tileAnimationData.animationStartTime = 0f;
            return true;
        }
        return false;
    }
}
