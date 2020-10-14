using UnityEngine;

namespace Gamebook
{
    public static class StateDrawers
    {
        public static void Draw(this State state)
        {
            Rect position = new Rect(state.position, state.size);
            GUIContent content = new GUIContent(state.name);
            GUIStyle style = GetStyle();

            GUI.Box(position, content, style);
        }


        public static Rect GetBoundingBox(this State state)
        {
            Rect box = new Rect(state.position, state.size);

            return box;
        }


        private static GUIStyle GetStyle()
        {
            GUIStyle style = new GUIStyle(GUI.skin.box);

            Color color = new Color(0.25f, 0.25f, 0.25f);
            Texture2D texture = new Texture2D(1, 1);
            texture.SetPixel(0, 0, color);
            texture.Apply();

            style.normal.background = texture;

            return style;
        }
    }
}
