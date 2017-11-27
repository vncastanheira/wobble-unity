using UnityEngine;

namespace vnc.FX
{
    [ExecuteInEditMode]
    public class WaterCamera : MonoBehaviour
    {
        public Material Wobble;

        private void Update()
        {
            float yAxis = transform.position.y;
            yAxis += Input.GetKey(KeyCode.UpArrow) ? 1 : 0;
            yAxis -= Input.GetKey(KeyCode.DownArrow) ? 1 : 0;
            yAxis = Mathf.Clamp(yAxis, 10, 40);
            transform.position = Vector3.up * yAxis;
        }

        private void OnRenderImage(RenderTexture source, RenderTexture destination)
        {
            if (Wobble == null)
            {
                Graphics.Blit(source, destination);
                return;
            }

            float yAxis = transform.position.y;
            if (yAxis <= 20)
            {
                Wobble.SetColor("_Color", Color.cyan);
                Graphics.Blit(source, destination, Wobble);
            }
            else
            {
                Wobble.SetColor("_Color", Color.white);
                Graphics.Blit(source, destination);
            }
        }
    }
}
