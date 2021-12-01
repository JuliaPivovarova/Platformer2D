using UnityEngine;
using UnityEngine.Tilemaps;

namespace Code.Controllers
{
    public class MarshingSquaresController
    {
        private Tile _tileGround;
        private Tilemap _tilemap;
        
        public class Node
        {
            public Vector3 _position;

            public Node(Vector3 position)
            {
                _position = position;
            }
        }
        
        public class ControlNode : Node
        {
            public bool _active;

            public ControlNode(Vector3 position, bool active) : base(position)
            {
                _active = active;
            }
        }
        
        public class Square
        {
            public ControlNode TopLeft, TopRight, BottomLeft, BottomRight;

            public Square(ControlNode topLeft, ControlNode topRight, ControlNode bottomLeft, ControlNode bottomRight)
            {
                TopLeft = topLeft;
                TopRight = topRight;
                BottomLeft = bottomLeft;
                BottomRight = bottomRight;
            }
        }
        
        public class SquareGrid
        {
            public Square[,] Squares;

            public SquareGrid(int[,] map, float squareSize)
            {
                int nodeCountX = map.GetLength(0);
                int nodeCountY = map.GetLength(1);

                float mapWidth = nodeCountX * squareSize;
                float mapHeight = nodeCountY * squareSize;

                ControlNode[,] controlNodes = new ControlNode[nodeCountX, nodeCountY];

                for (int x = 0; x < nodeCountX; x++)
                {
                    for (int y = 0; y < nodeCountY; y++)
                    {
                        Vector3 position = new Vector3(-mapWidth / 2 + x * squareSize + squareSize / 2,
                            -mapHeight / 2 + y * squareSize + squareSize / 2, 0);
                        controlNodes[x, y] = new ControlNode(position, map[x, y] == 1);
                    }
                }
            }
        }
    }
}
