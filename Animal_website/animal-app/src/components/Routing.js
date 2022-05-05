import React from 'react'

import MainContent from './MainContent';
import SearchForKitten from './SearchForKitten';
import DisplayRandomKitten from './DisplayRandomKitten';

import {Routes,Route} from 'react-router-dom';

// using Route we need wrap it withing Routes tag

// this file only concentrate on routing to have clean code

const Routing = () => {
  return (
    <div>
          <Routes>

              <Route index element = {<MainContent/>} />
              <Route path="/search-for-kitten" element = {<SearchForKitten/>} />
              <Route path="/display-random-fact" element = {<DisplayRandomKitten/>} />

          </Routes>

    </div>
  )
}

export default Routing