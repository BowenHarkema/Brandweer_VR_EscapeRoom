/* 
The script raises the lift up when the up button is pressed. It stops when you release the button, and starts again when you press the button.
It also lowers the lift, if the down button is pressed. and stops when you release the down button, and starts to go down when the down button is pressed again.
Also the crane can turn when the left or right turn button is pressed, it stops turn when the button is released. 
It will start turning again when the turn button is pressed again.
*/

using UnityEngine;
using System.Collections;
 
public class liftAnim : MonoBehaviour // liftAnim and C# file name must be the same
{
	//Private variables
	private Animator anim;
	private int goUp;
	private int goDown;
	private float animFrame;

	//Public variables
	public bool moveUp = false;
	public bool moveDown = false;


	// Sets up Starting conditions
	void Start() 
	{
		anim = GetComponent<Animator>();
		goDown = 2;
		goUp = 0;
        Pause();
    }

	// Runs once every frame
	void Update() 
	{	
		animFrame = anim.GetCurrentAnimatorStateInfo(0).normalizedTime;
	
		if (moveUp)
		{
			switch(goUp)
			{
				case 0:
				Up();
				break;
				
				case 1:
				
				break;
				
				default:
				break;
			}
		}else
        {
			Pause();
        }

		if (moveDown) 
		{
			switch(goDown)
			{
				case 0:
				Down();
				break;
				
				case 1:
				
				break;
				
				default:
				break;
			}
		}
	}

	// Start raising the lift
	void Up() 
	{
		anim.SetFloat ("Direction", 1);
		anim.speed = 1.0f;
		anim.Play("move", -1, float.NegativeInfinity);
		goUp = 1;
		goDown = 2;
	}

	// Start lowering the lift
	void Down() 
	{
		anim.SetFloat ("Direction", -1);
		anim.speed = 1.0f;
		anim.Play("move", -1, float.NegativeInfinity);
		goDown = 1;
		goUp = 2;
	}

	// Stop the lift where it is
	void Pause() 
	{
		goUp = 0;
		goDown = 0;
		anim.speed = 0.0f;
	}

	//Booleans for the true or flase state of the button press
	public void boolsetUp(bool b)
    {
		moveUp = b;
    }
	public void boolsetDown(bool b)
	{
		moveDown = b;
	}
}