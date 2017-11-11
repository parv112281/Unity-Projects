using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Victory : MonoBehaviour {

	public bool taken = false;
	public GameObject explosion;
    public string word = "";

    private List<string> _takenLetters = new List<string>();
    private List<string> _wordLetters = new List<string>();
    private int currentIndex = 0;

	// if the player touches the victory object, it has not already been taken, and the player can move (not dead or victory)
	// then the player has reached the victory point of the level
	void OnTriggerEnter2D (Collider2D other)
	{
        if (word.Length != _wordLetters.Count)
        {
            char[] charArr = word.ToUpper().ToCharArray();
            foreach (var character in charArr)
            {
                _wordLetters.Add(character.ToString());
            }
            Debug.Log("Word in _wordLetters list is " + string.Concat(_wordLetters.ToArray()));
        }

        if ((other.tag == "Player") && (!taken) && (other.gameObject.GetComponent<CharacterController2D>().playerCanMove))
        {
            if (this.name.EndsWith(_wordLetters[currentIndex]))
            {
                // mark as taken so doesn't get taken multiple times
                taken = true;

                // if explosion prefab is provide, then instantiate it
                if (explosion)
                {
                    Instantiate(explosion, transform.position, transform.rotation);
                }

                if (++currentIndex >= _wordLetters.Count)
                {
                    // do the player victory thing
                    other.gameObject.GetComponent<CharacterController2D>().Victory();
                }
                // destroy the victory gameobject
                DestroyObject(this.gameObject);

            }
        }

        //if ((other.tag == "Player" ) && (!taken) && (other.gameObject.GetComponent<CharacterController2D>().playerCanMove))
        //{
        //    // mark as taken so doesn't get taken multiple times
        //    taken=true;

        //    // if explosion prefab is provide, then instantiate it
        //    if (explosion)
        //    {
        //        Instantiate(explosion,transform.position,transform.rotation);
        //    }

        //    // do the player victory thing
        //    other.gameObject.GetComponent<CharacterController2D>().Victory();

        //    // destroy the victory gameobject
        //    DestroyObject(this.gameObject);
        //}
	}

}
