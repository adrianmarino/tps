#pragma strict
var acercar : boolean;
var alejar : boolean;
function Start () {
    alejar = true;
    acercar = true;
}

function Update () {
    if(GetComponent.<Camera>().fieldOfView <= 30){
        acercar = false;
    }
    if(GetComponent.<Camera>().fieldOfView >= 30){
        acercar = true;
    }
    if(GetComponent.<Camera>().fieldOfView >= 60){
        alejar = false;
    }
    if(GetComponent.<Camera>().fieldOfView < 60){
        alejar = true;
    }
	
    if (Input.GetAxis("Mouse ScrollWheel") < 0 &&alejar == true){
        GetComponent.<Camera>().fieldOfView += 3;
    }
    if (Input.GetAxis("Mouse ScrollWheel") > 0 && acercar == true){
        GetComponent.<Camera>().fieldOfView -= 3;
    }
}
