import React from 'react'
import { useState, useEffect } from 'react';
import './searchForKitten.css';
import Breed from './Breed';

// we use env to hide api from others

// process.env.REACT_APP_API_KEY


// ReactStrictMode in index.js causes executing API two times !!!

const SearchForKitten = () => {



  const [breeds,setBreeds] = useState([]);
  const [value, setValue] = useState('Abyssinian');   // this is useState to deal with dropdown list
  const [selected,setSelected] = useState(0);  // by default


  useEffect(() => {
    getDataFromApi('https://api.thecatapi.com/v1/breeds')
  }, []);  // this use effect is activate only once when the page is loade


  async function getDataFromApi(url) {
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

    setBreeds(data);

    console.log(data);
    console.log("here!!!");
    //console.log(data[0].name)
  }


  const handleChange = (event) => {
    setValue(event.target.value);
    //console.log(event.target.options.selectedIndex);  // we need to have selectred index to later generate card for partivcular breed
    setSelected(event.target.options.selectedIndex);
    console.log(breeds[selected]);

  };
  
  // value is changing dynamically

  // we render component on condition that we have sth in our table

  return (
    <main>

      <label>
        What kind of breed of the kitten are you the most interested?
        <select value={value}  onChange={handleChange}>  

          {breeds.map((breed,index)=>{return (<option key={index} value={breed.name}>{breed.name}</option>);})}

          

        </select>
      </label>
    
      

      {breeds.length > 0 &&
        <Breed  name={breeds[selected].name}  origin ={breeds[selected].origin} temperament={breeds[selected].temperament} wikiUrl = {breeds[selected].wikipedia_url != null ? breeds[selected].wikipedia_url : null} lifeSpan = {breeds[selected].life_span}   imgUrl = {breeds[selected].image != null ? breeds[selected].image.url : null}  desc = {breeds[selected].description} />
      }

      
      

    </main>
  )


}

export default SearchForKitten