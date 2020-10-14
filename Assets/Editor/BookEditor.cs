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

            HandleEvents();

            DrawTransitions();
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


        private void HandleEvents()
        {
            Event e = Event.current;
            switch (e.type)
            {
                case EventType.MouseDown:
                    {
                        Object obj = GetObjectAt(e.mousePosition);
                        if (obj == null)
                        {
                            Selection.activeObject = book;
                        }
                        else
                        {
                            Selection.activeObject = obj;
                        }

                        break;
                    }
            }
        }


        private Object GetObjectAt(Vector2 position)
        {
            for (int i = 0; i < book.states.Count; i++)
            {
                State state = book.states[i];
                if (state.GetBoundingBox().Contains(position))
                {
                    return state;
                }
            }

            for (int i = 0; i < book.states.Count; i++)
            {
                State state = book.states[i];
                for (int j = 0; j < state.transitions.Count; j++)
                {
                    Transition transition = state.transitions[j];
                    if (transition.GetBoundingBox().Contains(position))
                    {
                        return transition;
                    }
                }
            }

            return null;
        }


        private void DrawStates()
        {
            for (int i = book.states.Count - 1; i >= 0; i--)
            {
                State state = book.states[i];
                state.Draw();
            }
        }


        private void DrawTransitions()
        {
            for (int i = book.states.Count - 1; i >= 0; i--)
            {
                State state = book.states[i];
                for (int j = state.transitions.Count - 1; j >= 0; j--)
                {
                    Transition transition = state.transitions[j];
                    transition.Draw();
                }
            }
        }
    }
}
