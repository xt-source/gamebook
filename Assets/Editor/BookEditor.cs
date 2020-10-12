using UnityEditor;

namespace Gamebook
{
    public class BookEditor : EditorWindow
    {
        [MenuItem("Window/Book Editor")]
        private static BookEditor GetEditor()
        {
            BookEditor editor = GetWindow<BookEditor>("Book Editor", true, typeof(SceneView));
            return editor;
        }
    }
}
