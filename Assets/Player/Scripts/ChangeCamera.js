var thirdPersonCamera : Camera;
var firstPersonCamera : Camera;
var firstPersonCameraKey : String = "1";
var thirdPersonCameraKey : String = "2";

function Start () {
    thirdPersonCamera.enabled = true;
    firstPersonCamera.enabled = false;
}

function Update () {
    if(Input.GetKeyDown(thirdPersonCameraKey)) {
        thirdPersonCamera.enabled = true;
        firstPersonCamera.enabled = false;
    } else if(Input.GetKeyDown(firstPersonCameraKey)) {
        thirdPersonCamera.enabled = false;
        firstPersonCamera.enabled = true;
    }
}