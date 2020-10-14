using UnityEditor;
using UnityEngine;

namespace Gamebook
{
    public static class TransitionDrawers
    {
        public static void Draw(this Transition transition)
        {
            Vector2 source = transition.source.position + transition.source.size / 2;
            Vector2 target = transition.target.position + transition.target.size / 2;
            Vector2 delta = target - source;
            Vector2 center = source + delta / 2;
            float angle = Vector2.SignedAngle(Vector2.right, delta);

            DrawLine(source, target);
            DrawHandle(center, angle);
        }


        public static Rect GetBoundingBox(this Transition transition)
        {
            Vector2 size = new Vector2(30f, 30f);

            Vector2 source = transition.source.position + transition.source.size / 2;
            Vector2 target = transition.target.position + transition.target.size / 2;
            Vector2 delta = target - source;
            Vector2 center = source + delta / 2;

            Rect box = new Rect(center - size / 2, size);

            return box;
        }


        private static void DrawLine(Vector2 source, Vector2 target)
        {
            Texture2D lineTex = GetLineTexture();
            float width = 5f;

            Handles.DrawAAPolyLine(lineTex, width, source, target);
        }


        private static void DrawHandle(Vector2 center, float angle)
        {
            Vector2 p1 = center + (Vector2)(Quaternion.Euler(0f, 0f, angle) * new Vector2(-7.5f, 5f));
            Vector2 p2 = center + (Vector2)(Quaternion.Euler(0f, 0f, angle) * new Vector2(7.5f, 0f));
            Vector2 p3 = center + (Vector2)(Quaternion.Euler(0f, 0f, angle) * new Vector2(-7.5f, -5f));
            Handles.DrawAAConvexPolygon(p1, p2, p3);
        }


        private static Texture2D GetLineTexture()
        {
            Texture2D texture = new Texture2D(1, 3);
            texture.SetPixel(0, 0, Color.clear);
            texture.SetPixel(0, 1, Color.white);
            texture.SetPixel(0, 2, Color.white);
            texture.Apply();

            return texture;
        }
    }
}
