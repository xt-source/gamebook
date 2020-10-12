using System.Collections.Generic;
using UnityEngine;

namespace Gamebook
{
    [CreateAssetMenu]
    public class State : ScriptableObject
    {
        [SerializeField]
        private List<Transition> m_Transitions = new List<Transition>();


        public List<Transition> transitions { get => m_Transitions; set => m_Transitions = value; }
    }
}
