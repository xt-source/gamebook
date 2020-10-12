using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

namespace Gamebook
{
    public class BookEditor : EditorWindow
    {
        public Book book { get; private set; }


        [MenuItem("Window/Book Editor")]
        private static BookEditor GetEditor()
        {
            BookEditor editor = GetWindow<BookEditor>("Book Editor", true, typeof(SceneView));
            return editor;
        }


        [OnOpenAsset]
        private static bool OnOpenAsset(int instanceID, int line, int column)
        {
            string assetPath = AssetDatabase.GetAssetPath(instanceID);
            Book book = AssetDatabase.LoadAssetAtPath<Book>(assetPath);
            if (book == null)
            {
                return false;
            }

            BookEditor editor = GetEditor();
            editor.Load(book);
            return true;
        }


        private void OnSelectionChange()
        {
            Book book = Selection.activeObject as Book;
            if (book == null)
            {
                return;
            }

            Load(book);
        }


        private void OnGUI()
        {
            if (book == null)
            {
                return;
            }

            DrawStates();
        }


        private void Load(Book book)
        {
            if (book == null)
            {
                return;
            }

            this.book = book;
            Repaint();
        }


        private void DrawStates()
        {
            for (int i = book.states.Count - 1; i >= 0; i--)
            {
                State state = book.states[i];
                state.Draw();
            }
        }
    }
}
