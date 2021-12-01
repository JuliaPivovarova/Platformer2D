using UnityEngine;
using UnityEngine.Tilemaps;

namespace Code.View
{
    public class GeneratorLevelView : MonoBehaviour
    {
        [SerializeField] private Tilemap tilemap;
        [SerializeField] private Tile groundTile;
        [SerializeField] private Tile gruondTileOnTop;
        [SerializeField] private int mapWidth;
        [SerializeField] private int mapHeight;
        [SerializeField] private bool borders;
        
        [SerializeField] [Range(0, 100)] private int fillPercent;
        [SerializeField] [Range(0, 100)] private int smoothFactor;
        
        public Tilemap Tilemap
        {
            get => tilemap;
            set => tilemap = value;
        }
        public Tile GroundTile
        {
            get => groundTile;
            set => groundTile = value;
        }

        public Tile GruondTileOnTop
        {
            get => gruondTileOnTop;
            set => gruondTileOnTop = value;
        }
        public int MapWidth
        {
            get => mapWidth;
            set => mapWidth = value;
        }
        public int MapHeight
        {
            get => mapHeight;
            set => mapHeight = value;
        }
        public bool Borders
        {
            get => borders;
            set => borders = value;
        }
        public int FillPercent
        {
            get => fillPercent;
            set => fillPercent = value;
        }
        public int SmoothFactor
        {
            get => smoothFactor;
            set => smoothFactor = value;
        }
    }
}