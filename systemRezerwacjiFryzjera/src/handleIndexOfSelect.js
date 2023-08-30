
var selectedList = document.querySelector("select");
//document.cookie="indexs=" + 0;  // default select
selectedList.addEventListener('change',()=>{document.cookie="indexs=" + selectedList.selectedIndex;console.log("index select " + selectedList.selectedIndex);})


selectedList.options[getCookie('indexs')].setAttribute('selected',true);


function getCookie(cName) {
    const name = cName + "=";
    const cDecoded = decodeURIComponent(document.cookie); //to be careful
    const cArr = cDecoded.split('; ');
    let res;
    cArr.forEach(val => {
      if (val.indexOf(name) === 0) res = val.substring(name.length);
    })
    return res
  }



 // checking if pattern of inputs matches example
 
 
var inputDate = document.querySelector("#dateservice");
var inputTime = document.querySelector("#timeofservice");
var submitButton = document.querySelector("#submitVisitBtn");
var responseTextr = document.querySelector("#addResponseText");
var responseDiv = document.querySelector("#addResponse");
var inputPhone = document.querySelector("#addPhoneInput");


submitButton.addEventListener("click",function(event){
  

  // it includes leap years  verification as result we get boolean value
  var resultValidationDate =  /^(?:(?:31(-)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(-)(?:0?[13-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(-)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(-)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$/.test(inputDate.value);

  var resultValidationTime =  /^([0-1]?[0-9]|2[0-3]):[0-5][0-9]$/.test(inputTime.value);  // it does not include only time in working hours, you can add whatever you want but in good format


  var validationPhone = /^[0-9][0-9][0-9] [0-9][0-9][0-9] [0-9][0-9][0-9]$/.test(inputPhone.value);

  // we check if our date and time is bigger than this currently, we cannot add visit in the past!




if(!resultValidationDate || !resultValidationTime || !validationPhone)   // if we have incorrect inputs then we prevent from submitting form and display info
{
  event.preventDefault();
  responseTextr.innerHTML = "Nieprawidłowo wprowadzone dane!";
  responseDiv.style.display="block";
  responseDiv.style.animation="fade_in 0.75s ease-in-out forwards";


}




});




// handle of deleting visit by hairdresser


var deleteIcon = document.querySelectorAll('.deadline img');
var dateToDelete = document.querySelector("#m").textContent.trim();
var formToSubmit = document.querySelector("#afterDesc form");
var afterDecs = document.querySelectorAll(".afterImg");
var buttons = document.querySelectorAll(".afterImg");


buttons.forEach(item => {
  item.addEventListener('click', event => {
  
      event.preventDefault();

    
  })
})



afterDecs.forEach(item => {
  item.addEventListener('click', event => {

    var result = window.confirm("Jesteś pewny,ze chcesz usunac termin: " + dateToDelete);  

    //var button = event.target.parentElement;
    var form = event.target.parentElement.parentElement;

    // we turn off submit


    var visitTime = event.target.parentElement.parentElement.parentElement.previousElementSibling.previousElementSibling.textContent;


    //form.submit();

    const times = visitTime.split("-");
    var begginingTime = times[0];
    var endingTime = times[1];


    var timestampBeginning = dateToDelete + " " + begginingTime + ":00";
    var timestampEnding = dateToDelete + " " + endingTime + ":00";

   
 
    // we creates cookies to get in php details of visit to delete, in the future ajax is better option


    // confirmation window


      if(result == true)   // we want to delete so we will be submit our form
      {
        document.cookie="timestamp1ToDelete=" + timestampBeginning;
        document.cookie="timestamp2ToDelete=" + timestampEnding;

        form.submit();

      }
      

    
  })
})





