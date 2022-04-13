var whether_active = false;
var nav = document.querySelector("NAV");
var ul_header = document.querySelector("HEADER UL");


function toggler_action() // when we have mobile verion of website
{
	
	if(whether_active)
	{
		
		/*document.getElementById("active_icon").classList.remove="icon-up-dir";
		document.getElementById("active_icon").classList.add="icon-down-dir";*/
		document.querySelector("NAV").classList.remove("active");
		document.querySelector("HEADER UL").classList.remove("active");
		nav.classList.add("hide");
		ul_header.classList.add("fade");

		//document.querySelector("NAV UL LI").classList.remove("active");
		document.getElementById("active_icon").className = "icon-down-dir";
		
		whether_active = false;
	
	}
	else
	{
		//document.getElementById("men").style.display="block";
		/*document.getElementById("active_icon").classList.remove="icon-down-dir";
		document.getElementById("active_icon").classList.add="icon-up-dir";*/
		
		
		/*document.getElementById("toggler").style.display="block";
		document.getElementById("toggler-up").style.display="none";*/
		//document.getElementById("men").style.animation = "collapse-menu 2s ease-in-out forwards"; // mamy animowane zjazd menu
		
		nav.classList.remove("hide");
		ul_header.classList.remove("fade");

		document.querySelector("NAV").classList.add("active");
		document.querySelector("HEADER UL").classList.add("active");
		//document.querySelector("NAV UL LI").classList.add("active");
		document.getElementById("active_icon").className = "icon-up-dir";
		
		whether_active = true;
	}
	
}



// part with scroll animation

const scrollElements = document.querySelectorAll(".js-scroll"); // all objetct which have .js-scroll class 


scrollElements.forEach((el) => { // we want to hide originally
	el.style.opacity = 0
  })

  const elementInView = (el, offset = 0) => {  // we check if partcular element is in our window
	const elementTop = el.getBoundingClientRect().top;
    const bottomLen = el.getBoundingClientRect().bottom;
	/*return (
	  elementTop <= 
	  ((window.innerHeight || document.documentElement.clientHeight) * (percentageScroll / 100))
	);*/

	if( elementTop <= ((window.innerHeight || document.documentElement.clientHeight) - offset)){return true}
	else{return false;}

  };

  const displayScrollElement = (element) => { // adding class to be visible if it is on our window
	//element.style.animation = "menu-occur 2.5s ease forwards";
	element.classList.add("scrolled");
  };

  
  const hideScrollElement = (element) => {
	element.classList.remove("scrolled");
	//element.style.animation = "none";
  };
   
  const handleScrollAnimation = () => {   // we weant to display every element which is on our window during scrolling
	scrollElements.forEach((el) => { // for each element with .js-scroll class
	  if (elementInView(el, 1)) {
		displayScrollElement(el);
		const bottomLen = el.getBoundingClientRect().bottom;
		console.log(bottomLen);
	  } else {
		hideScrollElement(el); // when it is not on our window 
		console.log("nie jestem");
	  }
	})
  }


  window.addEventListener('scroll', () => {  // we attach our funcions to the event of scrolling of user
	throttle(handleScrollAnimation,250);  // we do not want to every pixel scroll check whether we should animate, it is power consuming
  })


//initialize throttleTimer as false
let throttleTimer = false;
 
const throttle = (callback, time) => {
    //don't run the function while throttle timer is true
    if (throttleTimer) return;
     
    //first set throttle timer to true so the function doesn't run
    throttleTimer = true;
     
    setTimeout(() => {
        //call the callback function in the setTimeout and set the throttle timer to false after the indicated time has passed 
        callback();
        throttleTimer = false;
    }, time);
}