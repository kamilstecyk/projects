import {BrowserRouter} from 'react-router-dom';

import './App.css';
import HeaderMenu from './components/HeaderMenu';
import Footer from './components/Footer';
import Routing from './components/Routing'


function App() {
  return (

   
    <section>
        <BrowserRouter>
          <HeaderMenu/>      
   
          <Routing/>

          <Footer/>
        </BrowserRouter>
    </section>
  );
}

export default App;
