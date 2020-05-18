using UnityEngine;

namespace spirit.Chan
{

    public class Manager : MonoBehaviour
    {
        public static Manager Inst = null;

        public static GameManager Game = null;
        public static DataManger Data = null;

        private void Awake()
        {
            if (Inst != null) Destroy(Inst.gameObject);
            Inst = this;

            Game = GetComponent<GameManager>();
            Data = GetComponent<DataManger>();
        }


    }

}