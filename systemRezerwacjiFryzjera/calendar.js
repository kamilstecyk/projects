// obsluga kalendarza
const date = new Date();

const calendar = document.querySelector('.proper_calendar');
const choosed_day = document.querySelector('.choosed_day');
const date_choosed_day = document.getElementById('time_today');
const foundTime = document.querySelector('.found_time');



function change_left(event) {
    date.setMonth(date.getMonth()-1);renderCalendar();
}


const renderCalendar =() =>
{
    
date.setDate(1);  // ustawiamy na pierwszy dzien obecnego miesiaca

console.log("data pocatek: " + date.toDateString());

const actual_month = date.getMonth();  // from 0 to 11


const monthDays = document.querySelector(".days");


const firstDayIndex = date.getDay();
console.log("index of day: " + firstDayIndex);

console.log(firstDayIndex);

const lastDayIndex = new Date(date.getFullYear(),date.getMonth()+1,0).getDay();

console.log(lastDayIndex);

const nextDays = 7 - lastDayIndex - 1;

console.log(nextDays);

const months = ["STYCZEŃ","LUTY","MARZEC","KWIECIEŃ","MAJ","CZERWIEC","LIPIEC","SIERPIEŃ","WRZESIEŃ","PAŹDZIERNIK","LISTOPAD","GRUDZIEŃ"];
const lastDay = new Date(date.getFullYear(),date.getMonth()+1,0).getDate();  // we get last day of current month


const prevLastDay  = new Date(date.getFullYear(),date.getMonth(),0).getDate();

//document.querySelector('.cal_today').innerHTML = date.toDateString().toUpperCase();

var todays_date = document.getElementById('cal_today');
//todays_date.innerHTML = new Date().toDateString();  // abysmy mieli porpawna aktualna
todays_date.innerHTML =  (new Date().getDate()) + " " +  months[new Date().getMonth()]  +  " " + (new Date().getFullYear());   // aktualna data


//todays_date.innerHTML = date.getDay() + " " + date.getMonth.toString +  " " + date.getFullYear.toString;


// trzeba zmienic na polskie nazwy
let days = "";


// we print previous days
for(let x = firstDayIndex; x > 0; x-- )
{
    days += `<div class="prev-date">${prevLastDay - x + 1}</div>`;
    monthDays.innerHTML = days;
    console.log("itetion prev");
}

console.log("Todays day = " + new Date().getDate());

// we must find  last days for particular month
for(let i =1;i<=lastDay;i++)
{
    if(i == new Date().getDate() && date.getMonth() === new Date().getMonth() && date.getFullYear() == new Date().getFullYear())
    {
        days += `<div class="td">${i}</div>`;
        monthDays.innerHTML = days;

    }
    else{
        days += `<div>${i}</div>`;
        monthDays.innerHTML = days;

    }
}

for(let j = 1;j<=nextDays;j++)
{
    days += `<div class="next-date">${j}</div>`;
}

console.log("tekst do wstawienia: " + days);
monthDays.innerHTML = days;

const mon = document.getElementById('m');
mon.innerHTML = months[date.getMonth()];

const year = document.querySelector('.display_year');
year.innerHTML = date.getFullYear();

const allDays = document.querySelectorAll('.days div:not(.prev-date):not(.next-date)');   // not previous and not next we have to specify, we will define here 
var $particularDay;
var $particularMonth;
var $particularYear;


var restriction = 0;
if(date.getMonth() == new Date().getMonth())
{
    restriction = new Date().getDate()-1;  // because it is indexed from 0 to 31
}

for(var i=0;i<restriction;++i)
{
    allDays[i].style="opacity: 0.5;cursor:default;";   // we cannot reserve them
}

for (var i = restriction; i <allDays.length; i++) {   // after rendering we have to add eventlisteners
    allDays[i].addEventListener('click', (e)=>{
        $particularDay = e.target.innerHTML;
        $particularMonth = date.getMonth()+1;  // because we have month from 0 to 11
        $particularYear = date.getFullYear();

        document.cookie="day=" + $particularDay;  // uzywamy cookies, mozna ajax alternatywnie
        document.cookie="month=" + $particularMonth;
        document.cookie = "polishMonth=" + months[$particularMonth-1];
        document.cookie="year=" + $particularYear;

        console.log("Wybrana data: " + $particularDay + " " +  $particularMonth + " " + $particularYear);
        //alert("Wybrałeś dzień, teraz okno czasu");
        date_choosed_day.innerHTML = $particularDay + " " + months[$particularMonth-1] + " " + $particularYear;
        calendar.style.display = 'none';
        choosed_day.style.display = 'block';
        choosed_day.classList.add('animate_fade_in');
        choosed_day.addEventListener('animationend',()=>{choosed_day.classList.remove('animate_fade_in');});
    

    });
  }


// restriction on booking previous deadlines from current day
  if( date.getMonth() == new Date().getMonth() && date.getFullYear() == new Date().getFullYear() )
  {
    document.getElementById('change_month_left').removeEventListener('click',change_left);
    document.getElementById('change_month_left').style="filter: invert(0);cursor:default;";   // it is unavailable to go left
  }
  else
  {
    document.getElementById('change_month_left').addEventListener('click',change_left);
    document.getElementById('change_month_left').style="filter: invert(1);cursor:pointer;";     // it is available
  }


}


// powrot do kalendarza z dniami 

const return_button = document.getElementById('return_btn');
return_button.addEventListener('click',()=>{choosed_day.style.display = 'none';foundTime.innerHTML='';calendar.style.display = 'block';calendar.classList.add('animate_fade_in');calendar.addEventListener('animationend',()=>{calendar.classList.remove('animate_fade_in');})
});




// we prevent booking in previous month  == is senseless


//document.getElementById('change_month_left').addEventListener('click',()=>{date.setMonth(date.getMonth()-1);renderCalendar();console.log("nacisnieto");console.log("zmiana: " + date.toDateString())});


//document.getElementById('change_month_left').addEventListener('click',change_left);


document.querySelector('.change_month_right').addEventListener('click',()=>{date.setMonth(date.getMonth()+1);renderCalendar();console.log("nacisnieto");});

renderCalendar();


// get index of selected item in drop down list

//window.alert(document.getElementById('selectService').selectedIndex);

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

