
var ToiletWaterAnim : GameObject;
var ToiletWaterSurface : GameObject;
var Toilet : GameObject;
var FlushAudio : AudioSource;

private var FlushDone  : int = 0;
  
function Start() 
{


    ToiletWaterAnim.SetActive(false);

}  
  
  
function Update()
{
 
	if (Input.GetButtonDown("Fire1")) //check to see if the left mouse was pressed
    {

        if (FlushDone == 0)
        {
            ToiletFlush();
        }
   
    }

            
 }
 
 
 function ToiletFlush()
 {

    FlushDone = 1;

    FlushAudio.Play();
    Toilet.GetComponent.<Animation>().Play();

    yield WaitForSeconds(0.25);

    ToiletWaterAnim.SetActive(false);
    ToiletWaterAnim.SetActive(true);
    ToiletWaterSurface.GetComponent.<Animation>().Play();

    yield WaitForSeconds(5);



    FlushDone = 0;



 }


