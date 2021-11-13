using UnityEngine;
using UnityEngine.SceneManagement;

namespace WhiteWolf {

	public class WW_LevelChanger : MonoBehaviour {

		[Space]

		public int scene;

		[Header("Mouse")]
		public bool left;
		public bool right;

		[Header("Key")]
		public KeyCode keyCode;

		/*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

		Animator animator;
		int levelToLoad;

		/*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

		void Start() => animator = this.gameObject.GetComponent<Animator>();

        void Update(){

            if ( left || right ){ Mouse(); }
            else if ( keyCode != KeyCode.None ){ Key(); }

		}

		/*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

		void Mouse(){

			if ( left && Input.GetMouseButtonDown( 0 ) ){ FadeToLevel( scene ); }
			if ( right && Input.GetMouseButtonDown( 1 ) ){ FadeToLevel( scene ); }

        }

		void Key(){ if ( Input.GetKeyDown( keyCode ) ){ FadeToLevel( scene ); } }

		/*––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––––*/

		public void FadeToLevel ( int levelIndex ){

			levelToLoad = levelIndex;
			animator.SetTrigger("FadeOut");

		}

		public void OnFadeComplete () => SceneManager.LoadScene(levelToLoad);
	
	}

}