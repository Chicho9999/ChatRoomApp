import React, { useState } from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import '../css/Login.css';
import Cookies from 'universal-cookie';
import axios from 'axios';
import { useNavigate } from 'react-router-dom';

function Login(props){
    
    const baseUrl = "https://localhost:7181/api/account/login";
    const cookie = new Cookies();
    let history = useNavigate();

    const [form, setForm] = useState({
        username: '',
        password: ''
    });

    const handleChange =e=> {
        const {name, value} = e.target;
        setForm({
            ...form,
            [name]: value
        });
    }

    const iniciarSesion = async()=>{
        await axios.post(baseUrl, {username : form.username, password : form.password})
        .then(response => {
            return response.data;
        }).then(secondResponse=>{
            if(secondResponse.isAuthSuccessful){
                debugger;
                cookie.set('id', secondResponse.userId);
                cookie.set('token', secondResponse.token, {expires: new Date(Date.now()+1080000)});
                cookie.set('username', secondResponse.username);
                history("/rooms");
            }else{
                alert('error usuario password');
            }
        })
        .catch(error => {
            console.log(error);
        });
    }

    return(
        <div className="primaryContainer">
            <div className="loginContainer">
                <div className="form-group">
                    <label>User: </label>
                    <br/>
                    <input type="text" className="form-control" name="username" onChange={handleChange}></input>
                    <br/>
                    <label>Password: </label>
                    <br/>
                    <input type="password" className="form-control" name="password" onChange={handleChange}></input>
                    <br/>
                    <button className="btn btn-primary" onClick={() => iniciarSesion()}> Log in</button>
                </div>
            </div>
        </div>
    )
}

export default Login;