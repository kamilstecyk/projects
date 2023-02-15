import React from 'react'
import './breed.css';


const breed = (props) => {
  return (
    <div className='container'>
      <div className='desc'>
                Breed: { props.name }
          <br/><br/> {props.desc}
          <br/><br/> Origin: {props.origin}
          <br/> Temperament: {props.temperament}
          <br/> Life span: {props.lifeSpan} years
          <br/> <a  style={{textDecoration : 'none'}} target="_blank" href = {props.wikiUrl}>Wikipedia URL</a>
          
      </div>
      {/* <div className='imgCat'>
        <img style={{height : '100%',width : '100%', objectFit : 'contain'}} src={props.imgUrl} alt="kitten"/>
      </div> */}
    </div>
  )
}

export default breed