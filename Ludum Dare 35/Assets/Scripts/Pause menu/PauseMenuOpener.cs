using UnityEngine;
using System.Collections;

namespace Pausemenu {
    public class PauseMenuOpener : MonoBehaviour {

        public Transform pauseMenuPrefab;

        Transform menu;

        void Start() {
        }

        void Update()
        {
            bool openPauseMenu = Input.GetButtonDown("Cancel");
            if (openPauseMenu && menu == null)
            {
                var position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, -1);
                menu = (Transform)Instantiate(pauseMenuPrefab, position, Quaternion.identity);
            }
        }
    }
}
