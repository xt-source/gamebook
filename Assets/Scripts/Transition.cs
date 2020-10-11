using UnityEngine;

namespace Gamebook
{
    [CreateAssetMenu]
    public class Transition : ScriptableObject
    {
        [SerializeField]
        private State m_Source;


        [SerializeField]
        private State m_Target;


        public State source { get => m_Source; set => m_Source = value; }


        public State target { get => m_Target; set => m_Target = value; }
    }
}
