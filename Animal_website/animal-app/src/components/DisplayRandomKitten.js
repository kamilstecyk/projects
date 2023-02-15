import React from 'react'
import { useState,useEffect } from 'react';
import arrow from '../Images/dice.svg';
import cat from '../Images/cat.gif';
import './displayRandomKitten.css';

const DisplayRandomKitten = () => {
  

  const [fact,setFact] = useState([]);
  const [change,setChange] = useState(false);


  useEffect(() => {
    getDataFromApi('https://catfact.ninja/fact')
  }, []);  // this use effect is activate only once when the page is loade

  useEffect(() => {
    getDataFromApi('https://catfact.ninja/fact')
  }, [change]);  // this use effect is activate only once when the page is loade



  async function getDataFromApi(url = '') {
    // Default options are marked with *
    const response = await fetch(url, {
      method: 'GET', // *GET, POST, PUT, DELETE, etc.
      //mode: 'no-cors',
      headers: {
        'Content-Type': 'application/json'
        // 'Content-Type': 'application/x-www-form-urlencoded',
      },
    });
   // await console.log(response);

    const data = await response.json();

    // we update useState

    setFact(data);

    console.log(data);
    //console.log(data[0].name)
  };


  const handler = (e) =>
  {
    //window.location.reload(true); // we want to refresh page to get another random fact from API
    setChange(!change);
  }


  
  
  // value is changing dynamically

  // we render component on condition that we have sth in our table

  return (
    <main>

      <div className="photo">
          <img src={cat} alt="cat"/>
      </div>
      
      <div className='fact'>
        <p>
            {fact.fact}
        </p>
      </div>
        
      <div className='btn'>
        <button onClick={handler} ><img src={arrow} alt="arrow"/></button>
      </div>
      

    </main>
  );

}


export default DisplayRandomKitten