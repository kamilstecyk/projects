import React from 'react'
import './mainContent.css';
import sfinks from '../Images/sfinks.jpg';

// we need to add photo in this way 

const MainContent = () => {
  return (
    <main>
       <div className='container'> 
       
          <div className='catDesc'>
              <p>
                      This website is dedicated to cats. You can search for particular kittens, see their descriptions and interesting facts.
                      
                      <br/><br/> Did you know that there are over 500 million domestic cats in the world and cats conserve energy by sleeping for an average of 13 to 14 hours a day?

                      <br/> <br/> In the photo on the right side there is a sphynx cat -  a breed of cat known for its lack of fur. Hairlessness in cats is a naturally occurring genetic mutation, and the Sphynx was developed through selective breeding of these animals, starting in the 1960s.
              </p>
          </div>


          <div className='catImg'>
                  <img src= {sfinks} alt="Photo of the cat" />
          </div>
        
        </div>

    </main>
  )
}

export default MainContent