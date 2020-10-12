using System.Collections.Generic;
using UnityEngine;

namespace Gamebook
{
    [CreateAssetMenu]
    public class Book : ScriptableObject
    {
        [SerializeField]
        private List<State> m_States = new List<State>();


        [SerializeField]
        private State m_EntryState;


        public List<State> states { get => m_States; set => m_States = value; }


        public State entryState { get => m_EntryState; set => m_EntryState = value; }
    }
}
