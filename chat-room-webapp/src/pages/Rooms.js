import React, { useEffect, useState } from 'react';
import axios from 'axios';
import Cookies from 'universal-cookie';
import { useNavigate } from 'react-router-dom';

function Rooms(){

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
            
        }else{
            (async function() {
                try {
                    const result = await axios.get(roomsUrl, config);
                    setRooms(result.data);
                } catch (e) {
                    console.error(e);
                }
            })();
        }
    }, []);
    
    const enterRoom = (room) => {
        cookie.set( 'roomName', room.name)
        const roomId = room.id;
        history("/room/" + roomId);
    }

    return(
        <div>
            <h1>Rooms</h1>

                {
                    rooms.map(item => (
                            <div>
                                <btn class="btn btn-primary" key={item.id} onClick={() => enterRoom(item)}>{item.name}</btn>
                                <br/>
                            </div>
                    ))
                }
        </div>
    )
}

export default Rooms;