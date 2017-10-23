var cam : Camera;
var cam1 : Camera;
 
function Start () {
    cam.enabled=true;
    cam1.enabled=false;
}
 
function Update () {
    if(Input.GetKeyDown("1")) {
        cam.enabled=true;
        cam1.enabled=false;
    } 
    if(Input.GetKeyDown("2")) {
        cam.enabled=false;
        cam1.enabled=true;
    }
}