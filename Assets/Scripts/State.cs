using System.Collections.Generic;
using UnityEngine;

namespace Gamebook
{
    [CreateAssetMenu]
    public class State : ScriptableObject
    {
        [SerializeField]
        private Vector2 m_Position = new Vector2(0f, 0f);


        [SerializeField]
        private Vector2 m_Size = new Vector2(150f, 75f);


        [SerializeField]
        private List<Transition> m_Transitions = new List<Transition>();


        public Vector2 position { get => m_Position; set => m_Position = value; }


        public Vector2 size { get => m_Size; set => m_Size = value; }

        
        public List<Transition> transitions { get => m_Transitions; set => m_Transitions = value; }
    }
}
