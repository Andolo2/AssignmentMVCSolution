
document.getElementById("footer").style.marginTop = "220px";

function SetHeight () {
    var offsetHeight = document.getElementById('footer').offsetHeight;
    var screenHeight = screen.height;

    if (offsetHeight < screenHeight) {

        document.getElementById("footer").style.position = "fixed";
         document.getElementById("footer").style.right = "0";
        document.getElementById("footer").style.bottom = "0";
        document.getElementById("footer").style.left = "0";
       
               
    }
};

SetHeight()