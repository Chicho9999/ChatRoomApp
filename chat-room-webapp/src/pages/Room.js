import React, { useEffect, useState } from 'react';
import axios from 'axios';
import Cookies from 'universal-cookie';
import { useNavigate } from 'react-router-dom';

function Room(){

    let history = useNavigate();
    const [rooms, setRooms] = useState([])
    const roomsUrl = "https://localhost:7181/api/room/GetAllRooms";
    const cookie = new Cookies();
    const config = {
        headers: { Authorization: `Bearer ${cookie.get('token')}` }
    }
    useEffect(() => {
        if(!cookie.get('token')){
            history("/");
        }
    }, []);
            

    return(
        <div>
            <h1>Room {cookie.get('roomName')}</h1>

        </div>
    )
}

export default Room;