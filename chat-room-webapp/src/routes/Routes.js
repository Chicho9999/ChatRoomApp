import React from 'react';
import {BrowserRouter, Routes, Route} from 'react-router-dom';
import Login from '../pages/Login';
import Rooms from '../pages/Rooms';
import Room from '../pages/Room';

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route exact path='/' element={<Login/>}/>
        <Route exact path='/rooms' element={<Rooms/>} />
        <Route exact path='/room/:roomId' element={<Room/>} />
      </Routes>
    </BrowserRouter>
  );
}

export default App;
