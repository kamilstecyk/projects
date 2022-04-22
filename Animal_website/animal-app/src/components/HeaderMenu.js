import React from 'react'
import './headerMenu.css'
import {Link,BrowserRouter} from 'react-router-dom';

// if we want to use Link component , it must be wrapped in BrowserRouter

// Link must be wrapped in the browser router , so i napp.js we wrap everythin in browserrouter


// link provides redirect to particular pages withour=t reloading page , this is important difference between using here <a></a> tag and <Link> tag



const HeaderMenu = () => {
  return (
    <header>
            <div className='menuElement' > 
              
              <Link className = "Link" to={`/`}>Main Page</Link>
            </div>

            <div className='menuElement' > 
                <Link className = "Link" to={`/search-for-kitten`}>  Search for kitten  </Link>
            </div>

            <div className='menuElement' > 
            <Link className = "Link" to={`/display-random-fact`}>  Display random fact </Link>
            </div>
    </header>
  )
}

export default HeaderMenu