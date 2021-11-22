using UnityEngine;

namespace Code.Controllers
{
        public class CameraController
        {
                private float X;
                private float Y;
        
                private float _offsetX;
                private float _offsetY;

                private int _camSpeed = 300;

                private Transform _playerTransfomr;
                private Transform _cameraTransfomr;

                public CameraController(Transform player, Transform camera)
                {
                        _playerTransfomr = player;
                        _cameraTransfomr = camera;
                }

                public void Update()
                {
                        X = _playerTransfomr.transform.position.x;
                        Y = _playerTransfomr.transform.position.y;
                        
                        _cameraTransfomr.transform.position = Vector3.Lerp(_cameraTransfomr.position, new Vector3(X + _offsetX, Y + _offsetY, _cameraTransfomr.position.z), Time.deltaTime * _camSpeed);
                }
        }
}